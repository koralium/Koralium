import BaseDecoder from "./baseDecoder";
import { Block, Page, ColumnMetadata } from "../generated/koralium_pb";
export default class IntDecoder extends BaseDecoder {
    constructor(column: ColumnMetadata);
    baseValue(): number;
    getValuesList(block: Block): any[];
    onNewPage(page: Page): void;
    getValue(values: any[], index: number): any;
}
