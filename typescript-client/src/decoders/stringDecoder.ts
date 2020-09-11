import BaseDecoder from "./baseDecoder";
import { Page, Block, ColumnMetadata } from "../../generated/koralium_pb";

export default class StringDecoder extends BaseDecoder {

  columnId: number;
  cache: Array<string> = [];

  constructor(column: ColumnMetadata) {
    super(column.getName());

    this.columnId = column.getColumnid();
  }

  baseValue() {
    return "";
  }

  onNewPage(page: Page): void {
    this.buildCache(page);
  }

  getValuesList(block: Block): any[] {
    return block.getStrings().getStringidList();
  }

  getValue(values: any[], index: number) {
    return this.cache[values[index]];
  }

  buildCache(page: Page) {
    const stringColumn = page.getStringsList().find(x => x.getColumnid() === this.columnId);
    const strArray = stringColumn.getStringsList();

    if(stringColumn.getClearprevious()) {
      this.cache.length = 0;
    }

    for(var i = 0, len = strArray.length; i < len; i++) {
      this.cache.push(strArray[i]);
    }
  }

}