using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFrameworkCore.Koralium.Storage.Internal
{
    public class KoraliumSqlGenerationHelper : RelationalSqlGenerationHelper
    {
        public KoraliumSqlGenerationHelper(RelationalSqlGenerationHelperDependencies dependencies) : base(dependencies)
        {
        }
    }
}
