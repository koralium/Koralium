"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.FieldQuery = exports.FilterResult = exports.writeFilterWithParameterBuilder = exports.writeFilter = void 0;
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
const parameterBuilder_1 = require("./parameterBuilder");
function isString(val) {
    return typeof (val) === "string";
}
function isNumber(val) {
    return typeof (val) === "number";
}
//Check if the value is a FieldQuery type
function isFieldQuery(val) {
    return val.eq !== undefined ||
        val.lt !== undefined ||
        val.lte !== undefined ||
        val.gt !== undefined ||
        val.gte !== undefined ||
        val.startsWith !== undefined ||
        val.endsWith !== undefined ||
        val.contains !== undefined;
}
function writeSingleValue(arr, parameters, val, operation) {
    if (val !== undefined) {
        if (isString(val)) {
            const parameterName = parameters.getParameterName(val);
            arr.push(operation(`@${parameterName}`));
        }
        if (isNumber(val)) {
            arr.push(operation(`${val}`));
        }
    }
}
function writeFilter(filter) {
    const parameters = new parameterBuilder_1.ParameterBuilder();
    const result = writeFilterWithParameterBuilder(parameters, filter);
    return new FilterResult(result, parameters.getParameters());
}
exports.writeFilter = writeFilter;
function writeFilterWithParameterBuilder(parameterBuilder, filter) {
    const operations = [];
    let andOperation = null;
    let orOperation = null;
    for (let [key, value] of Object.entries(filter)) {
        if (isFieldQuery(value)) {
            operations.push(writeFilterField(key, value, parameterBuilder));
        }
        if (key === "and") {
            andOperation = writeFilterWithParameterBuilder(parameterBuilder, value);
        }
        if (key === "or") {
            orOperation = writeFilterWithParameterBuilder(parameterBuilder, value);
        }
    }
    let query = `(${operations.join(" AND ")})`;
    if (andOperation != null) {
        query += ` AND ${andOperation}`;
    }
    if (orOperation != null) {
        query += ` OR ${orOperation}`;
    }
    return query;
}
exports.writeFilterWithParameterBuilder = writeFilterWithParameterBuilder;
function writeFilterField(fieldName, field, parameters) {
    const basicOperations = [];
    writeSingleValue(basicOperations, parameters, field.eq, c => `${fieldName} = ${c}`);
    writeSingleValue(basicOperations, parameters, field.gt, c => `${fieldName} > ${c}`);
    writeSingleValue(basicOperations, parameters, field.gte, c => `${fieldName} >= ${c}`);
    writeSingleValue(basicOperations, parameters, field.lt, c => `${fieldName} < ${c}`);
    writeSingleValue(basicOperations, parameters, field.lte, c => `${fieldName} <= ${c}`);
    //string specific
    writeSingleValue(basicOperations, parameters, field.contains, c => `${fieldName} LIKE '%' + ${c} + '%'`);
    writeSingleValue(basicOperations, parameters, field.endsWith, c => `${fieldName} LIKE '%' + ${c}`);
    writeSingleValue(basicOperations, parameters, field.startsWith, c => `${fieldName} LIKE ${c} + '%'`);
    let basicQuery = basicOperations.join(" AND ");
    return basicQuery;
}
class FilterResult {
    constructor(filter, parameters) {
        this.filter = filter;
        this.parameters = parameters;
    }
}
exports.FilterResult = FilterResult;
class FieldQuery {
}
exports.FieldQuery = FieldQuery;
//# sourceMappingURL=filterBuilder.js.map