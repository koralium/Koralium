"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
const koralium_pb_1 = require("../../generated/koralium_pb");
const timestamp_pb_1 = require("google-protobuf/google/protobuf/timestamp_pb");
function encodeScalar(value) {
    console.log(value.constructor.name);
    const scalar = new koralium_pb_1.Scalar();
    if (typeof (value) == "string") {
        scalar.setString(value);
    }
    else if (typeof (value) == "number") {
        scalar.setDouble(value);
    }
    else if (value instanceof Date) {
        const date = value;
        const timestamp = new timestamp_pb_1.Timestamp();
        timestamp.fromDate(date);
        scalar.setTimestamp(timestamp);
    }
    else {
        throw new Error("The type was not supported");
    }
    return scalar;
}
exports.default = encodeScalar;
//# sourceMappingURL=scalarEncoder.js.map