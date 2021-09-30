using Koralium.SqlToExpression.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Koralium.SqlToExpression.Metadata
{
    public class StoredProcedureMetadata
    {
        public string Name { get; }

        public Type Type { get; }

        public IOperationsProvider OperationsProvider { get; }

        public StoredProcedureMetadata(
            string name,
            Type type,
            IOperationsProvider operationsProvider = null)
        {
            Name = name;
            Type = type;
            OperationsProvider = operationsProvider;
        }
    }
}
