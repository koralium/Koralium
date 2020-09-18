"use strict";
var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", { value: true });
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
const baseDecoder_1 = __importDefault(require("./baseDecoder"));
const decoders_1 = require("./decoders");
class ArrayDecoder extends baseDecoder_1.default {
    constructor(column) {
        super(column.getName());
        const subColumns = column.getSubcolumnsList();
        if (subColumns.length != 1) {
            throw new Error("Arrays can only have one sub column");
        }
        this.subDecoder = decoders_1.getDecoder(subColumns[0]);
    }
    baseValue() {
        return [];
    }
    onNewPage(page) {
        this.subDecoder.newPage(page);
    }
    getValuesList(block) {
        const arrayBlock = block.getArrays();
        if (arrayBlock === undefined) {
            throw new Error("Internal error: array block was undefined");
        }
        const sizeList = arrayBlock.getSizeList();
        this.currentBlock = arrayBlock.getValues();
        return sizeList;
    }
    getValue(values, index) {
        const size = values[this.arrayCount];
        const subArray = [];
        if (this.currentBlock === undefined) {
            throw new Error("Internal error: array internal block was undefined");
        }
        this.subDecoder.decodeArray(this.currentBlock, subArray, 0, size);
        return subArray;
    }
}
exports.default = ArrayDecoder;
//# sourceMappingURL=arrayDecoder.js.map