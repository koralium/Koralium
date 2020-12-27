using Apache.Arrow.Flight;
using Apache.Arrow.Flight.Client;
using Data.Koralium.Internal;
using Data.Koralium.Properties;
using Grpc.Core;
using Grpc.Net.Client;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Data.Koralium.DataReaders
{
    /// <summary>
    /// Takes multiple flight endpoints and reads them as different result sets
    /// </summary>
    internal class FlightEndpointsDataReader : DbDataReader
    {
        private static readonly DbDataReader NoReadDataReader = new ReadErrorDataReader(Resources.NoRead);
        private static readonly DbDataReader EndOfResultSetDataReader = new ReadErrorDataReader(Resources.EndOfResultSet);

        private readonly KoraliumCommand _koraliumCommand;
        private readonly IReadOnlyList<FlightEndpoint> _flightEndpoints;
        private readonly Metadata _headers;

        private int _endpointsCounter;

        private UnsafeRecordBatchDataReader _dataReader;
        private DbDataReader _currentReader;

        private FlightRecordBatchStreamingCall _stream;

        private enum State
        {
            NotStarted,
            Reading,
            ResultSetDone,
            Closed
        }

        private State _state;

        internal FlightEndpointsDataReader(KoraliumCommand koraliumCommand, IReadOnlyList<FlightEndpoint> flightEndpoints, Metadata headers)
        {
            _koraliumCommand = koraliumCommand;
            _endpointsCounter = 0;
            _flightEndpoints = flightEndpoints;
            _currentReader = NoReadDataReader;
            _headers = headers;
        }

        private void CheckRead(in int ordinal)
        {
            if (ordinal >= _dataReader.FieldCount)
            {
                throw new InvalidOperationException(Resources.OrdinalNotFound(ordinal, _dataReader.FieldCount));
            }
        }

        public override object this[int ordinal] => GetValue(ordinal);

        public override object this[string name] => GetValue(GetOrdinal(name));

        public override int Depth => 0;

        public override int FieldCount => _dataReader.FieldCount;

        public override bool HasRows => _dataReader.HasRows;

        public override bool IsClosed => _state != State.Closed;

        /// <summary>
        /// Records affected is not yet supported.
        /// </summary>
        public override int RecordsAffected => -1;

        public override bool GetBoolean(int ordinal)
        {
            CheckRead(ordinal);
            return _currentReader.GetBoolean(ordinal);
        }

        public override byte GetByte(int ordinal)
        {
            CheckRead(ordinal);
            return _currentReader.GetByte(ordinal);
        }

        public override long GetBytes(int ordinal, long dataOffset, byte[] buffer, int bufferOffset, int length)
        {
            CheckRead(ordinal);
            return _currentReader.GetBytes(ordinal, dataOffset, buffer, bufferOffset, length);
        }

        public override char GetChar(int ordinal)
        {
            CheckRead(ordinal);
            return _currentReader.GetChar(ordinal);
        }

        public override long GetChars(int ordinal, long dataOffset, char[] buffer, int bufferOffset, int length)
        {
            CheckRead(ordinal);
            return _currentReader.GetChars(ordinal, dataOffset, buffer, bufferOffset, length);
        }

        public override string GetDataTypeName(int ordinal)
        {
            CheckRead(ordinal);

            //Use the data reader here, since this should work before calling Read()
            return _dataReader.GetDataTypeName(ordinal);
        }

        public override DateTime GetDateTime(int ordinal)
        {
            CheckRead(ordinal);
            return _currentReader.GetDateTime(ordinal);
        }

        public override decimal GetDecimal(int ordinal)
        {
            CheckRead(ordinal);
            return _currentReader.GetDecimal(ordinal);
        }

        public override double GetDouble(int ordinal)
        {
            CheckRead(ordinal);
            return _currentReader.GetDouble(ordinal);
        }

        public override IEnumerator GetEnumerator()
        {
            return new DbEnumerator(this, false);
        }

        public override Type GetFieldType(int ordinal)
        {
            CheckRead(ordinal);

            //Use the data reader here since it should give correct results before read()
            return _dataReader.GetFieldType(ordinal);
        }

        public override float GetFloat(int ordinal)
        {
            CheckRead(ordinal);
            return _currentReader.GetFloat(ordinal);
        }

        public override Guid GetGuid(int ordinal)
        {
            CheckRead(ordinal);
            return _currentReader.GetGuid(ordinal);
        }

        public override short GetInt16(int ordinal)
        {
            CheckRead(ordinal);
            return _currentReader.GetInt16(ordinal);
        }

        public override int GetInt32(int ordinal)
        {
            CheckRead(ordinal);
            return _currentReader.GetInt32(ordinal);
        }

        public override long GetInt64(int ordinal)
        {
            CheckRead(ordinal);
            return _currentReader.GetInt64(ordinal);
        }

        public override string GetName(int ordinal)
        {
            CheckRead(ordinal);
            //Use the data reader here since it should give correct results before read()
            return _dataReader.GetName(ordinal);
        }

        public override int GetOrdinal(string name)
        {
            //Use the data reader here since it should give correct results before read()
            return _dataReader.GetOrdinal(name);
        }

        public override string GetString(int ordinal)
        {
            CheckRead(ordinal);
            return _currentReader.GetString(ordinal);
        }

        public override object GetValue(int ordinal)
        {
            CheckRead(ordinal);
            return _currentReader.GetValue(ordinal);
        }

        public override int GetValues(object[] values)
        {
            return _currentReader.GetValues(values);
        }

        public override bool IsDBNull(int ordinal)
        {
            CheckRead(ordinal);
            return _currentReader.IsDBNull(ordinal);
        }

        public override T GetFieldValue<T>(int ordinal)
        {
            CheckRead(ordinal);
            return _currentReader.GetFieldValue<T>(ordinal);
        }

        public override bool NextResult()
        {
            if (_state == State.Closed)
            {
                throw new InvalidOperationException(Resources.DataReaderClosed);
            }
            if (_endpointsCounter >= _flightEndpoints.Count)
            {
                return false;
            }

            return AsyncHelper.RunSync(() => LoadNextStream(default));
        }

        private async Task<bool> LoadNextStream(CancellationToken cancellationToken)
        {
            var endpoint = _flightEndpoints[_endpointsCounter++];

            GrpcChannel grpcChannel = null;

            var locations = endpoint.Locations.ToList();
            
            if(locations.Count > 0)
            {
                var firstLocation = locations.First();

                //TODO: Fix using location from endpoint
            }
            else
            {
                //If locations are empty, use the channel entered in the connection
                grpcChannel = _koraliumCommand.KoraliumConnection.Channel;
            }

            var client = new FlightClient(grpcChannel);
            _stream = client.GetStream(endpoint.Ticket, _headers);
            var moveNextResult = await _stream.ResponseStream.MoveNext(cancellationToken).ConfigureAwait(false);
            
            if(!moveNextResult)
            {
                //No result set available, close the data reader
                Close();
                return false;
            }

            var initialBatch = _stream.ResponseStream.Current;

            //Set a new data reader to read the new schema if any.
            _dataReader = new UnsafeRecordBatchDataReader(initialBatch);

            //Set the current reader to notify that the user must call Read() before reading data.
            _currentReader = NoReadDataReader;

            return true;
        }
            
        public override Task<bool> NextResultAsync(CancellationToken cancellationToken)
        {
            if(_state == State.Closed)
            {
                throw new InvalidOperationException(Resources.DataReaderClosed);
            }
            if (_endpointsCounter >= _flightEndpoints.Count)
            {
                return Task.FromResult(false);
            }

            return LoadNextStream(cancellationToken);
        }

        /// <summary>
        /// Retrieves the next record batch from the server
        /// </summary>
        /// <returns></returns>
        private async Task<bool> ReadNextRecordBatch(CancellationToken cancellationToken)
        {
            var movedNext = await _stream.ResponseStream.MoveNext(cancellationToken).ConfigureAwait(false);
            if (movedNext)
            {
                _dataReader.ReadNewRecordBatch(_stream.ResponseStream.Current);
            }
            return movedNext;
        }

        public override bool Read()
        {
            if (_currentReader.Read())
            {
                return true;
            }

            if (_state == State.NotStarted)
            {
                //Set the current reader to the data reader
                _currentReader = _dataReader;
                _state = State.Reading;

                //Try and read from the initial record batch
                if (_currentReader.Read())
                {
                    return true;
                }
            }

            if (_state == State.Reading)
            {
                CancellationTokenSource tokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(1));
                if (AsyncHelper.RunSync(() => ReadNextRecordBatch(tokenSource.Token)) && _currentReader.Read())
                {
                    return true;
                }
                //Check if more there are more flight endpoints to get data from
                else if(_endpointsCounter < _flightEndpoints.Count)
                {
                    _state = State.ResultSetDone;
                    //Change the current reader to give message to read in the next result set.
                    _currentReader = EndOfResultSetDataReader;
                    return false;
                }
                //No more data in the current result set and no more result sets.
                else
                {
                    //Close this data reader
                    Close();
                    return false;
                }
            }

            //Check if the user is trying to call read() when a result set is done.
            if(_state == State.ResultSetDone)
            {
                throw new InvalidOperationException(Resources.EndOfResultSet);
            }

            //If the state is closed, the user should be notified
            if(_state == State.Closed)
            {
                throw new InvalidOperationException(Resources.DataReaderClosed);
            }

            throw new InvalidOperationException(Resources.UnknownDataReaderState(_state));
        }

        protected override void Dispose(bool disposing)
        {
            if (!disposing || _state == State.Closed)
            {
                return;
            }

            //Dispose the flight stream if it is not finished
            _stream.Dispose();

            //Set the current reader to an error reader, to produce errors
            _currentReader = new ReadErrorDataReader("Data reader is closed");
            _state = State.Closed;

            //Close the data reader
            _dataReader.Close();
        }

        public override void Close()
            => Dispose(true);
    }
}
