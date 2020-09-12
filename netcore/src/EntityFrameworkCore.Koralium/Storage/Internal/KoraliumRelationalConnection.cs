using Data.Koralium;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace EntityFrameworkCore.Koralium.Storage.Internal
{
    public class KoraliumRelationalConnection : RelationalConnection
    {
        public KoraliumRelationalConnection(RelationalConnectionDependencies dependencies) : base(dependencies)
        {
        }

        protected override DbConnection CreateDbConnection()
        {
            var conn = new KoraliumConnection();
            conn.ConnectionString = this.ConnectionString;
            return conn;
        }
    }
}
