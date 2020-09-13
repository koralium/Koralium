"use strict";
var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", { value: true });
const baseDecoder_1 = __importDefault(require("./baseDecoder"));
class StringDecoder extends baseDecoder_1.default {
    constructor(column) {
        super(column.getName());
        this.cache = [];
        this.columnId = column.getColumnid();
    }
    baseValue() {
        return "";
    }
    onNewPage(page) {
        this.buildCache(page);
    }
    getValuesList(block) {
        return block.getStrings().getStringidList();
    }
    getValue(values, index) {
        return this.cache[values[index]];
    }
    buildCache(page) {
        const stringColumn = page.getStringsList().find(x => x.getColumnid() === this.columnId);
        const strArray = stringColumn.getStringsList();
        if (stringColumn.getClearprevious()) {
            this.cache.length = 0;
        }
        for (var i = 0, len = strArray.length; i < len; i++) {
            this.cache.push(strArray[i]);
        }
    }
}
exports.default = StringDecoder;
//# sourceMappingURL=stringDecoder.js.map