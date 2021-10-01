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
import { KoraliumClient } from '@koralium/base-client';
import { ApolloServer, gql } from 'apollo-server'
import { credentials } from 'grpc';
import { KoraliumArrowClient } from '../src/koraliumarrowclient';
import { QueryServer } from './queryserver';

// The GraphQL schema
const typeDefs = gql`
  type Query {
    test: [TestType]
  }

  type TestType {
    intvalue: Int

    intlist: [Int]

    decimalvalue: Float
  }
`;

var server: QueryServer;
var client: KoraliumClient;

jest.setTimeout(30000);

beforeAll(async () => {
  server = new QueryServer();
  await server.start();

  client = new KoraliumArrowClient(`${server.getIpAddress()}:${server.getPort()}`, credentials.createInsecure());
});

afterAll(async () => {
  if (server) {
    await server.stop();
  }
})

// A map of functions which return data for the schema.
const resolvers = {
  Query: {
    test: async () => {
      //TODO: Investigate why select * does not work
      const v = await client.query("select * from typetest")
      return v.rows;
    }
  },
};

//TODO: Activate test again
test("Can fetch data", async () => {
  const server = new ApolloServer({
    typeDefs,
    resolvers,
  });

  const result = await server.executeOperation({
    query: "{ test { intvalue intlist } }"
  })

  expect(result.data).toEqual({
    test: [
    {
      intvalue: 1,
      intlist: [
        1,
        2,
        3
      ]
    },
    {
      intvalue: 3,
      intlist: []
    },
    {
      intvalue: 17,
      intlist: null
    },
    {
      intvalue: 1,
      intlist: [
        1,
        2,
        3
      ]
    },
    {
      intvalue: 3,
      intlist: []
    },
  ]})
})

test("Can fetch decimal data", async () => {
  const server = new ApolloServer({
    typeDefs,
    resolvers,
  });

  const result = await server.executeOperation({
    query: "{ test { decimalvalue } }"
  })

  expect(result.data).toEqual({
    test: [
    {
      decimalvalue: 1,
    },
    {
      decimalvalue: 3,
    },
    {
      decimalvalue: 17,
    },
    {
      decimalvalue: 1,
    },
    {
      decimalvalue: 3,
    },
  ]})
})