using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Moonfish.Guerilla
{
    public static class GuerillaExtensions
    {
        public delegate void PreProcessFieldSet(BinaryReader reader, List<tag_field> fieldSet);

        public static List<tag_field> ReadFields(this BinaryReader reader)
        {
            var fields = new List<tag_field>();
            var field = new tag_field();
            do
            {
                long currentAddress = reader.BaseStream.Position;
                field = reader.ReadFieldDefinition<tag_field>();
                fields.Add(field);
                // Seek to the next tag_field.
                reader.BaseStream.Position = currentAddress + 16;
            }
            while (field.type != field_type._field_terminator);
            return fields;
        }

        public static List<tag_field> ReadFieldSet(this BinaryReader reader, ref TagBlockDefinition definition, out tag_field_set field_set)
        {
            field_set = new tag_field_set();
            if (definition.Name == "sound_block")
            {
                definition.field_sets_address = 0x957870;
                //definition.field_set_latest_address = 0x906178;
                field_set.version.fields_address = 0x906178;
                field_set.version.index = 0;
                field_set.version.upgrade_proc = 0;
                field_set.version.size_of = -1;
                field_set.size = 172;
                field_set.alignment_bit = 0;
                field_set.parent_version_index = -1;
                field_set.fields_address = 0x906178;
                field_set.size_string_address = 0x00795330;
                field_set.size_string = "sizeof(sound_definition)";
            }
            else
            {
                // We are going to use the latest tag_field_set for right now.
                if (definition.Name == "animation_pool_block")
                {
                    reader.BaseStream.Position = definition.field_sets_address + ((definition.field_set_count - 2) * 76) - Guerilla.BaseAddress;
                }
                else if (definition.Name == "decorator_cache_block_data_block")
                {
                    reader.BaseStream.Position = definition.field_sets_address + ((definition.field_set_count - 1) * 76) - Guerilla.BaseAddress;
                }
                else
                {
                    reader.BaseStream.Position = definition.field_set_latest_address - Guerilla.BaseAddress;
                }
                field_set = reader.ReadFieldDefinition<tag_field_set>();
            }
            // Seek to the field set address.
            reader.BaseStream.Position = field_set.fields_address - Guerilla.BaseAddress;

            var fields = new List<tag_field>();
            var field = new tag_field();
            do
            {
                long currentAddress = reader.BaseStream.Position;
                field = reader.ReadFieldDefinition<tag_field>();
                fields.Add(field);
                // Seek to the next tag_field.
                reader.BaseStream.Position = currentAddress + 16;// sizeof(tag_field);
            }
            while (field.type != field_type._field_terminator);
            var blockName = definition.Name;
            var methods = (from method in Assembly.GetExecutingAssembly().GetTypes().SelectMany(x => x.GetMethods(BindingFlags.NonPublic | BindingFlags.Static))
                           where method.IsDefined(typeof(GuerillaPreProcessMethodAttribute), false)
                           from attribute in method.GetCustomAttributes(typeof(GuerillaPreProcessMethodAttribute), false)
                           where (attribute as GuerillaPreProcessMethodAttribute).BlockName == blockName
                           select method).ToArray();

            if (methods.Count() > 0)
            {
                methods[0].Invoke(null, new object[] { reader, fields });
            }
            return fields;
        }

        public static T ReadFieldDefinition<T>(this BinaryReader reader) where T : IReadDefinition, new()
        {
            // Read the tag_block_definition struct from the stream.
            T definition = new T();

            definition.Read(Guerilla.h2LangLib, reader);
            return definition;
        }

        public static T ReadFieldDefinition<T>(this BinaryReader reader, tag_field field) where T : IReadDefinition, new()
        {
            // Seek to the tag_block_definition address.
            reader.BaseStream.Position = field.definition - Guerilla.BaseAddress;

            return ReadFieldDefinition<T>(reader);
        }
    };
}
