using Data.Koralium.Client;
using Data.Koralium.Client.Decoders;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;
using System.Threading;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Data.Koralium
{
    public class KoraliumDataReader : DbDataReader
    {
        private readonly CancellationToken _cancellationToken;
        private readonly KoraliumClient _client;
        private readonly ChannelReader<KoraliumRow> _channelReader;

        private KoraliumRow _currentRow;

        public KoraliumDataReader(KoraliumClient client, ChannelReader<KoraliumRow> channelReader, CancellationToken cancellationToken)
        {
            _client = client;
            _channelReader = channelReader;
            _cancellationToken = cancellationToken;
        }


        public override object this[int ordinal] => GetValue(ordinal);

        public override object this[string name] => GetValue(GetOrdinal(name));

        public override int Depth => 0;

        public override int FieldCount => _client.GetNumberOfColumns();

        public override bool HasRows => true;

        public override bool IsClosed => _channelReader.Completion.IsCompleted || _channelReader.Completion.IsCanceled;

        public override int RecordsAffected => 0;

        public override bool GetBoolean(int ordinal)
        {
            return _client.GetBoolean(ordinal, _currentRow);
        }

        public override byte GetByte(int ordinal)
        {
            return _client.GetByte(ordinal, _currentRow);
        }

        public override long GetBytes(int ordinal, long dataOffset, byte[] buffer, int bufferOffset, int length)
        {
            return _client.GetBytes(ordinal, _currentRow, dataOffset, buffer, bufferOffset, length);
        }

        public override char GetChar(int ordinal)
        {
            return _client.GetChar(ordinal, _currentRow);
        }

        public override long GetChars(int ordinal, long dataOffset, char[] buffer, int bufferOffset, int length)
        {
            return _client.GetChars(ordinal, _currentRow, dataOffset, buffer, bufferOffset, length);
        }

        public override string GetDataTypeName(int ordinal)
        {
            return _client.GetDataTypeName(ordinal);
        }

        public override DateTime GetDateTime(int ordinal)
        {
            return _client.GetDateTime(ordinal, _currentRow);
        }

        public override T GetFieldValue<T>(int ordinal)
        {
            return _client.GetFieldValue<T>(ordinal, _currentRow);
        }

        public override decimal GetDecimal(int ordinal)
        {
            return _client.GetDecimal(ordinal, _currentRow);
        }

        public override double GetDouble(int ordinal)
        {
            return _client.GetDouble(ordinal, _currentRow);
        }

        public override IEnumerator GetEnumerator()
        {
            throw new NotSupportedException();
        }

        public override Type GetFieldType(int ordinal)
        {
            return _client.GetFieldType(ordinal);
        }

        public override float GetFloat(int ordinal)
        {
            return _client.GetFloat(ordinal, _currentRow);
        }

        public override Guid GetGuid(int ordinal)
        {
            return _client.GetGuid(ordinal, _currentRow);
        }

        public override short GetInt16(int ordinal)
        {
            return _client.GetInt16(ordinal, _currentRow);
        }

        public override int GetInt32(int ordinal)
        {
            return _client.GetInt32(ordinal, _currentRow);
        }

        public override long GetInt64(int ordinal)
        {
            return _client.GetInt64(ordinal, _currentRow);
        }

        public override string GetName(int ordinal)
        {
            return _client.GetName(ordinal);
        }

        public override int GetOrdinal(string name)
        {
            return _client.GetOrdinal(name);
        }

        public override string GetString(int ordinal)
        {
            return _client.GetString(ordinal, _currentRow);
        }

        public override object GetValue(int ordinal)
        {
            return _client.GetValue(ordinal, _currentRow);
        }

        public override int GetValues(object[] values)
        {
            //TODO
            throw new NotImplementedException();
        }

        public override bool IsDBNull(int ordinal)
        {
            return _client.IsDBNull(ordinal, _currentRow);
        }

        public override bool NextResult()
        {
            return false;
        }

        public override bool Read()
        {
            if (_channelReader.Completion.IsCompleted)
                return false;


            while(!_channelReader.TryRead(out _currentRow) && !_channelReader.Completion.IsCompleted && !_cancellationToken.IsCancellationRequested)
            {
                //Iterate 
            }

            if (_channelReader.Completion.IsCompleted && _currentRow == null)
            {
                return false;
            }

            return true;
        }
    }
}
