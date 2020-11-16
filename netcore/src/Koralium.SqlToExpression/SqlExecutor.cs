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
using Koralium.SqlParser;
using Koralium.SqlParser.ANTLR;
using Koralium.SqlToExpression.Exceptions;
using Koralium.SqlToExpression.Executors;
using Koralium.SqlToExpression.Interfaces;
using Koralium.SqlToExpression.Metadata;
using Koralium.SqlToExpression.Models;
using Koralium.SqlToExpression.Stages;
using Koralium.SqlToExpression.Utils;
using Koralium.SqlToExpression.Visitors;
using Microsoft.SqlServer.TransactSql.ScriptDom;
using System;
using System.IO;
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <param name="data">Additional data that one wants to send to the table resolver</param>
        /// <returns></returns>
        public ValueTask<QueryResult> Execute(string sql, SqlParameters parameters = null, object data = null)
        {
            if (string.IsNullOrEmpty(sql))
            {
                throw new SqlErrorException("Empty query string");
            }

            var tree = _sqlParser.Parse(sql);

            var mainVisitor = new MainVisitor(new VisitorMetadata(parameters, _tablesMetadata, _searchExpressionProvider, _stringOperationsProvider));
            tree.Accept(mainVisitor);

            //Convert into execute stages
            var executeStages = _stageConverter.Convert(mainVisitor.Stages);

            return _queryExecutor.Execute(executeStages, data);
        }
    }
}
