"use strict";
var __createBinding = (this && this.__createBinding) || (Object.create ? (function(o, m, k, k2) {
    if (k2 === undefined) k2 = k;
    Object.defineProperty(o, k2, { enumerable: true, get: function() { return m[k]; } });
}) : (function(o, m, k, k2) {
    if (k2 === undefined) k2 = k;
    o[k2] = m[k];
}));
var __setModuleDefault = (this && this.__setModuleDefault) || (Object.create ? (function(o, v) {
    Object.defineProperty(o, "default", { enumerable: true, value: v });
}) : function(o, v) {
    o["default"] = v;
});
var __importStar = (this && this.__importStar) || function (mod) {
    if (mod && mod.__esModule) return mod;
    var result = {};
    if (mod != null) for (var k in mod) if (k !== "default" && Object.hasOwnProperty.call(mod, k)) __createBinding(result, mod, k);
    __setModuleDefault(result, mod);
    return result;
};
var __awaiter = (this && this.__awaiter) || function (thisArg, _arguments, P, generator) {
    function adopt(value) { return value instanceof P ? value : new P(function (resolve) { resolve(value); }); }
    return new (P || (P = Promise))(function (resolve, reject) {
        function fulfilled(value) { try { step(generator.next(value)); } catch (e) { reject(e); } }
        function rejected(value) { try { step(generator["throw"](value)); } catch (e) { reject(e); } }
        function step(result) { result.done ? resolve(result.value) : adopt(result.value).then(fulfilled, rejected); }
        step((generator = generator.apply(thisArg, _arguments || [])).next());
    });
};
var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", { value: true });
exports.KoraliumClient = void 0;
const koralium_grpc_pb_1 = require("./generated/koralium_grpc_pb");
const grpc = __importStar(require("grpc"));
const koralium_pb_1 = require("./generated/koralium_pb");
const decoders_1 = require("./decoders/decoders");
const ScalarDecoder_1 = __importDefault(require("./decoders/ScalarDecoder"));
const parameterEncoder_1 = __importDefault(require("./encoders/parameterEncoder"));
class KoraliumClient {
    constructor(url) {
        this.client = new koralium_grpc_pb_1.KoraliumServiceClient(url, grpc.credentials.createInsecure());
    }
    createDecoders(columns) {
        return columns.map(x => decoders_1.getDecoder(x));
    }
    createBaseObject(decoders) {
        const baseObject = {};
        for (let i = 0; i < decoders.length; i++) {
            const name = decoders[i].getFieldName();
            baseObject[name] = decoders[i].baseValue();
        }
        return baseObject;
    }
    queryScalar(sql, parameters, headers = {}) {
        const queryRequest = new koralium_pb_1.QueryRequest();
        queryRequest.setQuery(sql);
        if (parameters) {
            queryRequest.setParametersList(parameterEncoder_1.default(parameters));
        }
        const metadata = new grpc.Metadata();
        for (let [key, value] of Object.entries(headers)) {
            metadata.add(key, value);
        }
        return new Promise((resolve, reject) => {
            this.client.queryScalar(queryRequest, metadata, (error, data) => {
                if (error) {
                    reject(error.message);
                }
                resolve(ScalarDecoder_1.default(data));
            });
        });
    }
    query(sql, parameters, headers = {}) {
        return __awaiter(this, void 0, void 0, function* () {
            const queryRequest = new koralium_pb_1.QueryRequest();
            queryRequest.setQuery(sql);
            queryRequest.setMaxbatchsize(1000000);
            if (parameters) {
                queryRequest.setParametersList(parameterEncoder_1.default(parameters));
            }
            const metadata = new grpc.Metadata();
            for (let [key, value] of Object.entries(headers)) {
                metadata.add(key, value);
            }
            let stream = this.client.query(queryRequest, metadata);
            const objects = [];
            let decoders = [];
            let baseObject = {};
            yield new Promise((resolve, reject) => {
                stream.on("data", response => {
                    const page = response;
                    const metadataList = page.getMetadataList();
                    //Check if it contains metadata, if so, create the decoders
                    if (metadataList.length > 0) {
                        decoders = this.createDecoders(metadataList);
                        baseObject = this.createBaseObject(decoders);
                    }
                    const rowCount = page.getRowcount();
                    const startLength = objects.length;
                    //Create all the objects that will be parsed
                    for (let i = 0; i < rowCount; i++) {
                        objects.push(Object.assign({}, baseObject));
                    }
                    const blocks = page.getColumns();
                    const blockList = blocks.getBlocksList();
                    for (let i = 0; i < decoders.length; i++) {
                        decoders[i].newPage(page);
                        decoders[i].decode(blockList[i], objects, startLength);
                    }
                });
                stream.on("end", () => {
                    resolve(objects);
                });
                stream.on("close", () => {
                    resolve(objects);
                });
            });
            return objects;
        });
    }
}
exports.KoraliumClient = KoraliumClient;
//# sourceMappingURL=client.js.map