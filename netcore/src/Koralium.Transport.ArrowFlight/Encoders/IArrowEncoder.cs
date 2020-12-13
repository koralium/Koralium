﻿using Apache.Arrow;
using System;
using System.Collections.Generic;
using System.Text;

namespace Koralium.Transport.ArrowFlight.Encoders
{
    /// <summary>
    /// Interface for the encoders to take C# data into Apache Arrow format
    /// </summary>
    interface IArrowEncoder
    {
        /// <summary>
        /// Called when a new batch is started.
        /// This should create a new builder
        /// </summary>
        void NewBatch();

        IArrowArray BuildArray();

        void Encode(object row);

        void Encode(IReadOnlyList<object> rows);

        long Size();
    }
}