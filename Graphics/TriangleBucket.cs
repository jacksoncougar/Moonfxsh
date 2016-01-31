namespace Moonfish.Graphics
{
    public class TriangleBucket : VertexArrayObject
    {
        public TriangleBucket( VertexAttributeType vertexDataFormat )
        {
            VertexDataFormat = vertexDataFormat;
        }

        public VertexAttributeType VertexDataFormat { get; private set; }
    }
}