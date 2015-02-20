using Moonfish.ResourceManagement;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Moonfish.Guerilla.Tags
{
    partial class StructureInstancedGeometryRenderInfoStructBlock
    {
        internal override StructureBspClusterDataBlockNew[] ReadStructureBspClusterDataBlockNewArray( System.IO.BinaryReader binaryReader )
        {
            binaryReader.ReadBytes( 8 );
            using( binaryReader.BaseStream.Pin( ) )
            {
                ResourceStream source = Halo2.GetResourceBlock( this.geometryBlockInfo );
                BinaryReader reader = new BinaryReader( source );
                return new[] { new StructureBspClusterDataBlockNew( reader ) };
            }
        }
    }
}
