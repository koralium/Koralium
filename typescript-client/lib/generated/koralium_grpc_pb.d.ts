/// <reference types="grpc" />
export namespace KoraliumServiceService {
    export namespace query {
        export const path: string;
        export const requestStream: boolean;
        export const responseStream: boolean;
        export const requestType: typeof import("./koralium_pb.js").QueryRequest;
        export const responseType: typeof import("./koralium_pb.js").Page;
        export { serialize_QueryRequest as requestSerialize };
        export { deserialize_QueryRequest as requestDeserialize };
        export { serialize_Page as responseSerialize };
        export { deserialize_Page as responseDeserialize };
    }
    export namespace queryScalar {
        const path_1: string;
        export { path_1 as path };
        const requestStream_1: boolean;
        export { requestStream_1 as requestStream };
        const responseStream_1: boolean;
        export { responseStream_1 as responseStream };
        const requestType_1: typeof import("./koralium_pb.js").QueryRequest;
        export { requestType_1 as requestType };
        const responseType_1: typeof import("./koralium_pb.js").Scalar;
        export { responseType_1 as responseType };
        export { serialize_QueryRequest as requestSerialize };
        export { deserialize_QueryRequest as requestDeserialize };
        export { serialize_Scalar as responseSerialize };
        export { deserialize_Scalar as responseDeserialize };
    }
    export namespace getTables {
        const path_2: string;
        export { path_2 as path };
        const requestStream_2: boolean;
        export { requestStream_2 as requestStream };
        const responseStream_2: boolean;
        export { responseStream_2 as responseStream };
        const requestType_2: typeof import("google-protobuf/google/protobuf/empty_pb").Empty;
        export { requestType_2 as requestType };
        const responseType_2: typeof import("./koralium_pb.js").TableMetadataResponse;
        export { responseType_2 as responseType };
        export { serialize_google_protobuf_Empty as requestSerialize };
        export { deserialize_google_protobuf_Empty as requestDeserialize };
        export { serialize_TableMetadataResponse as responseSerialize };
        export { deserialize_TableMetadataResponse as responseDeserialize };
    }
    export namespace getIndex {
        const path_3: string;
        export { path_3 as path };
        const requestStream_3: boolean;
        export { requestStream_3 as requestStream };
        const responseStream_3: boolean;
        export { responseStream_3 as responseStream };
        const requestType_3: typeof import("./koralium_pb.js").IndexRequest;
        export { requestType_3 as requestType };
        const responseType_3: typeof import("./koralium_pb.js").Page;
        export { responseType_3 as responseType };
        export { serialize_IndexRequest as requestSerialize };
        export { deserialize_IndexRequest as requestDeserialize };
        export { serialize_Page as responseSerialize };
        export { deserialize_Page as responseDeserialize };
    }
}
export var KoraliumServiceClient: typeof import("grpc").Client;
declare function serialize_QueryRequest(arg: any): Buffer;
declare function deserialize_QueryRequest(buffer_arg: any): import("./koralium_pb.js").QueryRequest;
declare function serialize_Page(arg: any): Buffer;
declare function deserialize_Page(buffer_arg: any): import("./koralium_pb.js").Page;
declare function serialize_Scalar(arg: any): Buffer;
declare function deserialize_Scalar(buffer_arg: any): import("./koralium_pb.js").Scalar;
declare function serialize_google_protobuf_Empty(arg: any): Buffer;
declare function deserialize_google_protobuf_Empty(buffer_arg: any): import("google-protobuf/google/protobuf/empty_pb").Empty;
declare function serialize_TableMetadataResponse(arg: any): Buffer;
declare function deserialize_TableMetadataResponse(buffer_arg: any): import("./koralium_pb.js").TableMetadataResponse;
declare function serialize_IndexRequest(arg: any): Buffer;
declare function deserialize_IndexRequest(buffer_arg: any): import("./koralium_pb.js").IndexRequest;
export {};
