using System.Linq;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace Moonfish.Graphics
{
    internal class Box : TriangleBatch
    {
        public int ElementCount { get; private set; }
        public PrimitiveType PrimitiveType { get; private set; }

        public Box(Vector3 min, Vector3 max)
        {
            PrimitiveType = PrimitiveType.Lines;

            var coordinates = new Vector3[8];
            coordinates[0] = min;
            coordinates[1] = new Vector3(max[0], min[1], min[2]);
            coordinates[2] = new Vector3(min[0], max[1], min[2]);
            coordinates[3] = new Vector3(max[0], max[1], min[2]);
            coordinates[4] = max;
            coordinates[5] = new Vector3(min[0], max[1], max[2]);
            coordinates[6] = new Vector3(max[0], min[1], max[2]);
            coordinates[7] = new Vector3(min[0], min[1], max[2]);
            var indices = new ushort[]
            {
                0, 1,
                0, 2,
                0, 7,
                7, 5,
                7, 6,
                4, 6,
                4, 5,
                3, 1,
                3, 2,
                3, 4,
                5, 2,
                6, 1,
            };
            ElementCount = indices.Length;

            using (Begin())
            {
                GenerateBuffer();
                BindBuffer(BufferTarget.ArrayBuffer, BufferIdents.Last());
                VertexAttribArray(0, 3, VertexAttribPointerType.Float);
                BufferVertexAttributeData(coordinates, BufferUsageHint.StaticDraw );

                GenerateBuffer();
                BindBuffer(BufferTarget.ElementArrayBuffer, BufferIdents.Last());
                BufferElementArrayData(indices);
            }
        }

        public void Resize(Vector3 min, Vector3 max)
        {
            var coordinates = new[]
            {
                min,
                new Vector3(max[0], min[1], min[2]),
                new Vector3(min[0], max[1], min[2]),
                new Vector3(max[0], max[1], min[2]),
                max,
                new Vector3(min[0], max[1], max[2]),
                new Vector3(max[0], min[1], max[2]),
                new Vector3(min[0], min[1], max[2])
            };

            using (Begin())
            {
                BindBuffer(BufferTarget.ArrayBuffer, BufferIdents.First());
                BufferVertexAttributeData(coordinates, BufferUsageHint.StaticDraw );
            }
        }
    }
}