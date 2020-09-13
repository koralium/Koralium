"use strict";
var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", { value: true });
const baseDecoder_1 = __importDefault(require("./baseDecoder"));
const decoders_1 = require("./decoders");
class ObjectDecoder extends baseDecoder_1.default {
    constructor(column) {
        super(column.getName());
        this.columnNames = [];
        this.decoders = [];
        this.cache = [];
        this.baseObject = {};
        this.columnId = column.getColumnid();
        const subColumns = column.getSubcolumnsList();
        for (let i = 0; i < subColumns.length; i++) {
            const columnName = subColumns[i].getName();
            //Add the column name
            this.columnNames.push(columnName);
            //add the decoder
            const decoder = decoders_1.getDecoder(subColumns[i]);
            this.decoders.push(decoder);
            //Add it to the base object
            this.baseObject[columnName] = decoder.baseValue();
        }
    }
    baseValue() {
        return {};
    }
    onNewPage(page) {
        this.decoders.forEach(x => x.newPage(page));
        this.buildCache(page);
    }
    buildCache(page) {
        const objectColumn = page.getObjectsList().find(x => x.getColumnid() == this.columnId);
        if (objectColumn.getClearprevious()) {
            //Clear the local cache
            this.cache.length = 0;
        }
        const blocks = objectColumn.getObjects().getBlocksList();
        const objectsCount = objectColumn.getCount();
        for (let i = 0; i < objectsCount; i++) {
            const newObject = Object.assign({}, this.baseObject);
            this.cache.push(newObject);
        }
        for (let i = 0; i < this.decoders.length; i++) {
            this.decoders[i].decode(blocks[i], this.cache, 0);
        }
    }
    getValuesList(block) {
        return block.getObjects().getValuesList();
    }
    getValue(values, index) {
        return this.cache[values[index]];
    }
}
exports.default = ObjectDecoder;
//# sourceMappingURL=objectDecoder.js.map