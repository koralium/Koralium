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
exports.QueryServer = void 0;
const testcontainers_1 = require("testcontainers");
const path_1 = __importDefault(require("path"));
class QueryServer {
    start() {
        return __awaiter(this, void 0, void 0, function* () {
            this.container = yield new testcontainers_1.GenericContainer("koraliumwebtest")
                .withExposedPorts(5015)
                .withBindMount(path_1.default.resolve(__dirname, "../../TestData/"), "/app/Data/", "ro")
                .withWaitStrategy(testcontainers_1.Wait.forLogMessage('Application started. Press Ctrl+C to shut down.'))
                .start();
        });
    }
    stop() {
        return __awaiter(this, void 0, void 0, function* () {
            if (this.container != undefined) {
                yield this.container.stop();
            }
        });
    }
    getIpAddress() {
        return this.container.getContainerIpAddress();
    }
    getPort() {
        return this.container.getMappedPort(5015);
    }
}
exports.QueryServer = QueryServer;
//# sourceMappingURL=queryserver.js.map