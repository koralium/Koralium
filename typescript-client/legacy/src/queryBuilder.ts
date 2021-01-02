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

  private orderby?: string | null = null;

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

  addFilter(filter: string | {} | null | undefined): QueryBuilder {
    if(filter === undefined || filter === null) {
      return this;
    }
    if(typeof filter === "string") {
      this.filters.push( filter);
    }
    else {
      const result = writeFilterWithParameterBuilder(this.parameterBuilder, filter);
      this.filters.push(result);
    }

    return this;
  }

  addInFilter(columnName: string, array: Array<any>): QueryBuilder {

    if(array.length == 0) {
      return this;
    }
      
    const firstValue = array[0];
    if (typeof firstValue === "string") {
      const filter = `${columnName} IN (${array.map(x => `'${x}'`).join(", ")})`;
      this.addFilter(filter);
    }
    else if (typeof firstValue === "number") {
      const filter = `${columnName} IN (${array.join(", ")})`;
      this.addFilter(filter);
    }
    else {
      throw new Error("Only strings and numbers can be used in IN");
    }
    return this;
  }

  orderBy(columnName: string, descending: boolean) {
    if(descending) {
      this.orderby = `${columnName} desc`;
    }
    else {
      this.orderby = `${columnName}`;
    }
  }

  //This is used in graphQL and similar scenarios
  //Example: { asc: Name} or { desc: Name }
  orderByWithObject(obj: {[key: string]: string;} | undefined | null): QueryBuilder {

    if(obj === undefined || obj === null){
      return this;
    }

    if(obj.asc !== undefined) {
      this.orderby = `${obj.asc}`
    }
    else if (obj.desc !== undefined) {
      this.orderby = `${obj.desc} desc`
    }
    else {
      throw new Error("Could not find either asc or desc field");
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
      //Try and filter out any empty filters
      this.filters = this.filters.filter(x => x.trim() != "");
      //Check again if there still are filters
      if(this.filters.length > 0) {
        sql += ` WHERE ${this.filters.join(" AND ")}`;
      } 
    }

    if(this.orderby != null) {
      sql += ` ORDER BY ${this.orderby}`
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