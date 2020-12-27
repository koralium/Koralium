using System.IO;
using System.Threading;
using Apache.Arrow.Flatbuf;
using Apache.Arrow.Ipc;
using Google.Protobuf;

namespace Apache.Arrow.Flight.Internal
{
    /// <summary>
    /// This class handles writing schemas
    /// </summary>
    internal class SchemaWriter : ArrowStreamWriter
    {
        private SchemaWriter(Stream baseStream, Schema schema) : base(baseStream, schema)
        {
        }

        public void WriteSchema(Schema schema, CancellationToken cancellationToken)
        {
            var offset = base.SerializeSchema(schema);
            WriteMessage(MessageHeader.Schema, offset, 0);
        }

        public static ByteString SerializeSchema(Schema schema, CancellationToken cancellationToken = default(CancellationToken))
        {
            using(var memoryStream = new MemoryStream())
            {
                var writer = new SchemaWriter(memoryStream, schema);
                writer.WriteSchema(schema, cancellationToken);

                memoryStream.Position = 0;
                return ByteString.FromStream(memoryStream);
            }
        }
    }
}
