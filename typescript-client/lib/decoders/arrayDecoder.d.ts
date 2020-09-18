import BaseDecoder from "./baseDecoder";
import { Page, Block, ColumnMetadata } from "../generated/koralium_pb";
import { IDecoder } from "./decoder";
export default class ArrayDecoder extends BaseDecoder {
    subDecoder: IDecoder;
    currentBlock?: Block;
    constructor(column: ColumnMetadata);
    baseValue(): never[];
    onNewPage(page: Page): void;
    getValuesList(block: Block): any[];
    getValue(values: any[], index: number): [];
}
