/*
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */
import BaseDecoder from "./baseDecoder";
import { Page, Block, ColumnMetadata } from "../generated/koralium_pb";
import { IDecoder } from "./decoder";
import { getDecoder } from "./decoders";

export default class ArrayDecoder extends BaseDecoder {

  subDecoder: IDecoder;
  currentBlock?: Block;

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
    const arrayBlock = block.getArrays();

    if (arrayBlock === undefined) {
      throw new Error("Internal error: array block was undefined");
    }

    const sizeList = arrayBlock.getSizeList();
    this.currentBlock = arrayBlock.getValues();
    return sizeList;
  }

  getValue(values: any[], index: number) {
    const size = values[this.arrayCount];
    const subArray: [] = [];

    if(this.currentBlock === undefined) {
      throw new Error("Internal error: array internal block was undefined");
    }

    this.subDecoder.decodeArray(this.currentBlock, subArray, 0, size);
    return subArray;
  }

}