using System.Runtime.InteropServices;
using Moonfish.Guerilla;

namespace Moonfish.Tags
{
    [GuerillaType( MoonfishFieldType.FieldLongBlockIndex1 )]
    [StructLayout( LayoutKind.Sequential, Size = 4 )]
    public struct LongBlockIndex1
    {
        private int index;

        public static explicit operator int( LongBlockIndex1 blockIndex )
        {
            return blockIndex.index;
        }

        public static explicit operator LongBlockIndex1( int value )
        {
            return new LongBlockIndex1 {index = value};
        }

        public override string ToString( )
        {
            return index.ToString( );
        }
    }
}