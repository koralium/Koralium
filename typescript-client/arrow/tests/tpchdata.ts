/*
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */
import neatCsv from 'neat-csv';
import fs from 'fs';

export default class TpchData {

  orders?: Order[];

  async load() {
    this.orders = await getOrders();
  }

  getOrders(): Order[] {
    if(this.orders === undefined) {
      throw new Error("TpchData has not been loaded.");
    }
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
    fs.createReadStream('../../TestData/tpch/orders.csv'), {
      mapValues:  ({ header, index, value }) => {

        if(value === "null") {
          return null;
        }

        if(header === "orderdate") {
          return new Date(value); //.replace(".000", "");
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