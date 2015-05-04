using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Moonfish.Guerilla.Preprocess
{
    internal class BitmapDataBlock
    {
        [GuerillaPreProcessMethod(BlockName = "bitmap_data_block")]
        protected static void GuerillaPreProcessMethod(BinaryReader binaryReader, IList<tag_field> fields)
        {
            (fields[5].Definition as enum_definition).Options =
                new List<string>(new[] {"Texture2D", "Texture3D", "Cubemap"});
            var index = (from field in fields
                where field.Name == "Pixels Offset*"
                select fields.IndexOf(field)).Single();
            for (int i = 0; i < 10; ++i)
                fields.RemoveAt(index + 1);
            fields.Insert(fields.Count - 1,
                new tag_field() {type = field_type._field_long_integer, Name = "LOD1 Texture Data Offset"});
            fields.Insert(fields.Count - 1,
                new tag_field() {type = field_type._field_long_integer, Name = "LOD2 Texture Data Offset"});
            fields.Insert(fields.Count - 1,
                new tag_field() {type = field_type._field_long_integer, Name = "LOD3 Texture Data Offset"});
            fields.Insert(fields.Count - 1,
                new tag_field() {type = field_type._field_skip, Name = "", definition = 12});
            fields.Insert(fields.Count - 1,
                new tag_field() {type = field_type._field_long_integer, Name = "LOD1 Texture Data Length"});
            fields.Insert(fields.Count - 1,
                new tag_field() {type = field_type._field_long_integer, Name = "LOD2 Texture Data Length"});
            fields.Insert(fields.Count - 1,
                new tag_field() {type = field_type._field_long_integer, Name = "LOD3 Texture Data Length"});
            fields.Insert(fields.Count - 1,
                new tag_field() {type = field_type._field_skip, Name = "", definition = 52});
        }
    }
}