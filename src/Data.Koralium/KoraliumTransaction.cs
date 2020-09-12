using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;

namespace Data.Koralium
{
    public class KoraliumTransaction : DbTransaction
    {
        private readonly KoraliumConnection _connection;
        private readonly IsolationLevel _isolationLevel;

        public override IsolationLevel IsolationLevel => _isolationLevel;

        protected override DbConnection DbConnection => _connection;

        internal KoraliumTransaction(KoraliumConnection connection, IsolationLevel isolationLevel)
        {
            _connection = connection;
            _isolationLevel = isolationLevel;
        }


        public override void Commit()
        {
            throw new NotImplementedException();
        }

        public override void Rollback()
        {
            throw new NotImplementedException();
        }
    }
}
