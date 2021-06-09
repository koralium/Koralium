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
using Koralium.Shared.Utils;
using System;
using System.Linq.Expressions;
using System.Reflection;

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

        public abstract bool TryGetValue(Type type, out object value);

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
                try
                {
                    value = (TValue)Convert.ChangeType(Value, typeof(TValue));
                    return true;
                }
                catch (FormatException)
                {
                    value = default;
                    return false;
                }
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

        public override bool TryGetValue(Type type, out object value)
        {
            if(Equals(typeof(T), type))
            {
                value = Value;
                return true;
            }
            return TypeConvertUtils.TryConvertToType(Value, type, out value);
        }
    }
}
