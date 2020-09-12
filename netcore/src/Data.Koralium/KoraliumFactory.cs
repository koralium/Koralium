using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace Data.Koralium
{
    public class KoraliumFactory : DbProviderFactory
    {
        private KoraliumFactory()
        {
        }

        public static readonly KoraliumFactory Instance = new KoraliumFactory();

        public override DbCommand CreateCommand()
            => new KoraliumCommand();

        public override DbConnection CreateConnection()
            => new KoraliumConnection();

        public override DbConnectionStringBuilder CreateConnectionStringBuilder()
            => new KoraliumConnectionStringBuilder();

        public override DbParameter CreateParameter()
            => new KoraliumParameter();
    }
}
