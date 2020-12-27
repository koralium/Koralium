
namespace Apache.Arrow.Ipc
{
    internal readonly struct Block
    {
        public readonly long Offset;
        public readonly long BodyLength;
        public readonly int MetadataLength;

        public Block(long offset, long length, int metadataLength)
        {
            Offset = offset;
            BodyLength = length;
            MetadataLength = metadataLength;
        }

        public Block(Flatbuf.Block block)
        {
            Offset = block.Offset;
            BodyLength = block.BodyLength;
            MetadataLength = block.MetaDataLength;
        }
    }
}
