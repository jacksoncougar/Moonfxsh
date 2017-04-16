using System.Collections.Generic;
using System.IO;
using System.Linq;
using Moonfish.Guerilla;

namespace Moonfish.Tags
{

    #region Halo 2 Xbox => Vista Remapping

    partial class StructureBinarySeperationPlane
    {
        [GuerillaPreProcessMethod(BlockName = "scenario_structure_bsp_block")]
        protected static void GuerillaPreProcessMethod(BinaryReader binaryReader, IList<tag_field> fields)
        {
            //fields.Insert( 0, new tag_field( ) { type = field_type._field_long_integer, Name = "Block Length" } );
            //fields.Insert( 1, new tag_field( ) { type = field_type._field_long_integer, Name = "SBSP virtual start address" } );
            //fields.Insert( 2, new tag_field( ) { type = field_type._field_long_integer, Name = "LTMP virtual start address" } );
            //fields.Insert( 3, new tag_field( ) { type = field_type._field_tag, Name = "SBSP class" } );
        }
    }

    public partial class CollisionBSPPhysicsBlock
    {
        [GuerillaPreProcessMethod(BlockName = "collision_bsp_physics_block")]
        protected static void GuerillaPreProcessMethod(BinaryReader binaryReader, IList<tag_field> fields)
        {
            var field = fields.Last(x => x.type != field_type._field_terminator);
            fields.Remove(field);
            fields.Insert(fields.IndexOf(fields.Last()),
                new tag_field() {type = field_type._field_pad, Name = "padding", definition = 4});
        }
    }

    public partial class DecoratorCacheBlockBlock
    {
        [GuerillaPreProcessMethod(BlockName = "decorator_cache_block_block")]
        protected static void GuerillaPreProcessMethod(BinaryReader binaryReader, IList<tag_field> fields)
        {
            var field = fields.Last(x => x.type != field_type._field_terminator);
            fields.Remove(field);
            field = fields.Last(x => x.type != field_type._field_terminator);
            fields.Remove(field);
        }
    }

    #endregion
}

namespace Moonfish.Guerilla.Tags
{
    public partial class GlobalGeometryBlockInfoStructBlock
    {
        public int ResourceOffset
        {
            get { return (int) (BlockOffset & ~0xC0000000); }
        }
    };
}