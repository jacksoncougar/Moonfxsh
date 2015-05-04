using System;
using System.Collections.Generic;
using OpenTK;

namespace Moonfish.Graphics
{
    internal struct Conic
    {
        public IList<Vector3> VertexCoordinates { get; private set; }
        public IList<ushort> Indices { get; private set; }

        public Conic(float height, float width, int sideCount = 16)
            : this(default(Vector3), height, width, sideCount)
        {
        }

        private Conic(Vector3 origin, float height, float width, int sideCount = 16)
            : this()
        {
            var baseCoordinate = origin;
            var apexCoordinate = origin + Vector3.UnitZ*height;

            var circleCoordinates = GenerateCircleCoordinates(width/2, origin, sideCount);

            var coordinates = new List<Vector3>(circleCoordinates.Length + 2) {baseCoordinate, apexCoordinate};
            coordinates.AddRange(circleCoordinates);

            var indices = GenerateIndices((ushort) coordinates.Count);

            VertexCoordinates = coordinates;
            Indices = indices;
        }

        private static IList<ushort> GenerateIndices(ushort vertexCount)
        {
            var indices = new List<ushort>();
            var count = vertexCount - 2;
            const ushort offset = 1;
            indices.Add(0);
            for (var i = (ushort) (count + offset); i > offset; --i)
            {
                indices.Add(i);
            }
            indices.Add((ushort) (count + offset));
            indices.Add(ushort.MaxValue); // Primitive reset index            
            indices.Add(1);
            for (ushort i = offset + 1; i <= (ushort) (count + offset); ++i)
            {
                indices.Add(i);
            }
            indices.Add(offset + 1);
            return indices;
        }

        private static Vector3[] GenerateCircleCoordinates(float radius, Vector3 origin, int sideCount = 16)
        {
            var theta = 2*(float) Math.PI/(float) sideCount;
            var cosine = (float) Math.Cos(theta); //precalculate the sine and cosine
            var sine = (float) Math.Sin(theta);

            var x = radius; //we start at angle = 0 
            var y = 0.0f;

            var coorindates = new Vector3[sideCount];
            for (var i = 0; i < sideCount; i++)
            {
                //output vertex
                coorindates[i] = origin + new Vector3(x, y, 0);

                //apply the rotation matrix
                var t = x;
                x = cosine*x - sine*y;
                y = sine*t + cosine*y;
            }
            return coorindates;
        }
    }
}