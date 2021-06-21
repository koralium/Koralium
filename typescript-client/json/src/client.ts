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
import { QueryOptions } from "./queryOptions";
import { Metadata, QueryResult } from "./queryResult";

import axios from 'axios'
import { URL } from "url";

function isValidHttpUrl(value: string) {
  let url;
  
  try {
    url = new URL(value);
  } catch (_) {
    return false;  
  }

  return url.protocol === "http:" || url.protocol === "https:";
}


export class KoraliumClient {

  private url: string;

  constructor(url: string) {
    this.url = url;
    if (!isValidHttpUrl(this.url)) {
      throw new Error(`'${url}' is not a valid http url.`);
    }
  }

  async queryScalar(sql: string, parameters: {} | null = null, headers: {} = {}): Promise<any> {

    return this.query(sql, {
      headers: headers,
      parameters: parameters
    })
      .then(result => {
        if(result.rows.length == 0) {
          return null;
        }

        const firstRow = result.rows[0] as {[key: string]: any;};
        return firstRow[Object.keys(firstRow)[0]];
      });
  }

  async query(sql: string, queryOptions?: QueryOptions): Promise<QueryResult> {

    const headers: {[key: string]: any;} = {
      ...queryOptions?.headers
    };

    if(queryOptions?.parameters != null) {
      for (let [key, value] of Object.entries(queryOptions.parameters)) {
        headers["P_" + key] = value;
      }
    }
    
    return axios.post(this.url, sql, {
      headers: headers
    })
      .then(response => {
        return new QueryResult(response.data.values, new Metadata({}));
      })
      .catch(error => {
          throw error;
      });
  }
}