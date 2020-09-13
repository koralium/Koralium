"use strict";
var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", { value: true });
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