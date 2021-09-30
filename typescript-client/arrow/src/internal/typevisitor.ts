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
import { Field, ListVector, Schema, Visitor } from "apache-arrow";
import { DataType, RowLike } from "apache-arrow/type";
import { bignumToBigInt } from "apache-arrow/util/bn";
import * as type from './arrow/type';
import { KoraliumList } from "./KoraliumList";
import { KoraliumRow } from "./KoraliumRow";
import BigInt from 'big-integer'
import Decimal from "decimal.js";

export class TypeVisitor extends Visitor {

  public visit<T extends DataType>(node: Field<T> | T) {
    //const output = {}
    if (node instanceof Field) {
      return super.visit(node.type)
    }
    return {}
  }

  public visitBinary<T extends type.Binary>(type: T) {
    return (data) => data
  }

  public visitDate<T extends type.Date_>(type : T) {
    return (data) => data
  }

  public visitDecimal<T extends type.Decimal>(type: T) {
    return (data: Int32Array) => {
      const a = BigInt(data[3]).shiftLeft(96)
      const b = BigInt(data[2]).shiftLeft(64)
      const c = BigInt(data[1]).shiftLeft(32)
      const d = BigInt(data[0])
      const final = a.or(b).or(c).or(d)
      
      return new Decimal(`${final.toString()}e-${type.scale}`)
    }
  }

  public visitInt<T extends type.Int>(type: T) { 
    
    return (data) => data
  }

  public visitInt64<T extends type.Int>(type: T) { 
    return (data: Int32Array) => data ? (data[1] * Math.pow(2, 32) + data[0]) : null
  }

  public visitTimestamp<T extends type.Timestamp>(type: T) { 
    return (data) => data ? new Date(data) : null;
  }

  public visitFloat<T extends type.Float>(type: T) {
    return (data) => data;
  }

  public visitUtf8<T extends type.Utf8>(type: T) { 
    return (data) => data;
  }

  public visitList<T extends type.List>(type: T) {
    const children = this.visit(type.children[0])
    return (data: ListVector) => data ? new KoraliumList(data, children) : null
  }

  public visitBool<T extends type.Bool>(type: T) {
    return (data) => data
  }

  public visitStruct<T extends type.Struct>(type: T) {
    const proxyHandler =  createProxyHandler(type.children)
    return (data: RowLike<any>) => data ? new KoraliumRow(data, proxyHandler) : null
  }
}

export function createNameToFunc(schema: Schema) {
  return createNameToFuncFromFields(schema.fields)
}

export function createNameToFuncFromFields(fields: Field<any>[]): { [key: string]: (data: any) => any } {
  const vals = new TypeVisitor().visitMany(fields)

  const output = {}

  for (let i = 0; i < fields.length; i++) {
    output[fields[i].name] = vals[i]
  }

  return output;
}

export function createProxyHandler(fields: Field<any>[]) {
  const nameFuncs = createNameToFuncFromFields(fields)
  const RowProxyHandler: ProxyHandler<any> = {
    isExtensible() { return false; },
    deleteProperty() { return false; },
    preventExtensions() { return true; },
    ownKeys(row: any) { return [...row.keys()].map((x) => `${x}`); },
    has(row: any, key: PropertyKey) {
        return row.has(key);
    },
    get(row: any, key: PropertyKey, receiver: any) {
      if (key === 'toObject') {
        return () => {
          const output = {}

          Object.keys(nameFuncs).forEach((k) => {
            let value = nameFuncs[k](row[k])
            // Check if there is a toJSON function
            
            if (value && value.toObject) {
              // Call the toJSON function
              value = value.toObject()
            }
            output[k] = value
          })

          return output
        }
      }

      const val = Reflect.get(row, key, receiver);

      let func = undefined
      if ((func = nameFuncs[key as string])) {
        return func(val)
      }
      return val;
    }
  };

  return RowProxyHandler;
}
