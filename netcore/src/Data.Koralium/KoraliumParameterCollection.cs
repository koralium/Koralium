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
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace Data.Koralium
{
    public class KoraliumParameterCollection : DbParameterCollection
    {
        private readonly List<KoraliumParameter> _parameters = new List<KoraliumParameter>();

        protected internal KoraliumParameterCollection()
        {
        }

        public new virtual KoraliumParameter this[int index]
        {
            get => _parameters[index];
            set
            {
                if (_parameters[index] == value)
                {
                    return;
                }

                _parameters[index] = value;
            }
        }

        public new virtual KoraliumParameter this[string parameterName]
        {
            get => this[IndexOfChecked(parameterName)];
            set => this[IndexOfChecked(parameterName)] = value;
        }


        public override int Count => _parameters.Count;

        public override object SyncRoot => ((ICollection)_parameters).SyncRoot;

        public override int Add(object value)
        {
            _parameters.Add((KoraliumParameter)value);

            return Count - 1;
        }

        public virtual KoraliumParameter Add(KoraliumParameter value)
        {
            _parameters.Add(value);

            return value;
        }

        public override void AddRange(Array values)
        {
            AddRange(values.Cast<KoraliumParameter>());
        }

        public virtual void AddRange(IEnumerable<KoraliumParameter> values)
            => _parameters.AddRange(values);

        public override void Clear()
        {
            _parameters.Clear();
        }

        public override bool Contains(object value)
            => Contains((KoraliumParameter)value);

        public virtual bool Contains(KoraliumParameter value)
            => _parameters.Contains(value);

        public override bool Contains(string value) => IndexOf(value) != -1;

        public override void CopyTo(Array array, int index)
            => CopyTo((KoraliumParameter[])array, index);

        public virtual void CopyTo(KoraliumParameter[] array, int index)
            => _parameters.CopyTo(array, index);

        public override IEnumerator GetEnumerator() => _parameters.GetEnumerator();

        public override int IndexOf(object value)
            => IndexOf((KoraliumParameter)value);

        public virtual int IndexOf(KoraliumParameter value)
            => _parameters.IndexOf(value);


        public override int IndexOf(string parameterName)
        {
            for (var index = 0; index < _parameters.Count; index++)
            {
                if (_parameters[index].ParameterName == parameterName)
                {
                    return index;
                }
            }

            return -1;
        }

        public override void Insert(int index, object value)
            => Insert(index, (KoraliumParameter)value);

        public virtual void Insert(int index, KoraliumParameter value)
            => _parameters.Insert(index, value);

        public override void Remove(object value)
            => Remove((KoraliumParameter)value);

        public virtual void Remove(KoraliumParameter value)
            => _parameters.Remove(value);

        public override void RemoveAt(int index)
            => _parameters.RemoveAt(index);

        public override void RemoveAt(string parameterName)
            => RemoveAt(IndexOfChecked(parameterName));

        protected override DbParameter GetParameter(int index)
            => this[index];

        protected override DbParameter GetParameter(string parameterName)
            => GetParameter(IndexOfChecked(parameterName));

        protected override void SetParameter(int index, DbParameter value)
            => this[index] = (KoraliumParameter)value;

        protected override void SetParameter(string parameterName, DbParameter value)
            => SetParameter(IndexOfChecked(parameterName), value);

        private int IndexOfChecked(string parameterName)
        {
            var index = IndexOf(parameterName);
            if (index == -1)
            {
                throw new IndexOutOfRangeException();
            }

            return index;
        }
    }
}
