"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.ObjectToSelectMapper = void 0;
//This class is mostly useful in GraphQL or similar areas
//Where you want to map an object into the query builder.
class ObjectToSelectMapper {
    constructor() {
        this.mappingTable = {};
    }
    addMapping(key, select) {
        this.mappingTable[key] = select;
        return this;
    }
    isArray(value) {
        return Array.isArray(value);
    }
    addSelectsToQuery(queryBuilder, inputObject) {
        for (let [key] of Object.entries(inputObject)) {
            if (this.mappingTable[key] !== undefined) {
                const mappingTableValue = this.mappingTable[key];
                if (this.isArray(mappingTableValue)) {
                    mappingTableValue.forEach(x => queryBuilder.addSelectElement(x));
                }
                else {
                    queryBuilder.addSelectElement(mappingTableValue);
                }
            }
        }
    }
}
exports.ObjectToSelectMapper = ObjectToSelectMapper;
//# sourceMappingURL=objectToSelectMapper.js.map