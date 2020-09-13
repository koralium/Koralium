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