
export class Metadata {
  customMetadata: {};

  constructor(customMetadata: {}) {
    this.customMetadata = customMetadata;
  }
}

export class QueryResult {
  rows: Array<{}>;
  metadata: Metadata;

  constructor(rows: Array<{}>, metadata: Metadata) {
    this.rows = rows;
    this.metadata = metadata;
  }
}