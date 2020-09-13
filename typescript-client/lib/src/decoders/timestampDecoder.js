"use strict";
var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", { value: true });
const baseDecoder_1 = __importDefault(require("./baseDecoder"));
class TimestampDecoder extends baseDecoder_1.default {
    constructor(column) {
        super(column.getName());
    }
    baseValue() {
        return "";
    }
    getValuesList(block) {
        return block.getTimestamps().getValuesList();
    }
    onNewPage(page) {
    }
    getValue(values, index) {
        return values[index].toDate();
    }
}
exports.default = TimestampDecoder;
//# sourceMappingURL=timestampDecoder.js.map