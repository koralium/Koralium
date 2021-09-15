// GENERATED CODE -- DO NOT EDIT!

// Original file comments:
//
// Licensed to the Apache Software Foundation (ASF) under one
// or more contributor license agreements.  See the NOTICE file
// distributed with this work for additional information
// regarding copyright ownership.  The ASF licenses this file
// to you under the Apache License, Version 2.0 (the
// "License"); you may not use this file except in compliance
// with the License.  You may obtain a copy of the License at
// <p>
// http://www.apache.org/licenses/LICENSE-2.0
// <p>
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//
'use strict';
var grpc = require('grpc');
var Flight_pb = require('./Flight_pb.js');

function serialize_arrow_flight_protocol_Action(arg) {
  if (!(arg instanceof Flight_pb.Action)) {
    throw new Error('Expected argument of type arrow.flight.protocol.Action');
  }
  return Buffer.from(arg.serializeBinary());
}

function deserialize_arrow_flight_protocol_Action(buffer_arg) {
  return Flight_pb.Action.deserializeBinary(new Uint8Array(buffer_arg));
}

function serialize_arrow_flight_protocol_ActionType(arg) {
  if (!(arg instanceof Flight_pb.ActionType)) {
    throw new Error('Expected argument of type arrow.flight.protocol.ActionType');
  }
  return Buffer.from(arg.serializeBinary());
}

function deserialize_arrow_flight_protocol_ActionType(buffer_arg) {
  return Flight_pb.ActionType.deserializeBinary(new Uint8Array(buffer_arg));
}

function serialize_arrow_flight_protocol_Criteria(arg) {
  if (!(arg instanceof Flight_pb.Criteria)) {
    throw new Error('Expected argument of type arrow.flight.protocol.Criteria');
  }
  return Buffer.from(arg.serializeBinary());
}

function deserialize_arrow_flight_protocol_Criteria(buffer_arg) {
  return Flight_pb.Criteria.deserializeBinary(new Uint8Array(buffer_arg));
}

function serialize_arrow_flight_protocol_Empty(arg) {
  if (!(arg instanceof Flight_pb.Empty)) {
    throw new Error('Expected argument of type arrow.flight.protocol.Empty');
  }
  return Buffer.from(arg.serializeBinary());
}

function deserialize_arrow_flight_protocol_Empty(buffer_arg) {
  return Flight_pb.Empty.deserializeBinary(new Uint8Array(buffer_arg));
}

function serialize_arrow_flight_protocol_FlightData(arg) {
  if (!(arg instanceof Flight_pb.FlightData)) {
    throw new Error('Expected argument of type arrow.flight.protocol.FlightData');
  }
  return Buffer.from(arg.serializeBinary());
}

function deserialize_arrow_flight_protocol_FlightData(buffer_arg) {
  return Flight_pb.FlightData.deserializeBinary(new Uint8Array(buffer_arg));
}

function serialize_arrow_flight_protocol_FlightDescriptor(arg) {
  if (!(arg instanceof Flight_pb.FlightDescriptor)) {
    throw new Error('Expected argument of type arrow.flight.protocol.FlightDescriptor');
  }
  return Buffer.from(arg.serializeBinary());
}

function deserialize_arrow_flight_protocol_FlightDescriptor(buffer_arg) {
  return Flight_pb.FlightDescriptor.deserializeBinary(new Uint8Array(buffer_arg));
}

function serialize_arrow_flight_protocol_FlightInfo(arg) {
  if (!(arg instanceof Flight_pb.FlightInfo)) {
    throw new Error('Expected argument of type arrow.flight.protocol.FlightInfo');
  }
  return Buffer.from(arg.serializeBinary());
}

function deserialize_arrow_flight_protocol_FlightInfo(buffer_arg) {
  return Flight_pb.FlightInfo.deserializeBinary(new Uint8Array(buffer_arg));
}

function serialize_arrow_flight_protocol_HandshakeRequest(arg) {
  if (!(arg instanceof Flight_pb.HandshakeRequest)) {
    throw new Error('Expected argument of type arrow.flight.protocol.HandshakeRequest');
  }
  return Buffer.from(arg.serializeBinary());
}

function deserialize_arrow_flight_protocol_HandshakeRequest(buffer_arg) {
  return Flight_pb.HandshakeRequest.deserializeBinary(new Uint8Array(buffer_arg));
}

function serialize_arrow_flight_protocol_HandshakeResponse(arg) {
  if (!(arg instanceof Flight_pb.HandshakeResponse)) {
    throw new Error('Expected argument of type arrow.flight.protocol.HandshakeResponse');
  }
  return Buffer.from(arg.serializeBinary());
}

function deserialize_arrow_flight_protocol_HandshakeResponse(buffer_arg) {
  return Flight_pb.HandshakeResponse.deserializeBinary(new Uint8Array(buffer_arg));
}

function serialize_arrow_flight_protocol_PutResult(arg) {
  if (!(arg instanceof Flight_pb.PutResult)) {
    throw new Error('Expected argument of type arrow.flight.protocol.PutResult');
  }
  return Buffer.from(arg.serializeBinary());
}

function deserialize_arrow_flight_protocol_PutResult(buffer_arg) {
  return Flight_pb.PutResult.deserializeBinary(new Uint8Array(buffer_arg));
}

function serialize_arrow_flight_protocol_Result(arg) {
  if (!(arg instanceof Flight_pb.Result)) {
    throw new Error('Expected argument of type arrow.flight.protocol.Result');
  }
  return Buffer.from(arg.serializeBinary());
}

function deserialize_arrow_flight_protocol_Result(buffer_arg) {
  return Flight_pb.Result.deserializeBinary(new Uint8Array(buffer_arg));
}

function serialize_arrow_flight_protocol_SchemaResult(arg) {
  if (!(arg instanceof Flight_pb.SchemaResult)) {
    throw new Error('Expected argument of type arrow.flight.protocol.SchemaResult');
  }
  return Buffer.from(arg.serializeBinary());
}

function deserialize_arrow_flight_protocol_SchemaResult(buffer_arg) {
  return Flight_pb.SchemaResult.deserializeBinary(new Uint8Array(buffer_arg));
}

function serialize_arrow_flight_protocol_Ticket(arg) {
  if (!(arg instanceof Flight_pb.Ticket)) {
    throw new Error('Expected argument of type arrow.flight.protocol.Ticket');
  }
  return Buffer.from(arg.serializeBinary());
}

function deserialize_arrow_flight_protocol_Ticket(buffer_arg) {
  return Flight_pb.Ticket.deserializeBinary(new Uint8Array(buffer_arg));
}


//
// A flight service is an endpoint for retrieving or storing Arrow data. A
// flight service can expose one or more predefined endpoints that can be
// accessed using the Arrow Flight Protocol. Additionally, a flight service
// can expose a set of actions that are available.
var FlightServiceService = exports.FlightServiceService = {
  //
  // Handshake between client and server. Depending on the server, the
  // handshake may be required to determine the token that should be used for
  // future operations. Both request and response are streams to allow multiple
  // round-trips depending on auth mechanism.
  handshake: {
    path: '/arrow.flight.protocol.FlightService/Handshake',
    requestStream: true,
    responseStream: true,
    requestType: Flight_pb.HandshakeRequest,
    responseType: Flight_pb.HandshakeResponse,
    requestSerialize: serialize_arrow_flight_protocol_HandshakeRequest,
    requestDeserialize: deserialize_arrow_flight_protocol_HandshakeRequest,
    responseSerialize: serialize_arrow_flight_protocol_HandshakeResponse,
    responseDeserialize: deserialize_arrow_flight_protocol_HandshakeResponse,
  },
  //
  // Get a list of available streams given a particular criteria. Most flight
  // services will expose one or more streams that are readily available for
  // retrieval. This api allows listing the streams available for
  // consumption. A user can also provide a criteria. The criteria can limit
  // the subset of streams that can be listed via this interface. Each flight
  // service allows its own definition of how to consume criteria.
  listFlights: {
    path: '/arrow.flight.protocol.FlightService/ListFlights',
    requestStream: false,
    responseStream: true,
    requestType: Flight_pb.Criteria,
    responseType: Flight_pb.FlightInfo,
    requestSerialize: serialize_arrow_flight_protocol_Criteria,
    requestDeserialize: deserialize_arrow_flight_protocol_Criteria,
    responseSerialize: serialize_arrow_flight_protocol_FlightInfo,
    responseDeserialize: deserialize_arrow_flight_protocol_FlightInfo,
  },
  //
  // For a given FlightDescriptor, get information about how the flight can be
  // consumed. This is a useful interface if the consumer of the interface
  // already can identify the specific flight to consume. This interface can
  // also allow a consumer to generate a flight stream through a specified
  // descriptor. For example, a flight descriptor might be something that
  // includes a SQL statement or a Pickled Python operation that will be
  // executed. In those cases, the descriptor will not be previously available
  // within the list of available streams provided by ListFlights but will be
  // available for consumption for the duration defined by the specific flight
  // service.
  getFlightInfo: {
    path: '/arrow.flight.protocol.FlightService/GetFlightInfo',
    requestStream: false,
    responseStream: false,
    requestType: Flight_pb.FlightDescriptor,
    responseType: Flight_pb.FlightInfo,
    requestSerialize: serialize_arrow_flight_protocol_FlightDescriptor,
    requestDeserialize: deserialize_arrow_flight_protocol_FlightDescriptor,
    responseSerialize: serialize_arrow_flight_protocol_FlightInfo,
    responseDeserialize: deserialize_arrow_flight_protocol_FlightInfo,
  },
  //
  // For a given FlightDescriptor, get the Schema as described in Schema.fbs::Schema
  // This is used when a consumer needs the Schema of flight stream. Similar to
  // GetFlightInfo this interface may generate a new flight that was not previously
  // available in ListFlights.
  getSchema: {
    path: '/arrow.flight.protocol.FlightService/GetSchema',
    requestStream: false,
    responseStream: false,
    requestType: Flight_pb.FlightDescriptor,
    responseType: Flight_pb.SchemaResult,
    requestSerialize: serialize_arrow_flight_protocol_FlightDescriptor,
    requestDeserialize: deserialize_arrow_flight_protocol_FlightDescriptor,
    responseSerialize: serialize_arrow_flight_protocol_SchemaResult,
    responseDeserialize: deserialize_arrow_flight_protocol_SchemaResult,
  },
  //
  // Retrieve a single stream associated with a particular descriptor
  // associated with the referenced ticket. A Flight can be composed of one or
  // more streams where each stream can be retrieved using a separate opaque
  // ticket that the flight service uses for managing a collection of streams.
  doGet: {
    path: '/arrow.flight.protocol.FlightService/DoGet',
    requestStream: false,
    responseStream: true,
    requestType: Flight_pb.Ticket,
    responseType: Flight_pb.FlightData,
    requestSerialize: serialize_arrow_flight_protocol_Ticket,
    requestDeserialize: deserialize_arrow_flight_protocol_Ticket,
    responseSerialize: serialize_arrow_flight_protocol_FlightData,
    responseDeserialize: deserialize_arrow_flight_protocol_FlightData,
  },
  //
  // Push a stream to the flight service associated with a particular
  // flight stream. This allows a client of a flight service to upload a stream
  // of data. Depending on the particular flight service, a client consumer
  // could be allowed to upload a single stream per descriptor or an unlimited
  // number. In the latter, the service might implement a 'seal' action that
  // can be applied to a descriptor once all streams are uploaded.
  doPut: {
    path: '/arrow.flight.protocol.FlightService/DoPut',
    requestStream: true,
    responseStream: true,
    requestType: Flight_pb.FlightData,
    responseType: Flight_pb.PutResult,
    requestSerialize: serialize_arrow_flight_protocol_FlightData,
    requestDeserialize: deserialize_arrow_flight_protocol_FlightData,
    responseSerialize: serialize_arrow_flight_protocol_PutResult,
    responseDeserialize: deserialize_arrow_flight_protocol_PutResult,
  },
  //
  // Open a bidirectional data channel for a given descriptor. This
  // allows clients to send and receive arbitrary Arrow data and
  // application-specific metadata in a single logical stream. In
  // contrast to DoGet/DoPut, this is more suited for clients
  // offloading computation (rather than storage) to a Flight service.
  doExchange: {
    path: '/arrow.flight.protocol.FlightService/DoExchange',
    requestStream: true,
    responseStream: true,
    requestType: Flight_pb.FlightData,
    responseType: Flight_pb.FlightData,
    requestSerialize: serialize_arrow_flight_protocol_FlightData,
    requestDeserialize: deserialize_arrow_flight_protocol_FlightData,
    responseSerialize: serialize_arrow_flight_protocol_FlightData,
    responseDeserialize: deserialize_arrow_flight_protocol_FlightData,
  },
  //
  // Flight services can support an arbitrary number of simple actions in
  // addition to the possible ListFlights, GetFlightInfo, DoGet, DoPut
  // operations that are potentially available. DoAction allows a flight client
  // to do a specific action against a flight service. An action includes
  // opaque request and response objects that are specific to the type action
  // being undertaken.
  doAction: {
    path: '/arrow.flight.protocol.FlightService/DoAction',
    requestStream: false,
    responseStream: true,
    requestType: Flight_pb.Action,
    responseType: Flight_pb.Result,
    requestSerialize: serialize_arrow_flight_protocol_Action,
    requestDeserialize: deserialize_arrow_flight_protocol_Action,
    responseSerialize: serialize_arrow_flight_protocol_Result,
    responseDeserialize: deserialize_arrow_flight_protocol_Result,
  },
  //
  // A flight service exposes all of the available action types that it has
  // along with descriptions. This allows different flight consumers to
  // understand the capabilities of the flight service.
  listActions: {
    path: '/arrow.flight.protocol.FlightService/ListActions',
    requestStream: false,
    responseStream: true,
    requestType: Flight_pb.Empty,
    responseType: Flight_pb.ActionType,
    requestSerialize: serialize_arrow_flight_protocol_Empty,
    requestDeserialize: deserialize_arrow_flight_protocol_Empty,
    responseSerialize: serialize_arrow_flight_protocol_ActionType,
    responseDeserialize: deserialize_arrow_flight_protocol_ActionType,
  },
};

exports.FlightServiceClient = grpc.makeGenericClientConstructor(FlightServiceService);
