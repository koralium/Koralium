import BaseDecoder from "./baseDecoder";
import { Block, Page, ColumnMetadata } from "../generated/koralium_pb";
export default class BoolDecoder extends BaseDecoder {
    constructor(column: ColumnMetadata);
    baseValue(): boolean;
    getValuesList(block: Block): any[];
    onNewPage(page: Page): void;
    getValue(values: any[], index: number): any;
}
