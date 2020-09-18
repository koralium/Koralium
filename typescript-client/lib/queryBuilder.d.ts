import { ObjectToSelectMapper } from "./objectToSelectMapper";
export declare class QueryBuilder {
    private table;
    private selects;
    private limit?;
    private offset?;
    private filters;
    private parameterBuilder;
    private orderBy?;
    private mapper?;
    constructor(table: string, mapper?: ObjectToSelectMapper);
    addSelectElement(expression: string): QueryBuilder;
    addSelectsWithMapper(value: {}): QueryBuilder;
    setLimit(limit: number): QueryBuilder;
    setOffset(offset: number): QueryBuilder;
    addFilter(filter: string | {}): QueryBuilder;
    getParameters(): {};
    buildQuery(): string;
}
