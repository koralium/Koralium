"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.ParameterBuilder = void 0;
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
class ParameterBuilder {
    constructor() {
        this.valuesToParameters = {};
        this.counter = 0;
    }
    getParameterName(value) {
        if (this.valuesToParameters[value] !== undefined) {
            return this.valuesToParameters[value];
        }
        else {
            const newParameter = `P${this.counter++}`;
            this.valuesToParameters[value] = newParameter;
            return newParameter;
        }
    }
    getParameters() {
        const output = {};
        for (let [key, value] of Object.entries(this.valuesToParameters)) {
            output[value] = key;
        }
        console.log(output);
        return output;
    }
}
exports.ParameterBuilder = ParameterBuilder;
//# sourceMappingURL=parameterBuilder.js.map