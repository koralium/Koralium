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
import { ListVector } from "apache-arrow"

export class KoraliumList implements Iterable<any> {
  list: ListVector
  transformMethod: (data:any) => any

  /**
   *
   */
  constructor(list: ListVector, transformMethod: (data:any) => any) {
    this.list = list
    this.transformMethod = transformMethod
  }

  [Symbol.iterator](): Iterator<any, any, undefined> {
    const iterator = this.list[Symbol.iterator]()
    return {
      next: () => {
        const val = iterator.next()
        if (!val.done) {
          val.value = this.transformMethod(val.value)
        }
        return val
      }
    }
  }

  get(index: number) {
    return this.transformMethod(this.list.get(index))
  }

  public get length() { return this.list.length; }

  public toObject() {
    const output: Array<any> = []

    for (let i = 0; i < this.length; i++) {
      let val = this.get(i);

      if (val.toObject) {
        val = val.toObject();
      }

      output.push(val)
    }

    return output
  }
}