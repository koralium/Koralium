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
using Koralium.SqlToExpression.Exceptions;
using Koralium.SqlToExpression.Executors;
using Koralium.SqlToExpression.Metadata;
using Koralium.SqlToExpression.Models;
using Koralium.SqlToExpression.Stages;
using Koralium.SqlToExpression.Utils;
//using Koralium.SqlToExpression.Visitors;
using Koralium.SqlToExpression.Visitors;
using Microsoft.SqlServer.TransactSql.ScriptDom;
using System;
using System.Collections.Generic;
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

        private TSql150Parser  parser = new TSql150Parser(true);
        public SqlExecutor(
            TablesMetadata tablesMetadata,
            IQueryExecutor queryExecutor)
        {
            _tablesMetadata = tablesMetadata;
            _queryExecutor = queryExecutor;
            _stageConverter = new StageConverter();
        }

        public async ValueTask<object> ExecuteScalar(string sql, SqlParameters parameters = null, object data = null)
        {
            sql = OffsetLimitUtils.TransformQuery(sql);
            var tree = parser.Parse(new StringReader(sql), out var errors);
            var mainVisitor = new MainVisitor(new VisitorMetadata(parameters, _tablesMetadata));
            tree.Accept(mainVisitor);

            //Convert into execute stages
            var executeStages = _stageConverter.Convert(mainVisitor.Stages);

            try
            {
                var result = await _queryExecutor.Execute(executeStages, data);
                return result.Result.Cast<AnonType>()?.FirstOrDefault()?.P0;
            }
            catch (Exception e)
            {
                throw e;
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

            sql = OffsetLimitUtils.TransformQuery(sql);
            var tree = parser.Parse(new StringReader(sql), out var errors);
            var mainVisitor = new MainVisitor(new VisitorMetadata(parameters, _tablesMetadata));
            tree.Accept(mainVisitor);

            //Convert into execute stages
            var executeStages = _stageConverter.Convert(mainVisitor.Stages);

            try
            {
                return _queryExecutor.Execute(executeStages, data);
            }
            catch(Exception e)
            {
                throw e;
            }
            
        }
    }
}
