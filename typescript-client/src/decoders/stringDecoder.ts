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
    const stringBlock = block.getStrings();

    if (stringBlock === undefined) {
      throw new Error("Internal error: string block was undefined");
    }

    return stringBlock.getStringidList();
  }

  getValue(values: any[], index: number) {
    return this.cache[values[index]];
  }

  buildCache(page: Page) {
    const stringColumn = page.getStringsList().find(x => x.getColumnid() === this.columnId);

    if (stringColumn === undefined) {
      throw new Error("Internal error: could not find the string column");
    }

    const strArray = stringColumn.getStringsList();

    if(stringColumn.getClearprevious()) {
      this.cache.length = 0;
    }

    for(var i = 0, len = strArray.length; i < len; i++) {
      this.cache.push(strArray[i]);
    }
  }

}