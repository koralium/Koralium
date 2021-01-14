﻿using Apache.Arrow;
using System;
using System.Collections.Generic;
using System.Text;

namespace Koralium.Transport.ArrowFlight.Encoders
{
    class UInt8Encoder : IArrowEncoder
    {
        private UInt8Array.Builder _builder;
        private readonly Func<object, object> _getFunc;
        private readonly bool _nullable;

        public UInt8Encoder(Column column)
        {
            _getFunc = column.GetFunction;
            _nullable = column.IsNullable;
        }

        public IArrowArray BuildArray()
        {
            return _builder.Build();
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
                _builder.Append((byte)val);
            }
        }

        public void NewBatch()
        {
            _builder = new UInt8Array.Builder();
        }

        public void Pad(int length)
        {
            if (_nullable)
            {
                for (int i = 0; i < length; i++)
                {
                    _builder.AppendNull();
                }
            }
            else
            {
                for (int i = 0; i < length; i++)
                {
                    _builder.Append(0);
                }
            }
        }

        public long Size()
        {
            return _builder.Length * 1;
        }
    }
}