// GENERATED CODE -- DO NOT EDIT!

'use strict';
var grpc = require('grpc');
var koralium_pb = require('./koralium_pb.js');
var google_protobuf_timestamp_pb = require('google-protobuf/google/protobuf/timestamp_pb.js');
var google_protobuf_empty_pb = require('google-protobuf/google/protobuf/empty_pb.js');

function serialize_IndexRequest(arg) {
  if (!(arg instanceof koralium_pb.IndexRequest)) {
    throw new Error('Expected argument of type IndexRequest');
  }
  return Buffer.from(arg.serializeBinary());
}

function deserialize_IndexRequest(buffer_arg) {
  return koralium_pb.IndexRequest.deserializeBinary(new Uint8Array(buffer_arg));
}

function serialize_Page(arg) {
  if (!(arg instanceof koralium_pb.Page)) {
    throw new Error('Expected argument of type Page');
  }
  return Buffer.from(arg.serializeBinary());
}

function deserialize_Page(buffer_arg) {
  return koralium_pb.Page.deserializeBinary(new Uint8Array(buffer_arg));
}

function serialize_QueryRequest(arg) {
  if (!(arg instanceof koralium_pb.QueryRequest)) {
    throw new Error('Expected argument of type QueryRequest');
  }
  return Buffer.from(arg.serializeBinary());
}

function deserialize_QueryRequest(buffer_arg) {
  return koralium_pb.QueryRequest.deserializeBinary(new Uint8Array(buffer_arg));
}

function serialize_Scalar(arg) {
  if (!(arg instanceof koralium_pb.Scalar)) {
    throw new Error('Expected argument of type Scalar');
  }
  return Buffer.from(arg.serializeBinary());
}

function deserialize_Scalar(buffer_arg) {
  return koralium_pb.Scalar.deserializeBinary(new Uint8Array(buffer_arg));
}

function serialize_TableMetadataResponse(arg) {
  if (!(arg instanceof koralium_pb.TableMetadataResponse)) {
    throw new Error('Expected argument of type TableMetadataResponse');
  }
  return Buffer.from(arg.serializeBinary());
}

function deserialize_TableMetadataResponse(buffer_arg) {
  return koralium_pb.TableMetadataResponse.deserializeBinary(new Uint8Array(buffer_arg));
}

function serialize_google_protobuf_Empty(arg) {
  if (!(arg instanceof google_protobuf_empty_pb.Empty)) {
    throw new Error('Expected argument of type google.protobuf.Empty');
  }
  return Buffer.from(arg.serializeBinary());
}

function deserialize_google_protobuf_Empty(buffer_arg) {
  return google_protobuf_empty_pb.Empty.deserializeBinary(new Uint8Array(buffer_arg));
}


var KoraliumServiceService = exports.KoraliumServiceService = {
  query: {
    path: '/KoraliumService/Query',
    requestStream: false,
    responseStream: true,
    requestType: koralium_pb.QueryRequest,
    responseType: koralium_pb.Page,
    requestSerialize: serialize_QueryRequest,
    requestDeserialize: deserialize_QueryRequest,
    responseSerialize: serialize_Page,
    responseDeserialize: deserialize_Page,
  },
  queryScalar: {
    path: '/KoraliumService/QueryScalar',
    requestStream: false,
    responseStream: false,
    requestType: koralium_pb.QueryRequest,
    responseType: koralium_pb.Scalar,
    requestSerialize: serialize_QueryRequest,
    requestDeserialize: deserialize_QueryRequest,
    responseSerialize: serialize_Scalar,
    responseDeserialize: deserialize_Scalar,
  },
  getTables: {
    path: '/KoraliumService/GetTables',
    requestStream: false,
    responseStream: false,
    requestType: google_protobuf_empty_pb.Empty,
    responseType: koralium_pb.TableMetadataResponse,
    requestSerialize: serialize_google_protobuf_Empty,
    requestDeserialize: deserialize_google_protobuf_Empty,
    responseSerialize: serialize_TableMetadataResponse,
    responseDeserialize: deserialize_TableMetadataResponse,
  },
  getIndex: {
    path: '/KoraliumService/GetIndex',
    requestStream: false,
    responseStream: true,
    requestType: koralium_pb.IndexRequest,
    responseType: koralium_pb.Page,
    requestSerialize: serialize_IndexRequest,
    requestDeserialize: deserialize_IndexRequest,
    responseSerialize: serialize_Page,
    responseDeserialize: deserialize_Page,
  },
};

exports.KoraliumServiceClient = grpc.makeGenericClientConstructor(KoraliumServiceService);
