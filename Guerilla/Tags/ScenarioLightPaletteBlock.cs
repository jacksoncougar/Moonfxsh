using Moonfish.Tags;
using Moonfish.Tags.BlamExtension;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class ScenarioLightPaletteBlock : ScenarioLightPaletteBlockBase
    {
        public ScenarioLightPaletteBlock( BinaryReader binaryReader )
            : base( binaryReader )
        {

        }
    };
    [LayoutAttribute( Size = 40 )]
    public class ScenarioLightPaletteBlockBase
    {
        [TagReference( "ligh" )]
        internal Moonfish.Tags.TagReference name;
        internal byte[] invalidName_;
        internal ScenarioLightPaletteBlockBase( BinaryReader binaryReader )
        {
            this.name = binaryReader.ReadTagReference();
            this.invalidName_ = binaryReader.ReadBytes( 32 );
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
