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
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Koralium.Client.Decoders
{
    public abstract class ColumnDecoder : BaseDecoder
    {
        protected readonly int ordinal;
        public ColumnDecoder(int ordinal)
        {
            this.ordinal = ordinal;
        }


        public virtual bool GetBoolean(KoraliumRow row)
        {
            throw new NotSupportedException($"Column with ordinal {ordinal} and type {GetDataTypeName()} cant get a boolean value");
        }

        public virtual byte GetByte(KoraliumRow row)
        {
            throw new NotSupportedException($"Column with ordinal {ordinal} and type {GetDataTypeName()} cant get a byte value");
        }

        public virtual long GetBytes(KoraliumRow row, long dataOffset, byte[] buffer, int bufferOffset, int length)
        {
            throw new NotSupportedException($"Column with ordinal {ordinal} and type {GetDataTypeName()} cant get bytes value");
        }

        public virtual char GetChar(KoraliumRow row)
        {
            throw new NotSupportedException($"Column with ordinal {ordinal} and type {GetDataTypeName()} cant get a char value");
        }

        public virtual long GetChars(KoraliumRow row, long dataOffset, char[] buffer, int bufferOffset, int length)
        {
            throw new NotSupportedException($"Column with ordinal {ordinal} and type {GetDataTypeName()} cant get chars value");
        }

        public abstract string GetDataTypeName();

        public virtual DateTime GetDateTime(KoraliumRow row)
        {
            throw new NotSupportedException($"Column with ordinal {ordinal} and type {GetDataTypeName()} cant get a datetime value");
        }

        public virtual decimal GetDecimal(KoraliumRow row)
        {
            throw new NotSupportedException($"Column with ordinal {ordinal} and type {GetDataTypeName()} cant get a decimal value");
        }

        public virtual double GetDouble(KoraliumRow row)
        {
            throw new NotSupportedException($"Column with ordinal {ordinal} and type {GetDataTypeName()} cant get a double value");
        }

        public abstract Type GetFieldType();

        public virtual float GetFloat(KoraliumRow row)
        {
            throw new NotSupportedException($"Column with ordinal {ordinal} and type {GetDataTypeName()} cant get a float value");
        }

        public virtual Guid GetGuid(KoraliumRow row)
        {
            throw new NotSupportedException($"Column with ordinal {ordinal} and type {GetDataTypeName()} cant get a guid value");
        }

        public virtual short GetInt16(KoraliumRow row)
        {
            throw new NotSupportedException($"Column with ordinal {ordinal} and type {GetDataTypeName()} cant get a int16 value");
        }

        public virtual int GetInt32(KoraliumRow row)
        {
            throw new NotSupportedException($"Column with ordinal {ordinal} and type {GetDataTypeName()} cant get a int32 value");
        }

        public virtual long GetInt64(KoraliumRow row)
        {
            throw new NotSupportedException($"Column with ordinal {ordinal} and type {GetDataTypeName()} cant get a int64 value");
        }

        public virtual string GetString(KoraliumRow row)
        {
            throw new NotSupportedException($"Column with ordinal {ordinal} and type {GetDataTypeName()} cant get a string value");
        }

        public virtual object GetValue(KoraliumRow row)
        {
            return row.GetData(ordinal);
        }

        public virtual bool IsDBNull(KoraliumRow row)
        {
            return row.GetData(ordinal) == null;
        }

        public virtual T GetFieldValue<T>(KoraliumRow row)
        {
            return (T)row.GetData(ordinal);
        }
    }
}
