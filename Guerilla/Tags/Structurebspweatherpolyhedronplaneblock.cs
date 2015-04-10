using Moonfish.Tags;
using Moonfish.Tags.BlamExtension;
using System.IO;
using OpenTK;

namespace Moonfish.Guerilla.Tags
{
    public partial class StructureBspWeatherPolyhedronPlaneBlock : StructureBspWeatherPolyhedronPlaneBlockBase
    {
        public StructureBspWeatherPolyhedronPlaneBlock( BinaryReader binaryReader )
            : base( binaryReader )
        {

        }
    };
    [LayoutAttribute( Size = 16 )]
    public class StructureBspWeatherPolyhedronPlaneBlockBase
    {
        internal Vector4 plane;
        internal StructureBspWeatherPolyhedronPlaneBlockBase( BinaryReader binaryReader )
        {
            this.plane = binaryReader.ReadVector4();
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
