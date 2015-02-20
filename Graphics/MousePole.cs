using Moonfish.Collision;
using Moonfish.Tags;
using OpenTK;
using OpenTK.Graphics.ES30;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Moonfish.Graphics
{
    struct Conic_
    {
        public IList<Vector3> VertexCoordinates { get; private set; }
        public IList<ushort> Indices { get; private set; }

        public Conic_(float height, float width, int sideCount = 16)
            : this(default(Vector3), height, width, sideCount)
        {
        }
        private Conic_(Vector3 origin, float height, float width, int sideCount = 16)
            : this()
        {
            var coordinates = new List<Vector3>();
            var baseCoordinate = origin;
            var apexCoordinate = origin + Vector3.UnitZ * height;

            var circleCoordinates = GenerateCircleCoordinates(width / 2, origin, sideCount);

            coordinates = new List<Vector3>(circleCoordinates.Length + 2);
            coordinates.Add(baseCoordinate);
            coordinates.Add(apexCoordinate);
            coordinates.AddRange(circleCoordinates);

            var indices = GenerateIndices(coordinates.Count);

            this.VertexCoordinates = coordinates;
            this.Indices = indices;
        }

        private static IList<ushort> GenerateIndices(int vertexCount)
        {
            var indices = new List<ushort>();
            var count = (ushort)(vertexCount - 2);
            const ushort offset = 1;
            indices.Add(0);
            for (ushort i = (ushort)(count + offset); i > offset; --i)
            {
                indices.Add(i);
            }
            indices.Add((ushort)(count + offset));
            indices.Add(ushort.MaxValue); // Primitive reset index            
            indices.Add(1);
            for (ushort i = offset + 1; i <= (ushort)(count + offset); ++i)
            {
                indices.Add(i);
            }
            indices.Add(offset + 1);
            return indices;
        }
        private static Vector3[] GenerateCircleCoordinates(float radius, Vector3 origin, int sideCount = 16)
        {
            float theta = 2 * (float)Math.PI / (float)sideCount;
            float cosine = (float)Math.Cos(theta);//precalculate the sine and cosine
            float sine = (float)Math.Sin(theta);

            float x = radius;//we start at angle = 0 
            float y = 0;
            float t;

            Vector3[] coorindates = new Vector3[sideCount];
            for (int i = 0; i < sideCount; i++)
            {
                //output vertex
                coorindates[i] = origin + new Vector3(x, y, 0);

                //apply the rotation matrix
                t = x;
                x = cosine * x - sine * y;
                y = sine * t + cosine * y;
            }
            return coorindates;
        }
    }
}
