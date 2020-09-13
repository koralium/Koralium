import BaseDecoder from "./baseDecoder";
import { Block, Page, ColumnMetadata } from "../../generated/koralium_pb";

export default class TimestampDecoder extends BaseDecoder {

  constructor(column: ColumnMetadata) {
    super(column.getName())
  }

  baseValue() {
    return "";
  }

  getValuesList(block: Block): any[] {
    return block.getTimestamps().getValuesList();
  }

  onNewPage(page: Page): void {
  }

  getValue(values: any[], index: number) {
    return values[index].toDate();
  }
}