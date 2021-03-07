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
using Koralium.Shared;
using Koralium.SqlParser;
using Koralium.SqlParser.Statements;
using Koralium.SqlToExpression.Executors;
using Koralium.SqlToExpression.Interfaces;
using Koralium.SqlToExpression.Metadata;
using Koralium.SqlToExpression.Models;
using Koralium.SqlToExpression.Stages;
using Koralium.SqlToExpression.Stages.CompileStages;
using Koralium.SqlToExpression.Utils;
using Koralium.SqlToExpression.Visitors;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Koralium.SqlToExpression
{
    public class SqlExecutor
    {
        private readonly TablesMetadata _tablesMetadata;
        private readonly StageConverter _stageConverter;
        private readonly IQueryExecutor _queryExecutor;
        private readonly ISearchExpressionProvider _searchExpressionProvider;
        private readonly IStringOperationsProvider _stringOperationsProvider;

        private readonly ISqlParser _sqlParser;
        public SqlExecutor(
            ISqlParser sqlParser,
            TablesMetadata tablesMetadata,
            IQueryExecutor queryExecutor,
            ISearchExpressionProvider searchExpressionProvider,
            IStringOperationsProvider stringOperationsProvider)
        {
            _sqlParser = sqlParser;
            _tablesMetadata = tablesMetadata;
            _queryExecutor = queryExecutor;
            _stageConverter = new StageConverter();
            _searchExpressionProvider = searchExpressionProvider;
            _stringOperationsProvider = stringOperationsProvider;
        }

        public async ValueTask<object> ExecuteScalar(string sql, SqlParameters parameters = null, object data = null)
        {
            sql = OffsetLimitUtils.TransformQuery(sql);
            var tree = _sqlParser.Parse(sql);
            var mainVisitor = new MainVisitor(new VisitorMetadata(parameters, _tablesMetadata, _searchExpressionProvider, _stringOperationsProvider));
            tree.Accept(mainVisitor);

            //Convert into execute stages
            var executeStages = _stageConverter.Convert(mainVisitor.Stages);

            var result = await _queryExecutor.Execute(executeStages, data);
            var enumerator = result.Result.GetEnumerator();
            if(!enumerator.MoveNext())
            {
                return null;
            }
            else
            {
                var obj = enumerator.Current;

                return AnonTypeUtils.GetDelegates(obj.GetType())[0](obj);
            }
        }

        private IReadOnlyList<IQueryStage> GetStages(string sql, SqlParameters parameters)
        {
            if (string.IsNullOrEmpty(sql))
            {
                throw new SqlErrorException("Empty query string");
            }

            var tree = _sqlParser.Parse(sql, out var errors);

            if (errors.Count > 0)
            {
                var firstError = errors.FirstOrDefault();
                throw new SqlErrorException(firstError.Message);
            }

            var mainVisitor = new MainVisitor(new VisitorMetadata(parameters, _tablesMetadata, _searchExpressionProvider, _stringOperationsProvider));
            tree.Accept(mainVisitor);

            return mainVisitor.Stages;
        }

        private IReadOnlyList<IQueryStage> GetStages(StatementList tree, SqlParameters parameters)
        {
            var mainVisitor = new MainVisitor(new VisitorMetadata(parameters, _tablesMetadata, _searchExpressionProvider, _stringOperationsProvider));
            tree.Accept(mainVisitor);

            return mainVisitor.Stages;
        }

        public SchemaResult GetSchema(string sql, SqlParameters parameters = null)
        {
            var stages = GetStages(sql, parameters);

            var schemaCreator = new SchemaCreatorVisitor();
            return schemaCreator.GetSchema(stages);
        }

        public SchemaResult GetSchema(StatementList tree, SqlParameters parameters = null)
        {
            var stages = GetStages(tree, parameters);
            var schemaCreator = new SchemaCreatorVisitor();
            return schemaCreator.GetSchema(stages);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <param name="data">Additional data that one wants to send to the table resolver</param>
        /// <returns></returns>
        public ValueTask<QueryResult> Execute(string sql, SqlParameters parameters = null, object data = null)
        {
            var stages = GetStages(sql, parameters);

            //Convert into execute stages
            var executeStages = _stageConverter.Convert(stages);

            return _queryExecutor.Execute(executeStages, data);
        }

        public ValueTask<QueryResult> Execute(StatementList statementList, SqlParameters parameters = null, object data = null)
        {
            var stages = GetStages(statementList, parameters);

            //Convert into execute stages
            var executeStages = _stageConverter.Convert(stages);

            return _queryExecutor.Execute(executeStages, data);
        }
    }
}
