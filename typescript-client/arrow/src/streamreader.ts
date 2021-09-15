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
import { DataType, RecordBatch, Schema } from "apache-arrow";
import { AbstractVector } from "apache-arrow/vector";
import * as grpc from 'grpc';
import * as Flight_pb from "./generated/Flight_pb";
import { ITERATOR_DONE } from "./internal/arrow/io/interfaces";
import { VectorLoader } from "./internal/arrow/loader";
import { decodeMessage } from "./internal/arrow/utils/MessageReader";

interface PromiseFunctions {
  resolveFunc: (value: unknown) => void
  rejectFunc: (reason: any) => void
}

export class FlightAsyncRecordBatchStreamReader<T extends { [key: string]: DataType } = any> implements AsyncIterableIterator<RecordBatch<T>> {

  private stream: grpc.ClientReadableStream<Flight_pb.FlightData>
  private closed: boolean = false
  private schema?: Schema
  private batchBuffer: Array<RecordBatch<T>> = []
  private promiseBuffer: Array<PromiseFunctions> = []
  private error?: Error

  constructor(stream: grpc.ClientReadableStream<Flight_pb.FlightData>) {
    this.stream = stream;
    this.setUpStreamReading()
  }

  private setUpStreamReading() {

    this.stream.on("data", (data: Flight_pb.FlightData) => {
      const header = data.getDataHeader()
      const msg = decodeMessage(header)

      if (msg.isSchema()) {
        this.schema = msg.header()
      }
      if (msg.isRecordBatch()) {
        const batchHeader = msg.header()

        const batchData = data.getDataBody_asU8()
        const buff = new Uint8Array(batchData.buffer.slice(batchData.byteOffset))

        if (this.schema) {
          const v = new VectorLoader(buff, batchHeader.nodes, batchHeader.buffers, new Map<number, AbstractVector<any>>()).visitMany(this.schema.fields) as any;
          const recordBatch = new RecordBatch<T>(this.schema, batchHeader.length, v)

          // Check if a promise resolver exists, if not add it to an array buffer
          let promiseFunc: PromiseFunctions | undefined = undefined
          if ((promiseFunc = this.promiseBuffer.shift())) {
            promiseFunc.resolveFunc({done: false, value: recordBatch })
          } else {
            this.batchBuffer.push(recordBatch)
          }          
        }
      }
    });
    this.stream.on("error", (error) => {
      let promiseFunc: PromiseFunctions | undefined = undefined
      if ((promiseFunc = this.promiseBuffer.shift())) {
        promiseFunc.rejectFunc(error)
      } else {
        this.error = error
      } 
    });
    this.stream.on("close", () => {
      this.closed = true

      let promiseFunc: PromiseFunctions | undefined = undefined
      if (this.batchBuffer.length === 0 &&
        (promiseFunc = this.promiseBuffer.shift())) {
          promiseFunc.resolveFunc(ITERATOR_DONE)
      }
    })
  }

  public isAsync() { return true; }
  public isStream() { return true; }
  public [Symbol.asyncIterator](): AsyncIterableIterator<RecordBatch<T>> {
      return this as AsyncIterableIterator<RecordBatch<T>>;
  }
  public cancel() {
      if (!this.closed && (this.closed = true)) {
          this.stream.cancel()
      }
      return Promise.resolve()
  }

  public open(options?: any) {
      return Promise.resolve(this);
  }
  public async throw(value?: any): Promise<IteratorResult<any>> {
      return ITERATOR_DONE;
  }

  public async return(value?: any): Promise<IteratorResult<any>> {
      return ITERATOR_DONE;
  }

  public next() {
      // First check if existing batches has been collected
      let recordBatch: RecordBatch<T> | undefined = undefined
      if ((recordBatch = this.batchBuffer.shift())) {
        return Promise.resolve({done: false, value: recordBatch })
      }
      // If an error has come, the batches in the buffer came before it
      // Return those before the error
      else if (this.error) {
        return Promise.reject(this.error)
      }
      // If it is closed, existing batches in the buffer must first be returned
      else if (this.closed) {
        return ITERATOR_DONE
      }

      return new Promise<unknown>((resolve, reject) => {
        let recordBatch: RecordBatch<T> | undefined = undefined
        // Check if any new values was added to the batch buffer
        // If there was, return that value directly
        if ((recordBatch = this.batchBuffer.shift())) {
          resolve({done: false, value: recordBatch })
        } else {
          this.promiseBuffer.push({
            resolveFunc: resolve,
            rejectFunc: reject
          })
        }
      });
  }
}