using Apache.Arrow.Flight;
using Data.Koralium.DataReaders;
using Data.Koralium.Internal;
using Grpc.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Threading;
using System.Threading.Tasks;

namespace Data.Koralium
{
    public class KoraliumCommand : DbCommand
    {
        private KoraliumParameterCollection _parameters;

        public override string CommandText { get; set; }
        public override int CommandTimeout { get; set; }

        internal DbDataReader DataReader { get; private set; }

        public override CommandType CommandType
        {
            get => CommandType.Text;
            set
            {
                if (value != CommandType.Text)
                {
                    throw new ArgumentException();
                }
            }
        }

        public override bool DesignTimeVisible { get; set; }
        public override UpdateRowSource UpdatedRowSource { get; set; }

        protected override DbConnection DbConnection
        {
            get
            {
                return KoraliumConnection;
            }
            set
            {
                KoraliumConnection = (KoraliumConnection)value;
            }
        }

        internal KoraliumConnection KoraliumConnection { get; private set; }

        public new virtual KoraliumParameterCollection Parameters
        {
            get
            {
                if (_parameters == null)
                {
                    _parameters = new KoraliumParameterCollection();
                }
                return _parameters;
            }
        }

        protected override DbParameterCollection DbParameterCollection => Parameters;

        protected override DbTransaction DbTransaction { get; set; }

        public override void Cancel()
            => Dispose(true);

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                DataReader?.Dispose();
            }
        }

        public override int ExecuteNonQuery()
        {
            using var reader = ExecuteDbDataReader(CommandBehavior.Default);
            return reader.RecordsAffected;
        }

        public override object ExecuteScalar()
        {
            using var reader = ExecuteDbDataReader(CommandBehavior.Default);

            return reader.Read()
                ? reader.GetValue(0)
                : null;
        }

        public override void Prepare()
        {
            //Prepare should get the flight tickets required
            throw new NotSupportedException();
        }

        protected override DbParameter CreateDbParameter()
        {
            return new KoraliumParameter();
        }

        protected override DbDataReader ExecuteDbDataReader(CommandBehavior behavior)
        {
            var tokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(CommandTimeout));
            return AsyncHelper.RunSync(() => ExecuteDbDataReaderAsync(behavior, tokenSource.Token));
        }

        protected override async Task<DbDataReader> ExecuteDbDataReaderAsync(CommandBehavior behavior, CancellationToken cancellationToken)
        {
            //Check so no other data reader has been open with this command
            if(DataReader != null)
            {
                throw new InvalidOperationException("Another data reader has already been opened");
            }

            Metadata metadata = new Metadata();

            if (!string.IsNullOrEmpty(KoraliumConnection.ConnectionOptions.AccessToken))
            {
                metadata.Add("Authorization", $"Bearer {KoraliumConnection.ConnectionOptions.AccessToken}");
            }

            if(_parameters != null)
            {
                foreach (var parameter in _parameters)
                {
                    var koraliumParameter = (KoraliumParameter)parameter;
                    metadata.Add($"P_{koraliumParameter.ParameterName}", koraliumParameter.Value.ToString());
                }
            }
            

            var endpoints = new List<FlightEndpoint>();
            endpoints.Add(new FlightEndpoint(new FlightTicket(CommandText), new List<FlightLocation>()));

            DataReader = new FlightEndpointsDataReader(this, endpoints, metadata);

            await DataReader.NextResultAsync();

            return DataReader;
        }
    }
}
