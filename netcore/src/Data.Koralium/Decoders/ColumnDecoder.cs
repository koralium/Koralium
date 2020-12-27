using Apache.Arrow;
using System;

namespace Data.Koralium.Decoders
{
    internal abstract class ColumnDecoder
    {
        protected uint Ordinal { get; private set; }

        internal void SetOrdinal(uint ordinal)
        {
            Ordinal = ordinal;
        }

        public abstract string GetDataTypeName();

        public abstract Type GetFieldType();

        public abstract object GetValue(in int index);

        public abstract bool IsDbNull(in int index);

        /// <summary>
        /// Called when a new record batch is loaded and the passed in arrow array is for the ordinal this column decoder
        /// is responsible for.
        /// </summary>
        /// <param name="arrowArray"></param>
        internal abstract void NewBatch(IArrowArray arrowArray);

        public abstract object GetFieldValue(in int index, Type type);

        public virtual int GetInt32(in int index)
        {
            throw new NotSupportedException($"Column with ordinal {Ordinal} and type {GetDataTypeName()} cant get a int32 value");
        }

        public virtual short GetInt16(in int index)
        {
            throw new NotSupportedException($"Column with ordinal {Ordinal} and type {GetDataTypeName()} cant get a int16 value");
        }

        public virtual long GetInt64(in int index)
        {
            throw new NotSupportedException($"Column with ordinal {Ordinal} and type {GetDataTypeName()} cant get a int64 value");
        }

        public virtual byte GetByte(in int index)
        {
            throw new NotSupportedException($"Column with ordinal {Ordinal} and type {GetDataTypeName()} cant get a byte value");
        }

        public virtual float GetFloat(in int index)
        {
            throw new NotSupportedException($"Column with ordinal {Ordinal} and type {GetDataTypeName()} cant get a float value");
        }

        public virtual double GetDouble(in int index)
        {
            throw new NotSupportedException($"Column with ordinal {Ordinal} and type {GetDataTypeName()} cant get a double value");
        }

        public virtual decimal GetDecimal(in int index)
        {
            throw new NotSupportedException($"Column with ordinal {Ordinal} and type {GetDataTypeName()} cant get a decimal value");
        }

        public virtual T GetFieldValue<T>(in int index)
        {
            return (T)GetFieldValue(index, typeof(T));
        }

        public virtual string GetString(in int index)
        {
            throw new NotSupportedException($"Column with ordinal {Ordinal} and type {GetDataTypeName()} cant get a string value");
        }

        public virtual bool GetBoolean(in int index)
        {
            throw new NotSupportedException($"Column with ordinal {Ordinal} and type {GetDataTypeName()} cant get a boolean value");
        }

        public virtual char GetChar(in int index)
        {
            throw new NotSupportedException($"Column with ordinal {Ordinal} and type {GetDataTypeName()} cant get a char value");
        }

        public virtual long GetChars(in int index, in long dataOffset, in char[] buffer, in int bufferOffset, in int length)
        {
            throw new NotSupportedException($"Column with ordinal {Ordinal} and type {GetDataTypeName()} cant get chars");
        }

        public virtual Guid GetGuid(in int index)
        {
            throw new NotSupportedException($"Column with ordinal {Ordinal} and type {GetDataTypeName()} cant get a guid value");
        }

        public virtual long GetBytes(in int index, in long dataOffset, in byte[] buffer, in int bufferOffset, in int length)
        {
            throw new NotSupportedException($"Column with ordinal {Ordinal} and type {GetDataTypeName()} cant get bytes");
        }

        public virtual DateTime GetDateTime(in int index)
        {
            throw new NotSupportedException($"Column with ordinal {Ordinal} and type {GetDataTypeName()} cant get a DateTime value.");
        }
    }
}
