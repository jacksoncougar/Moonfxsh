using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Moonfish.Guerilla.Preprocess
{
    public partial class BitmapBlock
    {
        [GuerillaPreProcessMethod(BlockName = "bitmap_block")]
        protected static void GuerillaPreProcessMethod(BinaryReader binaryReader, IList<tag_field> fields)
        {
            (fields[2].Definition as enum_definition).Options = new List<string>(new[] {
                "TextureArray2D", 
                "TextureArray3D", 
                "Cubemaps", 
                "Sprites", 
                "Interface Bitmaps" });
            (fields[4].Definition as enum_definition).Options = new List<string>(new[] { 
                "Compressed with Color-Key Transparency", 
                "Compressed with Explicit Alpha", 
                "Compressed with Interpolated Alpha", 
                "Color 16-Bit", 
                "Color 32-Bit", 
                "Monochrome" 
            });
            fields[12].Name = "Sprite Size";
            var enumDefinition = (fields[12].Definition as enum_definition);
            for (int i = 0; i < enumDefinition.Options.Count; ++i)
            {
                enumDefinition.Options[i] = string.Format("Size{0}", enumDefinition.Options[i]);
            }
            var index = (from field in fields
                         where field.Name == "WDP fields"
                         select fields.IndexOf(field)).Single();
            var wdpFields = fields.Where(x => fields.IndexOf(x) >= index && fields.IndexOf(x) < index + 5).ToArray();
            var dataFields = fields.Where(x => x.type == field_type._field_data).ToArray();

            for (int i = 0; i < wdpFields.Count(); i++)
            {
                fields.Remove(wdpFields[i]);
            }
            for (int i = 0; i < dataFields.Count(); i++)
            {
                index = fields.IndexOf(dataFields[i]);
                fields.RemoveAt(index);
                fields.Insert(index, new tag_field() { type = field_type._field_skip, Name = "data", definition = 8 });
            }
        }
    }
    public partial class BitmapDataBlock
    {
        [GuerillaPreProcessMethod(BlockName = "bitmap_data_block")]
        protected static void GuerillaPreProcessMethod(BinaryReader binaryReader, IList<tag_field> fields)
        {
            (fields[5].Definition as enum_definition).Options = new List<string>(new[] { "Texture2D", "Texture3D", "Cubemap" });
            var index = (from field in fields
                         where field.Name == "Pixels Offset*"
                         select fields.IndexOf(field)).Single();
            for (int i = 0; i < 10; ++i)
                fields.RemoveAt(index + 1);
            fields.Insert(fields.Count - 1, new tag_field() { type = field_type._field_long_integer, Name = "LOD1 Texture Data Offset" });
            fields.Insert(fields.Count - 1, new tag_field() { type = field_type._field_long_integer, Name = "LOD2 Texture Data Offset" });
            fields.Insert(fields.Count - 1, new tag_field() { type = field_type._field_long_integer, Name = "LOD3 Texture Data Offset" });
            fields.Insert(fields.Count - 1, new tag_field() { type = field_type._field_skip, Name = "", definition = 12 });
            fields.Insert(fields.Count - 1, new tag_field() { type = field_type._field_long_integer, Name = "LOD1 Texture Data Length" });
            fields.Insert(fields.Count - 1, new tag_field() { type = field_type._field_long_integer, Name = "LOD2 Texture Data Length" });
            fields.Insert(fields.Count - 1, new tag_field() { type = field_type._field_long_integer, Name = "LOD3 Texture Data Length" });
            fields.Insert(fields.Count - 1, new tag_field() { type = field_type._field_skip, Name = "", definition = 52 });
        }
    }
}
