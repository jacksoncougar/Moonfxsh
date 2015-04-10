using Moonfish.Tags.BlamExtension;
using System.IO;
using Moonfish.Tags;

namespace Moonfish.Guerilla.Tags
{
    public partial class WaterGeometrySectionBlock : WaterGeometrySectionBlockBase
    {
        public WaterGeometrySectionBlock( BinaryReader binaryReader )
            : base( binaryReader )
        {

        }
    };
    [Layout( Size = 68 )]
    public class WaterGeometrySectionBlockBase
    {
        internal GlobalGeometrySectionStructBlock section;
        internal WaterGeometrySectionBlockBase( BinaryReader binaryReader )
        {
            this.section = new GlobalGeometrySectionStructBlock( binaryReader );
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
