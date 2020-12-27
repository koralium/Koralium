using System;
using System.Collections;
using System.Data.Common;

namespace Data.Koralium.DataReaders
{
    /// <summary>
    /// Throws an error on all Get operations.
    /// </summary>
    public class ReadErrorDataReader : DbDataReader
    {
        private readonly string _message;

        public ReadErrorDataReader(string message)
        {
            _message = message;
        }

        public override object this[int ordinal] => throw new NotImplementedException();

        public override object this[string name] => throw new NotImplementedException();

        public override int Depth => throw new NotImplementedException();

        public override int FieldCount => throw new NotImplementedException();

        public override bool HasRows => throw new NotImplementedException();

        public override bool IsClosed => throw new NotImplementedException();

        public override int RecordsAffected => throw new NotImplementedException();

        public override bool GetBoolean(int ordinal)
        {
            throw new InvalidOperationException(_message);
        }

        public override byte GetByte(int ordinal)
        {
            throw new InvalidOperationException(_message);
        }

        public override long GetBytes(int ordinal, long dataOffset, byte[] buffer, int bufferOffset, int length)
        {
            throw new InvalidOperationException(_message);
        }

        public override char GetChar(int ordinal)
        {
            throw new InvalidOperationException(_message);
        }

        public override long GetChars(int ordinal, long dataOffset, char[] buffer, int bufferOffset, int length)
        {
            throw new InvalidOperationException(_message);
        }

        public override string GetDataTypeName(int ordinal)
        {
            throw new InvalidOperationException(_message);
        }

        public override DateTime GetDateTime(int ordinal)
        {
            throw new InvalidOperationException(_message);
        }

        public override decimal GetDecimal(int ordinal)
        {
            throw new InvalidOperationException(_message);
        }

        public override double GetDouble(int ordinal)
        {
            throw new InvalidOperationException(_message);
        }

        public override IEnumerator GetEnumerator()
        {
            throw new InvalidOperationException(_message);
        }

        public override Type GetFieldType(int ordinal)
        {
            throw new InvalidOperationException(_message);
        }

        public override float GetFloat(int ordinal)
        {
            throw new InvalidOperationException(_message);
        }

        public override Guid GetGuid(int ordinal)
        {
            throw new InvalidOperationException(_message);
        }

        public override short GetInt16(int ordinal)
        {
            throw new InvalidOperationException(_message);
        }

        public override int GetInt32(int ordinal)
        {
            throw new InvalidOperationException(_message);
        }

        public override long GetInt64(int ordinal)
        {
            throw new InvalidOperationException(_message);
        }

        public override string GetName(int ordinal)
        {
            throw new InvalidOperationException(_message);
        }

        public override int GetOrdinal(string name)
        {
            throw new InvalidOperationException(_message);
        }

        public override string GetString(int ordinal)
        {
            throw new InvalidOperationException(_message);
        }

        public override object GetValue(int ordinal)
        {
            throw new InvalidOperationException(_message);
        }

        public override int GetValues(object[] values)
        {
            throw new InvalidOperationException(_message);
        }

        public override bool IsDBNull(int ordinal)
        {
            throw new InvalidOperationException(_message);
        }

        public override bool NextResult()
        {
            return false;
        }

        public override bool Read()
        {
            return false;
        }
    }
}
