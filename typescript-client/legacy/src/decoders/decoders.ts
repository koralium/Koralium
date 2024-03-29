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
import { ColumnMetadata, Page, Block } from "../generated/koralium_pb";
import { IDecoder } from "./decoder";
import ObjectDecoder from "./objectDecoder";
import ArrayDecoder from "./arrayDecoder";
import StringDecoder from "./stringDecoder";
import DoubleDecoder from "./doubleDecoder";
import FloatDecoder from "./floatDecoder";
import IntDecoder from "./IntDecoder";
import LongDecoder from "./longDecoder";
import BoolDecoder from "./boolDecoder";
import TimestampDecoder from "./timestampDecoder";

export function getDecoder(column: ColumnMetadata) : IDecoder {
  const type = column.getType();

  if (type === 0) {
    return new DoubleDecoder(column);
  }

  if (type === 1) {
    return new FloatDecoder(column);
  }

  if (type === 2) {
    return new IntDecoder(column);
  }

  if (type === 3) {
    return new LongDecoder(column);
  }

  if (type === 4) {
    return new BoolDecoder(column);
  }

  if (type === 5) {
    return new StringDecoder(column);
  }

  if (type === 6) {
    return new TimestampDecoder(column);
  }

  if (type === 7) {
    return new ObjectDecoder(column);
  }

  if (type === 8) {
    return new ArrayDecoder(column);
  }
  
  throw new Error("Decoder not found for typeId: " + type);
}