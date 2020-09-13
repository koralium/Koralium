"use strict";
var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", { value: true });
const baseDecoder_1 = __importDefault(require("./baseDecoder"));
const decoders_1 = require("./decoders");
class ArrayDecoder extends baseDecoder_1.default {
    constructor(column) {
        super(column.getName());
        const subColumns = column.getSubcolumnsList();
        if (subColumns.length != 1) {
            throw new Error("Arrays can only have one sub column");
        }
        this.subDecoder = decoders_1.getDecoder(subColumns[0]);
    }
    baseValue() {
        return [];
    }
    onNewPage(page) {
        this.subDecoder.newPage(page);
    }
    getValuesList(block) {
        const sizeList = block.getArrays().getSizeList();
        this.currentBlock = block.getArrays().getValues();
        return sizeList;
    }
    getValue(values, index) {
        const size = values[this.arrayCount];
        const subArray = [];
        this.subDecoder.decodeArray(this.currentBlock, subArray, 0, size);
        return subArray;
    }
}
exports.default = ArrayDecoder;
//# sourceMappingURL=arrayDecoder.js.map