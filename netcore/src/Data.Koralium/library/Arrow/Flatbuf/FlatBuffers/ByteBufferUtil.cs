
namespace FlatBuffers
{
	/// <summary>
	/// Class that collects utility functions around `ByteBuffer`.
	/// </summary>
	internal class ByteBufferUtil
	{
		// Extract the size prefix from a `ByteBuffer`.
		public static int GetSizePrefix(ByteBuffer bb) {
			return bb.GetInt(bb.Position);
		}

		// Create a duplicate of a size-prefixed `ByteBuffer` that has its position
		// advanced just past the size prefix.
		public static ByteBuffer RemoveSizePrefix(ByteBuffer bb) {
			ByteBuffer s = bb.Duplicate();
			s.Position += FlatBufferConstants.SizePrefixLength;
			return s;
		}
	}
}
