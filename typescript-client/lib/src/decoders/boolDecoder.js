"use strict";
var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", { value: true });
const baseDecoder_1 = __importDefault(require("./baseDecoder"));
class BoolDecoder extends baseDecoder_1.default {
    constructor(column) {
        super(column.getName());
    }
    baseValue() {
        return false;
    }
    getValuesList(block) {
        return block.getBools().getValuesList();
    }
    onNewPage(page) {
    }
    getValue(values, index) {
        return values[index];
    }
}
exports.default = BoolDecoder;
//# sourceMappingURL=boolDecoder.js.map