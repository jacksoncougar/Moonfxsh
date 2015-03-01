using Moonfish.Tags;
using Moonfish.Tags.BlamExtension;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class RenderModelNodeMapBlock : RenderModelNodeMapBlockBase
    {
        public RenderModelNodeMapBlock( BinaryReader binaryReader )
            : base( binaryReader )
        {

        }
    };
    [LayoutAttribute( Size = 1 )]
    public class RenderModelNodeMapBlockBase
    {
        internal byte nodeIndex;
        internal RenderModelNodeMapBlockBase( BinaryReader binaryReader )
        {
            this.nodeIndex = binaryReader.ReadByte();
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
