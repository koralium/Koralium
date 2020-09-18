"use strict";
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
function decodeScalar(scalar) {
    switch (scalar.getValueCase()) {
        case koralium_pb_1.Scalar.ValueCase.BOOL:
            return scalar.getBool();
        case koralium_pb_1.Scalar.ValueCase.DOUBLE:
            return scalar.getDouble();
        case koralium_pb_1.Scalar.ValueCase.FLOAT:
            return scalar.getFloat();
        case koralium_pb_1.Scalar.ValueCase.INT:
            return scalar.getInt();
        case koralium_pb_1.Scalar.ValueCase.LONG:
            return scalar.getLong();
        case koralium_pb_1.Scalar.ValueCase.TIMESTAMP:
            const timestamp = scalar.getTimestamp();
            if (timestamp === undefined) {
                throw new Error("Internal error, timestamp was undefined in scalar decoder");
            }
            return timestamp.toDate().toISOString();
    }
}
exports.default = decodeScalar;
//# sourceMappingURL=ScalarDecoder.js.map