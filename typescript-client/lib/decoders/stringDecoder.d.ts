import BaseDecoder from "./baseDecoder";
import { Page, Block, ColumnMetadata } from "../generated/koralium_pb";
export default class StringDecoder extends BaseDecoder {
    columnId: number;
    cache: Array<string>;
    constructor(column: ColumnMetadata);
    baseValue(): string;
    onNewPage(page: Page): void;
    getValuesList(block: Block): any[];
    getValue(values: any[], index: number): string;
    buildCache(page: Page): void;
}
