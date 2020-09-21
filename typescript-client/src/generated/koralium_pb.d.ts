// package: 
// file: koralium.proto

import * as jspb from "google-protobuf";
import * as google_protobuf_timestamp_pb from "google-protobuf/google/protobuf/timestamp_pb";
import * as google_protobuf_empty_pb from "google-protobuf/google/protobuf/empty_pb";

export class Page extends jspb.Message {
  hasColumns(): boolean;
  clearColumns(): void;
  getColumns(): Columns | undefined;
  setColumns(value?: Columns): void;

  clearStringsList(): void;
  getStringsList(): Array<StringColumn>;
  setStringsList(value: Array<StringColumn>): void;
  addStrings(value?: StringColumn, index?: number): StringColumn;

  clearObjectsList(): void;
  getObjectsList(): Array<ObjectColumn>;
  setObjectsList(value: Array<ObjectColumn>): void;
  addObjects(value?: ObjectColumn, index?: number): ObjectColumn;

  getRowcount(): number;
  setRowcount(value: number): void;

  hasMetadata(): boolean;
  clearMetadata(): void;
  getMetadata(): QueryMetadata | undefined;
  setMetadata(value?: QueryMetadata): void;

  serializeBinary(): Uint8Array;
  toObject(includeInstance?: boolean): Page.AsObject;
  static toObject(includeInstance: boolean, msg: Page): Page.AsObject;
  static extensions: {[key: number]: jspb.ExtensionFieldInfo<jspb.Message>};
  static extensionsBinary: {[key: number]: jspb.ExtensionFieldBinaryInfo<jspb.Message>};
  static serializeBinaryToWriter(message: Page, writer: jspb.BinaryWriter): void;
  static deserializeBinary(bytes: Uint8Array): Page;
  static deserializeBinaryFromReader(message: Page, reader: jspb.BinaryReader): Page;
}

export namespace Page {
  export type AsObject = {
    columns?: Columns.AsObject,
    stringsList: Array<StringColumn.AsObject>,
    objectsList: Array<ObjectColumn.AsObject>,
    rowcount: number,
    metadata?: QueryMetadata.AsObject,
  }
}

export class QueryMetadata extends jspb.Message {
  clearColumnsList(): void;
  getColumnsList(): Array<ColumnMetadata>;
  setColumnsList(value: Array<ColumnMetadata>): void;
  addColumns(value?: ColumnMetadata, index?: number): ColumnMetadata;

  clearCustommetadataList(): void;
  getCustommetadataList(): Array<KeyValue>;
  setCustommetadataList(value: Array<KeyValue>): void;
  addCustommetadata(value?: KeyValue, index?: number): KeyValue;

  serializeBinary(): Uint8Array;
  toObject(includeInstance?: boolean): QueryMetadata.AsObject;
  static toObject(includeInstance: boolean, msg: QueryMetadata): QueryMetadata.AsObject;
  static extensions: {[key: number]: jspb.ExtensionFieldInfo<jspb.Message>};
  static extensionsBinary: {[key: number]: jspb.ExtensionFieldBinaryInfo<jspb.Message>};
  static serializeBinaryToWriter(message: QueryMetadata, writer: jspb.BinaryWriter): void;
  static deserializeBinary(bytes: Uint8Array): QueryMetadata;
  static deserializeBinaryFromReader(message: QueryMetadata, reader: jspb.BinaryReader): QueryMetadata;
}

export namespace QueryMetadata {
  export type AsObject = {
    columnsList: Array<ColumnMetadata.AsObject>,
    custommetadataList: Array<KeyValue.AsObject>,
  }
}

export class Columns extends jspb.Message {
  clearBlocksList(): void;
  getBlocksList(): Array<Block>;
  setBlocksList(value: Array<Block>): void;
  addBlocks(value?: Block, index?: number): Block;

  serializeBinary(): Uint8Array;
  toObject(includeInstance?: boolean): Columns.AsObject;
  static toObject(includeInstance: boolean, msg: Columns): Columns.AsObject;
  static extensions: {[key: number]: jspb.ExtensionFieldInfo<jspb.Message>};
  static extensionsBinary: {[key: number]: jspb.ExtensionFieldBinaryInfo<jspb.Message>};
  static serializeBinaryToWriter(message: Columns, writer: jspb.BinaryWriter): void;
  static deserializeBinary(bytes: Uint8Array): Columns;
  static deserializeBinaryFromReader(message: Columns, reader: jspb.BinaryReader): Columns;
}

export namespace Columns {
  export type AsObject = {
    blocksList: Array<Block.AsObject>,
  }
}

export class Block extends jspb.Message {
  clearNullsList(): void;
  getNullsList(): Array<number>;
  setNullsList(value: Array<number>): void;
  addNulls(value: number, index?: number): number;

  hasDoubles(): boolean;
  clearDoubles(): void;
  getDoubles(): DoubleBlock | undefined;
  setDoubles(value?: DoubleBlock): void;

  hasFloats(): boolean;
  clearFloats(): void;
  getFloats(): FloatBlock | undefined;
  setFloats(value?: FloatBlock): void;

  hasInts(): boolean;
  clearInts(): void;
  getInts(): Int32Block | undefined;
  setInts(value?: Int32Block): void;

  hasLongs(): boolean;
  clearLongs(): void;
  getLongs(): Int64Block | undefined;
  setLongs(value?: Int64Block): void;

  hasBools(): boolean;
  clearBools(): void;
  getBools(): BoolBlock | undefined;
  setBools(value?: BoolBlock): void;

  hasTimestamps(): boolean;
  clearTimestamps(): void;
  getTimestamps(): TimestampBlock | undefined;
  setTimestamps(value?: TimestampBlock): void;

  hasObjects(): boolean;
  clearObjects(): void;
  getObjects(): ObjectRefBlock | undefined;
  setObjects(value?: ObjectRefBlock): void;

  hasStrings(): boolean;
  clearStrings(): void;
  getStrings(): StringRefBlock | undefined;
  setStrings(value?: StringRefBlock): void;

  hasArrays(): boolean;
  clearArrays(): void;
  getArrays(): ArrayBlock | undefined;
  setArrays(value?: ArrayBlock): void;

  getBlockCase(): Block.BlockCase;
  serializeBinary(): Uint8Array;
  toObject(includeInstance?: boolean): Block.AsObject;
  static toObject(includeInstance: boolean, msg: Block): Block.AsObject;
  static extensions: {[key: number]: jspb.ExtensionFieldInfo<jspb.Message>};
  static extensionsBinary: {[key: number]: jspb.ExtensionFieldBinaryInfo<jspb.Message>};
  static serializeBinaryToWriter(message: Block, writer: jspb.BinaryWriter): void;
  static deserializeBinary(bytes: Uint8Array): Block;
  static deserializeBinaryFromReader(message: Block, reader: jspb.BinaryReader): Block;
}

export namespace Block {
  export type AsObject = {
    nullsList: Array<number>,
    doubles?: DoubleBlock.AsObject,
    floats?: FloatBlock.AsObject,
    ints?: Int32Block.AsObject,
    longs?: Int64Block.AsObject,
    bools?: BoolBlock.AsObject,
    timestamps?: TimestampBlock.AsObject,
    objects?: ObjectRefBlock.AsObject,
    strings?: StringRefBlock.AsObject,
    arrays?: ArrayBlock.AsObject,
  }

  export enum BlockCase {
    BLOCK_NOT_SET = 0,
    DOUBLES = 2,
    FLOATS = 3,
    INTS = 4,
    LONGS = 5,
    BOOLS = 6,
    TIMESTAMPS = 7,
    OBJECTS = 8,
    STRINGS = 9,
    ARRAYS = 10,
  }
}

export class DoubleBlock extends jspb.Message {
  clearValuesList(): void;
  getValuesList(): Array<number>;
  setValuesList(value: Array<number>): void;
  addValues(value: number, index?: number): number;

  serializeBinary(): Uint8Array;
  toObject(includeInstance?: boolean): DoubleBlock.AsObject;
  static toObject(includeInstance: boolean, msg: DoubleBlock): DoubleBlock.AsObject;
  static extensions: {[key: number]: jspb.ExtensionFieldInfo<jspb.Message>};
  static extensionsBinary: {[key: number]: jspb.ExtensionFieldBinaryInfo<jspb.Message>};
  static serializeBinaryToWriter(message: DoubleBlock, writer: jspb.BinaryWriter): void;
  static deserializeBinary(bytes: Uint8Array): DoubleBlock;
  static deserializeBinaryFromReader(message: DoubleBlock, reader: jspb.BinaryReader): DoubleBlock;
}

export namespace DoubleBlock {
  export type AsObject = {
    valuesList: Array<number>,
  }
}

export class FloatBlock extends jspb.Message {
  clearValuesList(): void;
  getValuesList(): Array<number>;
  setValuesList(value: Array<number>): void;
  addValues(value: number, index?: number): number;

  serializeBinary(): Uint8Array;
  toObject(includeInstance?: boolean): FloatBlock.AsObject;
  static toObject(includeInstance: boolean, msg: FloatBlock): FloatBlock.AsObject;
  static extensions: {[key: number]: jspb.ExtensionFieldInfo<jspb.Message>};
  static extensionsBinary: {[key: number]: jspb.ExtensionFieldBinaryInfo<jspb.Message>};
  static serializeBinaryToWriter(message: FloatBlock, writer: jspb.BinaryWriter): void;
  static deserializeBinary(bytes: Uint8Array): FloatBlock;
  static deserializeBinaryFromReader(message: FloatBlock, reader: jspb.BinaryReader): FloatBlock;
}

export namespace FloatBlock {
  export type AsObject = {
    valuesList: Array<number>,
  }
}

export class Int32Block extends jspb.Message {
  clearValuesList(): void;
  getValuesList(): Array<number>;
  setValuesList(value: Array<number>): void;
  addValues(value: number, index?: number): number;

  serializeBinary(): Uint8Array;
  toObject(includeInstance?: boolean): Int32Block.AsObject;
  static toObject(includeInstance: boolean, msg: Int32Block): Int32Block.AsObject;
  static extensions: {[key: number]: jspb.ExtensionFieldInfo<jspb.Message>};
  static extensionsBinary: {[key: number]: jspb.ExtensionFieldBinaryInfo<jspb.Message>};
  static serializeBinaryToWriter(message: Int32Block, writer: jspb.BinaryWriter): void;
  static deserializeBinary(bytes: Uint8Array): Int32Block;
  static deserializeBinaryFromReader(message: Int32Block, reader: jspb.BinaryReader): Int32Block;
}

export namespace Int32Block {
  export type AsObject = {
    valuesList: Array<number>,
  }
}

export class Int64Block extends jspb.Message {
  clearValuesList(): void;
  getValuesList(): Array<number>;
  setValuesList(value: Array<number>): void;
  addValues(value: number, index?: number): number;

  serializeBinary(): Uint8Array;
  toObject(includeInstance?: boolean): Int64Block.AsObject;
  static toObject(includeInstance: boolean, msg: Int64Block): Int64Block.AsObject;
  static extensions: {[key: number]: jspb.ExtensionFieldInfo<jspb.Message>};
  static extensionsBinary: {[key: number]: jspb.ExtensionFieldBinaryInfo<jspb.Message>};
  static serializeBinaryToWriter(message: Int64Block, writer: jspb.BinaryWriter): void;
  static deserializeBinary(bytes: Uint8Array): Int64Block;
  static deserializeBinaryFromReader(message: Int64Block, reader: jspb.BinaryReader): Int64Block;
}

export namespace Int64Block {
  export type AsObject = {
    valuesList: Array<number>,
  }
}

export class BoolBlock extends jspb.Message {
  clearValuesList(): void;
  getValuesList(): Array<boolean>;
  setValuesList(value: Array<boolean>): void;
  addValues(value: boolean, index?: number): boolean;

  serializeBinary(): Uint8Array;
  toObject(includeInstance?: boolean): BoolBlock.AsObject;
  static toObject(includeInstance: boolean, msg: BoolBlock): BoolBlock.AsObject;
  static extensions: {[key: number]: jspb.ExtensionFieldInfo<jspb.Message>};
  static extensionsBinary: {[key: number]: jspb.ExtensionFieldBinaryInfo<jspb.Message>};
  static serializeBinaryToWriter(message: BoolBlock, writer: jspb.BinaryWriter): void;
  static deserializeBinary(bytes: Uint8Array): BoolBlock;
  static deserializeBinaryFromReader(message: BoolBlock, reader: jspb.BinaryReader): BoolBlock;
}

export namespace BoolBlock {
  export type AsObject = {
    valuesList: Array<boolean>,
  }
}

export class TimestampBlock extends jspb.Message {
  clearValuesList(): void;
  getValuesList(): Array<google_protobuf_timestamp_pb.Timestamp>;
  setValuesList(value: Array<google_protobuf_timestamp_pb.Timestamp>): void;
  addValues(value?: google_protobuf_timestamp_pb.Timestamp, index?: number): google_protobuf_timestamp_pb.Timestamp;

  serializeBinary(): Uint8Array;
  toObject(includeInstance?: boolean): TimestampBlock.AsObject;
  static toObject(includeInstance: boolean, msg: TimestampBlock): TimestampBlock.AsObject;
  static extensions: {[key: number]: jspb.ExtensionFieldInfo<jspb.Message>};
  static extensionsBinary: {[key: number]: jspb.ExtensionFieldBinaryInfo<jspb.Message>};
  static serializeBinaryToWriter(message: TimestampBlock, writer: jspb.BinaryWriter): void;
  static deserializeBinary(bytes: Uint8Array): TimestampBlock;
  static deserializeBinaryFromReader(message: TimestampBlock, reader: jspb.BinaryReader): TimestampBlock;
}

export namespace TimestampBlock {
  export type AsObject = {
    valuesList: Array<google_protobuf_timestamp_pb.Timestamp.AsObject>,
  }
}

export class ObjectRefBlock extends jspb.Message {
  clearValuesList(): void;
  getValuesList(): Array<number>;
  setValuesList(value: Array<number>): void;
  addValues(value: number, index?: number): number;

  serializeBinary(): Uint8Array;
  toObject(includeInstance?: boolean): ObjectRefBlock.AsObject;
  static toObject(includeInstance: boolean, msg: ObjectRefBlock): ObjectRefBlock.AsObject;
  static extensions: {[key: number]: jspb.ExtensionFieldInfo<jspb.Message>};
  static extensionsBinary: {[key: number]: jspb.ExtensionFieldBinaryInfo<jspb.Message>};
  static serializeBinaryToWriter(message: ObjectRefBlock, writer: jspb.BinaryWriter): void;
  static deserializeBinary(bytes: Uint8Array): ObjectRefBlock;
  static deserializeBinaryFromReader(message: ObjectRefBlock, reader: jspb.BinaryReader): ObjectRefBlock;
}

export namespace ObjectRefBlock {
  export type AsObject = {
    valuesList: Array<number>,
  }
}

export class StringRefBlock extends jspb.Message {
  clearStringidList(): void;
  getStringidList(): Array<number>;
  setStringidList(value: Array<number>): void;
  addStringid(value: number, index?: number): number;

  serializeBinary(): Uint8Array;
  toObject(includeInstance?: boolean): StringRefBlock.AsObject;
  static toObject(includeInstance: boolean, msg: StringRefBlock): StringRefBlock.AsObject;
  static extensions: {[key: number]: jspb.ExtensionFieldInfo<jspb.Message>};
  static extensionsBinary: {[key: number]: jspb.ExtensionFieldBinaryInfo<jspb.Message>};
  static serializeBinaryToWriter(message: StringRefBlock, writer: jspb.BinaryWriter): void;
  static deserializeBinary(bytes: Uint8Array): StringRefBlock;
  static deserializeBinaryFromReader(message: StringRefBlock, reader: jspb.BinaryReader): StringRefBlock;
}

export namespace StringRefBlock {
  export type AsObject = {
    stringidList: Array<number>,
  }
}

export class ArrayBlock extends jspb.Message {
  clearSizeList(): void;
  getSizeList(): Array<number>;
  setSizeList(value: Array<number>): void;
  addSize(value: number, index?: number): number;

  hasValues(): boolean;
  clearValues(): void;
  getValues(): Block | undefined;
  setValues(value?: Block): void;

  serializeBinary(): Uint8Array;
  toObject(includeInstance?: boolean): ArrayBlock.AsObject;
  static toObject(includeInstance: boolean, msg: ArrayBlock): ArrayBlock.AsObject;
  static extensions: {[key: number]: jspb.ExtensionFieldInfo<jspb.Message>};
  static extensionsBinary: {[key: number]: jspb.ExtensionFieldBinaryInfo<jspb.Message>};
  static serializeBinaryToWriter(message: ArrayBlock, writer: jspb.BinaryWriter): void;
  static deserializeBinary(bytes: Uint8Array): ArrayBlock;
  static deserializeBinaryFromReader(message: ArrayBlock, reader: jspb.BinaryReader): ArrayBlock;
}

export namespace ArrayBlock {
  export type AsObject = {
    sizeList: Array<number>,
    values?: Block.AsObject,
  }
}

export class StringColumn extends jspb.Message {
  getColumnid(): number;
  setColumnid(value: number): void;

  clearStringsList(): void;
  getStringsList(): Array<string>;
  setStringsList(value: Array<string>): void;
  addStrings(value: string, index?: number): string;

  getClearprevious(): boolean;
  setClearprevious(value: boolean): void;

  serializeBinary(): Uint8Array;
  toObject(includeInstance?: boolean): StringColumn.AsObject;
  static toObject(includeInstance: boolean, msg: StringColumn): StringColumn.AsObject;
  static extensions: {[key: number]: jspb.ExtensionFieldInfo<jspb.Message>};
  static extensionsBinary: {[key: number]: jspb.ExtensionFieldBinaryInfo<jspb.Message>};
  static serializeBinaryToWriter(message: StringColumn, writer: jspb.BinaryWriter): void;
  static deserializeBinary(bytes: Uint8Array): StringColumn;
  static deserializeBinaryFromReader(message: StringColumn, reader: jspb.BinaryReader): StringColumn;
}

export namespace StringColumn {
  export type AsObject = {
    columnid: number,
    stringsList: Array<string>,
    clearprevious: boolean,
  }
}

export class Objects extends jspb.Message {
  clearColumnsList(): void;
  getColumnsList(): Array<ObjectColumn>;
  setColumnsList(value: Array<ObjectColumn>): void;
  addColumns(value?: ObjectColumn, index?: number): ObjectColumn;

  serializeBinary(): Uint8Array;
  toObject(includeInstance?: boolean): Objects.AsObject;
  static toObject(includeInstance: boolean, msg: Objects): Objects.AsObject;
  static extensions: {[key: number]: jspb.ExtensionFieldInfo<jspb.Message>};
  static extensionsBinary: {[key: number]: jspb.ExtensionFieldBinaryInfo<jspb.Message>};
  static serializeBinaryToWriter(message: Objects, writer: jspb.BinaryWriter): void;
  static deserializeBinary(bytes: Uint8Array): Objects;
  static deserializeBinaryFromReader(message: Objects, reader: jspb.BinaryReader): Objects;
}

export namespace Objects {
  export type AsObject = {
    columnsList: Array<ObjectColumn.AsObject>,
  }
}

export class ObjectColumn extends jspb.Message {
  getColumnid(): number;
  setColumnid(value: number): void;

  hasObjects(): boolean;
  clearObjects(): void;
  getObjects(): Columns | undefined;
  setObjects(value?: Columns): void;

  getClearprevious(): boolean;
  setClearprevious(value: boolean): void;

  getCount(): number;
  setCount(value: number): void;

  serializeBinary(): Uint8Array;
  toObject(includeInstance?: boolean): ObjectColumn.AsObject;
  static toObject(includeInstance: boolean, msg: ObjectColumn): ObjectColumn.AsObject;
  static extensions: {[key: number]: jspb.ExtensionFieldInfo<jspb.Message>};
  static extensionsBinary: {[key: number]: jspb.ExtensionFieldBinaryInfo<jspb.Message>};
  static serializeBinaryToWriter(message: ObjectColumn, writer: jspb.BinaryWriter): void;
  static deserializeBinary(bytes: Uint8Array): ObjectColumn;
  static deserializeBinaryFromReader(message: ObjectColumn, reader: jspb.BinaryReader): ObjectColumn;
}

export namespace ObjectColumn {
  export type AsObject = {
    columnid: number,
    objects?: Columns.AsObject,
    clearprevious: boolean,
    count: number,
  }
}

export class QueryRequest extends jspb.Message {
  getQuery(): string;
  setQuery(value: string): void;

  getMaxbatchsize(): number;
  setMaxbatchsize(value: number): void;

  clearParametersList(): void;
  getParametersList(): Array<KeyValue>;
  setParametersList(value: Array<KeyValue>): void;
  addParameters(value?: KeyValue, index?: number): KeyValue;

  clearExtradataList(): void;
  getExtradataList(): Array<KeyValue>;
  setExtradataList(value: Array<KeyValue>): void;
  addExtradata(value?: KeyValue, index?: number): KeyValue;

  serializeBinary(): Uint8Array;
  toObject(includeInstance?: boolean): QueryRequest.AsObject;
  static toObject(includeInstance: boolean, msg: QueryRequest): QueryRequest.AsObject;
  static extensions: {[key: number]: jspb.ExtensionFieldInfo<jspb.Message>};
  static extensionsBinary: {[key: number]: jspb.ExtensionFieldBinaryInfo<jspb.Message>};
  static serializeBinaryToWriter(message: QueryRequest, writer: jspb.BinaryWriter): void;
  static deserializeBinary(bytes: Uint8Array): QueryRequest;
  static deserializeBinaryFromReader(message: QueryRequest, reader: jspb.BinaryReader): QueryRequest;
}

export namespace QueryRequest {
  export type AsObject = {
    query: string,
    maxbatchsize: number,
    parametersList: Array<KeyValue.AsObject>,
    extradataList: Array<KeyValue.AsObject>,
  }
}

export class Scalar extends jspb.Message {
  hasDouble(): boolean;
  clearDouble(): void;
  getDouble(): number;
  setDouble(value: number): void;

  hasFloat(): boolean;
  clearFloat(): void;
  getFloat(): number;
  setFloat(value: number): void;

  hasInt(): boolean;
  clearInt(): void;
  getInt(): number;
  setInt(value: number): void;

  hasLong(): boolean;
  clearLong(): void;
  getLong(): number;
  setLong(value: number): void;

  hasBool(): boolean;
  clearBool(): void;
  getBool(): boolean;
  setBool(value: boolean): void;

  hasTimestamp(): boolean;
  clearTimestamp(): void;
  getTimestamp(): google_protobuf_timestamp_pb.Timestamp | undefined;
  setTimestamp(value?: google_protobuf_timestamp_pb.Timestamp): void;

  hasString(): boolean;
  clearString(): void;
  getString(): string;
  setString(value: string): void;

  getValueCase(): Scalar.ValueCase;
  serializeBinary(): Uint8Array;
  toObject(includeInstance?: boolean): Scalar.AsObject;
  static toObject(includeInstance: boolean, msg: Scalar): Scalar.AsObject;
  static extensions: {[key: number]: jspb.ExtensionFieldInfo<jspb.Message>};
  static extensionsBinary: {[key: number]: jspb.ExtensionFieldBinaryInfo<jspb.Message>};
  static serializeBinaryToWriter(message: Scalar, writer: jspb.BinaryWriter): void;
  static deserializeBinary(bytes: Uint8Array): Scalar;
  static deserializeBinaryFromReader(message: Scalar, reader: jspb.BinaryReader): Scalar;
}

export namespace Scalar {
  export type AsObject = {
    pb_double: number,
    pb_float: number,
    pb_int: number,
    pb_long: number,
    bool: boolean,
    timestamp?: google_protobuf_timestamp_pb.Timestamp.AsObject,
    string: string,
  }

  export enum ValueCase {
    VALUE_NOT_SET = 0,
    DOUBLE = 2,
    FLOAT = 3,
    INT = 4,
    LONG = 5,
    BOOL = 6,
    TIMESTAMP = 7,
    STRING = 8,
  }
}

export class KeyValue extends jspb.Message {
  getName(): string;
  setName(value: string): void;

  hasValue(): boolean;
  clearValue(): void;
  getValue(): Scalar | undefined;
  setValue(value?: Scalar): void;

  serializeBinary(): Uint8Array;
  toObject(includeInstance?: boolean): KeyValue.AsObject;
  static toObject(includeInstance: boolean, msg: KeyValue): KeyValue.AsObject;
  static extensions: {[key: number]: jspb.ExtensionFieldInfo<jspb.Message>};
  static extensionsBinary: {[key: number]: jspb.ExtensionFieldBinaryInfo<jspb.Message>};
  static serializeBinaryToWriter(message: KeyValue, writer: jspb.BinaryWriter): void;
  static deserializeBinary(bytes: Uint8Array): KeyValue;
  static deserializeBinaryFromReader(message: KeyValue, reader: jspb.BinaryReader): KeyValue;
}

export namespace KeyValue {
  export type AsObject = {
    name: string,
    value?: Scalar.AsObject,
  }
}

export class IndexRequest extends jspb.Message {
  getTableid(): number;
  setTableid(value: number): void;

  getIndexid(): number;
  setIndexid(value: number): void;

  getMaxbatchsize(): number;
  setMaxbatchsize(value: number): void;

  clearFieldsList(): void;
  getFieldsList(): Array<string>;
  setFieldsList(value: Array<string>): void;
  addFields(value: string, index?: number): string;

  hasRecords(): boolean;
  clearRecords(): void;
  getRecords(): Page | undefined;
  setRecords(value?: Page): void;

  serializeBinary(): Uint8Array;
  toObject(includeInstance?: boolean): IndexRequest.AsObject;
  static toObject(includeInstance: boolean, msg: IndexRequest): IndexRequest.AsObject;
  static extensions: {[key: number]: jspb.ExtensionFieldInfo<jspb.Message>};
  static extensionsBinary: {[key: number]: jspb.ExtensionFieldBinaryInfo<jspb.Message>};
  static serializeBinaryToWriter(message: IndexRequest, writer: jspb.BinaryWriter): void;
  static deserializeBinary(bytes: Uint8Array): IndexRequest;
  static deserializeBinaryFromReader(message: IndexRequest, reader: jspb.BinaryReader): IndexRequest;
}

export namespace IndexRequest {
  export type AsObject = {
    tableid: number,
    indexid: number,
    maxbatchsize: number,
    fieldsList: Array<string>,
    records?: Page.AsObject,
  }
}

export class TableMetadata extends jspb.Message {
  getName(): string;
  setName(value: string): void;

  clearColumnsList(): void;
  getColumnsList(): Array<ColumnMetadata>;
  setColumnsList(value: Array<ColumnMetadata>): void;
  addColumns(value?: ColumnMetadata, index?: number): ColumnMetadata;

  getTableid(): number;
  setTableid(value: number): void;

  clearIndiciesList(): void;
  getIndiciesList(): Array<IndexMetadata>;
  setIndiciesList(value: Array<IndexMetadata>): void;
  addIndicies(value?: IndexMetadata, index?: number): IndexMetadata;

  serializeBinary(): Uint8Array;
  toObject(includeInstance?: boolean): TableMetadata.AsObject;
  static toObject(includeInstance: boolean, msg: TableMetadata): TableMetadata.AsObject;
  static extensions: {[key: number]: jspb.ExtensionFieldInfo<jspb.Message>};
  static extensionsBinary: {[key: number]: jspb.ExtensionFieldBinaryInfo<jspb.Message>};
  static serializeBinaryToWriter(message: TableMetadata, writer: jspb.BinaryWriter): void;
  static deserializeBinary(bytes: Uint8Array): TableMetadata;
  static deserializeBinaryFromReader(message: TableMetadata, reader: jspb.BinaryReader): TableMetadata;
}

export namespace TableMetadata {
  export type AsObject = {
    name: string,
    columnsList: Array<ColumnMetadata.AsObject>,
    tableid: number,
    indiciesList: Array<IndexMetadata.AsObject>,
  }
}

export class IndexMetadata extends jspb.Message {
  getIndexid(): number;
  setIndexid(value: number): void;

  clearColumnsList(): void;
  getColumnsList(): Array<ColumnMetadata>;
  setColumnsList(value: Array<ColumnMetadata>): void;
  addColumns(value?: ColumnMetadata, index?: number): ColumnMetadata;

  getName(): string;
  setName(value: string): void;

  serializeBinary(): Uint8Array;
  toObject(includeInstance?: boolean): IndexMetadata.AsObject;
  static toObject(includeInstance: boolean, msg: IndexMetadata): IndexMetadata.AsObject;
  static extensions: {[key: number]: jspb.ExtensionFieldInfo<jspb.Message>};
  static extensionsBinary: {[key: number]: jspb.ExtensionFieldBinaryInfo<jspb.Message>};
  static serializeBinaryToWriter(message: IndexMetadata, writer: jspb.BinaryWriter): void;
  static deserializeBinary(bytes: Uint8Array): IndexMetadata;
  static deserializeBinaryFromReader(message: IndexMetadata, reader: jspb.BinaryReader): IndexMetadata;
}

export namespace IndexMetadata {
  export type AsObject = {
    indexid: number,
    columnsList: Array<ColumnMetadata.AsObject>,
    name: string,
  }
}

export class ColumnMetadata extends jspb.Message {
  getName(): string;
  setName(value: string): void;

  getColumnid(): number;
  setColumnid(value: number): void;

  getType(): KoraliumTypeMap[keyof KoraliumTypeMap];
  setType(value: KoraliumTypeMap[keyof KoraliumTypeMap]): void;

  clearSubcolumnsList(): void;
  getSubcolumnsList(): Array<ColumnMetadata>;
  setSubcolumnsList(value: Array<ColumnMetadata>): void;
  addSubcolumns(value?: ColumnMetadata, index?: number): ColumnMetadata;

  serializeBinary(): Uint8Array;
  toObject(includeInstance?: boolean): ColumnMetadata.AsObject;
  static toObject(includeInstance: boolean, msg: ColumnMetadata): ColumnMetadata.AsObject;
  static extensions: {[key: number]: jspb.ExtensionFieldInfo<jspb.Message>};
  static extensionsBinary: {[key: number]: jspb.ExtensionFieldBinaryInfo<jspb.Message>};
  static serializeBinaryToWriter(message: ColumnMetadata, writer: jspb.BinaryWriter): void;
  static deserializeBinary(bytes: Uint8Array): ColumnMetadata;
  static deserializeBinaryFromReader(message: ColumnMetadata, reader: jspb.BinaryReader): ColumnMetadata;
}

export namespace ColumnMetadata {
  export type AsObject = {
    name: string,
    columnid: number,
    type: KoraliumTypeMap[keyof KoraliumTypeMap],
    subcolumnsList: Array<ColumnMetadata.AsObject>,
  }
}

export class TableMetadataResponse extends jspb.Message {
  clearTablesList(): void;
  getTablesList(): Array<TableMetadata>;
  setTablesList(value: Array<TableMetadata>): void;
  addTables(value?: TableMetadata, index?: number): TableMetadata;

  serializeBinary(): Uint8Array;
  toObject(includeInstance?: boolean): TableMetadataResponse.AsObject;
  static toObject(includeInstance: boolean, msg: TableMetadataResponse): TableMetadataResponse.AsObject;
  static extensions: {[key: number]: jspb.ExtensionFieldInfo<jspb.Message>};
  static extensionsBinary: {[key: number]: jspb.ExtensionFieldBinaryInfo<jspb.Message>};
  static serializeBinaryToWriter(message: TableMetadataResponse, writer: jspb.BinaryWriter): void;
  static deserializeBinary(bytes: Uint8Array): TableMetadataResponse;
  static deserializeBinaryFromReader(message: TableMetadataResponse, reader: jspb.BinaryReader): TableMetadataResponse;
}

export namespace TableMetadataResponse {
  export type AsObject = {
    tablesList: Array<TableMetadata.AsObject>,
  }
}

export interface KoraliumTypeMap {
  DOUBLE: 0;
  FLOAT: 1;
  INT32: 2;
  INT64: 3;
  BOOL: 4;
  STRING: 5;
  TIMESTAMP: 6;
  OBJECT: 7;
  ARRAY: 8;
}

export const KoraliumType: KoraliumTypeMap;

