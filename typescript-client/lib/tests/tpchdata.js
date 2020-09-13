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
exports.Order = void 0;
const neat_csv_1 = __importDefault(require("neat-csv"));
const fs_1 = __importDefault(require("fs"));
class TpchData {
    load() {
        return __awaiter(this, void 0, void 0, function* () {
            this.orders = yield getOrders();
        });
    }
    getOrders() {
        return this.orders;
    }
}
exports.default = TpchData;
class Order {
    constructor(orderkey, custkey, orderstatus, totalprice, orderdate, orderpriority, clerk, shippriority, comment) {
        this.orderkey = orderkey;
        this.custkey = custkey;
        this.orderstatus = orderstatus;
        this.orderdate = orderdate;
        this.totalprice = totalprice;
        this.orderpriority = orderpriority;
        this.clerk = clerk;
        this.shippriority = shippriority;
        this.comment = comment;
    }
}
exports.Order = Order;
const getOrders = () => __awaiter(void 0, void 0, void 0, function* () {
    const expected = yield neat_csv_1.default(fs_1.default.createReadStream('../TestData/tpch/orders.csv'), {
        mapValues: ({ header, index, value }) => {
            if (value === "null") {
                return null;
            }
            if (header === "orderdate") {
                return new Date(value).toISOString();
            }
            if (header === "orderkey") {
                return Number.parseInt(value);
            }
            if (header === "custkey") {
                return Number.parseInt(value);
            }
            if (header === "totalprice") {
                return Number.parseFloat(value);
            }
            if (header === "shippriority") {
                return Number.parseInt(value);
            }
            return value;
        }
    });
    const mapped = expected.map(x => new Order(x["orderkey"], x["custkey"], x["orderstatus"], x["totalprice"], new Date(x["orderdate"]), x["orderpriority"], x["clerk"], x["shippriority"], x["comment"]));
    return mapped;
});
//# sourceMappingURL=tpchdata.js.map