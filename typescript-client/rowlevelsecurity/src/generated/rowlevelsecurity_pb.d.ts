// package: 
// file: rowlevelsecurity.proto

import * as jspb from "google-protobuf";

export class RowLevelSecurityRequest extends jspb.Message {
  getTablename(): string;
  setTablename(value: string): void;

  getFormat(): FormatMap[keyof FormatMap];
  setFormat(value: FormatMap[keyof FormatMap]): void;

  hasSqloptions(): boolean;
  clearSqloptions(): void;
  getSqloptions(): SqlOptions | undefined;
  setSqloptions(value?: SqlOptions): void;

  hasElasticsearchoptions(): boolean;
  clearElasticsearchoptions(): void;
  getElasticsearchoptions(): ElasticSearchOptions | undefined;
  setElasticsearchoptions(value?: ElasticSearchOptions): void;

  hasCubejsoptions(): boolean;
  clearCubejsoptions(): void;
  getCubejsoptions(): CubeJsOptions | undefined;
  setCubejsoptions(value?: CubeJsOptions): void;

  getFormatoptionsCase(): RowLevelSecurityRequest.FormatoptionsCase;
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
    format: FormatMap[keyof FormatMap],
    sqloptions?: SqlOptions.AsObject,
    elasticsearchoptions?: ElasticSearchOptions.AsObject,
    cubejsoptions?: CubeJsOptions.AsObject,
  }

  export enum FormatoptionsCase {
    FORMATOPTIONS_NOT_SET = 0,
    SQLOPTIONS = 4,
    ELASTICSEARCHOPTIONS = 5,
    CUBEJSOPTIONS = 6,
  }
}

export class RowLevelSecurityResponse extends jspb.Message {
  getFilter(): string;
  setFilter(value: string): void;

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
    filter: string,
  }
}

export class SqlOptions extends jspb.Message {
  getTablealias(): string;
  setTablealias(value: string): void;

  serializeBinary(): Uint8Array;
  toObject(includeInstance?: boolean): SqlOptions.AsObject;
  static toObject(includeInstance: boolean, msg: SqlOptions): SqlOptions.AsObject;
  static extensions: {[key: number]: jspb.ExtensionFieldInfo<jspb.Message>};
  static extensionsBinary: {[key: number]: jspb.ExtensionFieldBinaryInfo<jspb.Message>};
  static serializeBinaryToWriter(message: SqlOptions, writer: jspb.BinaryWriter): void;
  static deserializeBinary(bytes: Uint8Array): SqlOptions;
  static deserializeBinaryFromReader(message: SqlOptions, reader: jspb.BinaryReader): SqlOptions;
}

export namespace SqlOptions {
  export type AsObject = {
    tablealias: string,
  }
}

export class ElasticSearchOptions extends jspb.Message {
  getLowercasestringvalues(): boolean;
  setLowercasestringvalues(value: boolean): void;

  serializeBinary(): Uint8Array;
  toObject(includeInstance?: boolean): ElasticSearchOptions.AsObject;
  static toObject(includeInstance: boolean, msg: ElasticSearchOptions): ElasticSearchOptions.AsObject;
  static extensions: {[key: number]: jspb.ExtensionFieldInfo<jspb.Message>};
  static extensionsBinary: {[key: number]: jspb.ExtensionFieldBinaryInfo<jspb.Message>};
  static serializeBinaryToWriter(message: ElasticSearchOptions, writer: jspb.BinaryWriter): void;
  static deserializeBinary(bytes: Uint8Array): ElasticSearchOptions;
  static deserializeBinaryFromReader(message: ElasticSearchOptions, reader: jspb.BinaryReader): ElasticSearchOptions;
}

export namespace ElasticSearchOptions {
  export type AsObject = {
    lowercasestringvalues: boolean,
  }
}

export class CubeJsOptions extends jspb.Message {
  getCubename(): string;
  setCubename(value: string): void;

  getLowercasefirstmembercharacter(): boolean;
  setLowercasefirstmembercharacter(value: boolean): void;

  serializeBinary(): Uint8Array;
  toObject(includeInstance?: boolean): CubeJsOptions.AsObject;
  static toObject(includeInstance: boolean, msg: CubeJsOptions): CubeJsOptions.AsObject;
  static extensions: {[key: number]: jspb.ExtensionFieldInfo<jspb.Message>};
  static extensionsBinary: {[key: number]: jspb.ExtensionFieldBinaryInfo<jspb.Message>};
  static serializeBinaryToWriter(message: CubeJsOptions, writer: jspb.BinaryWriter): void;
  static deserializeBinary(bytes: Uint8Array): CubeJsOptions;
  static deserializeBinaryFromReader(message: CubeJsOptions, reader: jspb.BinaryReader): CubeJsOptions;
}

export namespace CubeJsOptions {
  export type AsObject = {
    cubename: string,
    lowercasefirstmembercharacter: boolean,
  }
}

export interface FormatMap {
  SQL: 0;
  ELASTICSEARCH: 1;
  CUBEJS: 2;
}

export const Format: FormatMap;

