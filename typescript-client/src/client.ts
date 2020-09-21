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
import { KoraliumServiceClient } from "./generated/koralium_grpc_pb"
import * as grpc from 'grpc';
import { QueryRequest, Page, ColumnMetadata, IndexRequest, TableMetadataResponse } from "./generated/koralium_pb";
import { IDecoder } from "./decoders/decoder";
import { getDecoder } from "./decoders/decoders";
import decodeScalar from "./decoders/ScalarDecoder";
import encodeParameters from "./encoders/parameterEncoder";
import { Empty } from "google-protobuf/google/protobuf/empty_pb";

export class KoraliumClient {
  client: KoraliumServiceClient;

  constructor(url: string) {
    this.client = new KoraliumServiceClient(url, grpc.credentials.createInsecure());
  }

  private createDecoders(columns: ColumnMetadata[]): IDecoder[] {
    return columns.map(x => getDecoder(x));
  }

  private createBaseObject(decoders: IDecoder[]): {} {

    const baseObject: {[key: string]: any;} = {};
    for(let i = 0; i < decoders.length; i++) {
      const name = decoders[i].getFieldName();
      baseObject[name] = decoders[i].baseValue();
    }
    return baseObject;
  }

   queryScalar(sql: string, parameters: {} | null = null, headers: {} = {}) {
    const queryRequest = new QueryRequest();
    queryRequest.setQuery(sql);

    if (parameters) {
      queryRequest.setParametersList(encodeParameters(parameters));
    }

    const metadata = new grpc.Metadata();

    for (let [key, value] of Object.entries(headers)) {
        metadata.add(key, value as any);
    }

    return new Promise <any>((resolve: any, reject: any) => {
      try {
        this.client.queryScalar(queryRequest, metadata, (error, data) => {

          if(error) {
            reject(error.message);
          }
          if(data !== undefined) {
            resolve(decodeScalar(data));
          }
          else {
            reject("got invalid response.")
          }
        });
      }
      catch(error) {
        reject(error);
      }
    });
  }

  async query(sql: string, parameters: {} | null = null, headers: {} = {}) {
    const queryRequest = new QueryRequest();
    queryRequest.setQuery(sql);
    queryRequest.setMaxbatchsize(1000000);

    if (parameters) {
      queryRequest.setParametersList(encodeParameters(parameters));
    }

    const metadata = new grpc.Metadata();

    for (let [key, value] of Object.entries(headers)) {
        metadata.add(key, value as any);
    }

    let stream = this.client.query(queryRequest, metadata);

    const objects: {}[] = [];

    let decoders: Array<IDecoder> = [];
    let baseObject = {};

    await new Promise <{}[]>((resolve: any, reject: any) => {

      stream.on("data", response => {
          const page = (response as unknown) as Page;
          
          const metadata = page.getMetadata();
          
          if(metadata !== undefined) {
            const metadataColumns = metadata.getColumnsList();

            //Check if it contains metadata, if so, create the decoders
            if(metadataColumns.length > 0) {
              decoders = this.createDecoders(metadataColumns);
              baseObject = this.createBaseObject(decoders);
            }
          }
          
          const rowCount = page.getRowcount();

          const startLength = objects.length;
          //Create all the objects that will be parsed
          for (let i = 0; i < rowCount; i++) {
              objects.push({
                  ...baseObject
              })
          }

          const blocks = page.getColumns();

          if(blocks === undefined) {
            throw new Error("Internal error, blocks are undefined");
          }

          const blockList = blocks.getBlocksList();

          for (let i = 0; i < decoders.length; i++) {
            decoders[i].newPage(page);
            decoders[i].decode(blockList[i], objects, startLength);
          }
      });

      stream.on("error", (error) => {
        reject(error);
      })

      stream.on("end", () => {
          resolve(objects);
      })

      stream.on("close", () => {
          resolve(objects);
      });
    });

    return objects;
  }


}