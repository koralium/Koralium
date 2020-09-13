"use strict";
var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", { value: true });
exports.getDecoder = void 0;
const objectDecoder_1 = __importDefault(require("./objectDecoder"));
const arrayDecoder_1 = __importDefault(require("./arrayDecoder"));
const stringDecoder_1 = __importDefault(require("./stringDecoder"));
const doubleDecoder_1 = __importDefault(require("./doubleDecoder"));
const floatDecoder_1 = __importDefault(require("./floatDecoder"));
const IntDecoder_1 = __importDefault(require("./IntDecoder"));
const longDecoder_1 = __importDefault(require("./longDecoder"));
const boolDecoder_1 = __importDefault(require("./boolDecoder"));
const timestampDecoder_1 = __importDefault(require("./timestampDecoder"));
function getDecoder(column) {
    const type = column.getType();
    if (type === 0) {
        return new doubleDecoder_1.default(column);
    }
    if (type === 1) {
        return new floatDecoder_1.default(column);
    }
    if (type === 2) {
        return new IntDecoder_1.default(column);
    }
    if (type === 3) {
        return new longDecoder_1.default(column);
    }
    if (type === 4) {
        return new boolDecoder_1.default(column);
    }
    if (type === 5) {
        return new stringDecoder_1.default(column);
    }
    if (type === 6) {
        return new timestampDecoder_1.default(column);
    }
    if (type === 7) {
        return new objectDecoder_1.default(column);
    }
    if (type === 8) {
        return new arrayDecoder_1.default(column);
    }
    return null;
}
exports.getDecoder = getDecoder;
//# sourceMappingURL=decoders.js.map