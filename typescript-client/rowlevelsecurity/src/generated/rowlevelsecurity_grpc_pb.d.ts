// GENERATED CODE -- DO NOT EDIT!

// package: 
// file: rowlevelsecurity.proto

import * as rowlevelsecurity_pb from "./rowlevelsecurity_pb";
import * as grpc from "grpc";

interface IKoraliumRowLevelSecurityService extends grpc.ServiceDefinition<grpc.UntypedServiceImplementation> {
  getRowLevelSecurityFilter: grpc.MethodDefinition<rowlevelsecurity_pb.RowLevelSecurityRequest, rowlevelsecurity_pb.RowLevelSecurityResponse>;
}

export const KoraliumRowLevelSecurityService: IKoraliumRowLevelSecurityService;

export class KoraliumRowLevelSecurityClient extends grpc.Client {
  constructor(address: string, credentials: grpc.ChannelCredentials, options?: object);
  getRowLevelSecurityFilter(argument: rowlevelsecurity_pb.RowLevelSecurityRequest, callback: grpc.requestCallback<rowlevelsecurity_pb.RowLevelSecurityResponse>): grpc.ClientUnaryCall;
  getRowLevelSecurityFilter(argument: rowlevelsecurity_pb.RowLevelSecurityRequest, metadataOrOptions: grpc.Metadata | grpc.CallOptions | null, callback: grpc.requestCallback<rowlevelsecurity_pb.RowLevelSecurityResponse>): grpc.ClientUnaryCall;
  getRowLevelSecurityFilter(argument: rowlevelsecurity_pb.RowLevelSecurityRequest, metadata: grpc.Metadata | null, options: grpc.CallOptions | null, callback: grpc.requestCallback<rowlevelsecurity_pb.RowLevelSecurityResponse>): grpc.ClientUnaryCall;
}
