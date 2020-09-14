import neatCsv from 'neat-csv';
import fs from 'fs';


export default class TpchData {

  orders: Order[];

  async load() {
    this.orders = await getOrders();
  }

  getOrders() {
    return this.orders;
  }

}

export class Order {
  orderkey: number;
  custkey: number;
  orderstatus: string;
  totalprice: number;
  orderdate: string;
  orderpriority: string;
  clerk: string;
  shippriority: number;
  comment: string;

  constructor(
    orderkey: number,
    custkey: number,
    orderstatus: string,
    totalprice: number,
    orderdate: string,
    orderpriority: string,
    clerk: string,
    shippriority: number,
    comment: string) {
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


const getOrders = async () => {
  const expected = await neatCsv(
    fs.createReadStream('../TestData/tpch/orders.csv'), {
      mapValues:  ({ header, index, value }) => {

        if(value === "null") {
          return null;
        }

        if(header === "orderdate") {
          return new Date(value).toISOString();
        }

        if(header === "orderkey") {
          return Number.parseInt(value);
        }

        if(header === "custkey") {
          return Number.parseInt(value);
        }

        if(header === "totalprice") {
          return Number.parseFloat(value);
        }

        if(header === "shippriority") {
          return Number.parseInt(value);
        }

        return value;
      }
    }
  );

  const mapped = expected.map(x => new Order(<number><unknown>x["orderkey"], <number><unknown>x["custkey"], x["orderstatus"], <number><unknown>x["totalprice"], x["orderdate"], x["orderpriority"], x["clerk"], <number><unknown>x["shippriority"], x["comment"]));
  return mapped;
};