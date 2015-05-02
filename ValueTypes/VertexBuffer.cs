using System.Runtime.InteropServices;
using Moonfish.Graphics;
using Moonfish.Guerilla;

namespace Moonfish.Tags
{
    [GuerillaType( MoonfishFieldType.FieldVertexBuffer )]
    [StructLayout( LayoutKind.Sequential, Size = 32 )]
    public struct VertexBuffer
    {
        public VertexAttributeType Type; //?
        public byte[] Data;
    }
}