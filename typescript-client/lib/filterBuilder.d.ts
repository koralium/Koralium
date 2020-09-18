import { ParameterBuilder } from "./parameterBuilder";
export declare function writeFilter(filter: {} | FieldQuery): FilterResult;
export declare function writeFilterWithParameterBuilder(parameterBuilder: ParameterBuilder, filter: {} | FieldQuery): string;
export declare class FilterResult {
    filter: string;
    parameters: {};
    constructor(filter: string, parameters: {});
}
export declare class FieldQuery {
    eq: string | number | undefined;
    lt: string | number | undefined;
    lte: string | number | undefined;
    gt: string | number | undefined;
    gte: string | number | undefined;
    startsWith: string | number | undefined;
    endsWith: string | number | undefined;
    contains: string | number | undefined;
}
