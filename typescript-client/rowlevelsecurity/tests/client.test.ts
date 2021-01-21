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
import { KoraliumRowLevelSecurityClient } from "../src/"
import { QueryServer } from "./queryserver"

//Basic jwt token that is used just for testing
const accessToken = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxMjM0NTY3ODkwIiwibmFtZSI6IlRlc3QgdGVzdCIsInVuaXF1ZV9uYW1lIjoidGVzdCIsImlhdCI6MTUxNjIzOTAyMn0.aF80OiteMckPhSQcAL549V4AcyKHJA8LUs4mhzBnf2w";

var client: KoraliumRowLevelSecurityClient;
var server: QueryServer;

jest.setTimeout(30000);

beforeAll(async () => {
  // docker container is not working fully yet
  // so the web test must be running to run these tests
  client = new KoraliumRowLevelSecurityClient('127.0.0.1:5016');
});

afterAll(async () => {
})

test("Get filter no table alias", async () => {
  const expected = "(Custkey > 10) AND (Custkey < 100)"
  const result = await client.GetFilter("secure", {
    Authorization: `Bearer ${accessToken}`
  })

  expect(result).toEqual(expected);
})

test("Get filter with table alias", async () => {
  const expected = "(s.Custkey > 10) AND (s.Custkey < 100)"
  const result = await client.GetFilter("secure", "s", {
    Authorization: `Bearer ${accessToken}`
  })

  expect(result).toEqual(expected);
})

test("Get filter unauthorized", async () => {
  const t = async () => {
    await client.GetFilter("secure", "s")
  };

  expect(t).rejects.toMatch("13 INTERNAL: Internal error");
})