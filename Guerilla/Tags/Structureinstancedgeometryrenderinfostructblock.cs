using Moonfish.ResourceManagement;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    partial class StructureInstancedGeometryRenderInfoStructBlock
    {
        internal StructureBspClusterDataBlockNew[] ReadStructureBspClusterDataBlockNewArray(
            System.IO.BinaryReader binaryReader )
        {
            binaryReader.ReadBytes( 8 );
            using ( binaryReader.BaseStream.Pin( ) )
            {
                ResourceStream source = Halo2.GetResourceBlock( this.geometryBlockInfo );
                BinaryReader reader = new BinaryReader( source );
                return new[] {new StructureBspClusterDataBlockNew( reader )};
            }
        }
    }
}