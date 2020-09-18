import BaseDecoder from "./baseDecoder";
import { IDecoder } from "./decoder";
import { ColumnMetadata, Page, Block } from "../generated/koralium_pb";
export default class ObjectDecoder extends BaseDecoder {
    columnId: number;
    columnNames: string[];
    decoders: IDecoder[];
    cache: Array<{}>;
    baseObject: {
        [key: string]: any;
    };
    constructor(column: ColumnMetadata);
    baseValue(): any;
    onNewPage(page: Page): void;
    buildCache(page: Page): void;
    getValuesList(block: Block): any[];
    getValue(values: any[], index: number): {};
}
