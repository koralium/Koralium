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
const client_1 = __importDefault(require("./client"));
const client = new client_1.default("127.0.0.1:5016");
var readline = require('readline');
var log = console.log;
var rl = readline.createInterface({
    input: process.stdin,
    output: process.stdout
});
var recursiveAsyncReadLine = function () {
    rl.question('Command: ', function (answer) {
        return __awaiter(this, void 0, void 0, function* () {
            if (answer == 'exit') //we need some base case, for recursion
                return rl.close(); //closing RL and returning from function.
            var results = yield client.query(answer, { '@name': 'alex', '@id': 1 });
            log(results);
            recursiveAsyncReadLine(); //Calling this function again to ask new question
        });
    });
};
recursiveAsyncReadLine();
//# sourceMappingURL=index.js.map