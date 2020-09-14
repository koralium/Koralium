import { QueryBuilder } from "./queryBuilder";
export declare class ObjectToSelectMapper {
    mappingTable: {
        [key: string]: string | Array<string>;
    };
    addMapping(key: string, select: string | Array<string>): ObjectToSelectMapper;
    private isArray;
    addSelectsToQuery(queryBuilder: QueryBuilder, inputObject: {}): void;
}
