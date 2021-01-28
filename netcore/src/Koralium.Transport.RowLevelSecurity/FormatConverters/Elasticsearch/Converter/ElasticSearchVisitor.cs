using Koralium.SqlParser;
using Koralium.SqlParser.Expressions;
using Koralium.SqlParser.Literals;
using Koralium.SqlParser.Visitor;
using Koralium.Transport.RowLevelSecurity.FormatConverters.Elasticsearch.Models;
using System.Collections.Generic;
using System.Text;

namespace Koralium.Transport.RowLevelSecurity.FormatConverters.Elasticsearch
{
    class ElasticSearchVisitor : KoraliumSqlVisitor
    {
        private readonly ElasticSearchOptions _elasticSearchOptions;
        private readonly Stack<BoolOperation> _stack = new Stack<BoolOperation>();

        public ElasticSearchVisitor(ElasticSearchOptions elasticSearchOptions)
        {
            _elasticSearchOptions = elasticSearchOptions;
        }

        public Bool GetBool()
        {
            if (_stack.Count == 0)
            {
                return new Bool();
            }
            else
            {
                var op = _stack.Peek();
                if (op is Bool b)
                {
                    return b;
                }
                else
                {
                    return new Bool()
                    {
                        Must = new List<BoolOperation>()
                        {
                            op
                        }
                    };
                }
            }
        }

        private object GetTerm(object val)
        {
            if (val is string s && _elasticSearchOptions.LowerCaseStringValues)
            {
                return s.ToLower();
            }
            return val;
        }

        private BoolOperation VisitPop(SqlNode sqlNode)
        {
            Visit(sqlNode);
            return _stack.Pop();
        }

        private void Push(BoolOperation boolOperation)
        {
            _stack.Push(boolOperation);
        }

        public override void VisitBooleanBinaryExpression(BooleanBinaryExpression booleanBinaryExpression)
        {
            var left = VisitPop(booleanBinaryExpression.Left);
            var right = VisitPop(booleanBinaryExpression.Right);
            Bool b = new Bool();
            switch (booleanBinaryExpression.Type)
            {
                case BooleanBinaryType.AND:
                    b.Must = new List<BoolOperation>()
                    {
                        left,
                        right
                    };
                    break;
                case BooleanBinaryType.OR:
                    b.Should = new List<BoolOperation>()
                    {
                        left,
                        right
                    };
                    break;
            }
            Push(b);
        }

        private (string fieldName, object value) CheckComparisonArguments(ScalarExpression left, ScalarExpression right)
        {
            ColumnReference columnReference = null;
            object value = null;
            if (left is ColumnReference leftColumn)
            {
                columnReference = leftColumn;
            }
            if (right is ColumnReference rightColumn)
            {
                if (columnReference != null)
                {
                    //TODO: Fix exception
                    throw new System.Exception("Elasticsearch filter can not compare two columns");
                }
                columnReference = rightColumn;
            }
            if (left is Literal leftLiteral)
            {
                value = leftLiteral.GetValue();
            }
            if (right is Literal rightLiteral)
            {
                value = rightLiteral.GetValue();
            }
            if (columnReference == null || value == null)
            {
                throw new System.Exception("Comparisions for elasticsearch filter must contain only a column and a value");
            }
            return (string.Join(".", columnReference.Identifiers), value);
        }

        public override void VisitBooleanComparisonExpression(BooleanComparisonExpression booleanComparisonExpression)
        {
            var (fieldName, value) = CheckComparisonArguments(booleanComparisonExpression.Left, booleanComparisonExpression.Right);
            switch (booleanComparisonExpression.Type)
            {
                case BooleanComparisonType.Equals:
                    Push(new Term()
                    {
                        FieldName = fieldName,
                        Value = GetTerm(value)
                    });
                    break;
                case BooleanComparisonType.GreaterThan:
                    Push(new Range()
                    {
                        FieldName = fieldName,
                        GreaterThan = GetTerm(value)
                    });
                    break;
                case BooleanComparisonType.GreaterThanOrEqualTo:
                    Push(new Range()
                    {
                        FieldName = fieldName,
                        GreaterThanEqual = GetTerm(value)
                    });
                    break;
                case BooleanComparisonType.LessThan:
                    Push(new Range()
                    {
                        FieldName = fieldName,
                        LessThan = GetTerm(value)
                    });
                    break;
                case BooleanComparisonType.LessThanOrEqualTo:
                    Push(new Range()
                    {
                        FieldName = fieldName,
                        LessThanEqual = GetTerm(value)
                    });
                    break;
                case BooleanComparisonType.NotEqualTo:
                    Push(new Bool()
                    {
                        MustNot = new List<BoolOperation>()
                        {
                            new Term()
                            {
                                FieldName = fieldName,
                                Value = GetTerm(value),
                            }
                        }
                    });
                    break;
            }
        }

        public override void VisitNotExpression(NotExpression notExpression)
        {
            var op = VisitPop(notExpression.BooleanExpression);
            Push(new Bool()
            {
                MustNot = new List<BoolOperation>()
                {
                    op
                }
            });
        }

        public override void VisitInExpression(InExpression inExpression)
        {
            if (!(inExpression.Expression is ColumnReference column))
            {
                //TODO: Fix exception
                throw new System.Exception("In expressions can only be done on columns for elasticseach filters");
            }

            List<object> values = new List<object>();
            foreach(var val in inExpression.Values)
            {
                if (!(val is Literal literal))
                {
                    throw new System.Exception("In expression can only have literals as valeus for elasticsearch filters");
                }
                values.Add(GetTerm(literal.GetValue()));
            }
            Push(new Terms()
            {
                FieldName = string.Join(".", column.Identifiers),
                Values = values
            });
        }

        public override void VisitBinaryExpression(BinaryExpression binaryExpression)
        {
            throw new System.Exception("Binary expressions are not supported in elasticsearch filters");
        }
    }
}
