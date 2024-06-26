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
import { ParameterBuilder } from "./parameterBuilder";


function isString(val: any): val is string {
  return typeof (val) === "string";
}

function isNumber(val: any): val is number {
  return typeof (val) === "number";
}

function isBoolean(val: any): val is boolean {
  return typeof (val) === 'boolean';
}

//Check if the value is a FieldQuery type
function isFieldQuery(val: any): val is FieldQuery {
  return val.eq !== undefined ||
      val.lt !== undefined ||
      val.lte !== undefined ||
      val.gt !== undefined ||
      val.gte !== undefined ||
      val.startsWith !== undefined ||
      val.endsWith !== undefined ||
      val.contains !== undefined ||
      val.in !== undefined;
}


function writeSingleValue(arr: Array<string>, parameters: ParameterBuilder, val: string | number | boolean | undefined, operation: (string: string) => string): void {
  if (val !== undefined) {
      if (isString(val)) {
          const parameterName = parameters.getParameterName(val);
          arr.push(operation(`@${parameterName}`));
      }
      if (isNumber(val)) {
          arr.push(operation(`${val}`));
      }
      if (isBoolean(val)) {
          arr.push(operation(`${val}`));
      }
  }
}

function writeArrayValue(arr: Array<string>, parameters: ParameterBuilder, val: Array<string | number | boolean> | undefined, operation: (values: Array<string>) => string) {
  if (!!val && val.length > 0) {
    const arrayvalues: Array<string> = [];
    for(let v of val) {
      if (isString(v)) {
        const parameterName = parameters.getParameterName(v);
        arrayvalues.push(`@${parameterName}`);
      }
      if (isNumber(v) || isBoolean(v)) {
          arrayvalues.push(`${v}`);
      }
    }
    arr.push(operation(arrayvalues));
  }
}

export function writeFilter(filter: {} | FieldQuery): FilterResult {

  const parameters = new ParameterBuilder();
  
  const result = writeFilterWithParameterBuilder(parameters, filter);

  return new FilterResult(result, parameters.getParameters());
}

function writeSearchFilter(parameters: ParameterBuilder, value: SearchFilter): string {
  
  if (value.queryString !== undefined) {

    let output = "CONTAINS(";

    if (value.fields !== undefined) {
      output += `(${value.fields.join(', ')})`;
    }
    else{
      output += "*";
    }
    output += ", ";
    output += `@${parameters.getParameterName(value.queryString)}`;
    output += ")";
    
    return output;
  }

  return "";
}

export function writeFilterWithParameterBuilder(parameterBuilder: ParameterBuilder, filter: {} | FieldQuery): string {
  let operations: Array<string> = [];
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
      if(key === "search") {
        operations.push(writeSearchFilter(parameterBuilder, value));
      }
  }
  let query = "";

  operations = operations.filter(x => x !== "");
  
  if(operations.length > 0) {
    query = `(${operations.join(" AND ")})`;
  }

  if (andOperation != null) {
    if(query !== "") {
      query += " AND ";
    }
    query += andOperation;
  }
  if (orOperation != null) {
    if(query !== "") {
      query += " OR ";
    }
    query += orOperation;
  }

  return query;
}

function writeFilterField(fieldName: string, field: FieldQuery, parameters: ParameterBuilder): string {

  const basicOperations: Array<string> = [];

  writeSingleValue(basicOperations, parameters, field.eq, c => `${fieldName} = ${c}`);
  writeSingleValue(basicOperations, parameters, field.gt, c => `${fieldName} > ${c}`);
  writeSingleValue(basicOperations, parameters, field.gte, c => `${fieldName} >= ${c}`);
  writeSingleValue(basicOperations, parameters, field.lt, c => `${fieldName} < ${c}`);
  writeSingleValue(basicOperations, parameters, field.lte, c => `${fieldName} <= ${c}`);

  writeArrayValue(basicOperations, parameters, field.in, c => `${fieldName} IN (${c.join(', ')})`);

  //string specific
  writeSingleValue(basicOperations, parameters, field.contains, c => `${fieldName} LIKE '%' + ${c} + '%'`);
  writeSingleValue(basicOperations, parameters, field.endsWith, c => `${fieldName} LIKE '%' + ${c}`);
  writeSingleValue(basicOperations, parameters, field.startsWith, c => `${fieldName} LIKE ${c} + '%'`);
  
  let basicQuery = basicOperations.join(" AND ");

  return basicQuery;
}

export class FilterResult {
  filter: string;
  parameters: {};

  constructor(filter: string, parameters: {}) {
    this.filter = filter;
    this.parameters = parameters;
  }
}

export class FieldQuery {
  eq: string | number | boolean | undefined;

  lt: string | number | undefined;
  lte: string | number | undefined;
  gt: string | number | undefined;
  gte: string | number | undefined;

  in: Array<string | number | boolean> | undefined;

  //String specific
  startsWith: string | number | undefined;
  endsWith: string | number | undefined;
  contains: string | number | undefined;
}

export class SearchFilter {
  queryString: string | undefined;
  fields: Array<string> | undefined;
}