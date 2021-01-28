export interface QueryFilter {
  member: string;
  operator: 'equals' | 'notEquals' | 'contains' | 'notContains' | 'gt' | 'gte' | 'lt' | 'lte' | 'set' | 'notSet' | 'inDateRange' | 'notInDateRange' | 'beforeDate' | 'afterDate';
  values?: string[];
}

export interface BinaryFilter {
  or?: Array<QueryFilter | BinaryFilter>
  and?: Array<QueryFilter | BinaryFilter>
} 

export declare type QueryTimeDimensionGranularity = 'hour' | 'day' | 'week' | 'month' | 'year';
interface QueryTimeDimension {
  dimension: string;
  dateRange?: string[] | string;
  granularity?: QueryTimeDimensionGranularity;
}
export interface Query {
  measures: string[];
  dimensions?: string[];
  filters?: (QueryFilter | BinaryFilter)[];
  timeDimensions?: QueryTimeDimension[];
  segments?: string[];
  limit?: number;
  offset?: number;
  order?: 'asc' | 'desc';
  timezone?: string;
  renewQuery?: boolean;
  ungrouped?: boolean;
}