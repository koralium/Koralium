"use strict";
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
const client_1 = __importDefault(require("../src/client"));
const queryserver_1 = require("./queryserver");
const tpchdata_1 = __importDefault(require("./tpchdata"));
//import jest from "jest"
const accessToken = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxMjM0NTY3ODkwIiwibmFtZSI6IlRlc3QgdGVzdCIsInVuaXF1ZV9uYW1lIjoidGVzdCIsImlhdCI6MTUxNjIzOTAyMn0.aF80OiteMckPhSQcAL549V4AcyKHJA8LUs4mhzBnf2w";
var client;
var server;
var tpchData;
jest.setTimeout(30000);
beforeAll(() => __awaiter(void 0, void 0, void 0, function* () {
    server = new queryserver_1.QueryServer();
    yield server.start();
    tpchData = new tpchdata_1.default();
    yield tpchData.load();
    //client = new KoraliumClient(`${server.getIpAddress()}:${server.getPort()}`);
    client = new client_1.default("127.0.0.1:5016");
}));
afterAll(() => __awaiter(void 0, void 0, void 0, function* () {
    yield server.stop();
}));
test("Get orders", () => __awaiter(void 0, void 0, void 0, function* () {
    const expected = tpchData.getOrders();
    const results = yield client.query("select orderkey, custkey, orderstatus, totalprice, orderdate, orderpriority, clerk, shippriority, comment from orders");
    expect(results).toEqual(expected);
}));
test("Get secure data", () => __awaiter(void 0, void 0, void 0, function* () {
    const expected = tpchData.getOrders();
    const results = yield client.query("select orderkey, custkey, orderstatus, totalprice, orderdate, orderpriority, clerk, shippriority, comment from secure", null, {
        Authorization: `Bearer ${accessToken}`
    });
    expect(results).toEqual(expected);
}));
test("Test limit", () => __awaiter(void 0, void 0, void 0, function* () {
    const expected = tpchData.getOrders().slice(0, 100);
    const results = yield client.query("select orderkey, custkey, orderstatus, totalprice, orderdate, orderpriority, clerk, shippriority, comment from orders limit 100");
    expect(results).toEqual(expected);
}));
test("Test limit with parameter", () => __awaiter(void 0, void 0, void 0, function* () {
    const expected = tpchData.getOrders().slice(0, 100);
    const results = yield client.query("select orderkey, custkey, orderstatus, totalprice, orderdate, orderpriority, clerk, shippriority, comment from orders limit @limit", {
        '@limit': 100
    });
    expect(results).toEqual(expected);
}));
test("filter on date in parameter", () => __awaiter(void 0, void 0, void 0, function* () {
    const expected = tpchData.getOrders().filter(x => x.orderdate >= new Date("1993-01-01"));
    const results = yield client.query("select orderkey, custkey, orderstatus, totalprice, orderdate, orderpriority, clerk, shippriority, comment from orders where Orderdate >= @date", {
        '@date': '1993-01-01'
    });
    expect(results).toEqual(expected);
}));
test("select single field", () => __awaiter(void 0, void 0, void 0, function* () {
    const expected = tpchData.getOrders().map(x => { return { orderkey: x.orderkey }; });
    const results = yield client.query("select orderkey from orders");
    expect(results).toEqual(expected);
}));
//# sourceMappingURL=client.test.js.map