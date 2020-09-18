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
import { IDecoder } from "./decoder";
import { Page, Block } from "../generated/koralium_pb";

export default abstract class BaseDecoder implements IDecoder {
  arrayCount: number = 0;
  globalCount: number = 0;
  nullCounter: number = 0;
  fieldName: string;

  constructor(name: string) {
    this.fieldName = name;
  }

  abstract baseValue(): any;

  newPage(page: Page): void {
    this.onNewPage(page);
    this.arrayCount = 0;
    this.globalCount = 0;
    this.nullCounter = 0;
  }

  getFieldName(): string {
    return this.fieldName;
  }

  abstract onNewPage(page: Page): void;

  abstract getValuesList(block: Block) : any[];

  abstract getValue(values: any[], index: number): any;

  decode(block: Block, objects: any[], startIndex: number, numberOfElements: number = Number.MAX_VALUE): number {

    const nulls = block.getNullsList();
    const valuesList = this.getValuesList(block);
    
    var localCount = 0;
    while ((nulls.length > this.nullCounter || valuesList.length > this.arrayCount) && numberOfElements > localCount) {
        if (nulls.length > this.nullCounter) {
            if (nulls[this.nullCounter] == this.globalCount) {
                objects[startIndex + this.globalCount][this.fieldName] = null;
                this.nullCounter++;
                this.globalCount++;
                localCount++;
                continue;
            }
        }
        if (valuesList.length > this.arrayCount) {
            objects[startIndex + this.globalCount][this.fieldName] = this.getValue(valuesList, this.arrayCount);
            this.arrayCount++;
            this.globalCount++;
            localCount++;
        }
    }

    return 0;
  }

  decodeArray(block: Block, array: any[], startIndex: number, numberOfElements: number = Number.MAX_VALUE): number {
    const nulls = block.getNullsList();
    const valuesList = this.getValuesList(block);

    var localCount = 0;
    while ((nulls.length > this.nullCounter || valuesList.length > this.arrayCount) && numberOfElements > localCount) {
        if (nulls.length > this.nullCounter) {
            if (nulls[this.nullCounter] == this.globalCount) {
                array.push(null);
                this.nullCounter++;
                this.globalCount++;
                localCount++;
                continue;
            }
        }
        if (valuesList.length > this.arrayCount) {
            array.push(this.getValue(valuesList, this.arrayCount));
            this.arrayCount++;
            this.globalCount++;
            localCount++;
        }
    }

    return 0;
  }
}