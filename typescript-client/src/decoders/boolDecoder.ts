import BaseDecoder from "./baseDecoder";
import { Block, Page, ColumnMetadata } from "../generated/koralium_pb";

export default class BoolDecoder extends BaseDecoder {

  constructor(column: ColumnMetadata) {
    super(column.getName())
  }

  baseValue() {
    return false;
  }

  getValuesList(block: Block): any[] {
    return block.getBools().getValuesList();
  }

  onNewPage(page: Page): void {
  }

  getValue(values: any[], index: number) {
    return values[index];
  }
}