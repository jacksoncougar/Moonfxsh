using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Moonfish.Tags;

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
        void Read(IntPtr h2LangLib, BinaryReader reader);
    }

    public class tag_field : IReadDefinition
    {
        public field_type type;
        public short padding;
        public int name_address;
        public int definition;
        public int group_tag;

        public TagClass Class { get { return new TagClass(group_tag); } }
        public string Name { get; set; }
        public dynamic Definition { get; private set; }

        public void Read(IntPtr h2LangLib, BinaryReader reader)
        {
            // Read all the fields from the stream.
            this.type = (field_type)reader.ReadInt16();
            this.padding = reader.ReadInt16();
            this.name_address = reader.ReadInt32();
            this.definition = reader.ReadInt32();
            this.group_tag = reader.ReadInt32();

            // Read Properties
            this.Name = Guerilla.ReadString(reader, this.name_address);
            this.Definition = ReadDefinition(reader);
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

        public TagClass Class { get { return new TagClass(group_tag); } }

        public void Read(IntPtr h2LangLib, BinaryReader reader)
        {
            // Read all the fields from the stream.
            this.flags = reader.ReadInt32();
            this.group_tag = reader.ReadInt32();
            this.group_tags_address = reader.ReadInt32();
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
        public string Name { get { return this.name; } }

        private string maximum_size_string;
        /// <summary>
        /// Gets the string representation of the maximum size of the tag data definition.
        /// </summary>
        public string MaximumSize { get { return this.maximum_size_string; } }

        public void Read(IntPtr h2LangLib, BinaryReader reader)
        {
            // Read all the fields from the stream.
            this.nameAddress = reader.ReadInt32();
            this.flags = reader.ReadInt32();
            this.alignmentBit = reader.ReadInt32();
            this.maximumSize = reader.ReadInt32();
            this.maximumSizeStringAddress = reader.ReadInt32();
            this.byteswapFunction = reader.ReadInt32();
            this.copyFunction = reader.ReadInt32();

            // Read the strings.
            this.name = Guerilla.ReadString(reader, this.nameAddress);
            this.maximum_size_string = Guerilla.ReadString(reader, this.maximumSizeStringAddress);
        }

        public int Alignment { get { return Guerilla.GetAlignmentValue(alignmentBit); } }
    }

    public struct block_index_custom_search_definition : IReadDefinition
    {
        public int get_block_proc;
        public int is_valid_source_block_proc;

        public void Read(IntPtr h2LangLib, BinaryReader reader)
        {
            // Read the fields from the stream.
            this.get_block_proc = reader.ReadInt32();
            this.is_valid_source_block_proc = reader.ReadInt32();
        }
    }

    public class enum_definition : IReadDefinition
    {
        public int option_count;
        public int options_address;
        public int flags; //?

        public List<string> Options { get; set; }

        public void Read(IntPtr h2LangLib, BinaryReader reader)
        {
            // Read all the fields from the stream.
            this.option_count = reader.ReadInt32();
            this.options_address = reader.ReadInt32();
            this.flags = reader.ReadInt32();

            Options = new List<string>(option_count);
            for (var i = 0; i < option_count; ++i)
            {
                // Seek to the next option name address.
                reader.BaseStream.Position = options_address + (i * 4);

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

        public string Name { get { return this.name; } }
        public TagClass Class { get { return new TagClass(group_tag); } }
        public dynamic Definition { get; set; }

        public tag_struct_definition(BinaryReader reader)
            : this()
        {
            // Read all the fields from the stream.
            this.name_address = reader.ReadInt32();
            this.group_tag = reader.ReadInt32();
            this.display_name_address = reader.ReadInt32();
            this.block_definition_address = reader.ReadInt32();

            this.displayName = Guerilla.ReadString(reader, this.display_name_address);
            this.name = Guerilla.ReadString(reader, this.name_address);

            reader.BaseStream.Seek(block_definition_address, SeekOrigin.Begin);
            Definition = reader.ReadFieldDefinition<TagBlockDefinition>();
        }

        public void Read(IntPtr h2LangLib, BinaryReader reader)
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
        public string DisplayName { get { return this.display_name; } }

        private string name;
        public string Name { get { return this.name; } }

        private string maximum_element_count_str;
        public string MaximumElementCount { get { return this.maximum_element_count_str; } }

        public List<tag_field_set> FieldSets { get; set; }
        public tag_field_set LatestFieldSet { get; set; }

        public TagBlockDefinition(BinaryReader reader)
            : this()
        {
            // Read all the fields from the stream.
            this.display_name_address = reader.ReadInt32();
            this.name_address = reader.ReadInt32();
            this.flags = reader.ReadInt32();
            this.maximum_element_count = reader.ReadInt32();
            this.maximum_element_count_string_address = reader.ReadInt32();
            this.field_sets_address = reader.ReadInt32();
            this.field_set_count = reader.ReadInt32();
            this.field_set_latest_address = reader.ReadInt32();
            reader.BaseStream.Position += 4;
            this.postprocess_proc = reader.ReadInt32();
            this.format_proc = reader.ReadInt32();
            this.generate_default_proc = reader.ReadInt32();
            this.dispose_element_proc = reader.ReadInt32();

            // Read the display name and name strings.
            this.display_name = Guerilla.ReadString(reader, this.display_name_address);
            this.name = Guerilla.ReadString(reader, this.name_address);
            this.maximum_element_count_str = Guerilla.ReadString(reader, this.maximum_element_count_string_address);
            if (name == "sound_block")
            {
                this.field_sets_address = 0x957870;

                FieldSets = new List<tag_field_set>(1);
                var fieldSet = new tag_field_set();

                //definition.field_set_latest_address = 0x906178;
                fieldSet.version.fields_address = 0x906178;
                fieldSet.version.index = 0;
                fieldSet.version.upgrade_proc = 0;
                fieldSet.version.size_of = -1;
                fieldSet.size = 172;
                fieldSet.alignment_bit = 0;
                fieldSet.parent_version_index = -1;
                fieldSet.fields_address = 0x906178;
                fieldSet.size_string_address = 0x00795330;
                fieldSet.size_string = "sizeof(sound_definition)";

                var definitionName = this.name;
                fieldSet.ReadFields(reader, Guerilla.PostprocessFunctions.Where(x => x.Key == definitionName).Select(x => x.Value).FirstOrDefault());
                LatestFieldSet = fieldSet;
                FieldSets.Add(fieldSet);
            }
            else
            {
                FieldSets = new List<tag_field_set>(field_set_count);
                var definitionName = this.name;
                var address = field_sets_address;
                for (var i = 0; i < field_set_count; ++i)
                {
                    reader.BaseStream.Seek(address, SeekOrigin.Begin);
                    var fieldSet = new tag_field_set(reader);
                    FieldSets.Add(fieldSet);
                    address += tag_field_set.Size;
                }
                if (this.name == "sound_promotion_parameters_struct_block")
                {
                    LatestFieldSet = FieldSets[0];
                }
                else
                {
                    reader.BaseStream.Seek(this.field_set_latest_address, SeekOrigin.Begin);
                    var latestFieldSet = new tag_field_set(reader, Guerilla.PostprocessFunctions.Where(x => x.Key == definitionName).Select(x => x.Value).FirstOrDefault());
                    LatestFieldSet = latestFieldSet;
                }
            }
        }

        public void Read(IntPtr h2LangLib, BinaryReader reader)
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
            this.fields_address = reader.ReadInt32();
            this.index = reader.ReadInt32();
            this.upgrade_proc = reader.ReadInt32();
            reader.BaseStream.Position += 4;
            this.size_of = reader.ReadInt32();
        }
        public void Read(IntPtr h2LangLib, BinaryReader reader)
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
        public string SizeString { get { return this.size_string; } }
        public int Alignment { get { return Guerilla.GetAlignmentValue(alignment_bit); } }
        public List<tag_field> Fields;

        public tag_field_set(BinaryReader reader, Action<BinaryReader, IList<tag_field>> postprocessFunction = null)
            : this()
        {
            this.version = reader.ReadFieldDefinition<s_tag_field_set_version>();
            this.size = reader.ReadInt32();
            this.alignment_bit = reader.ReadInt32();
            this.parent_version_index = reader.ReadInt32();
            this.fields_address = reader.ReadInt32();
            this.size_string_address = reader.ReadInt32();

            // Read the size_of string.
            this.size_string = Guerilla.ReadString(reader, this.size_string_address);

            ReadFields(reader, postprocessFunction);
        }

        public void ReadFields(BinaryReader reader, Action<BinaryReader, IList<tag_field>> postprocessFunction)
        {
            Fields = new List<tag_field>();
            reader.BaseStream.Position = fields_address;
            Fields = reader.ReadFields();

            if (postprocessFunction != null) postprocessFunction(reader, Fields);
        }

        public void Read(IntPtr h2LangLib, BinaryReader reader)
        {
            this = new tag_field_set(reader);
        }
    }


    public struct tag_group : IReadDefinition
    {
        public int name_address;
        public int flags;
        public int group_tag;
        public int parent_group_tag;
        public short version;
        public byte initialized;
        //public byte b1;
        public int postprocess_proc;
        public int save_postprocess_proc;
        public int postprocess_for_sync_proc;
        //public int i1;
        public int definition_address;
        public int[] child_group_tags;
        public short childs_count;
        //public short s1;
        public int default_tag_path_address;

        private string text;
        public string Name { get { return this.text; } }
        public string DefaultPath { get; set; }
        public TagClass Class { get { return new TagClass(this.group_tag); } }
        public TagClass ParentClass { get { return new TagClass(this.parent_group_tag); } }

        public dynamic Definition { get; set; }

        public tag_group(BinaryReader reader)
            : this()
        {
            var stream = reader.BaseStream;

            this.name_address = reader.ReadInt32();
            this.flags = reader.ReadInt32();
            this.group_tag = reader.ReadInt32();
            this.parent_group_tag = reader.ReadInt32();
            this.version = reader.ReadInt16();
            this.initialized = reader.ReadByte();

            stream.Seek(1, SeekOrigin.Current);

            this.postprocess_proc = reader.ReadInt32();
            this.save_postprocess_proc = reader.ReadInt32();
            this.postprocess_for_sync_proc = reader.ReadInt32();

            stream.Seek(4, SeekOrigin.Current);

            this.definition_address = reader.ReadInt32();
            this.child_group_tags = new int[16];
            for (int i = 0; i < 16; i++)
                this.child_group_tags[i] = reader.ReadInt32();
            this.childs_count = reader.ReadInt16();

            stream.Seek(2, SeekOrigin.Current);

            this.default_tag_path_address = reader.ReadInt32();


            this.text = Guerilla.ReadString(reader, this.name_address);

            DefaultPath = Guerilla.ReadString(reader, this.default_tag_path_address);
            stream.Seek(this.definition_address, SeekOrigin.Begin);
            if (Class.ToString() == "snd!")
            {

                Definition = reader.ReadFieldDefinition<TagBlockDefinition>();
            }
            else
            {
                Definition = reader.ReadFieldDefinition<TagBlockDefinition>();
            }
        }

        public void Read(IntPtr h2LangLib, BinaryReader reader)
        {
            this = new tag_group(reader);
        }
    }
}
