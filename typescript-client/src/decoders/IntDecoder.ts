import BaseDecoder from "./baseDecoder";
import { Block, Page, ColumnMetadata } from "../generated/koralium_pb";

export default class IntDecoder extends BaseDecoder {
  
  constructor(column: ColumnMetadata) {
    super(column.getName());
  }

  baseValue() {
    return 0;
  }

  getValuesList(block: Block): any[] {
    return block.getInts().getValuesList();
  }

  onNewPage(page: Page): void {

  }

  getValue(values: any[], index: number): any {
    return values[index];
  }
}