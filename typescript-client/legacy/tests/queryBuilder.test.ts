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
import { QueryBuilder } from "../src/queryBuilder"
import { ObjectToSelectMapper } from "../src/objectToSelectMapper" 

test("count with filter", () => {
  const expected = "SELECT count(*) FROM testtable WHERE name = 'test'"
  const result = new QueryBuilder("testtable")
    .addSelectElement("count(*)")
    .addFilter("name = 'test'")
    .buildQuery();

    expect(result).toEqual(expected);
});

test("Select same column", () => {
  const expected = "SELECT column FROM testtable";
  const result = new QueryBuilder("testtable")
    .addSelectElement("column")
    .addSelectElement("column")
    .buildQuery();

    expect(result).toEqual(expected);
});

test("Select with limit and offset", () => {
  const expected = "SELECT * FROM testtable LIMIT 100 OFFSET 200";
  const result = new QueryBuilder("testtable")
    .addSelectElement("*")
    .setLimit(100)
    .setOffset(200)
    .buildQuery();

    expect(result).toEqual(expected);
});

test("Select multiple columns, filter, limit, offset", () => {
  const expected = "SELECT column1, column2 FROM testtable WHERE name = 'test' LIMIT 100 OFFSET 200";
  const result = new QueryBuilder("testtable")
    .addFilter("name = 'test'")
    .addSelectElement("column1")
    .addSelectElement("column2")
    .setLimit(100)
    .setOffset(200)
    .buildQuery();

    expect(result).toEqual(expected);
});

test("Object mapper", () => {
  const mapper = new ObjectToSelectMapper()
    .addMapping("c1", "c1")
    .addMapping("c2", ["c2", "c3"]);

  const queryBuilder = new QueryBuilder("testtable");
  mapper.addSelectsToQuery(queryBuilder, {
    c1: {},
    c2: {}
  });
  const result = queryBuilder.buildQuery();
  const expected = "SELECT c1, c2, c3 FROM testtable";

  expect(result).toEqual(expected);
});

test("Object mapper, missing mapping", () => {
  const mapper = new ObjectToSelectMapper()
    .addMapping("c1", "c1")
    .addMapping("c2", ["c2", "c3"]);

  const queryBuilder = new QueryBuilder("testtable");
  mapper.addSelectsToQuery(queryBuilder, {
    c1: {},
    c2: {},
    c3: {},
    c4: {}
  });
  
  const result = queryBuilder.buildQuery();
  const expected = "SELECT c1, c2, c3 FROM testtable";

  expect(result).toEqual(expected);
});

test("Filter builder equals", () => {
  const mapper = new ObjectToSelectMapper()
    .addMapping("c1", "c1")
    .addMapping("c2", ["c2", "c3"]);

  const queryBuilder = new QueryBuilder("testtable", mapper)
    .addSelectsWithMapper({
      c1: {},
      c2: {}
    })
    .addFilter({
      c1: {
        eq: 1
      },
      c2: {
        startsWith: "hello"
      }
    });

  const queryResult = queryBuilder.buildQuery();
  const expectedQuery = "SELECT c1, c2, c3 FROM testtable WHERE (c1 = 1 AND c2 LIKE @P0 + '%')"

  const parametersResult = queryBuilder.getParameters();
  const expectedParameters = {
    P0: "hello"
  };

  expect(queryResult).toEqual(expectedQuery);
  expect(parametersResult).toEqual(expectedParameters);
});

test("test in predicate for numbers", () => {
  const queryBuilder = new QueryBuilder("testtable")
    .addInFilter("c1", [1, 2])
    .addSelectElement("c1");

    const result = queryBuilder.buildQuery();
    const expected = "SELECT c1 FROM testtable WHERE c1 IN (1, 2)";

    expect(result).toEqual(expected);
});

test("test in predicate for strings", () => {
  const queryBuilder = new QueryBuilder("testtable")
    .addInFilter("c1", ["1", "2"])
    .addSelectElement("c1");

    const result = queryBuilder.buildQuery();
    const expected = "SELECT c1 FROM testtable WHERE c1 IN ('1', '2')";

    expect(result).toEqual(expected);
});

test("Order by with object ascending", () => {
  const result = new QueryBuilder("testtable")
    .orderByWithObject({ asc: "c1" })
    .addSelectElement("c1")
    .buildQuery();

  const expected = "SELECT c1 FROM testtable ORDER BY c1";

  expect(result).toEqual(expected);
}); 

test("Order by with object descending", () => {
  const result = new QueryBuilder("testtable")
    .orderByWithObject({ desc: "c1" })
    .addSelectElement("c1")
    .buildQuery();

  const expected = "SELECT c1 FROM testtable ORDER BY c1 desc";

  expect(result).toEqual(expected);
}); 

test("Empty filter string", () => {
  const result = new QueryBuilder("testtable")
  .addFilter("")
  .addSelectElement("c1")
  .buildQuery();

  const expected = "SELECT c1 FROM testtable"

  expect(result).toEqual(expected);
});

test("Empty filter object", () => {
  const result = new QueryBuilder("testtable")
  .addFilter({})
  .addSelectElement("c1")
  .buildQuery();

  const expected = "SELECT c1 FROM testtable"

  expect(result).toEqual(expected);
});

test("Search filter all fields", () => {
  const mapper = new ObjectToSelectMapper()
    .addMapping("c1", "c1")
    .addMapping("c2", ["c2", "c3"]);

  const queryBuilder = new QueryBuilder("testtable", mapper)
    .addSelectsWithMapper({
      c1: {},
      c2: {}
    })
    .addFilter({
      search: {
        queryString: "test"
      }
    });

  const queryResult = queryBuilder.buildQuery();
  const expectedQuery = "SELECT c1, c2, c3 FROM testtable WHERE (CONTAINS(*, @P0))"

  const parametersResult = queryBuilder.getParameters();
  const expectedParameters = {
    P0: "test"
  };

  expect(queryResult).toEqual(expectedQuery);
  expect(parametersResult).toEqual(expectedParameters);
})

test("Search filter two fields", () => {
  const mapper = new ObjectToSelectMapper()
    .addMapping("c1", "c1")
    .addMapping("c2", ["c2", "c3"]);

  const queryBuilder = new QueryBuilder("testtable", mapper)
    .addSelectsWithMapper({
      c1: {},
      c2: {}
    })
    .addFilter({
      search: {
        queryString: "test",
        fields: ["c1, c2"]
      }
    });

  const queryResult = queryBuilder.buildQuery();
  const expectedQuery = "SELECT c1, c2, c3 FROM testtable WHERE (CONTAINS((c1, c2), @P0))"

  const parametersResult = queryBuilder.getParameters();
  const expectedParameters = {
    P0: "test"
  };

  expect(queryResult).toEqual(expectedQuery);
  expect(parametersResult).toEqual(expectedParameters);
})