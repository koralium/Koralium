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
import { QueryBuilder } from "./queryBuilder";

//This class is mostly useful in GraphQL or similar areas
//Where you want to map an object into the query builder.
export class ObjectToSelectMapper {

  mappingTable: {[key: string]: string | Array<string>;} = {};

  addMapping(key: string, select: string | Array<string>) : ObjectToSelectMapper {
    this.mappingTable[key] = select;
    return this;
  }

  private isArray(value: string | Array<string>): value is Array<string> {
    return Array.isArray(value);
  }

  addSelectsToQuery(queryBuilder: QueryBuilder, inputObject: {}) {
    for (let [key] of Object.entries(inputObject)) {

      if (this.mappingTable[key] !== undefined) {
        const mappingTableValue = this.mappingTable[key];

        if(this.isArray(mappingTableValue)) {
          mappingTableValue.forEach(x => queryBuilder.addSelectElement(x));
        }
        else {
          queryBuilder.addSelectElement(mappingTableValue);
        }
      }
    }
  }
}