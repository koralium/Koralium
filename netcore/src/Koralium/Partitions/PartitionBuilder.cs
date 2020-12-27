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
using Koralium.Models;
using Koralium.Partitions;
using Koralium.SqlParser;
using Koralium.SqlParser.Expressions;
using Koralium.SqlParser.Statements;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Koralium
{
    public class PartitionBuilder
    {
        private StatementList _statementList;
        private readonly List<BooleanExpression> filters = new List<BooleanExpression>();
        private readonly List<ServiceLoction> serviceLoctions = new List<ServiceLoction>();
        internal PartitionBuilder(StatementList statementList)
        {
            _statementList = statementList;
        }

        public PartitionBuilder AddFilter(BooleanExpression booleanExpression)
        {
            //add the filter
            filters.Add(booleanExpression);
            return this;
        }

        public PartitionBuilder AddFilter<TEntity>(Expression<Func<TEntity, bool>> expression)
        {
            //add the filter
            AddFilter(QueryBuilder.BooleanExpression(expression));
            return this;
        }

        public PartitionBuilder AddServiceLocation(ServiceLoction serviceLoction)
        {
            serviceLoctions.Add(serviceLoction);
            return this;
        }

        public Partition Build()
        {
            if(filters.Count > 0)
            {
                var filter = QueryBuilder.And(filters);

                //Add the filter to the sql
                new PartitionFilterVisitor(filter).Visit(_statementList);
            }

            return new Partition(serviceLoctions, _statementList);
        }
    }
}
