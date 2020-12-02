using Koralium.Shared;
using Koralium.SqlParser.Clauses;
using Koralium.SqlParser.From;
using Koralium.SqlParser.Visitor;
using Koralium.SqlToExpression.Metadata;
using Koralium.SqlToExpression.Models;
using Koralium.SqlToExpression.Stages.CompileStages;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Koralium.SqlToExpression.Visitors.From
{
    internal class FromVisitor : KoraliumSqlVisitor
    {
        private readonly VisitorMetadata _visitorMetadata;
        private TableMetadata _table;

        public TableMetadata Table => _table;
        public FromAliases FromAliases { get; } = new FromAliases();

        public IReadOnlyList<IQueryStage> Stages { get; private set; } = null;

        public FromVisitor(VisitorMetadata visitorMetadata)
        {
            _visitorMetadata = visitorMetadata;
        }

        public override void VisitFromClause(FromClause fromClause)
        {
            var tableReference = fromClause.TableReference;
            if (tableReference is FromTableReference namedTableReference)
            {
                var tableName = namedTableReference.TableName;
                Debug.Assert(tableName != null);

                if (!_visitorMetadata.TablesMetadata.TryGetTable(tableName, out _table))
                {
                    throw new SqlErrorException($"The table '{tableName}' was not found");
                }

                var alias = namedTableReference?.Alias;
                if (alias != null)
                {
                    FromAliases.AddAlias(alias);
                }
            }
            else if (tableReference is Subquery queryDerivedTable)
            {
                MainVisitor mainVisitor = new MainVisitor(_visitorMetadata);
                queryDerivedTable.Accept(mainVisitor);
                Stages = mainVisitor.Stages;

                var alias = queryDerivedTable?.Alias;
                if (alias != null)
                {
                    FromAliases.AddAlias(alias);
                }
            }
            else
            {
                throw new SqlErrorException("Subqueries or joins are not supported at this time");
            }
        }
    }
}
