using System.Runtime.InteropServices;
using Moonfish.Guerilla;

namespace Moonfish.Tags
{
    [GuerillaType( MoonfishFieldType.FieldCharBlockIndex2 )]
    [StructLayout( LayoutKind.Sequential, Size = 1 )]
    public struct ByteBlockIndex2
    {
        private byte index;

        public static explicit operator byte( ByteBlockIndex2 blockIndex )
        {
            return blockIndex.index;
        }

        public static explicit operator ByteBlockIndex2( byte value )
        {
            return new ByteBlockIndex2 {index = value};
        }

        public override string ToString( )
        {
            return index.ToString( );
        }
    }
}