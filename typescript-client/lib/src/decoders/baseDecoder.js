"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
class BaseDecoder {
    constructor(name) {
        this.arrayCount = 0;
        this.globalCount = 0;
        this.nullCounter = 0;
        this.fieldName = name;
    }
    newPage(page) {
        this.onNewPage(page);
        this.arrayCount = 0;
        this.globalCount = 0;
        this.nullCounter = 0;
    }
    getFieldName() {
        return this.fieldName;
    }
    decode(block, objects, startIndex, numberOfElements = Number.MAX_VALUE) {
        const nulls = block.getNullsList();
        const valuesList = this.getValuesList(block);
        var localCount = 0;
        while ((nulls.length > this.nullCounter || valuesList.length > this.arrayCount) && numberOfElements > localCount) {
            if (nulls.length > this.nullCounter) {
                if (nulls[this.nullCounter] == this.globalCount) {
                    objects[startIndex + this.globalCount][this.fieldName] = null;
                    this.nullCounter++;
                    this.globalCount++;
                    localCount++;
                    continue;
                }
            }
            if (valuesList.length > this.arrayCount) {
                objects[startIndex + this.globalCount][this.fieldName] = this.getValue(valuesList, this.arrayCount);
                this.arrayCount++;
                this.globalCount++;
                localCount++;
            }
        }
        return 0;
    }
    decodeArray(block, array, startIndex, numberOfElements = Number.MAX_VALUE) {
        const nulls = block.getNullsList();
        const valuesList = this.getValuesList(block);
        var localCount = 0;
        while ((nulls.length > this.nullCounter || valuesList.length > this.arrayCount) && numberOfElements > localCount) {
            if (nulls.length > this.nullCounter) {
                if (nulls[this.nullCounter] == this.globalCount) {
                    array.push(null);
                    this.nullCounter++;
                    this.globalCount++;
                    localCount++;
                    continue;
                }
            }
            if (valuesList.length > this.arrayCount) {
                array.push(this.getValue(valuesList, this.arrayCount));
                this.arrayCount++;
                this.globalCount++;
                localCount++;
            }
        }
        return 0;
    }
}
exports.default = BaseDecoder;
//# sourceMappingURL=baseDecoder.js.map