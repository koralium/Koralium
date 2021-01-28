import { Query } from '../src/cubejsModels';
import { KoraliumCubeJsQueryTransformer } from '../src/koraliumCubeJsQueryTransformer'

const accessToken = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxMjM0NTY3ODkwIiwibmFtZSI6IlRlc3QgdGVzdCIsInVuaXF1ZV9uYW1lIjoidGVzdCIsImlhdCI6MTUxNjIzOTAyMn0.aF80OiteMckPhSQcAL549V4AcyKHJA8LUs4mhzBnf2w";

jest.setTimeout(30000);

//var queryTransformer: KoraliumCubeJsQueryTransformer;
beforeAll(() => {
  //queryTransformer = new KoraliumCubeJsQueryTransformer();

})

test('Add filters to query', async () => {
  const queryTransformer = new KoraliumCubeJsQueryTransformer();
  queryTransformer.addCubeTable('orders', 'secure', '127.0.0.1:5016')

  const actual = await queryTransformer.transformQuery({
    measures: [],
    dimensions: [
      'Orders.orderkey'
    ]
  }, accessToken)

  const expected: Query = {
    measures: [],
    dimensions: [
      'Orders.orderkey'
    ],
    filters: [
      {
        and: [
          {
            member: "orders.custkey",
            operator: "gt",
            values: ["10"]
          },
          {
            member: "orders.custkey",
            operator: "lt",
            values: ["100"]
          }
        ]
      }
    ]
  }

  expect(actual).toEqual(expected)
  
})

test('Test cache', async () => {
  const queryTransformer = new KoraliumCubeJsQueryTransformer();
  queryTransformer.addCubeTable('orders', 'secure', '127.0.0.1:5016')

  const actual1 = await queryTransformer.transformQuery({
    measures: [],
    dimensions: [
      'Orders.orderkey'
    ]
  }, accessToken)

  const actual2 = await queryTransformer.transformQuery({
    measures: [],
    dimensions: [
      'Orders.orderkey'
    ]
  }, accessToken)

  const expected: Query = {
    measures: [],
    dimensions: [
      'Orders.orderkey'
    ],
    filters: [
      {
        and: [
          {
            member: "orders.custkey",
            operator: "gt",
            values: ["10"]
          },
          {
            member: "orders.custkey",
            operator: "lt",
            values: ["100"]
          }
        ]
      }
    ]
  }

  expect(actual1).toEqual(expected)
  expect(actual2).toEqual(expected)
})