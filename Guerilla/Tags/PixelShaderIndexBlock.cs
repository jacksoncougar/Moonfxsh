using Moonfish.Tags;
using Moonfish.Tags.BlamExtension;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class PixelShaderIndexBlock : PixelShaderIndexBlockBase
    {
        public PixelShaderIndexBlock( BinaryReader binaryReader )
            : base( binaryReader )
        {

        }
    };
    [LayoutAttribute( Size = 1 )]
    public class PixelShaderIndexBlockBase
    {
        internal byte pixelShaderIndex;
        internal PixelShaderIndexBlockBase( BinaryReader binaryReader )
        {
            this.pixelShaderIndex = binaryReader.ReadByte();
        }
        internal virtual byte[] ReadData( BinaryReader binaryReader )
        {
            var blamPointer = binaryReader.ReadBlamPointer( 1 );
            var data = new byte[ blamPointer.count ];
            if ( blamPointer.count > 0 )
            {
                using ( binaryReader.BaseStream.Pin() )
                {
                    binaryReader.BaseStream.Position = blamPointer[ 0 ];
                    data = binaryReader.ReadBytes( blamPointer.count );
                }
            }
            return data;
        }
    };
}
