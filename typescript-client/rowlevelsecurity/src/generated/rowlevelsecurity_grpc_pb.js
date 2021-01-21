// GENERATED CODE -- DO NOT EDIT!

'use strict';
var grpc = require('grpc');
var rowlevelsecurity_pb = require('./rowlevelsecurity_pb.js');

function serialize_RowLevelSecurityRequest(arg) {
  if (!(arg instanceof rowlevelsecurity_pb.RowLevelSecurityRequest)) {
    throw new Error('Expected argument of type RowLevelSecurityRequest');
  }
  return Buffer.from(arg.serializeBinary());
}

function deserialize_RowLevelSecurityRequest(buffer_arg) {
  return rowlevelsecurity_pb.RowLevelSecurityRequest.deserializeBinary(new Uint8Array(buffer_arg));
}

function serialize_RowLevelSecurityResponse(arg) {
  if (!(arg instanceof rowlevelsecurity_pb.RowLevelSecurityResponse)) {
    throw new Error('Expected argument of type RowLevelSecurityResponse');
  }
  return Buffer.from(arg.serializeBinary());
}

function deserialize_RowLevelSecurityResponse(buffer_arg) {
  return rowlevelsecurity_pb.RowLevelSecurityResponse.deserializeBinary(new Uint8Array(buffer_arg));
}


var KoraliumRowLevelSecurityService = exports.KoraliumRowLevelSecurityService = {
  getRowLevelSecurityFilter: {
    path: '/KoraliumRowLevelSecurity/GetRowLevelSecurityFilter',
    requestStream: false,
    responseStream: false,
    requestType: rowlevelsecurity_pb.RowLevelSecurityRequest,
    responseType: rowlevelsecurity_pb.RowLevelSecurityResponse,
    requestSerialize: serialize_RowLevelSecurityRequest,
    requestDeserialize: deserialize_RowLevelSecurityRequest,
    responseSerialize: serialize_RowLevelSecurityResponse,
    responseDeserialize: deserialize_RowLevelSecurityResponse,
  },
};

exports.KoraliumRowLevelSecurityClient = grpc.makeGenericClientConstructor(KoraliumRowLevelSecurityService);
