using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Moonfish.Guerilla.Tags;
using Moonfish.Tags;
using OpenTK.Graphics.OpenGL;

namespace Moonfish.Graphics
{
    /// <summary>
    /// Wrapper class for buffering Halo 2 mesh data for use through OpenGL
    /// </summary>
    public class Mesh : IDisposable, IEnumerable<TriangleBatch>
    {
        public TriangleBatch TriangleBatch { get; private set; }

        public RenderModelSectionBlock SectionBlock;

        private bool _disposed;

        public GlobalGeometryPartBlockNew[] Parts
        {
            get;
            private set;
        }

        public Mesh(GlobalGeometrySectionStructBlock section) :
            this(section.parts,
                section.stripIndices.Select(x => x.index).ToArray(),
                section.vertexBuffers.Select(x => x.vertexBuffer).ToArray())
        {
        }

        public Mesh(GlobalGeometryPartBlockNew[] parts, short[] indices, VertexBuffer[] vertexArrayBufferData)
        {
            Parts = parts;
            TriangleBatch = new TriangleBatch();
            BufferElementArrayData(indices);
            BufferVertexAttributeData(vertexArrayBufferData);
        }

        private void BufferVertexAttributeData(IList<VertexBuffer> vertexBuffers)
        {
            using (TriangleBatch.Begin())
            {
                for (int i = 0, count = vertexBuffers.Count; i < count; ++i)
                {
                    if (!Enum.IsDefined(typeof(VertexAttributeType), vertexBuffers[i].Type)) continue;

                    TriangleBatch.GenerateBuffer();
                    TriangleBatch.BindBuffer(BufferTarget.ArrayBuffer, TriangleBatch.BufferIdents.Last());
                    TriangleBatch.BufferVertexAttributeData(vertexBuffers[i].Data);

                    var attributeType = vertexBuffers[i].Type;
                    var attributeSize = attributeType.GetSize();
                    switch (attributeType)
                    {
                        case VertexAttributeType.CoordinateCompressed:
                        case VertexAttributeType.CoordinateWithSingleNode:
                        case VertexAttributeType.CoordinateWithTripleNode:
                        case VertexAttributeType.CoordinateWithDoubleNode:
                            TriangleBatch.VertexAttribArray(i, 3, VertexAttribPointerType.Short, true, attributeSize);
                            break;
                        case VertexAttributeType.TextureCoordinateCompressed:
                            TriangleBatch.VertexAttribArray(i, 2, VertexAttribPointerType.Short, false, attributeSize);
                            break;
                        case VertexAttributeType.TangentSpaceUnitVectorsCompressed:
                            count += 2;
                            TriangleBatch.VertexAttribArray(i++, 1, VertexAttribIntegerType.Int, attributeSize);
                            TriangleBatch.VertexAttribArray(i++, 1, VertexAttribIntegerType.Int, attributeSize, 4);
                            TriangleBatch.VertexAttribArray(i, 1, VertexAttribIntegerType.Int, attributeSize, 8);
                            break;
                        case VertexAttributeType.CoordinateFloat:
                            TriangleBatch.VertexAttribArray(i, 3, VertexAttribPointerType.Float, false, attributeSize);
                            break;
                        case VertexAttributeType.TextureCoordinateFloat:
                            TriangleBatch.VertexAttribArray(i, 2, VertexAttribPointerType.Float, false, attributeSize);
                            break;
                    }
                }
            }
        }

        private void BufferElementArrayData(short[] indices)
        {
            using (TriangleBatch.Begin())
            {
                TriangleBatch.GenerateBuffer();
                TriangleBatch.BindBuffer(BufferTarget.ElementArrayBuffer, TriangleBatch.BufferIdents.Last());
                TriangleBatch.BufferElementArrayData(indices);
            }

        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed || !disposing) return;
            GL.BindVertexArray(0);
            TriangleBatch.Dispose();
            _disposed = true;
        }

        IEnumerator<TriangleBatch> IEnumerable<TriangleBatch>.GetEnumerator()
        {
            if (TriangleBatch != null) yield return TriangleBatch;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<TriangleBatch>)this).GetEnumerator();
        }
    }


    public static class VertexAttributeTypeExtensions
    {
        public static byte GetSize(this VertexAttributeType attributeType)
        {
            var value = (short)attributeType;
            var size = (byte)(value & 0x00FF);
            return size;
        }

        public static VertexAttributeType ReadVertexAttributeType(this BinaryReader binaryReader)
        {
            var msb = binaryReader.ReadByte();
            var lsb = binaryReader.ReadByte();
            var type = (VertexAttributeType)(msb << 8 | lsb);
            return type;
        }
    }

    public enum VertexAttributeType : short
    {
        None = 0x0000,
        CoordinateFloat = 0x010C,
        CoordinateCompressed = 0x0206,
        CoordinateWithSingleNode = 0x0408,
        CoordinateWithDoubleNode = 0x060C,
        CoordinateWithTripleNode = 0x080C,

        TextureCoordinateFloatPc = 0x1708,
        TextureCoordinateFloat = 0x1808,
        TextureCoordinateCompressed = 0x1904,

        TangentSpaceUnitVectorsFloat = 0x1924,
        TangentSpaceUnitVectorsCompressed = 0x1B0C,

        LightmapUvCoordinateOne = 0x1F08,
        LightmapUvCoordinateTwo = 0x3008,

        DiffuseColour = 0x350C,
    }
}