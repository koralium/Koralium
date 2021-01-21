// package: 
// file: rowlevelsecurity.proto

import * as jspb from "google-protobuf";

export class RowLevelSecurityRequest extends jspb.Message {
  getTablename(): string;
  setTablename(value: string): void;

  getTablealias(): string;
  setTablealias(value: string): void;

  serializeBinary(): Uint8Array;
  toObject(includeInstance?: boolean): RowLevelSecurityRequest.AsObject;
  static toObject(includeInstance: boolean, msg: RowLevelSecurityRequest): RowLevelSecurityRequest.AsObject;
  static extensions: {[key: number]: jspb.ExtensionFieldInfo<jspb.Message>};
  static extensionsBinary: {[key: number]: jspb.ExtensionFieldBinaryInfo<jspb.Message>};
  static serializeBinaryToWriter(message: RowLevelSecurityRequest, writer: jspb.BinaryWriter): void;
  static deserializeBinary(bytes: Uint8Array): RowLevelSecurityRequest;
  static deserializeBinaryFromReader(message: RowLevelSecurityRequest, reader: jspb.BinaryReader): RowLevelSecurityRequest;
}

export namespace RowLevelSecurityRequest {
  export type AsObject = {
    tablename: string,
    tablealias: string,
  }
}

export class RowLevelSecurityResponse extends jspb.Message {
  getSqlfilter(): string;
  setSqlfilter(value: string): void;

  serializeBinary(): Uint8Array;
  toObject(includeInstance?: boolean): RowLevelSecurityResponse.AsObject;
  static toObject(includeInstance: boolean, msg: RowLevelSecurityResponse): RowLevelSecurityResponse.AsObject;
  static extensions: {[key: number]: jspb.ExtensionFieldInfo<jspb.Message>};
  static extensionsBinary: {[key: number]: jspb.ExtensionFieldBinaryInfo<jspb.Message>};
  static serializeBinaryToWriter(message: RowLevelSecurityResponse, writer: jspb.BinaryWriter): void;
  static deserializeBinary(bytes: Uint8Array): RowLevelSecurityResponse;
  static deserializeBinaryFromReader(message: RowLevelSecurityResponse, reader: jspb.BinaryReader): RowLevelSecurityResponse;
}

export namespace RowLevelSecurityResponse {
  export type AsObject = {
    sqlfilter: string,
  }
}

