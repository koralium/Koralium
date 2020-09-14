"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.QueryBuilder = void 0;
class QueryBuilder {
    constructor(table) {
        this.table = "";
        this.selects = [];
        this.limit = null;
        this.offset = null;
        this.filter = null;
        this.table = table;
    }
    addSelectElement(expression) {
        if (!this.selects.includes(expression)) {
            this.selects.push(expression);
        }
        return this;
    }
    setLimit(limit) {
        this.limit = limit;
        return this;
    }
    setOffset(offset) {
        this.offset = offset;
        return this;
    }
    setFilter(filter) {
        this.filter = filter;
        return this;
    }
    build() {
        var selectElements = this.selects.join(", ");
        let sql = `SELECT ${selectElements} FROM ${this.table}`;
        if (this.filter != null) {
            sql += ` WHERE ${this.filter}`;
        }
        if (this.limit != null) {
            sql += ` LIMIT ${this.limit}`;
        }
        if (this.offset != null) {
            sql += ` OFFSET ${this.offset}`;
        }
        return sql;
    }
}
exports.QueryBuilder = QueryBuilder;
//# sourceMappingURL=queryBuilder.js.map