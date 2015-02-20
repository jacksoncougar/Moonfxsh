using Moonfish.Collision;
using Moonfish.Guerilla.Tags;
using OpenTK;
using OpenTK.Graphics.ES30;
using OpenTK.Input;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace Moonfish.Graphics
{
    class Box : Primitive, IRenderable, IDisposable
    {
        int vao, arrayBuffer, elementBuffer;
        int elementCount;

        public Box(Vector3 min, Vector3 max)
        {
            var coordinates = new Vector3[8];
            coordinates[0] = min;
            coordinates[1] = new Vector3(max[0], min[1], min[2]);
            coordinates[2] = new Vector3(min[0], max[1], min[2]);
            coordinates[3] = new Vector3(max[0], max[1], min[2]);
            coordinates[4] = max;
            coordinates[5] = new Vector3(min[0], max[1], max[2]);
            coordinates[6] = new Vector3(max[0], min[1], max[2]);
            coordinates[7] = new Vector3(min[0], min[1], max[2]);
            ushort[] indices = new ushort[]{
                0,1,
                0,2,
                0,7,
                7,5,
                7,6,
                4,6,
                4,5,
                3,1,
                3,2,
                3,4,
                5,2,
                6,1,
            };
            this.elementCount = indices.Length;
            vao = GL.GenVertexArray();
            arrayBuffer = GL.GenBuffer();
            elementBuffer = GL.GenBuffer();
            GL.BindVertexArray(vao);

            GL.BindBuffer(BufferTarget.ArrayBuffer, arrayBuffer);
            GL.BufferData(BufferTarget.ArrayBuffer, (IntPtr)(Vector3.SizeInBytes * coordinates.Length), coordinates, BufferUsageHint.StaticDraw);

            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 0, 0);
            GL.EnableVertexAttribArray(0);

            GL.BindBuffer(BufferTarget.ElementArrayBuffer, elementBuffer);
            GL.BufferData(BufferTarget.ElementArrayBuffer, (IntPtr)(sizeof(ushort) * indices.Length), indices, BufferUsageHint.StaticDraw);

        }

        public void Render(IEnumerable<Program> shaderPasses)
        {
            GL.BindVertexArray(vao);
            GL.DrawElements(PrimitiveType.Lines, elementCount, DrawElementsType.UnsignedShort, IntPtr.Zero);
        }

        public void Render(IEnumerable<Program> shaderPasses, IList<IH2ObjectInstance> instances)
        {
            throw new NotImplementedException();
        }

        void IDisposable.Dispose()
        {
            GL.DeleteVertexArray(vao);
            GL.DeleteBuffer(arrayBuffer);
            GL.DeleteBuffer(elementBuffer);
        }
    }
 
    public class Primitive : IDisposable
    {
        protected int elementBufferOffset;
        protected int elementCount;

        protected int arrayBufferOffset;
        protected int arrayBufferCount;
        protected int arrayBufferStride;

        public virtual int ArrayBufferLength { get; protected set; }
        public virtual int ElementBufferLength { get; protected set; }

        protected void BufferPrimitiveData(IList<byte> coordinates, IList<ushort> indices, int stride, int arrayBuffer, ref int arrayBufferOffset, int elementBuffer, ref int elementBufferOffset)
        {
            int lengthOfElementData = indices.Count * sizeof(ushort),
                lengthOfArrayData = coordinates.Count;

            this.arrayBufferOffset = arrayBufferOffset;
            this.arrayBufferCount = lengthOfArrayData / stride;
            this.arrayBufferStride = stride;

            this.elementBufferOffset = elementBufferOffset;
            this.elementCount = indices.Count;

            GL.BindBuffer(BufferTarget.ArrayBuffer, arrayBuffer);
            GL.BufferSubData(BufferTarget.ArrayBuffer, (IntPtr)arrayBufferOffset, (IntPtr)(lengthOfArrayData), coordinates.ToArray());

            var check = GL.GetError();
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, elementBuffer);
            GL.BufferSubData(BufferTarget.ElementArrayBuffer, (IntPtr)elementBufferOffset, (IntPtr)(lengthOfElementData), indices.ToArray());

            check = GL.GetError();
            arrayBufferOffset += lengthOfArrayData;
            elementBufferOffset += lengthOfElementData;

        }

        public void Dispose()
        {
            Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            this.arrayBufferOffset = 0;
            this.arrayBufferStride = 0;
            this.arrayBufferCount = 0;
            this.elementBufferOffset = 0;
            this.elementCount = 0;

            if (disposing)
            {
            }
        }
    }

    class MouseOrb
    {
        public Vector3 position;
        public float radius;

        public void OnMouseDown(Ray mouseRay, MouseButton mouseButton)
        {

        }
    }

    class Conic : Primitive, IRenderable
    {
        public override int ArrayBufferLength
        {
            get
            {
                return VertexCoordinates.Count * Vector3.SizeInBytes;
            }
        }

        public override int ElementBufferLength
        {
            get
            {
                return Indices.Count * sizeof(ushort);
            }
        }

        public IList<Vector3> VertexCoordinates { get; private set; }
        public IList<ushort> Indices { get; private set; }

        public Conic(Vector3 origin, float height, float width, int sideCount = 16)
        {
            var coordinates = new List<Vector3>();
            var baseCoordinate = origin;
            var apexCoordinate = origin + Vector3.UnitZ * height;

            var circleCoordinates = GenerateCircleCoordinates(width / 2, origin, sideCount);

            coordinates = new List<Vector3>(circleCoordinates.Length + 2);
            coordinates.Add(baseCoordinate);
            coordinates.Add(apexCoordinate);
            coordinates.AddRange(circleCoordinates);

            var indices = GenerateIndices(coordinates);

            this.VertexCoordinates = coordinates;
            this.Indices = indices;
        }

        public void BufferConeData(int arrayBuffer, ref int arrayBufferOffset, int elementBuffer, ref int elementBufferOffset)
        {
            base.BufferPrimitiveData(
                this.VertexCoordinates
                .SelectMany(vector =>
                {
                    byte[] buffer = new byte[Vector3.SizeInBytes];
                    var array = new[] { vector.X, vector.Y, vector.Z };
                    Buffer.BlockCopy(array, 0, buffer, 0, buffer.Length);
                    return buffer;
                }).ToArray(), this.Indices, Vector3.SizeInBytes, arrayBuffer, ref arrayBufferOffset, elementBuffer, ref elementBufferOffset);
        }

        private static IList<ushort> GenerateIndices(IList<Vector3> vertices)
        {
            var indices = new List<ushort>();
            var count = (ushort)(vertices.Count - 2);
            const ushort offset = 1;
            indices.Add(0);
            for (ushort i = (ushort)(count + offset); i > offset; --i)
            {
                indices.Add(i);
            }
            indices.Add((ushort)(count + offset));
            indices.Add(ushort.MaxValue); // reset primitive            
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

        public void Render(IEnumerable<Program> shaderPasses)
        {
            //GL.DrawElementsBaseVertex(PrimitiveType.TriangleFan, base.elementCount, DrawElementsType.UnsignedShort, (IntPtr)base.elementBufferOffset, base.elementBufferOffset / sizeof(ushort));
        }

        public void Render(IEnumerable<Program> shaderPasses, IList<IH2ObjectInstance> instances)
        {
            throw new NotImplementedException();
        }
    }

    struct Cone
    {
        Vector3 base_position;
        Vector3 axis;
        float height;
        float radius;

        public Cone(Vector3 in_base_position, float in_height, float in_radius)
        {
            base_position = in_base_position;
            height = in_height;
            radius = in_radius;
            axis = Vector3.UnitX;
        }

        public float? TestRayIntersection(Ray ray)
        {
            //Ray = P + tV;
            var P = ray.Origin;
            var V = ray.Direction;

            var A = -axis;
            // var X = //Vector3.Perpendicular(axis);
            return null;
        }
    }

    class ConePrimitive
    {

        Vector3[] vertices;
        ushort[] indices;

        public Vector3[] Vertices { get { return vertices; } }
        public ushort[] Indices { get { return indices; } }

        public ConePrimitive(Vector3 apex_position, Vector3 base_position, float radius, ushort segments)
        {
            Vector3 apex_vector = apex_position - base_position;

            Vector3 base_vector = new Vector3(apex_vector.Y, -apex_vector.Z, 0.0f);
            if (apex_vector.X * apex_vector.X > 0) base_vector = new Vector3(apex_vector.Y, -apex_vector.X, apex_vector.Z);

            Vector3.Normalize(base_vector);
            Vector3.Multiply(ref base_vector, radius, out base_vector);

            float theta = (float)(Math.PI * 2) / segments;
            Matrix4 rotation_matrix = Matrix4.CreateFromAxisAngle(apex_vector, theta);

            var vertex_position = base_position + base_vector;
            var vertex_count = segments + 2;
            vertices = new Vector3[vertex_count];
            for (int i = 0; i != segments; ++i)
            {
                vertices[i] = vertex_position;
                Vector3.Transform(ref vertex_position, ref rotation_matrix, out vertex_position);
            }
            vertices[segments] = apex_position;
            vertices[segments + 1] = base_position;

            var index_count = segments * 2 + 5;
            indices = new ushort[index_count];

            int current_index = 0;
            indices[current_index++] = (ushort)(segments + 1);
            for (ushort i = 0; i < segments; ++i)
            {
                indices[current_index++] = i;
            }
            indices[current_index++] = 0;

            indices[current_index++] = ushort.MaxValue;
            indices[current_index++] = (ushort)(segments);
            for (ushort i = 0; i < segments; ++i)
            {
                indices[current_index++] = i;
            }
            indices[current_index++] = 0;

            if (current_index != index_count) throw new IndexOutOfRangeException();
        }
    }
}
