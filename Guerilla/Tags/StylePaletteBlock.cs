using Moonfish.Tags.BlamExtension;
using System.IO;
using Moonfish.Tags;

namespace Moonfish.Guerilla.Tags
{
    public partial class StylePaletteBlock : StylePaletteBlockBase
    {
        public StylePaletteBlock( BinaryReader binaryReader )
            : base( binaryReader )
        {

        }
    };
    [Layout( Size = 8 )]
    public class StylePaletteBlockBase
    {
        [TagReference( "styl" )]
        internal TagReference reference;
        internal StylePaletteBlockBase( BinaryReader binaryReader )
        {
            this.reference = binaryReader.ReadTagReference();
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
