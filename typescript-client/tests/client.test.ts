import { KoraliumClient } from "../src/client"
import { QueryServer } from "./queryserver"
import TpchData from "./tpchdata";
//import jest from "jest"

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

  //client = new KoraliumClient(`${server.getIpAddress()}:${server.getPort()}`);
  client = new KoraliumClient("127.0.0.1:5016");
});

afterAll(async () => {
  await server.stop();
})

test("Get orders", async () => {
  const expected = tpchData.getOrders();
  const results = await client.query("select orderkey, custkey, orderstatus, totalprice, orderdate, orderpriority, clerk, shippriority, comment from orders");
  expect(results).toEqual(expected);
});

test("Get secure data", async () => {
  const expected = tpchData.getOrders();
  const results = await client.query("select orderkey, custkey, orderstatus, totalprice, orderdate, orderpriority, clerk, shippriority, comment from secure", null, {
    Authorization: `Bearer ${accessToken}`
  });
  expect(results).toEqual(expected);
});

test("Test limit", async () => {
  const expected = tpchData.getOrders().slice(0, 100);
  const results = await client.query("select orderkey, custkey, orderstatus, totalprice, orderdate, orderpriority, clerk, shippriority, comment from orders limit 100");
  expect(results).toEqual(expected);
});

test("Test limit with parameter", async () => {
  const expected = tpchData.getOrders().slice(0, 100);
  const results = await client.query(
    "select orderkey, custkey, orderstatus, totalprice, orderdate, orderpriority, clerk, shippriority, comment from orders limit @limit",
    {
      '@limit': 100
    }
  );
  expect(results).toEqual(expected);
});

test("filter on date in parameter", async () => {
  const expected = tpchData.getOrders().filter(x => new Date(x.orderdate) >= new Date("1993-01-01"));
  const results = await client.query(
    "select orderkey, custkey, orderstatus, totalprice, orderdate, orderpriority, clerk, shippriority, comment from orders where Orderdate >= @date",
    {
      '@date': '1993-01-01'
    }
  );
  expect(results).toEqual(expected);
});

test("select single field", async () => {
  const expected = tpchData.getOrders().map(x =>  { return { orderkey: x.orderkey } });
  const results = await client.query(
    "select orderkey from orders"
  );
  expect(results).toEqual(expected);
});