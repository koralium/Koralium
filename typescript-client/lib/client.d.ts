import { KoraliumServiceClient } from "./generated/koralium_grpc_pb";
export declare class KoraliumClient {
    client: KoraliumServiceClient;
    constructor(url: string);
    private createDecoders;
    private createBaseObject;
    queryScalar(sql: string, parameters?: {} | null, headers?: {}): Promise<any>;
    query(sql: string, parameters?: {} | null, headers?: {}): Promise<{}[]>;
}
