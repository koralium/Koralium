using Apache.Arrow;
using System;
using System.Collections.Generic;
using System.Text;

namespace Koralium.Transport.ArrowFlight.Encoders
{
    class FloatEncoder : IArrowEncoder
    {
        private FloatArray.Builder _builder;
        private readonly Func<object, object> _getFunc;
        private readonly bool _nullable;
        public FloatEncoder(Column column)
        {
            _getFunc = column.GetFunction;
            _nullable = column.IsNullable;
        }

        public IArrowArray BuildArray()
        {
            return _builder.Build();
        }

        public void NewBatch()
        {
            _builder = new FloatArray.Builder();
        }

        public void Encode(object row)
        {
            var val = _getFunc(row);

            if (_nullable && val == null)
            {
                _builder.AppendNull();

            }
            else
            {
                _builder.Append((float)val);
            }
        }

        public void Encode(IReadOnlyList<object> rows)
        {
            if (_nullable)
            {
                for (int i = 0; i < rows.Count; i++)
                {
                    var val = _getFunc(rows[i]);
                    if (val == null)
                    {
                        _builder.AppendNull();
                    }
                    else
                    {
                        _builder.Append((float)val);
                    }
                }
            }
            else
            {
                for (int i = 0; i < rows.Count; i++)
                {
                    var val = _getFunc(rows[i]);
                    _builder.Append((float)val);
                }
            }
        }

        public long Size()
        {
            return _builder.Length * 4;
        }
    }
}
