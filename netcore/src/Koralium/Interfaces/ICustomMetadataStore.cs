
namespace Koralium.Interfaces
{
    public interface ICustomMetadataStore
    {
        void AddMetadata<T>(string name, T value);
    }
}
