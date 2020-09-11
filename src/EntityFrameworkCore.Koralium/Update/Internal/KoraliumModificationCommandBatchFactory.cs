using Microsoft.EntityFrameworkCore.Update;
using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFrameworkCore.Koralium.Update.Internal
{
    public class KoraliumModificationCommandBatchFactory : IModificationCommandBatchFactory
    {
        private readonly ModificationCommandBatchFactoryDependencies _dependencies;

        public KoraliumModificationCommandBatchFactory(
              ModificationCommandBatchFactoryDependencies dependencies)
        {
            _dependencies = dependencies;
        }

        public ModificationCommandBatch Create()
        {
            return new SingularModificationCommandBatch(_dependencies);
        }
    }
}
