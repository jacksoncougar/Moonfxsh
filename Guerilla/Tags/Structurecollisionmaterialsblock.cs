using Moonfish.Tags.BlamExtension;
using System.IO;
using Moonfish.Tags;

namespace Moonfish.Guerilla.Tags
{
    public partial class StructureCollisionMaterialsBlock : StructureCollisionMaterialsBlockBase
    {
        public StructureCollisionMaterialsBlock( BinaryReader binaryReader )
            : base( binaryReader )
        {

        }
    };
    [Layout( Size = 20 )]
    public class StructureCollisionMaterialsBlockBase
    {
        [TagReference( "shad" )]
        internal TagReference oldShader;
        internal byte[] invalidName_;
        internal ShortBlockIndex1 conveyorSurfaceIndex;
        [TagReference( "shad" )]
        internal TagReference newShader;
        internal StructureCollisionMaterialsBlockBase( BinaryReader binaryReader )
        {
            this.oldShader = binaryReader.ReadTagReference();
            this.invalidName_ = binaryReader.ReadBytes( 2 );
            this.conveyorSurfaceIndex = binaryReader.ReadShortBlockIndex1();
            this.newShader = binaryReader.ReadTagReference();
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
