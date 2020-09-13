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
      return scalar.getTimestamp().toDate().toISOString();
  }
}