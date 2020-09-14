export declare class QueryBuilder {
    table: string;
    selects: Array<string>;
    limit?: number;
    offset?: number;
    filter?: string;
    constructor(table: string);
    addSelectElement(expression: string): QueryBuilder;
    setLimit(limit: number): QueryBuilder;
    setOffset(offset: number): QueryBuilder;
    setFilter(filter: string): QueryBuilder;
    build(): string;
}
