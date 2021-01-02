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
import { Scalar } from "../generated/koralium_pb";

export default function decodeScalar(scalar: Scalar) {
  switch(scalar.getValueCase()) {
    case Scalar.ValueCase.BOOL:
      return scalar.getBool();
    case Scalar.ValueCase.DOUBLE:
      return scalar.getDouble();
    case Scalar.ValueCase.FLOAT:
      return scalar.getFloat();
    case Scalar.ValueCase.INT:
      return scalar.getInt();
    case Scalar.ValueCase.LONG:
      return scalar.getLong();
    case Scalar.ValueCase.TIMESTAMP:
      const timestamp = scalar.getTimestamp();
      if(timestamp === undefined) {
        throw new Error("Internal error, timestamp was undefined in scalar decoder");
      }
      return timestamp.toDate().toISOString();
  }
}