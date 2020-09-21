using System;
using System.Collections.Generic;
using System.Text;

namespace Koralium.Interfaces
{
    public interface ICustomMetadataStore
    {
        void AddMetadata<T>(string name, T value);
    }
}
