using Moonfish.Guerilla;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Runtime.InteropServices;
using Moonfish.ResourceManagement;

namespace Moonfish.Tags
{
    #region Halo 2 Xbox => Vista Remapping
    partial class StructureBinarySeperationPlane
    {
        [GuerillaPreProcessMethod( BlockName = "scenario_structure_bsp_block" )]
        protected static void GuerillaPreProcessMethod( BinaryReader binaryReader, IList<tag_field> fields )
        {
            //fields.Insert( 0, new tag_field( ) { type = field_type._field_long_integer, Name = "Block Length" } );
            //fields.Insert( 1, new tag_field( ) { type = field_type._field_long_integer, Name = "SBSP virtual start address" } );
            //fields.Insert( 2, new tag_field( ) { type = field_type._field_long_integer, Name = "LTMP virtual start address" } );
            //fields.Insert( 3, new tag_field( ) { type = field_type._field_tag, Name = "SBSP class" } );
        }
    }
    public partial class CollisionBSPPhysicsBlock
    {
        [GuerillaPreProcessMethod( BlockName = "collision_bsp_physics_block" )]
        protected static void GuerillaPreProcessMethod( BinaryReader binaryReader, IList<tag_field> fields )
        {
            var field = fields.Last( x => x.type != field_type._field_terminator );
            fields.Remove( field );
            fields.Insert( fields.IndexOf( fields.Last( ) ), new tag_field( ) { type = field_type._field_pad, Name = "padding", definition = 4 } );
        }
    }
    public partial class DecoratorCacheBlockBlock
    {
        [GuerillaPreProcessMethod( BlockName = "decorator_cache_block_block" )]
        protected static void GuerillaPreProcessMethod( BinaryReader binaryReader, IList<tag_field> fields )
        {
            var field = fields.Last( x => x.type != field_type._field_terminator );
            fields.Remove( field );
            field = fields.Last( x => x.type != field_type._field_terminator );
            fields.Remove( field );
        }
    }
    #endregion
    partial class ScenarioStructureBSP : Moonfish.Guerilla.Tags.ScenarioStructureBspBlock
    {
        public ScenarioStructureBSP( BinaryReader binaryReader )
            : base( binaryReader )
        {
        }
    }
}

namespace Moonfish.Guerilla.Tags
{
    partial class StructureBspClusterBlock
    {
        internal override StructureBspClusterDataBlockNew[] ReadStructureBspClusterDataBlockNewArray( BinaryReader binaryReader )
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

    public partial class GlobalGeometryBlockInfoStructBlock
    {
        public int ResourceOffset { get { return (int)(base.blockOffset & ~0xC0000000); } }

        public Halo2.ResourceSource ResourceLocation { get { return (Halo2.ResourceSource)( ( base.blockOffset & 0xC0000000 ) >> 30 ); } }
    };
}
