using Moonfish.Tags;
using Moonfish.Tags.BlamExtension;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class PixelShaderExternMapBlock : PixelShaderExternMapBlockBase
    {
        public PixelShaderExternMapBlock( BinaryReader binaryReader )
            : base( binaryReader )
        {

        }
    };
    [LayoutAttribute( Size = 2 )]
    public class PixelShaderExternMapBlockBase
    {
        internal byte switchParameter;
        internal byte caseScalar;
        internal PixelShaderExternMapBlockBase( BinaryReader binaryReader )
        {
            this.switchParameter = binaryReader.ReadByte();
            this.caseScalar = binaryReader.ReadByte();
        }
        internal virtual byte[] ReadData( BinaryReader binaryReader )
        {
            var blamPointer = binaryReader.ReadBlamPointer( 1 );
            var data = new byte[ blamPointer.Count ];
            if ( blamPointer.Count > 0 )
            {
                using ( binaryReader.BaseStream.Pin() )
                {
                    binaryReader.BaseStream.Position = blamPointer[ 0 ];
                    data = binaryReader.ReadBytes( blamPointer.Count );
                }
            }
            return data;
        }
    };
}
