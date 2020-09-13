import BaseDecoder from "./baseDecoder";
import { Page, Block, ColumnMetadata } from "../generated/koralium_pb";
import { IDecoder } from "./decoder";
import { getDecoder } from "./decoders";

export default class ArrayDecoder extends BaseDecoder {

  subDecoder: IDecoder;
  currentBlock: Block;

  constructor(column: ColumnMetadata) {
    super(column.getName());

    const subColumns = column.getSubcolumnsList();
    
    if(subColumns.length != 1) {
      throw new Error("Arrays can only have one sub column");
    }

    this.subDecoder = getDecoder(subColumns[0]);
  }
  
  baseValue() {
    return [];
  }

  onNewPage(page: Page): void {
    this.subDecoder.newPage(page);
  }

  getValuesList(block: Block): any[] {
    const sizeList = block.getArrays().getSizeList();
    this.currentBlock = block.getArrays().getValues();
    return sizeList;
  }

  getValue(values: any[], index: number) {
    const size = values[this.arrayCount];
    const subArray = [];
    this.subDecoder.decodeArray(this.currentBlock, subArray, 0, size);
    return subArray;
  }

}