﻿/*
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
using Koralium.SqlParser.Visitor;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Koralium.SqlParser.Expressions
{
    public class FunctionCall : ScalarExpression
    {
        public string FunctionName { get; set; }

        /// <summary>
        /// Is a wildcard used as parameter?
        /// </summary>
        public bool Wildcard { get; set; }

        public List<SqlExpression> Parameters { get; set; }

        public FunctionCall()
        {
            Parameters = new List<SqlExpression>();
        }

        public override void Accept(KoraliumSqlVisitor visitor)
        {
            visitor.VisitFunctionCall(this);
        }

        public override SqlNode Clone()
        {
            return new FunctionCall()
            {
                FunctionName = FunctionName,
                Parameters = Parameters.Select(x => x.Clone() as SqlExpression).ToList(),
                Wildcard = Wildcard
            };
        }

        public override int GetHashCode()
        {
            var hashCode = new HashCode();
            hashCode.Add(FunctionName);
            hashCode.Add(Wildcard);

            foreach (var parameter in Parameters)
            {
                hashCode.Add(parameter);
            }
            return hashCode.ToHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj is FunctionCall other)
            {
                return Equals(FunctionName, other.FunctionName) &&
                    Equals(Wildcard, other.Wildcard) &&
                    Parameters.AreEqual(other.Parameters);
            }
            return false;
        }
    }
}
