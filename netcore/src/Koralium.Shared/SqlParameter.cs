using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace Koralium.Shared
{
    public abstract class SqlParameter
    {
        public string Name { get; }

        protected SqlParameter(string name)
        {
            Name = name;
        }

        internal abstract Expression GetValueAsExpression();


        public static SqlParameter<T> Create<T>(string name, T value)
        {
            return new SqlParameter<T>(name, value);
        }

        public abstract bool TryGetValue<TValue>(out TValue value);

        public abstract object GetValue();

        public abstract Type GetValueType();
    }

    public class SqlParameter<T> : SqlParameter
    {
        public T Value { get; }

        public SqlParameter(string name, T value) : base(name)
        {
            Value = value;
        }

        internal override Expression GetValueAsExpression()
        {
            return GetMemberAccess(Expression.Constant(this));
        }

        private readonly static MemberInfo ValueMemberInfo = typeof(SqlParameter<T>).GetProperty("Value");
        private static Expression GetMemberAccess(Expression parameter) => Expression.MakeMemberAccess(parameter, ValueMemberInfo);

        public override bool TryGetValue<TValue>(out TValue value)
        {
            if (!(Value is TValue))
            {
                value = default(TValue);
                return false;
            }
            value = (TValue)Convert.ChangeType(Value, typeof(TValue));
            return true;
        }

        public override object GetValue()
        {
            return Value;
        }

        public override Type GetValueType()
        {
            return typeof(T);
        }
    }
}
