using Apache.Arrow;
using Data.Koralium.Decoders;
using Data.Koralium.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;

namespace Data.Koralium.DataReaders
{
    /// <summary>
    /// Reads a single record batch at a time.
    /// 
    /// This reader is unsafe and does not check that the ordinal exist
    /// </summary>
    internal class UnsafeRecordBatchDataReader : DbDataReader
    {
        private readonly Schema _schema;
        private readonly IReadOnlyList<ColumnDecoder> _columnDecoders;
        
        private RecordBatch _currentBatch;
        private int _currentIndex = -1;

        public UnsafeRecordBatchDataReader(RecordBatch recordBatch)
        {
            _schema = recordBatch.Schema;
            _columnDecoders = SchemaToDecoder.SchemaToDecoders(recordBatch.Schema);

            ReadNewRecordBatch(recordBatch);
        }

        public void ReadNewRecordBatch(RecordBatch recordBatch)
        {
            //Dispose the previous batch
            _currentBatch?.Dispose();
            _currentBatch = recordBatch;
            _currentIndex = -1;

            for (int i = 0; i < _columnDecoders.Count; i++)
            {
                _columnDecoders[i].NewBatch(recordBatch.Column(i));
            }
        }

        protected override void Dispose(bool disposing)
        {
            //Dispose the currently read batch
            if (disposing)
            {
                _currentBatch?.Dispose();
                _currentBatch = null;
            }
        }

        public override void Close()
        {
            Dispose(true);
        }

        public override object this[int ordinal] => GetValue(ordinal);

        public override object this[string name] => GetValue(GetOrdinal(name));

        public override int Depth => 0;

        public override int FieldCount => _columnDecoders.Count;

        public override bool HasRows => _currentBatch.Length > 0;

        public override bool IsClosed => false;

        public override int RecordsAffected => -1;

        public override bool GetBoolean(int ordinal)
        {
            return _columnDecoders[ordinal].GetBoolean(_currentIndex);
        }

        public override byte GetByte(int ordinal)
        {
            return _columnDecoders[ordinal].GetByte(_currentIndex);
        }

        public override long GetBytes(int ordinal, long dataOffset, byte[] buffer, int bufferOffset, int length)
        {
            return _columnDecoders[ordinal].GetBytes(_currentIndex, dataOffset, buffer, bufferOffset, length);
        }

        public override char GetChar(int ordinal)
        {
            return _columnDecoders[ordinal].GetChar(_currentIndex);
        }

        public override long GetChars(int ordinal, long dataOffset, char[] buffer, int bufferOffset, int length)
        {
            return _columnDecoders[ordinal].GetChars(_currentIndex, dataOffset, buffer, bufferOffset, length);
        }

        public override string GetDataTypeName(int ordinal)
        {
            return _columnDecoders[ordinal].GetDataTypeName();
        }

        public override DateTime GetDateTime(int ordinal)
        {
            return _columnDecoders[ordinal].GetDateTime(_currentIndex);
        }

        public override decimal GetDecimal(int ordinal)
        {
            return _columnDecoders[ordinal].GetDecimal(_currentIndex);
        }

        public override double GetDouble(int ordinal)
        {
            return _columnDecoders[ordinal].GetDouble(_currentIndex);
        }

        public override IEnumerator GetEnumerator()
        {
            return new DbEnumerator(this, false);
        }

        public override Type GetFieldType(int ordinal)
        {
            return _columnDecoders[ordinal].GetFieldType();
        }

        public override float GetFloat(int ordinal)
        {
            return _columnDecoders[ordinal].GetFloat(_currentIndex);
        }

        public override Guid GetGuid(int ordinal)
        {
            return _columnDecoders[ordinal].GetGuid(_currentIndex);
        }

        public override short GetInt16(int ordinal)
        {
            return _columnDecoders[ordinal].GetInt16(_currentIndex);
        }

        public override int GetInt32(int ordinal)
        {
            return _columnDecoders[ordinal].GetInt32(_currentIndex);
        }

        public override long GetInt64(int ordinal)
        {
            return _columnDecoders[ordinal].GetInt64(_currentIndex);
        }

        public override string GetName(int ordinal)
        {
            return _schema.GetFieldByIndex(ordinal).Name;
            throw new NotImplementedException();
        }

        public override int GetOrdinal(string name)
        {
            return _schema.GetFieldIndex(name);
        }

        public override string GetString(int ordinal)
        {
            return _columnDecoders[ordinal].GetString(_currentIndex);
        }

        public override object GetValue(int ordinal)
        {
            return _columnDecoders[ordinal].GetValue(_currentIndex);
        }

        public override int GetValues(object[] values)
        {
            if (values.Length < _columnDecoders.Count)
            {
                throw new InvalidOperationException("The values array is smaller than the number of columns");
            }

            for (int i = 0; i < _columnDecoders.Count; i++)
            {
                values[i] = GetValue(i);
            }

            return _columnDecoders.Count;
        }

        public override bool IsDBNull(int ordinal)
        {
            return _columnDecoders[ordinal].IsDbNull(_currentIndex);
        }

        public override T GetFieldValue<T>(int ordinal)
        {
            return _columnDecoders[ordinal].GetFieldValue<T>(_currentIndex);
        }

        public override bool NextResult()
        {
            return false;
        }

        public override bool Read()
        {
            _currentIndex++;
            if (_currentIndex >= _currentBatch.Length)
            {
                return false;
            }
            return true;
        }
    }
}
