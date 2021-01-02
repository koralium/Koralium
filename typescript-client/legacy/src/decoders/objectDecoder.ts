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
import { IDecoder } from "./decoder";
import { ColumnMetadata, Page, Block } from "../generated/koralium_pb";
import { getDecoder } from "./decoders";

export default class ObjectDecoder extends BaseDecoder {

  columnId: number;
  columnNames: string[] = [];
  decoders: IDecoder[] = [];
  cache: Array<{}> = [];
  baseObject: {[key: string]: any;} = {};

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

    if(objectColumn === undefined) {
      throw new Error("Internal error: could not find object column in page");
    }

    if (objectColumn.getClearprevious()) {
      //Clear the local cache
      this.cache.length = 0;
    }

    const objectsBlock = objectColumn.getObjects();
    
    if(objectsBlock === undefined) {
      throw new Error("Internal error: objects block was undefined");
    }

    const blocks = objectsBlock.getBlocksList();
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
    const objectBlock = block.getObjects();

    if (objectBlock === undefined) {
      throw new Error("Internal error: object value block was undefined");
    }

    return objectBlock.getValuesList();
  }

  getValue(values: any[], index: number) {
    return this.cache[values[index]];
  }
}