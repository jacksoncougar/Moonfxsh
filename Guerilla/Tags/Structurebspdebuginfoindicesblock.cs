using Moonfish.Tags;
using Moonfish.Tags.BlamExtension;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class StructureBspDebugInfoIndicesBlock : StructureBspDebugInfoIndicesBlockBase
    {
        public StructureBspDebugInfoIndicesBlock( BinaryReader binaryReader )
            : base( binaryReader )
        {

        }
    };
    [LayoutAttribute( Size = 4 )]
    public class StructureBspDebugInfoIndicesBlockBase
    {
        internal int index;
        internal StructureBspDebugInfoIndicesBlockBase( BinaryReader binaryReader )
        {
            this.index = binaryReader.ReadInt32();
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
