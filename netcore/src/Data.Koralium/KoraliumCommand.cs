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
using Data.Koralium.Client;
using Data.Koralium.Client.Decoders;
using System;
using System.Data;
using System.Data.Common;
using System.Threading;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Data.Koralium
{
    public class KoraliumCommand : DbCommand
    {
        private KoraliumParameterCollection _parameters;
        private KoraliumConnection _koraliumConnection;
        private KoraliumClient client = null;
        private Channel<KoraliumRow> channel = null;
        private Task executeTask = null;
        private readonly CancellationTokenSource cancellationToken = new CancellationTokenSource();

        public override string CommandText { get; set; }
        public override int CommandTimeout { get; set; }

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

        public override bool DesignTimeVisible { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override UpdateRowSource UpdatedRowSource { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        protected override DbConnection DbConnection
        {
            get
            {
                return _koraliumConnection;
            }
            set
            {
                _koraliumConnection = (KoraliumConnection)value;
            }
        }

        internal KoraliumConnection KoraliumConnection => _koraliumConnection;

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
        {
            cancellationToken.Cancel();
            executeTask.Wait();
        }

        public override int ExecuteNonQuery()
        {
            throw new NotImplementedException();
        }

        public override object ExecuteScalar()
        {
            client = new KoraliumClient(KoraliumConnection.Channel, cancellationToken.Token);
            return client.QueryScalar(CommandText);
        }

        public override void Prepare()
        {
            throw new NotSupportedException();
        }

        protected override DbParameter CreateDbParameter()
        {
            return new KoraliumParameter();
        }

        protected override DbDataReader ExecuteDbDataReader(CommandBehavior behavior)
        {
            client = new KoraliumClient(KoraliumConnection.Channel, cancellationToken.Token);
            channel = Channel.CreateUnbounded<KoraliumRow>();
            executeTask = client.Query(CommandText, channel.Writer);
            client.MetadataCollected.Wait(cancellationToken.Token); //Wait for metadata to be collected
            return new KoraliumDataReader(client, channel.Reader, cancellationToken.Token);
        }
    }
}
