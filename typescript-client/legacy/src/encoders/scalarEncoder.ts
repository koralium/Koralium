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
import { Timestamp } from "google-protobuf/google/protobuf/timestamp_pb";

export default function encodeScalar(value: any) {
  const scalar = new Scalar();
  if(typeof(value) == "string") {
    scalar.setString(<string>value);
  }
  else if (typeof(value) == "number") {
    if (Number.isInteger(value)) {
      scalar.setInt(value);
    }
    else {
      scalar.setDouble(value);
    }
  }
  else if (value instanceof Date) {
    const date = <Date>value;
    const timestamp = new Timestamp();
    timestamp.fromDate(date);
    scalar.setTimestamp(timestamp);
  }
  else {
    throw new Error("The type was not supported");
  }
  return scalar;
}