"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
class QueryBuilder {
    constructor() {
        this.selects = [];
    }
    selectExpression(name) {
        this.selects.push(name);
    }
    selectColumn(key) {
        this.selects.push(key.toString());
    }
    whereExpression(expression) {
    }
    whereEqual(model) {
    }
    build() {
        var selects = this.selects.join(", ");
        return `SELECT ${selects}`;
    }
}
exports.default = QueryBuilder;
//# sourceMappingURL=queryBuilder.js.map