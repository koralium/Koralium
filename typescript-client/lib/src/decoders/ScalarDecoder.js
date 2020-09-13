"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
const koralium_pb_1 = require("../../generated/koralium_pb");
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
            return scalar.getTimestamp().toDate().toISOString();
    }
}
exports.default = decodeScalar;
//# sourceMappingURL=ScalarDecoder.js.map