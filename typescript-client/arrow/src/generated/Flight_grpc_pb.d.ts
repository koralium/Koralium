// GENERATED CODE -- DO NOT EDIT!

// package: arrow.flight.protocol
// file: Flight.proto

import * as Flight_pb from "./Flight_pb";
import * as grpc from "grpc";

interface IFlightServiceService extends grpc.ServiceDefinition<grpc.UntypedServiceImplementation> {
  handshake: grpc.MethodDefinition<Flight_pb.HandshakeRequest, Flight_pb.HandshakeResponse>;
  listFlights: grpc.MethodDefinition<Flight_pb.Criteria, Flight_pb.FlightInfo>;
  getFlightInfo: grpc.MethodDefinition<Flight_pb.FlightDescriptor, Flight_pb.FlightInfo>;
  getSchema: grpc.MethodDefinition<Flight_pb.FlightDescriptor, Flight_pb.SchemaResult>;
  doGet: grpc.MethodDefinition<Flight_pb.Ticket, Flight_pb.FlightData>;
  doPut: grpc.MethodDefinition<Flight_pb.FlightData, Flight_pb.PutResult>;
  doExchange: grpc.MethodDefinition<Flight_pb.FlightData, Flight_pb.FlightData>;
  doAction: grpc.MethodDefinition<Flight_pb.Action, Flight_pb.Result>;
  listActions: grpc.MethodDefinition<Flight_pb.Empty, Flight_pb.ActionType>;
}

export const FlightServiceService: IFlightServiceService;

export interface IFlightServiceServer extends grpc.UntypedServiceImplementation {
  handshake: grpc.handleBidiStreamingCall<Flight_pb.HandshakeRequest, Flight_pb.HandshakeResponse>;
  listFlights: grpc.handleServerStreamingCall<Flight_pb.Criteria, Flight_pb.FlightInfo>;
  getFlightInfo: grpc.handleUnaryCall<Flight_pb.FlightDescriptor, Flight_pb.FlightInfo>;
  getSchema: grpc.handleUnaryCall<Flight_pb.FlightDescriptor, Flight_pb.SchemaResult>;
  doGet: grpc.handleServerStreamingCall<Flight_pb.Ticket, Flight_pb.FlightData>;
  doPut: grpc.handleBidiStreamingCall<Flight_pb.FlightData, Flight_pb.PutResult>;
  doExchange: grpc.handleBidiStreamingCall<Flight_pb.FlightData, Flight_pb.FlightData>;
  doAction: grpc.handleServerStreamingCall<Flight_pb.Action, Flight_pb.Result>;
  listActions: grpc.handleServerStreamingCall<Flight_pb.Empty, Flight_pb.ActionType>;
}

export class FlightServiceClient extends grpc.Client {
  constructor(address: string, credentials: grpc.ChannelCredentials, options?: object);
  handshake(metadataOrOptions?: grpc.Metadata | grpc.CallOptions | null): grpc.ClientDuplexStream<Flight_pb.HandshakeRequest, Flight_pb.HandshakeResponse>;
  handshake(metadata?: grpc.Metadata | null, options?: grpc.CallOptions | null): grpc.ClientDuplexStream<Flight_pb.HandshakeRequest, Flight_pb.HandshakeResponse>;
  listFlights(argument: Flight_pb.Criteria, metadataOrOptions?: grpc.Metadata | grpc.CallOptions | null): grpc.ClientReadableStream<Flight_pb.FlightInfo>;
  listFlights(argument: Flight_pb.Criteria, metadata?: grpc.Metadata | null, options?: grpc.CallOptions | null): grpc.ClientReadableStream<Flight_pb.FlightInfo>;
  getFlightInfo(argument: Flight_pb.FlightDescriptor, callback: grpc.requestCallback<Flight_pb.FlightInfo>): grpc.ClientUnaryCall;
  getFlightInfo(argument: Flight_pb.FlightDescriptor, metadataOrOptions: grpc.Metadata | grpc.CallOptions | null, callback: grpc.requestCallback<Flight_pb.FlightInfo>): grpc.ClientUnaryCall;
  getFlightInfo(argument: Flight_pb.FlightDescriptor, metadata: grpc.Metadata | null, options: grpc.CallOptions | null, callback: grpc.requestCallback<Flight_pb.FlightInfo>): grpc.ClientUnaryCall;
  getSchema(argument: Flight_pb.FlightDescriptor, callback: grpc.requestCallback<Flight_pb.SchemaResult>): grpc.ClientUnaryCall;
  getSchema(argument: Flight_pb.FlightDescriptor, metadataOrOptions: grpc.Metadata | grpc.CallOptions | null, callback: grpc.requestCallback<Flight_pb.SchemaResult>): grpc.ClientUnaryCall;
  getSchema(argument: Flight_pb.FlightDescriptor, metadata: grpc.Metadata | null, options: grpc.CallOptions | null, callback: grpc.requestCallback<Flight_pb.SchemaResult>): grpc.ClientUnaryCall;
  doGet(argument: Flight_pb.Ticket, metadataOrOptions?: grpc.Metadata | grpc.CallOptions | null): grpc.ClientReadableStream<Flight_pb.FlightData>;
  doGet(argument: Flight_pb.Ticket, metadata?: grpc.Metadata | null, options?: grpc.CallOptions | null): grpc.ClientReadableStream<Flight_pb.FlightData>;
  doPut(metadataOrOptions?: grpc.Metadata | grpc.CallOptions | null): grpc.ClientDuplexStream<Flight_pb.FlightData, Flight_pb.PutResult>;
  doPut(metadata?: grpc.Metadata | null, options?: grpc.CallOptions | null): grpc.ClientDuplexStream<Flight_pb.FlightData, Flight_pb.PutResult>;
  doExchange(metadataOrOptions?: grpc.Metadata | grpc.CallOptions | null): grpc.ClientDuplexStream<Flight_pb.FlightData, Flight_pb.FlightData>;
  doExchange(metadata?: grpc.Metadata | null, options?: grpc.CallOptions | null): grpc.ClientDuplexStream<Flight_pb.FlightData, Flight_pb.FlightData>;
  doAction(argument: Flight_pb.Action, metadataOrOptions?: grpc.Metadata | grpc.CallOptions | null): grpc.ClientReadableStream<Flight_pb.Result>;
  doAction(argument: Flight_pb.Action, metadata?: grpc.Metadata | null, options?: grpc.CallOptions | null): grpc.ClientReadableStream<Flight_pb.Result>;
  listActions(argument: Flight_pb.Empty, metadataOrOptions?: grpc.Metadata | grpc.CallOptions | null): grpc.ClientReadableStream<Flight_pb.ActionType>;
  listActions(argument: Flight_pb.Empty, metadata?: grpc.Metadata | null, options?: grpc.CallOptions | null): grpc.ClientReadableStream<Flight_pb.ActionType>;
}
