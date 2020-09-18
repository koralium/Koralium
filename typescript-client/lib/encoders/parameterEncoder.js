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
const koralium_pb_1 = require("../generated/koralium_pb");
const scalarEncoder_1 = __importDefault(require("./scalarEncoder"));
function encodeParameters(parameters) {
    const output = [];
    for (let [key] of Object.entries(parameters)) {
        const parameter = new koralium_pb_1.Parameter();
        parameter.setName(key);
        parameter.setValue(scalarEncoder_1.default(parameters[key]));
        output.push(parameter);
    }
    return output;
}
exports.default = encodeParameters;
//# sourceMappingURL=parameterEncoder.js.map