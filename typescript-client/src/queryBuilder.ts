export class QueryBuilder {

  table: string = "";
  selects: Array<string> = [];

  limit?: number = null;
  offset?: number = null;

  filter?: string = null;

  constructor(table: string) {
    this.table = table;
  }

  addSelectElement(expression: string): QueryBuilder {
    if(!this.selects.includes(expression)) {
      this.selects.push(expression);
    }
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

  setFilter(filter: string): QueryBuilder {
    this.filter = filter;
    return this;
  }

  build(): string {
    var selectElements = this.selects.join(", ");

    let sql = `SELECT ${selectElements} FROM ${this.table}`;

    if(this.filter != null) {
      sql += ` WHERE ${this.filter}`;
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