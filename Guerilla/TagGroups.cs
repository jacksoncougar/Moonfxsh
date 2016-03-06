using Moonfish.Tags;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Moonfish.Guerilla
{
    public partial class Guerilla
    {
        public static int GetAlignmentValue(int alignmentBit)
        {
            return alignmentBit > 0 ? 1 << alignmentBit : 4;
        }
    }

    public enum field_type : short
    {
        _field_string,
        _field_long_string,
        _field_string_id,
        _field_old_string_id,
        _field_char_integer,
        _field_short_integer,
        _field_long_integer,
        _field_angle,
        _field_tag,
        _field_char_enum,
        _field_enum,
        _field_long_enum,
        _field_long_flags,
        _field_word_flags,
        _field_byte_flags,
        _field_point_2d,
        _field_rectangle_2d,
        _field_rgb_color,
        _field_argb_color,
        _field_real,
        _field_real_fraction,
        _field_real_point_2d,
        _field_real_point_3d,
        _field_real_vector_2d,
        _field_real_vector_3d,
        _field_real_quaternion,
        _field_real_euler_angles_2d,
        _field_real_euler_angles_3d,
        _field_real_plane_2d,
        _field_real_plane_3d,
        _field_real_rgb_color,
        _field_real_argb_color,
        _field_real_hsv_color,
        _field_real_ahsv_color,
        _field_short_bounds,
        _field_angle_bounds,
        _field_real_bounds,
        _field_real_fraction_bounds,
        _field_tag_reference,
        _field_block,
        _field_long_block_flags,
        _field_word_block_flags,
        _field_byte_block_flags,
        _field_char_block_index1,
        _field_char_block_index2,
        _field_short_block_index1,
        _field_short_block_index2,
        _field_long_block_index1,
        _field_long_block_index2,
        _field_data,
        _field_vertex_buffer,
        _field_array_start,
        _field_array_end,
        _field_pad,
        _field_useless_pad,
        _field_skip,
        _field_explanation,
        _field_custom,
        _field_struct,
        _field_terminator,

        _field_moonfish_ident,

        _field_type_max,
    }

    public interface IReadDefinition
    {
        void Read(BinaryReader reader);
    }

    public class tag_field : IReadDefinition
    {
        public field_type type;
        public short padding;
        public int name_address;
        public int definition;
        public int group_tag;

        public TagClass Class
        {
            get { return new TagClass(group_tag); }
        }

        public string Name { get; set; }
        public dynamic Definition { get; private set; }

        public void Read(BinaryReader reader)
        {
            // Read all the fields from the stream.
            type = (field_type) reader.ReadInt16();
            if (type == field_type._field_rgb_color)
            {
            }
            padding = reader.ReadInt16();
            name_address = reader.ReadInt32();
            definition = reader.ReadInt32();
            group_tag = reader.ReadInt32();

            // Read Properties
            Name = Guerilla.ReadString(reader, name_address);
            Definition = ReadDefinition(reader);
        }

        private dynamic ReadDefinition(BinaryReader reader)
        {
            switch (type)
            {
                case field_type._field_block:
                    return reader.ReadFieldDefinition<TagBlockDefinition>(this);
                case field_type._field_struct:
                    return reader.ReadFieldDefinition<tag_struct_definition>(this);
                case field_type._field_char_enum:
                case field_type._field_enum:
                case field_type._field_long_enum:
                case field_type._field_byte_flags:
                case field_type._field_word_flags:
                case field_type._field_long_flags:
                    return reader.ReadFieldDefinition<enum_definition>(this);
                case field_type._field_tag_reference:
                    return reader.ReadFieldDefinition<tag_reference_definition>(this);
                case field_type._field_data:
                    return reader.ReadFieldDefinition<tag_data_definition>(this);
                case field_type._field_explanation:
                {
                    var value = Guerilla.ReadString(reader, definition);
                    return value;
                }
                default:
                    return definition;
            }
        }

        public override string ToString()
        {
            return string.Format("{0}:{1}", type, Name);
        }
    }

    public struct tag_reference_definition : IReadDefinition
    {
        public int flags;
        public int group_tag;
        public int group_tags_address;

        public TagClass Class
        {
            get { return new TagClass(group_tag); }
        }

        public void Read(BinaryReader reader)
        {
            // Read all the fields from the stream.
            flags = reader.ReadInt32();
            group_tag = reader.ReadInt32();
            group_tags_address = reader.ReadInt32();
        }
    }

    public struct tag_data_definition : IReadDefinition
    {
        public int nameAddress;
        public int flags;
        public int alignmentBit;
        public int maximumSize;
        public int maximumSizeStringAddress;
        public int byteswapFunction;
        public int copyFunction;

        private string name;

        /// <summary>
        /// Gets the name of the data definition.
        /// </summary>
        public string Name
        {
            get { return name; }
        }

        private string maximum_size_string;

        /// <summary>
        /// Gets the string representation of the maximum size of the tag data definition.
        /// </summary>
        public string MaximumSize
        {
            get { return maximum_size_string; }
        }

        public void Read(BinaryReader reader)
        {
            // Read all the fields from the stream.
            nameAddress = reader.ReadInt32();
            flags = reader.ReadInt32();
            alignmentBit = reader.ReadInt32();
            maximumSize = reader.ReadInt32();
            maximumSizeStringAddress = reader.ReadInt32();
            byteswapFunction = reader.ReadInt32();
            copyFunction = reader.ReadInt32();

            // Read the strings.
            name = Guerilla.ReadString(reader, nameAddress);
            maximum_size_string = Guerilla.ReadString(reader, maximumSizeStringAddress);
        }

        public int Alignment
        {
            get { return Guerilla.GetAlignmentValue(alignmentBit); }
        }
    }

    public struct block_index_custom_search_definition : IReadDefinition
    {
        public int get_block_proc;
        public int is_valid_source_block_proc;

        public void Read(BinaryReader reader)
        {
            // Read the fields from the stream.
            get_block_proc = reader.ReadInt32();
            is_valid_source_block_proc = reader.ReadInt32();
        }
    }

    public class enum_definition : IReadDefinition
    {
        public int option_count;
        public int options_address;
        public int flags; //?

        public List<string> Options { get; set; }

        public void Read(BinaryReader reader)
        {
            // Read all the fields from the stream.
            option_count = reader.ReadInt32();
            options_address = reader.ReadInt32();
            flags = reader.ReadInt32();

            Options = new List<string>(option_count);
            for (var i = 0; i < option_count; ++i)
            {
                // Seek to the next option name address.
                reader.BaseStream.Position = options_address + (i*4);

                // Read the string from the stream.
                int string_address = reader.ReadInt32();
                var option = Guerilla.ReadString(reader, string_address);
                Options.Add(option);
            }
        }
    }

    public struct tag_struct_definition : IReadDefinition
    {
        public int name_address;
        public int group_tag;
        public int display_name_address;
        public int block_definition_address;

        public string displayName;
        public string name;

        public string Name
        {
            get { return name; }
        }

        public TagClass Class
        {
            get { return new TagClass(group_tag); }
        }

        public dynamic Definition { get; set; }

        public tag_struct_definition(BinaryReader reader)
            : this()
        {
            // Read all the fields from the stream.
            name_address = reader.ReadInt32();
            group_tag = reader.ReadInt32();
            display_name_address = reader.ReadInt32();
            block_definition_address = reader.ReadInt32();

            displayName = Guerilla.ReadString(reader, display_name_address);
            name = Guerilla.ReadString(reader, name_address);

            reader.BaseStream.Seek(block_definition_address, SeekOrigin.Begin);
            Definition = reader.ReadFieldDefinition<TagBlockDefinition>();
        }

        public void Read(BinaryReader reader)
        {
            this = new tag_struct_definition(reader);
        }
    }

    public struct TagBlockDefinition : IReadDefinition
    {
        public int display_name_address;
        public int name_address;
        public int flags;
        public int maximum_element_count;
        public int maximum_element_count_string_address;
        public int field_sets_address;
        public int field_set_count;
        public int field_set_latest_address;
        //public int i1;
        public int postprocess_proc;
        public int format_proc;
        public int generate_default_proc;
        public int dispose_element_proc;

        private string display_name;

        public string DisplayName
        {
            get { return display_name; }
        }

        private string name;

        public string Name
        {
            get { return name; }
        }

        private string maximum_element_count_str;

        public string MaximumElementCount
        {
            get { return maximum_element_count_str; }
        }

        public List<tag_field_set> FieldSets { get; set; }
        public tag_field_set LatestFieldSet { get; set; }

        public TagBlockDefinition(BinaryReader reader)
            : this()
        {
            // Read all the fields from the stream.
            display_name_address = reader.ReadInt32();
            name_address = reader.ReadInt32();
            flags = reader.ReadInt32();
            maximum_element_count = reader.ReadInt32();
            maximum_element_count_string_address = reader.ReadInt32();
            field_sets_address = reader.ReadInt32();
            field_set_count = reader.ReadInt32();
            field_set_latest_address = reader.ReadInt32();
            reader.BaseStream.Position += 4;
            postprocess_proc = reader.ReadInt32();
            format_proc = reader.ReadInt32();
            generate_default_proc = reader.ReadInt32();
            dispose_element_proc = reader.ReadInt32();

            // Read the display name and name strings.
            display_name = Guerilla.ReadString(reader, display_name_address);
            name = Guerilla.ReadString(reader, name_address);
            maximum_element_count_str = Guerilla.ReadString(reader, maximum_element_count_string_address);
            if (name == "sound_block")
            {
                field_sets_address = 0x957870;
                field_set_latest_address = 0x906178;

                FieldSets = new List<tag_field_set>(1);
                var fieldSet = new tag_field_set
                {
                    version = {fields_address = 0x906178, index = 0, upgrade_proc = 0, size_of = -1},
                    size = 172,
                    alignment_bit = 0,
                    parent_version_index = -1,
                    fields_address = 0x906178,
                    size_string_address = 0x00795330,
                    size_string = "sizeof(sound_definition)"
                };


                var definitionName = name;
                fieldSet.ReadFields(reader,
                    Guerilla.PostprocessFunctions.Where(x => x.Key == definitionName)
                        .Select(x => x.Value)
                        .FirstOrDefault());
                LatestFieldSet = fieldSet;
                FieldSets.Add(fieldSet);
            }
            else
            {
                FieldSets = new List<tag_field_set>(field_set_count);
                var definitionName = name;
                var address = field_sets_address;
                for (var i = 0; i < field_set_count; ++i)
                {
                    reader.BaseStream.Seek(address, SeekOrigin.Begin);
                    var fieldSet = new tag_field_set(reader);
                    FieldSets.Add(fieldSet);
                    address += tag_field_set.Size;
                }
                switch (name)
                {
                    case "materials_block":
                        LatestFieldSet = FieldSets[0];
                        if(LatestFieldSet.Fields.Count == 5)
                        {
                            name = "phmo_materials_block";
                            definitionName = "phmo_materials_block";
                        }
                        break;
                    case "hud_globals_block":
                        LatestFieldSet = FieldSets[0];
                        break;
                    case "global_new_hud_globals_struct_block":
                        LatestFieldSet = FieldSets[0];
                        break;
                    case "sound_promotion_parameters_struct_block":
                        LatestFieldSet = FieldSets[0];
                        break;
                    case "animation_pool_block":
                        LatestFieldSet = FieldSets[4];
                        break;
                    case "sound_gestalt_promotions_block":
                        LatestFieldSet = FieldSets[0];
                        break;
                    case "sound_block":
                        LatestFieldSet = FieldSets[0];
                        break;
                    case "tag_block_index_struct_block":
                        LatestFieldSet = FieldSets[0];
                        break;
                    case "vertex_shader_classification_block":
                        LatestFieldSet = FieldSets[0];
                        break;
                    default:
                        reader.BaseStream.Seek(field_set_latest_address, SeekOrigin.Begin);
                        var latestFieldSet = new tag_field_set(reader,
                            Guerilla.PostprocessFunctions.Where(x => x.Key == definitionName)
                                .Select(x => x.Value)
                                .FirstOrDefault());
                        LatestFieldSet = latestFieldSet;
                        break;
                }
            }
        }

        public void Read(BinaryReader reader)
        {
            this = new TagBlockDefinition(reader);
        }
    }

    public struct s_tag_field_set_version : IReadDefinition
    {
        public int fields_address;
        public int index;
        public int upgrade_proc;
        //public int i1;
        public int size_of;

        public s_tag_field_set_version(BinaryReader reader)
        {
            // Read all the fields from the stream.
            fields_address = reader.ReadInt32();
            index = reader.ReadInt32();
            upgrade_proc = reader.ReadInt32();
            reader.BaseStream.Position += 4;
            size_of = reader.ReadInt32();
        }

        public void Read(BinaryReader reader)
        {
            this = new s_tag_field_set_version(reader);
        }
    }

    public struct tag_field_set : IReadDefinition
    {
        public const int Size = 76;

        public s_tag_field_set_version version;
        public int size;
        public int alignment_bit;
        public int parent_version_index;
        public int fields_address;
        public int size_string_address;
        //byteswap definition
        //runtime data

        public string size_string;

        /// <summary>
        /// Gets the sizeof string for this tag_field_set.
        /// </summary>
        public string SizeString
        {
            get { return size_string; }
        }

        public int Alignment
        {
            get { return Guerilla.GetAlignmentValue(alignment_bit); }
        }

        public List<tag_field> Fields;

        public tag_field_set(BinaryReader reader, Action<BinaryReader, IList<tag_field>> postprocessFunction = null)
            : this()
        {
            version = reader.ReadFieldDefinition<s_tag_field_set_version>();
            size = reader.ReadInt32();
            alignment_bit = reader.ReadInt32();
            parent_version_index = reader.ReadInt32();
            fields_address = reader.ReadInt32();
            size_string_address = reader.ReadInt32();

            // Read the size_of string.
            size_string = Guerilla.ReadString(reader, size_string_address);

            ReadFields(reader, postprocessFunction);
        }

        public void ReadFields(BinaryReader reader, Action<BinaryReader, IList<tag_field>> postprocessFunction)
        {
            Fields = new List<tag_field>();
            reader.BaseStream.Position = fields_address;
            Fields = reader.ReadFields();

            if (postprocessFunction != null) postprocessFunction(reader, Fields);
        }

        public void Read(BinaryReader reader)
        {
            this = new tag_field_set(reader);
        }
    }
}