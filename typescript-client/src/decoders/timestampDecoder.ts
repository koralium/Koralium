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

export default class TimestampDecoder extends BaseDecoder {

  constructor(column: ColumnMetadata) {
    super(column.getName())
  }

  baseValue() {
    return "";
  }

  getValuesList(block: Block): any[] {
    const timestamps = block.getTimestamps();
    if(timestamps === undefined) {
      throw new Error("Timestamp block was undefined");
    }
    return timestamps.getValuesList();
  }

  onNewPage(page: Page): void {
  }

  getValue(values: any[], index: number) {
    return values[index].toDate().toISOString();
  }
}