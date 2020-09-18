"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.QueryBuilder = void 0;
/*
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */
const filterBuilder_1 = require("./filterBuilder");
const parameterBuilder_1 = require("./parameterBuilder");
class QueryBuilder {
    constructor(table, mapper) {
        this.table = "";
        this.selects = [];
        this.limit = null;
        this.offset = null;
        this.filters = [];
        this.parameterBuilder = new parameterBuilder_1.ParameterBuilder();
        this.orderBy = null;
        this.table = table;
        this.mapper = mapper;
    }
    addSelectElement(expression) {
        if (!this.selects.includes(expression)) {
            this.selects.push(expression);
        }
        return this;
    }
    addSelectsWithMapper(value) {
        if (this.mapper === undefined) {
            throw new Error("No mapper was entered in the constructor");
        }
        this.mapper.addSelectsToQuery(this, value);
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
    addFilter(filter) {
        if (typeof filter === "string") {
            this.filters.push(filter);
        }
        else {
            const result = filterBuilder_1.writeFilterWithParameterBuilder(this.parameterBuilder, filter);
            this.filters.push(result);
        }
        return this;
    }
    getParameters() {
        return this.parameterBuilder.getParameters();
    }
    buildQuery() {
        var selectElements = this.selects.join(", ");
        let sql = `SELECT ${selectElements} FROM ${this.table}`;
        if (this.filters.length > 0) {
            sql += ` WHERE ${this.filters.join(" AND ")}`;
        }
        if (this.orderBy != null) {
            sql += ` ORDER BY ${this.orderBy}`;
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