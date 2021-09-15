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
import { KoraliumJsonClient } from "../src/client"
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

  client = new KoraliumJsonClient(`http://${server.getIpAddress()}:${server.getPort()}/sql`);
});

afterAll(async () => {
  if (server) {
    await server.stop();
  }
})

test("Get orders", async () => {
  const expected = tpchData.getOrders();
  const results = await client.query("select orderkey, custkey, orderstatus, totalprice, orderdate, orderpriority, clerk, shippriority, comment from orders");
  expect(results.rows.toArray()).toEqual(expected);
});

test("Get secure data", async () => {
  const expected = tpchData.getOrders().filter(x => x.custkey > 10 && x.custkey < 100);
  const results = await client.query(
    "select orderkey, custkey, orderstatus, totalprice, orderdate, orderpriority, clerk, shippriority, comment from secure",
    {headers: { Authorization: `Bearer ${accessToken}` }}
  );
    
  expect(results.rows.toArray()).toEqual(expected);
});

test("Test limit", async () => {
  const expected = tpchData.getOrders().slice(0, 100);
  const results = await client.query("select orderkey, custkey, orderstatus, totalprice, orderdate, orderpriority, clerk, shippriority, comment from orders limit 100");
  expect(results.rows.toArray()).toEqual(expected);
});

test("Test limit with parameter", async () => {
  const expected = tpchData.getOrders().slice(0, 100);
  const results = await client.query(
    "select orderkey, custkey, orderstatus, totalprice, orderdate, orderpriority, clerk, shippriority, comment from orders limit @limit",
    {parameters: { limit: 100 }}
  );
  expect(results.rows.toArray()).toEqual(expected);
});

test("filter on date in parameter", async () => {
  const expected = tpchData.getOrders().filter(x => new Date(x.orderdate) >= new Date("1993-01-01"));
  const results = await client.query(
    "select orderkey, custkey, orderstatus, totalprice, orderdate, orderpriority, clerk, shippriority, comment from orders where Orderdate >= @date",
    { parameters: { date: '1993-01-01'}}
  );

  expect(results.rows.toArray()).toEqual(expected);
});

test("select single field", async () => {
  const expected = tpchData.getOrders().map(x =>  { return { orderkey: x.orderkey } });
  const results = await client.query(
    "select orderkey from orders"
  );
  expect(results.rows.toArray()).toEqual(expected);
});

test("query scalar count", async () => {
  const expected = tpchData.getOrders().length;
  const result = await client.queryScalar("select count(*) from orders");

  expect(result).toEqual(expected);
})