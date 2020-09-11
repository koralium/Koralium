// GENERATED CODE -- DO NOT EDIT!

// package: 
// file: koralium.proto

import * as koralium_pb from "./koralium_pb";
import * as google_protobuf_empty_pb from "google-protobuf/google/protobuf/empty_pb";
import * as grpc from "grpc";

interface IKoraliumServiceService extends grpc.ServiceDefinition<grpc.UntypedServiceImplementation> {
  query: grpc.MethodDefinition<koralium_pb.QueryRequest, koralium_pb.Page>;
  queryScalar: grpc.MethodDefinition<koralium_pb.QueryRequest, koralium_pb.Scalar>;
  getTables: grpc.MethodDefinition<google_protobuf_empty_pb.Empty, koralium_pb.TableMetadataResponse>;
  getIndex: grpc.MethodDefinition<koralium_pb.IndexRequest, koralium_pb.Page>;
}

export const KoraliumServiceService: IKoraliumServiceService;

export class KoraliumServiceClient extends grpc.Client {
  constructor(address: string, credentials: grpc.ChannelCredentials, options?: object);
  query(argument: koralium_pb.QueryRequest, metadataOrOptions?: grpc.Metadata | grpc.CallOptions | null): grpc.ClientReadableStream<koralium_pb.Page>;
  query(argument: koralium_pb.QueryRequest, metadata?: grpc.Metadata | null, options?: grpc.CallOptions | null): grpc.ClientReadableStream<koralium_pb.Page>;
  queryScalar(argument: koralium_pb.QueryRequest, callback: grpc.requestCallback<koralium_pb.Scalar>): grpc.ClientUnaryCall;
  queryScalar(argument: koralium_pb.QueryRequest, metadataOrOptions: grpc.Metadata | grpc.CallOptions | null, callback: grpc.requestCallback<koralium_pb.Scalar>): grpc.ClientUnaryCall;
  queryScalar(argument: koralium_pb.QueryRequest, metadata: grpc.Metadata | null, options: grpc.CallOptions | null, callback: grpc.requestCallback<koralium_pb.Scalar>): grpc.ClientUnaryCall;
  getTables(argument: google_protobuf_empty_pb.Empty, callback: grpc.requestCallback<koralium_pb.TableMetadataResponse>): grpc.ClientUnaryCall;
  getTables(argument: google_protobuf_empty_pb.Empty, metadataOrOptions: grpc.Metadata | grpc.CallOptions | null, callback: grpc.requestCallback<koralium_pb.TableMetadataResponse>): grpc.ClientUnaryCall;
  getTables(argument: google_protobuf_empty_pb.Empty, metadata: grpc.Metadata | null, options: grpc.CallOptions | null, callback: grpc.requestCallback<koralium_pb.TableMetadataResponse>): grpc.ClientUnaryCall;
  getIndex(argument: koralium_pb.IndexRequest, metadataOrOptions?: grpc.Metadata | grpc.CallOptions | null): grpc.ClientReadableStream<koralium_pb.Page>;
  getIndex(argument: koralium_pb.IndexRequest, metadata?: grpc.Metadata | null, options?: grpc.CallOptions | null): grpc.ClientReadableStream<koralium_pb.Page>;
}
