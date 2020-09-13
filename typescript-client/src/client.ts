import { KoraliumServiceClient } from "./generated/koralium_grpc_pb"
import * as grpc from 'grpc';
import * as grpcEmpty from "google-protobuf/google/protobuf/empty_pb";
import { QueryRequest, Page, ColumnMetadata } from "./generated/koralium_pb";
import { IDecoder } from "./decoders/decoder";
import { getDecoder } from "./decoders/decoders";
import decodeScalar from "./decoders/ScalarDecoder";
import encodeParameters from "./encoders/parameterEncoder";

export default class KoraliumClient {
  client: KoraliumServiceClient;

  constructor(url: string) {
    this.client = new KoraliumServiceClient(url, grpc.credentials.createInsecure());
  }

  private createDecoders(columns: ColumnMetadata[]): IDecoder[] {
    return columns.map(x => getDecoder(x));
  }

  private createBaseObject(decoders: IDecoder[]): {} {

    const baseObject = {};
    for(let i = 0; i < decoders.length; i++) {
      const name = decoders[i].getFieldName();
      baseObject[name] = decoders[i].baseValue();
    }
    return baseObject;
  }

   queryScalar(sql: string, parameters?: {}, headers: {} = {}) {
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
      this.client.queryScalar(queryRequest, metadata, (error, data) => {

        if(error) {
          reject(error.message);
        }

        resolve(decodeScalar(data));
      });
    });
  }

  async query(sql: string, parameters?: {}, headers: {} = {}) {
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
          
          const metadataList = page.getMetadataList()

          //Check if it contains metadata, if so, create the decoders
          if(metadataList.length > 0) {
            decoders = this.createDecoders(metadataList);
            baseObject = this.createBaseObject(decoders);
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
          const blockList = blocks.getBlocksList();

          for (let i = 0; i < decoders.length; i++) {
            decoders[i].newPage(page);
            decoders[i].decode(blockList[i], objects, startLength);
          }
      });

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