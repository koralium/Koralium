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
import { Block, Page, ColumnMetadata } from "../generated/koralium_pb";

export default class BoolDecoder extends BaseDecoder {

  constructor(column: ColumnMetadata) {
    super(column.getName())
  }

  baseValue() {
    return false;
  }

  getValuesList(block: Block): any[] {
    const boolBlock = block.getBools();
    if(boolBlock === undefined) {
      throw new Error("Internal error: bool block was undefined");
    }
    return boolBlock.getValuesList();
  }

  onNewPage(page: Page): void {
  }

  getValue(values: any[], index: number) {
    return values[index];
  }
}