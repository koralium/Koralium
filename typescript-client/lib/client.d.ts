import { KoraliumServiceClient } from "./generated/koralium_grpc_pb";
export default class KoraliumClient {
    client: KoraliumServiceClient;
    constructor(url: string);
    private createDecoders;
    private createBaseObject;
    queryScalar(sql: string, parameters?: {}, headers?: {}): Promise<any>;
    query(sql: string, parameters?: {}, headers?: {}): Promise<{}[]>;
}
