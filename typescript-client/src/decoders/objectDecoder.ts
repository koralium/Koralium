import BaseDecoder from "./baseDecoder";
import { IDecoder } from "./decoder";
import { ColumnMetadata, Page, Block } from "../generated/koralium_pb";
import { getDecoder } from "./decoders";

export default class ObjectDecoder extends BaseDecoder {

  columnId: number;
  columnNames: string[] = [];
  decoders: IDecoder[] = [];
  cache: Array<{}> = [];
  baseObject: {} = {};

  constructor(column: ColumnMetadata) {
    super(column.getName());
    this.columnId = column.getColumnid();

    const subColumns = column.getSubcolumnsList();

    for (let i = 0; i < subColumns.length; i++) { 
      const columnName = subColumns[i].getName();

      //Add the column name
      this.columnNames.push(columnName);

      //add the decoder
      const decoder = getDecoder(subColumns[i]);
      this.decoders.push(decoder);

      //Add it to the base object
      this.baseObject[columnName] = decoder.baseValue();
    }
  }

  baseValue(): any {
    return {};
  }

  onNewPage(page: Page): void {
    this.decoders.forEach(x => x.newPage(page));

    this.buildCache(page);
  }

  buildCache(page: Page): void {
    const objectColumn = page.getObjectsList().find(x => x.getColumnid() == this.columnId);

    if (objectColumn.getClearprevious()) {
      //Clear the local cache
      this.cache.length = 0;
    }

    const blocks = objectColumn.getObjects().getBlocksList();
    const objectsCount = objectColumn.getCount();

    for (let i = 0; i < objectsCount; i++) {
      const newObject = {
          ...this.baseObject
      };
      this.cache.push(newObject);
    }
    
    for (let i = 0; i < this.decoders.length; i++) {
      this.decoders[i].decode(blocks[i], this.cache, 0);
    }
  }

  getValuesList(block: Block): any[] {
    return block.getObjects().getValuesList();
  }

  getValue(values: any[], index: number) {
    return this.cache[values[index]];
  }
}