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
import { writeFilter, writeFilterWithParameterBuilder } from "./filterBuilder";
import { ParameterBuilder } from "./parameterBuilder";
import { ObjectToSelectMapper } from "./objectToSelectMapper";

export class QueryBuilder {

  private table: string = "";
  private selects: Array<string> = [];

  private limit?: number | null = null;
  private offset?: number | null = null;

  private filters: Array<string> = [];
  private parameterBuilder: ParameterBuilder = new ParameterBuilder();

  private orderBy?: string | null = null;

  private mapper?: ObjectToSelectMapper;

  constructor(table: string, mapper?: ObjectToSelectMapper) {
    this.table = table;
    this.mapper = mapper;
  }

  addSelectElement(expression: string): QueryBuilder {
    if(!this.selects.includes(expression)) {
      this.selects.push(expression);
    }
    return this;
  }

  addSelectsWithMapper(value: {}): QueryBuilder {
    if(this.mapper === undefined) {
      throw new Error("No mapper was entered in the constructor");
    }
    this.mapper.addSelectsToQuery(this, value);
    return this;
  }

  setLimit(limit: number): QueryBuilder {
    this.limit = limit;
    return this;
  }

  setOffset(offset: number): QueryBuilder {
    this.offset = offset;
    return this;
  }

  addFilter(filter: string | {}): QueryBuilder {
    if(typeof filter === "string") {
      this.filters.push( filter);
    }
    else {
      const result = writeFilterWithParameterBuilder(this.parameterBuilder, filter);
      this.filters.push(result);
    }

    return this;
  }

  getParameters(): {} {
    return this.parameterBuilder.getParameters();
  }

  buildQuery(): string {
    var selectElements = this.selects.join(", ");

    let sql = `SELECT ${selectElements} FROM ${this.table}`;

    if(this.filters.length > 0) {
      sql += ` WHERE ${this.filters.join(" AND ")}`;
    }

    if(this.orderBy != null) {
      sql += ` ORDER BY ${this.orderBy}`
    }

    if(this.limit != null) {
      sql += ` LIMIT ${this.limit}`;
    }

    if(this.offset != null) {
      sql += ` OFFSET ${this.offset}`;
    }

    return sql;
  }

}