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
class BoolDecoder extends baseDecoder_1.default {
    constructor(column) {
        super(column.getName());
    }
    baseValue() {
        return false;
    }
    getValuesList(block) {
        const boolBlock = block.getBools();
        if (boolBlock === undefined) {
            throw new Error("Internal error: bool block was undefined");
        }
        return boolBlock.getValuesList();
    }
    onNewPage(page) {
    }
    getValue(values, index) {
        return values[index];
    }
}
exports.default = BoolDecoder;
//# sourceMappingURL=boolDecoder.js.map