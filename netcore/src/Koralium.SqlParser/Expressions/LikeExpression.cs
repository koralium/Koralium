﻿using Koralium.SqlParser.Visitor;
using System;
using System.Collections.Generic;
using System.Text;

namespace Koralium.SqlParser.Expressions
{
    public class LikeExpression : BooleanExpression
    {
        public ScalarExpression Left { get; set; }

        public ScalarExpression Right { get; set; }

        public override void Accept(KoraliumSqlVisitor visitor)
        {
            visitor.VisitLikeExpression(this);
        }
    }
}