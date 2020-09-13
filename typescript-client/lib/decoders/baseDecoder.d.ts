import { IDecoder } from "./decoder";
import { Page, Block } from "../generated/koralium_pb";
export default abstract class BaseDecoder implements IDecoder {
    arrayCount: number;
    globalCount: number;
    nullCounter: number;
    fieldName: string;
    constructor(name: string);
    abstract baseValue(): any;
    newPage(page: Page): void;
    getFieldName(): string;
    abstract onNewPage(page: Page): void;
    abstract getValuesList(block: Block): any[];
    abstract getValue(values: any[], index: number): any;
    decode(block: Block, objects: any[], startIndex: number, numberOfElements?: number): number;
    decodeArray(block: Block, array: any[], startIndex: number, numberOfElements?: number): number;
}
