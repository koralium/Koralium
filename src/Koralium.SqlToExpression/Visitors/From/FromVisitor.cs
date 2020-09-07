using Koralium.SqlToExpression.Exceptions;
using Koralium.SqlToExpression.Metadata;
using Koralium.SqlToExpression.Models;
using Koralium.SqlToExpression.Stages.CompileStages;
using Microsoft.SqlServer.TransactSql.ScriptDom;
using System.Collections.Generic;
using System.Diagnostics;

namespace Koralium.SqlToExpression.Visitors.From
{
    internal class FromVisitor : TSqlFragmentVisitor
    {
        private readonly VisitorMetadata _visitorMetadata;
        private IReadOnlyList<IQueryStage> _subStages = null;
        private TableMetadata _table;
        private FromAliases fromAliases = new FromAliases();

        public TableMetadata Table => _table;
        public FromAliases FromAliases => fromAliases;

        public IReadOnlyList<IQueryStage> Stages => _subStages;

        public FromVisitor(VisitorMetadata visitorMetadata)
        {
            _visitorMetadata = visitorMetadata;
        }

        public override void ExplicitVisit(FromClause fromClause)
        {
            foreach (var tableReference in fromClause.TableReferences)
            {
                //At this point no sub queries or joins are allowed
                if (tableReference is NamedTableReference namedTableReference)
                {
                    var tableName = namedTableReference.SchemaObject.BaseIdentifier.Value;
                    Debug.Assert(tableName != null);

                    if (!_visitorMetadata.TablesMetadata.TryGetTable(tableName, out _table))
                    {
                        throw new SqlErrorException($"The table '{tableName}' was not found");
                    }

                    var alias = namedTableReference?.Alias?.Value;
                    if (alias != null)
                    {
                        fromAliases.AddAlias(alias);
                    }
                }
                else if (tableReference is QueryDerivedTable queryDerivedTable)
                {
                    MainVisitor mainVisitor = new MainVisitor(_visitorMetadata);
                    queryDerivedTable.Accept(mainVisitor);
                    _subStages = mainVisitor.Stages;

                    var alias = queryDerivedTable?.Alias?.Value;
                    if (alias != null)
                    {
                        fromAliases.AddAlias(alias);
                    }
                }
                else
                {
                    throw new SqlErrorException("Subqueries or joins are not supported at this time");
                }
            }
        }
    }
}
