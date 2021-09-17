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
import { DataType, RecordBatch, Schema, Table, Type } from 'apache-arrow';
import { AbstractVector } from 'apache-arrow/vector';
import * as grpc from 'grpc';
import { FlightServiceClient } from './generated/Flight_grpc_pb';
import { Ticket, FlightData } from './generated/Flight_pb';
import { VectorLoader } from './internal/arrow/loader';
import { decodeMessage } from './internal/arrow/utils/MessageReader';
import { KoraliumClient, QueryOptions, QueryResult } from '@koralium/base-client'
import { ArrowResult } from './result';

export class KoraliumArrowClient implements KoraliumClient {

  private flightService: FlightServiceClient;
  
  constructor(url: string, credentials: grpc.ChannelCredentials, options?: object | undefined) {
    this.flightService = new FlightServiceClient(url, grpc.credentials.createInsecure())
  }

  async queryScalar(sql: string, queryOptions?: QueryOptions): Promise<any> {
    const table = await this.queryTable(sql, queryOptions)

    if(table.length == 0) {
      return null;
    }

    const arrowData = new ArrowResult(table)

    const firstRow = arrowData.get(0).toObject();

    if (firstRow) {
      return firstRow[Object.keys(firstRow)[0]]
    }
    return undefined;
  }

  async query(sql: string, queryOptions?: QueryOptions): Promise<QueryResult> {
    const table = await this.queryTable(sql, queryOptions)
    
    return {
      metadata: {
        customMetadata: {}
      },
      rows: new ArrowResult(table).toArray()
    }
  }

  queryTable<T extends { [key: string]: DataType<Type, any>; } = any>(query: string, queryOptions?: QueryOptions): Promise<Table<T>> {
    return new Promise<Table<T>>((resolve, reject) => {

      const metadata = new grpc.Metadata()

      if (queryOptions?.headers) {
        for (let [key, value] of Object.entries(queryOptions.headers)) {
          metadata.set(key, value.toString());
        }
      }
  
      if(queryOptions?.parameters != null) {
        for (let [key, value] of Object.entries(queryOptions.parameters)) {
          metadata.set("P_" + key, value.toString());
        }
      }

      const ticket = new Ticket();
      ticket.setTicket(Buffer.from(query).toString('base64'));
      const stream = this.flightService.doGet(ticket, metadata)
      let schema: Schema | undefined = undefined;
      const batches: Array<RecordBatch<T>> = []

      stream.on("data", (data: FlightData) => {
        const header = data.getDataHeader()
        const msg = decodeMessage(header)
  
        if (msg.isSchema()) {
          schema = msg.header()
        }
        if (msg.isRecordBatch()) {
          const batchHeader = msg.header()
  
          const batchData = data.getDataBody_asU8()
          const buff = new Uint8Array(batchData.buffer.slice(batchData.byteOffset))
  
          if (schema) {
            const v = new VectorLoader(buff, batchHeader.nodes, batchHeader.buffers, new Map<number, AbstractVector<any>>()).visitMany(schema.fields) as any;
            const recordBatch = new RecordBatch<T>(schema, batchHeader.length, v)
            batches.push(recordBatch)
          } else {
            reject(new Error("Got record batch before the schema"))
          }
        }
      });
      stream.on("error", (error) => {
        reject(error)
      });
      stream.on("close", () => {
        if (schema) {
          resolve(new Table<T>(schema, batches))
        }
        else {
          reject(new Error("No schema recieved."))
        }
      });
    })
  }

}