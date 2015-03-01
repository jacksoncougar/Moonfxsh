using Moonfish.Tags;
using Moonfish.Tags.BlamExtension;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class ScenarioDecalPaletteBlock : ScenarioDecalPaletteBlockBase
    {
        public ScenarioDecalPaletteBlock( BinaryReader binaryReader )
            : base( binaryReader )
        {

        }
    };
    [LayoutAttribute( Size = 8 )]
    public class ScenarioDecalPaletteBlockBase
    {
        [TagReference( "deca" )]
        internal Moonfish.Tags.TagReference reference;
        internal ScenarioDecalPaletteBlockBase( BinaryReader binaryReader )
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
