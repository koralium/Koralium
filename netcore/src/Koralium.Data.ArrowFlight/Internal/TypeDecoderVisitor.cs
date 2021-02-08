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
using Apache.Arrow.Types;
using Koralium.Data.ArrowFlight.Decoders;
using System;

namespace Koralium.Data.ArrowFlight.Internal
{
    internal class TypeDecoderVisitor :
        IArrowTypeVisitor<BooleanType>,
        IArrowTypeVisitor<Int8Type>,
        IArrowTypeVisitor<Int16Type>,
        IArrowTypeVisitor<Int32Type>,
        IArrowTypeVisitor<Int64Type>,
        IArrowTypeVisitor<UInt8Type>,
        IArrowTypeVisitor<UInt16Type>,
        IArrowTypeVisitor<UInt32Type>,
        IArrowTypeVisitor<UInt64Type>,
        IArrowTypeVisitor<FloatType>,
        IArrowTypeVisitor<DoubleType>,
        IArrowTypeVisitor<StringType>,
        IArrowTypeVisitor<Date32Type>,
        IArrowTypeVisitor<Date64Type>,
        IArrowTypeVisitor<Time32Type>,
        IArrowTypeVisitor<Time64Type>,
        IArrowTypeVisitor<BinaryType>,
        IArrowTypeVisitor<TimestampType>,
        IArrowTypeVisitor<ListType>,
        IArrowTypeVisitor<UnionType>,
        IArrowTypeVisitor<StructType>

    {
        public ColumnDecoder ColumnDecoder { get; private set; }

        public void Visit(IArrowType type)
        {
            throw new NotImplementedException();
        }

        public void Visit(BooleanType type)
        {
            ColumnDecoder = new BoolDecoder();
        }

        public void Visit(Int8Type type)
        {
            ColumnDecoder = new Int8Decoder();
        }

        public void Visit(Int16Type type)
        {
            ColumnDecoder = new Int16Decoder();
        }

        public void Visit(Int32Type type)
        {
            ColumnDecoder = new Int32Decoder();
        }

        public void Visit(Int64Type type)
        {
            ColumnDecoder = new Int64Decoder();
        }

        public void Visit(UInt8Type type)
        {
            ColumnDecoder = new UInt8Decoder();
        }

        public void Visit(UInt16Type type)
        {
            throw new NotImplementedException();
        }

        public void Visit(UInt32Type type)
        {
            ColumnDecoder = new UInt32Decoder();
        }

        public void Visit(UInt64Type type)
        {
            ColumnDecoder = new UInt64Decoder();
        }

        public void Visit(FloatType type)
        {
            ColumnDecoder = new FloatDecoder();
        }

        public void Visit(DoubleType type)
        {
            ColumnDecoder = new DoubleDecoder();
        }

        public void Visit(StringType type)
        {
            ColumnDecoder = new StringDecoder();
        }

        public void Visit(Date32Type type)
        {
            throw new NotImplementedException();
        }

        public void Visit(Date64Type type)
        {
            throw new NotImplementedException();
        }

        public void Visit(Time32Type type)
        {
            throw new NotImplementedException();
        }

        public void Visit(Time64Type type)
        {
            throw new NotImplementedException();
        }

        public void Visit(BinaryType type)
        {
            ColumnDecoder = new BinaryDecoder();
        }

        public void Visit(TimestampType type)
        {
            ColumnDecoder = new TimestampDecoder();
        }

        public void Visit(ListType type)
        {
            ColumnDecoder = new ListDecoder(type);
        }

        public void Visit(UnionType type)
        {
            throw new NotImplementedException();
        }

        public void Visit(StructType type)
        {
            ColumnDecoder = new StructDecoder(type);
        }
    }
}
