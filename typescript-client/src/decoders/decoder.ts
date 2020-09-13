import { Page, Block } from "../generated/koralium_pb";

export interface IDecoder {

  newPage(page: Page): void;

  getFieldName(): string;

  baseValue(): any;

  decode(block: Block, objects: any[], startIndex: number, numberOfElements?: number): number;

  decodeArray(block: Block, array: any[], startIndex: number, numberOfElements?: number): number;
}