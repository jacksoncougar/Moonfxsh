using Moonfish.Tags;
using Moonfish.Tags.BlamExtension;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class GNullBlock : GNullBlockBase
    {
        public GNullBlock( BinaryReader binaryReader )
            : base( binaryReader )
        {

        }
    };
    [LayoutAttribute( Size = 0 )]
    public class GNullBlockBase
    {
        internal GNullBlockBase( BinaryReader binaryReader )
        {

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
