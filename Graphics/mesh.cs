using Moonfish.Guerilla.Tags;
using Moonfish.Model;
using Moonfish.Tags;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Moonfish.Graphics
{

    /// <summary>
    /// Wrapper class for buffering Halo 2 mesh data for use through OpenGL
    /// </summary>
    public class Mesh : IDisposable
    {
        public RenderModelSectionBlock sectionBlock;

        int mVAO_id;
        List<int> mVBO_ids;

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
            this.Parts = parts;
            mVBO_ids = new List<int>();
            mVAO_id = GL.GenVertexArray();
            GL.BindVertexArray(mVAO_id);

            BufferElementArrayData(indices);
            BufferVertexAttributeData(vertexArrayBufferData);

            GL.BindVertexArray(0);
        }

        public IDisposable Bind()
        {
            GL.BindVertexArray(mVAO_id); OpenGL.ReportError();
            return new Handle(0);
        }

        private void BufferMeshResources(RenderModelSectionBlock section)
        {
            if (section.sectionData.Count() > 0)
            {


            }
        }

        private void BufferVertexAttributeData(VertexBuffer[] vertexBuffers)
        {
            for (int i = 0, count = vertexBuffers.Length; i < count; ++i)
            {
                if (!Enum.IsDefined(typeof(VertexAttributeType), vertexBuffers[i].Type)) continue;
                mVBO_ids.Add(GL.GenBuffer());

                GL.BindBuffer(BufferTarget.ArrayBuffer, mVBO_ids.Last()); OpenGL.ReportError();
                GL.BufferData(BufferTarget.ArrayBuffer, (IntPtr)vertexBuffers[i].Data.Length, vertexBuffers[i].Data, BufferUsageHint.StaticDraw); OpenGL.ReportError();
                GL.EnableVertexAttribArray(i); OpenGL.ReportError();

                var attribute_type = vertexBuffers[i].Type;
                var attribute_size = attribute_type.GetSize();
                switch (attribute_type)
                {
                    case VertexAttributeType.coordinate_compressed:
                        GL.VertexAttribPointer(i, 3, VertexAttribPointerType.Short, true, attribute_size, 0);
                        break;
                    case VertexAttributeType.coordinate_with_single_node:
                        GL.VertexAttribPointer(i, 3, VertexAttribPointerType.Short, true, attribute_size, 0);
                        break;
                    case VertexAttributeType.coordinate_with_double_node:
                        GL.VertexAttribPointer(i, 3, VertexAttribPointerType.Short, true, attribute_size, 0);
                        break;
                    case VertexAttributeType.coordinate_with_triple_node:
                        GL.VertexAttribPointer(i, 3, VertexAttribPointerType.Short, true, attribute_size, 0);
                        break;
                    case VertexAttributeType.texture_coordinate_compressed:
                        GL.VertexAttribPointer(i, 2, VertexAttribPointerType.Short, false, attribute_size, 0);
                        break;
                    case VertexAttributeType.tangent_space_unit_vectors_compressed:
                        count += 2;
                        GL.VertexAttribIPointer(i++, 1, VertexAttribIntegerType.Int, attribute_size, (IntPtr)0); GL.EnableVertexAttribArray(i);
                        GL.VertexAttribIPointer(i++, 1, VertexAttribIntegerType.Int, attribute_size, (IntPtr)4); GL.EnableVertexAttribArray(i);
                        GL.VertexAttribIPointer(i, 1, VertexAttribIntegerType.Int, attribute_size, (IntPtr)8); GL.EnableVertexAttribArray(i);
                        break;
                    case VertexAttributeType.coordinate_float:
                        GL.VertexAttribPointer(i, 3, VertexAttribPointerType.Float, false, attribute_size, 0);
                        break;
                    case VertexAttributeType.texture_coordinate_float:
                        GL.VertexAttribPointer(i, 2, VertexAttribPointerType.Float, false, attribute_size, 0);
                        break;
                    default: break;
                }
                OpenGL.ReportError();
            }
        }

        private void BufferElementArrayData(short[] indices)
        {
            mVBO_ids.Add(GL.GenBuffer());
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, mVBO_ids.Last());
            GL.BufferData(BufferTarget.ElementArrayBuffer, (IntPtr)(indices.Length * sizeof(short)), indices, BufferUsageHint.StaticDraw);

        }

        private Vector3 UnpackVectorInt(int compressedNormal, bool flip)
        {
            flip = true;
            int x10 = (compressedNormal & 0x000007FF);
            bool bx = false, by = false, bz = false;
            if ((x10 & 0x00000400) == 0x00000400 && flip)
            {
                x10 = -(~x10 & 0x000003FF);
                bx = true;
            }
            int y11 = (compressedNormal >> 11) & 0x000007FF;
            if ((y11 & 0x00000400) == 0x00000400 && flip)
            {
                y11 = -(~y11 & 0x000003FF);
                by = true;
            }
            int z11 = (compressedNormal >> 22) & 0x000003FF;
            if ((z11 & 0x00000200) == 0x00000200 && flip)
            {
                z11 = -(~z11 & 0x000001FF);
                bz = true;
            }

            float x = (float)x10 / 1023.0f;
            float y = (float)y11 / 1023.0f;
            float z = (float)z11 / 511.0f;

            Vector3 value = (new Vector3(x, y, z));
            return value;
        }

        public void Dispose()
        {
            //  Bind default VBA
            GL.BindVertexArray(0);
            //  Delete VBA buffer
            GL.DeleteBuffer(mVAO_id);
            //  Delete VBO buffers
            GL.DeleteBuffers(mVBO_ids.Count, mVBO_ids.ToArray());
        }

        private class Handle : IDisposable
        {
            int previousVAO;

            public Handle(int in_previousVAO)
            {
                previousVAO = in_previousVAO;
            }

            public void Dispose()
            {
                GL.BindVertexArray(previousVAO);
                GL.BindBuffer(BufferTarget.ElementArrayBuffer, 0);
            }
        }
    }


    public static class VertexAttributeTypeExtensions
    {
        public static byte GetSize(this VertexAttributeType attribute_type)
        {
            var value = (short)attribute_type;
            var size = (byte)(value & 0x00FF);
            return size;
        }

        public static VertexAttributeType ReadVertexAttributeType(this BinaryReader binaryReader)
        {
            byte msb = binaryReader.ReadByte();
            byte lsb = binaryReader.ReadByte();
            var type = (VertexAttributeType)(msb << 8 | lsb);
            return type;
        }
    }

    public enum VertexAttributeType : short
    {
        none = 0x0000,
        coordinate_float = 0x010C,
        coordinate_compressed = 0x0206,
        coordinate_with_single_node = 0x0408,
        coordinate_with_double_node = 0x060C,
        coordinate_with_triple_node = 0x080C,

        texture_coordinate_float_pc = 0x1708,
        texture_coordinate_float = 0x1808,
        texture_coordinate_compressed = 0x1904,

        tangent_space_unit_vectors_float = 0x1924,
        tangent_space_unit_vectors_compressed = 0x1B0C,

        lightmap_uv_coordinate_one = 0x1F08,
        lightmap_uv_coordinate_two = 0x3008,

        diffuse_colour = 0x350C,
    }
}