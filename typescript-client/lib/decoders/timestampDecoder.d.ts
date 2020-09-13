import BaseDecoder from "./baseDecoder";
import { Block, Page, ColumnMetadata } from "../generated/koralium_pb";
export default class TimestampDecoder extends BaseDecoder {
    constructor(column: ColumnMetadata);
    baseValue(): string;
    getValuesList(block: Block): any[];
    onNewPage(page: Page): void;
    getValue(values: any[], index: number): any;
}
