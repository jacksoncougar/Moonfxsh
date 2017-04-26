using System.Runtime.InteropServices;
using Moonfish.Graphics;
using Moonfish.Guerilla;

namespace Moonfish.Tags
{
    [GuerillaType(MoonfishFieldType.FieldVertexBuffer)]
    [StructLayout(LayoutKind.Sequential, Size = 32)]
    public struct VertexBuffer
    {
        public VertexAttributeType Type;
        public byte[] Data;

        public int VertexElementCount => Type.GetSize() != 0 ? Data?.Length ?? 0/Type.GetSize() : Type.GetSize();
    }
}