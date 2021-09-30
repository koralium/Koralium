/*
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */
import { KoraliumClient } from "@koralium/base-client";
import { DataFrame, ListVector, Table } from "apache-arrow";
import Decimal from "decimal.js";
import { credentials } from "grpc";
import { KoraliumArrowClient } from "../src/koraliumarrowclient"
import { QueryServer } from "./queryserver"
import TpchData from "./tpchdata";

//Basic jwt token that is used just for testing
const accessToken = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxMjM0NTY3ODkwIiwibmFtZSI6IlRlc3QgdGVzdCIsInVuaXF1ZV9uYW1lIjoidGVzdCIsImlhdCI6MTUxNjIzOTAyMn0.aF80OiteMckPhSQcAL549V4AcyKHJA8LUs4mhzBnf2w";

var client: KoraliumClient;
var server: QueryServer;
var tpchData: TpchData;

jest.setTimeout(30000);

beforeAll(async () => {
  server = new QueryServer();
  await server.start();

  tpchData = new TpchData();
  await tpchData.load();

  client = new KoraliumArrowClient(`${server.getIpAddress()}:${server.getPort()}`, credentials.createInsecure());
});

afterAll(async () => {
  if (server) {
    await server.stop();
  }
})

declare global {
  namespace jest {
    interface Matchers<R> {
      queryToEqual(expected: any): R;
    }
  }
}

function compareResults(actual, expected) {
  const expectedIterator = expected[Symbol.iterator]()
  const actualIterator = actual[Symbol.iterator]()

  let expectedValue = expectedIterator.next()
  let actualValue = actualIterator.next()
  while(!expectedValue.done && !actualValue.done) {
    expect(actualValue.value).toEqual(expectedValue.value)

    expectedValue = expectedIterator.next()
    actualValue = actualIterator.next()
  }

  expect(expectedValue.done).toEqual(true)
  expect(actualValue.done).toEqual(true)
}

test("Get orders", async () => {
  const expected = tpchData.getOrders();
  let results = await client.query("select orderkey, custkey, orderstatus, totalprice, orderdate, orderpriority, clerk, shippriority, comment from orders");
  let table = results.rows;

  compareResults(table, expected)
});

test("Get secure data", async () => {
  const expected = tpchData.getOrders().filter(x => x.custkey > 10 && x.custkey < 100);
  const results = await client.query(
    "select orderkey, custkey, orderstatus, totalprice, orderdate, orderpriority, clerk, shippriority, comment from secure",
    {headers: { Authorization: `Bearer ${accessToken}` }}
  );
    
  compareResults(results.rows, expected)
});

test("Test limit", async () => {
  const expected = tpchData.getOrders().slice(0, 100);
  const results = await client.query("select orderkey, custkey, orderstatus, totalprice, orderdate, orderpriority, clerk, shippriority, comment from orders limit 100");
  compareResults(results.rows, expected)
});

test("Test limit with parameter", async () => {
  const expected = tpchData.getOrders().slice(0, 100);
  const results = await client.query(
    "select orderkey, custkey, orderstatus, totalprice, orderdate, orderpriority, clerk, shippriority, comment from orders limit @limit",
    {parameters: { limit: 100 }}
  );
  compareResults(results.rows, expected)
});

test("filter on date in parameter", async () => {
  const expected = tpchData.getOrders().filter(x => new Date(x.orderdate) >= new Date("1993-01-01"));
  const results = await client.query(
    "select orderkey, custkey, orderstatus, totalprice, orderdate, orderpriority, clerk, shippriority, comment from orders where Orderdate >= @date",
    { parameters: { date: '1993-01-01'}}
  );

  compareResults(results.rows, expected)
});

test("select single field", async () => {
  const expected = tpchData.getOrders().map(x =>  { return { orderkey: x.orderkey } });
  const results = await client.query(
    "select orderkey from orders"
  );
  compareResults(results.rows, expected)
});

test("query scalar count", async () => {
  const expected = tpchData.getOrders().length;
  const result = await client.queryScalar("select count(*) from orders");

  expect(result).toEqual(expected);
})

test("bool value", async () => {

  const expected = [
    {
      boolvalue: true
    },
    {
      boolvalue: false
    },
    {
      boolvalue: true
    },
    {
      boolvalue: false
    },
    {
      boolvalue: true
    }
  ]
  const result = await client.query("select boolvalue from typetest");

  compareResults(result.rows, expected)
})

test("bool value nullable", async () => {
  const expected = [
    {
      boolvaluenullable: true
    },
    {
      boolvaluenullable: false
    },
    {
      boolvaluenullable: null
    },
    {
      boolvaluenullable: true
    },
    {
      boolvaluenullable: false
    }
  ]
  const result = await client.query("select boolvaluenullable from typetest");
  compareResults(result.rows, expected)
})

test("double value", async () => {
  const expected = [
    {
      doublevalue: 1.0
    },
    {
      doublevalue: 3.0
    },
    {
      doublevalue: 17.0
    },
    {
      doublevalue: 1.0
    },
    {
      doublevalue: 3.0
    }
  ]
  const result = await client.query("select doublevalue from typetest");
  compareResults(result.rows, expected)
})

test("double value nullable", async () => {
  const expected = [
    {
      doublevaluenullable: 1.0
    },
    {
      doublevaluenullable: 3.0
    },
    {
      doublevaluenullable: 17.0
    },
    {
      doublevaluenullable: null
    },
    {
      doublevaluenullable: 1.0
    }
  ]
  const result = await client.query("select doublevaluenullable from typetest");
  compareResults(result.rows, expected)
})

test("double value nullable", async () => {
  const expected = [
    {
      doublevaluenullable: 1.0
    },
    {
      doublevaluenullable: 3.0
    },
    {
      doublevaluenullable: 17.0
    },
    {
      doublevaluenullable: null
    },
    {
      doublevaluenullable: 1.0
    }
  ]
  const result = await client.query("select doublevaluenullable from typetest");
  compareResults(result.rows, expected)
})

test("date time", async () => {
  const expected = [
    {
      datetime: new Date("1990-03-13")
    },
    {
      datetime: new Date("1990-03-13")
    },
    {
      datetime: new Date("1990-03-13")
    },
    {
      datetime: new Date("1990-03-13")
    },
    {
      datetime: new Date("1990-03-13")
    }
  ]
  const result = await client.query("select datetime from typetest");
  compareResults(result.rows, expected)
})

test("date time nullable", async () => {
  const expected = [
    {
      datetimenullable: new Date("1990-03-13")
    },
    {
      datetimenullable: null
    },
    {
      datetimenullable: new Date("1990-03-13")
    },
    {
      datetimenullable: null
    },
    {
      datetimenullable: new Date("1990-03-13")
    }
  ]
  const result = await client.query("select datetimenullable from typetest");
  compareResults(result.rows, expected)
})

test("Long value", async () => {
  const expected = [
    {
      longvalue: 1
    },
    {
      longvalue: 3
    },
    {
      longvalue: 17
    },
    {
      longvalue: 1
    },
    {
      longvalue: 3
    }
  ]
  const result = await client.query("select longvalue from typetest");
  compareResults(result.rows, expected)
})

test("Long value nullable", async () => {
  const expected = [
    {
      longvaluenullable: 1
    },
    {
      longvaluenullable: 3
    },
    {
      longvaluenullable: 17
    },
    {
      longvaluenullable: null
    },
    {
      longvaluenullable: 1
    }
  ]
  const result = await client.query("select longvaluenullable from typetest");
  compareResults(result.rows, expected)
})

test("String Value", async () => {
  const expected = [
    {
      stringvalue: "test"
    },
    {
      stringvalue: null
    },
    {
      stringvalue: "test"
    },
    {
      stringvalue: null
    },
    {
      stringvalue: "test"
    }
  ]
  const result = await client.query("select stringvalue from typetest");
  compareResults(result.rows, expected)
})

test("Int List Value", async () => {
  const expected = [
    {
      intlist: [
        1,
        2,
        3
      ]
    },
    {
      intlist: []
    },
    {
      intlist: null
    },
    {
      intlist: [
        1,
        2,
        3
      ]
    },
    {
      intlist: []
    },
  ]
  const result = await client.query("select intlist from typetest");

  compareResults(result.rows, expected)
})

test("Test object value", async () => {
  const expected = [
    {
      object: {
        StringValue: 'test',
        intList: [
          1,
          2,
          3
        ],
        intValue: 321,
        object: {
          stringValue: 'test'
        }
      }
    },
    {
      object: {
        StringValue: 'test2',
        intList: [],
        object: null,
        intValue: 0
      }
    },
    {
      object: null
    },
    {
      object: {
        StringValue: 'test',
        intList: [
          1,
          2,
          3
        ],
        intValue: 321,
        object: {
          stringValue: 'test'
        }
      }
    },
    {
      object: {
        StringValue: 'test2',
        intList: [],
        object: null,
        intValue: 0
      }
    }
  ]
  const result = await client.query("select object from typetest");

  compareResults(result.rows, expected)
})

test("Decimal Value", async () => {
  const expected = [
    {
      decimalvalue: new Decimal(1)
    },
    {
      decimalvalue: new Decimal(3)
    },
    {
      decimalvalue: new Decimal(17)
    },
    {
      decimalvalue: new Decimal(1)
    },
    {
      decimalvalue: new Decimal(3)
    },
  ]
  const result = await client.query("select decimalvalue from typetest");
  compareResults(result.rows, expected)
})