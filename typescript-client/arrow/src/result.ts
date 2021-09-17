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
import { DataType, Table } from "apache-arrow";
import { RowLike } from "apache-arrow/type";
import { KoraliumRow } from "./internal/KoraliumRow";
import { createProxyHandler } from "./internal/typevisitor";

export class ArrowResult<T extends { [key: string]: DataType } = any> {
  private table: Table<T>;
  private proxyHandler: ProxyHandler<T>
  /**
   *
   */
  constructor(table: Table<T>) {
    this.table = table;
    this.proxyHandler = createProxyHandler(table.schema.fields)
  }

  get(index: number): T {
    const row = this.table.get(index)
    return new KoraliumRow(row, this.proxyHandler) as T
  }

  [Symbol.iterator](): Iterator<T, any, undefined> {
    const it: Iterator<RowLike<T>> = this.table[Symbol.iterator]()
    return new DataIterator<T>(it as any, this.proxyHandler as any)
  }

  public get length() {
    return this.table.length
  }

  public toArray() {
    const output: Array<T> = []

    for(let obj of this) {
      output.push((obj as any).toObject())
    }

    return output
  }
}

class DataIterator<T extends { [key: string]: DataType } = any> implements Iterator<T, any, undefined> {

  it: Iterator<T>;
  proxyHandler: ProxyHandler<T>
  /**
   *
   */
  constructor(it: Iterator<T>, proxyHandler: ProxyHandler<T>) {
    this.it = it;
    this.proxyHandler = proxyHandler
  }

  next(...args: [] | [undefined]): IteratorResult<T, any> {
    const result = this.it.next()

    if (!result.done && result.value) {
      result.value = new KoraliumRow(result.value, this.proxyHandler)
    }
    
    return result;
  }

}