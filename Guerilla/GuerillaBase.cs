using Microsoft.CSharp;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;

namespace Moonfish.Guerilla
{
    public partial class Guerilla
    {
        /// <summary>
        /// The image load address used for translating virtual addresses to physical addresses.
        /// </summary>
        public const int BaseAddress = 0x400000;

        /// <summary>
        /// Virtual address of the tag layout table.
        /// </summary>
        public const int TagLayoutTableAddress = 0x00901B90;

        /// <summary>
        /// The number of tag layouts in the tag layout table.
        /// </summary>
        public const int NumberOfTagLayouts = 120;

        /// <summary>
        /// Name of the h2 language library used for localizing user interface strings.
        /// </summary>
        public const string H2LanguageLibrary = @"C:\Users\seed\Documents\Halo 2 Modding\h2alang.dll";

        #region Imports

        [DllImport("kernel32")]
        public extern static IntPtr LoadLibrary(string librayName);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int LoadString(IntPtr hInstance, uint uID, StringBuilder lpBuffer, int nBufferMax);

        #endregion

        public readonly static IntPtr h2LangLib;
        public static List<tag_group> h2Tags;
        public readonly static Dictionary<string, Action<BinaryReader, IList<tag_field>>> PostprocessFunctions;

        static Guerilla()
        {
            h2Tags = new List<tag_group>();
            Guerilla.h2LangLib = LoadLibrary(H2LanguageLibrary);
            PostprocessFunctions = new Dictionary<string, Action<BinaryReader, IList<tag_field>>>();
            var methods = (from method in Assembly.GetExecutingAssembly().GetTypes().SelectMany(
                               x => x.GetMethods(BindingFlags.NonPublic | BindingFlags.Static))
                           where method.IsDefined(typeof(GuerillaPreProcessMethodAttribute), false)
                           select method).ToArray();
            foreach (var method in methods)
            {
                var attributes = method.GetCustomAttributes(typeof(GuerillaPreProcessMethodAttribute), false);

                foreach (GuerillaPreProcessMethodAttribute attribute in attributes)
                {
                    PostprocessFunctions[attribute.BlockName] = (Action<BinaryReader, IList<tag_field>>)Delegate.CreateDelegate(typeof(Action<BinaryReader, IList<tag_field>>), (method));
                }
            }
        }

        protected Guerilla(string guerillaExecutablePath)
        {
            // Open the guerilla executable.
            using (BinaryReader reader = new BinaryReader(new VirtualMemoryStream(guerillaExecutablePath, Guerilla.BaseAddress)))
            {
                Guerilla.h2Tags = new List<tag_group>(Guerilla.NumberOfTagLayouts);

                // Loop through all the tag layouts and extract each one.
                for (int i = 0; i < Guerilla.NumberOfTagLayouts; i++)
                {
                    // Go to the tag layout table.
                    reader.BaseStream.Position = Guerilla.TagLayoutTableAddress + (i * 4);

                    // Read the tag layout pointer.
                    int layoutAddress = reader.ReadInt32();

                    // Go to the tag layout and read it.
                    reader.BaseStream.Position = layoutAddress;
                    tag_group tag = new tag_group(reader);
                    h2Tags.Add(tag);
                }
            }
        }

        protected virtual string FormatAttributeString(string attributeString)
        {
            return attributeString;
        }

        public static int CalculateSizeOfFieldSet(IList<tag_field> fields)
        {
            var totalFieldSetSize = 0;
            for (int i = 0; i < fields.Count; ++i)
            {
                var field = fields[i];
                var fieldSize = CalculateSizeOfField(field);
                if (field.type == field_type._field_array_start)
                {
                    var arrayCount = field.definition;
                    var elementSize = 0;
                    do
                    {
                        field = fields[++i];
                        elementSize += CalculateSizeOfField(field);
                    } while (field.type != field_type._field_array_end);
                    fieldSize += elementSize * arrayCount;
                }
                totalFieldSetSize += fieldSize;
            }
            return totalFieldSetSize;
        }

        public static int CalculateSizeOfField(tag_field field)
        {
            switch (field.type)
            {
                case field_type._field_struct:
                    {
                        tag_struct_definition struct_definition = (tag_struct_definition)field.Definition;
                        TagBlockDefinition blockDefinition = struct_definition.Definition;

                        return CalculateSizeOfFieldSet(blockDefinition.LatestFieldSet.Fields);
                    }
                case field_type._field_skip:
                case field_type._field_pad:
                    return field.definition;
                default:
                    return GetFieldSize(field.type);
            }
        }

        public static int GetFieldSize(field_type type)
        {
            switch (type)
            {
                #region Standard Types
                case field_type._field_char_integer:
                case field_type._field_char_enum:
                case field_type._field_byte_flags:
                case field_type._field_byte_block_flags:
                case field_type._field_char_block_index1:
                case field_type._field_char_block_index2:
                    return 1;
                case field_type._field_short_integer:
                case field_type._field_enum:
                case field_type._field_word_flags:
                case field_type._field_word_block_flags:
                case field_type._field_short_block_index1:
                case field_type._field_short_block_index2:
                    return 2;
                case field_type._field_long_integer:
                case field_type._field_long_enum:
                case field_type._field_long_flags:
                case field_type._field_long_block_flags:
                case field_type._field_long_block_index1:
                case field_type._field_long_block_index2:
                    return 4;
                #endregion
                case field_type._field_string:
                    return 32;
                case field_type._field_long_string:
                    return 256;
                case field_type._field_string_id:
                case field_type._field_old_string_id: //?
                    return 4;

                case field_type._field_point_2d:
                    {
                        return 4;
                    }
                case field_type._field_rectangle_2d:
                    return 8;

                #region Real, Vector, Point, Angle Types
                case field_type._field_real:
                case field_type._field_angle:
                case field_type._field_real_fraction:
                    return 4;
                case field_type._field_real_point_2d:
                case field_type._field_real_vector_2d:
                case field_type._field_real_euler_angles_2d:
                    return 8;
                case field_type._field_real_point_3d:
                case field_type._field_real_vector_3d:
                case field_type._field_real_euler_angles_3d:
                    return 12;
                case field_type._field_real_quaternion:
                    return 16;
                case field_type._field_real_plane_2d:
                    return 12;
                case field_type._field_real_plane_3d:
                    return 16;
                #endregion

                #region Colour Types
                case field_type._field_rgb_color:
                    return 3;
                case field_type._field_argb_color:
                    return 4;
                case field_type._field_real_rgb_color:
                case field_type._field_real_hsv_color:
                    return 12;
                case field_type._field_real_argb_color:
                case field_type._field_real_ahsv_color:
                    return 16;
                #endregion

                #region Bounds
                case field_type._field_short_bounds:
                    return 4;
                case field_type._field_angle_bounds:
                case field_type._field_real_bounds:
                case field_type._field_real_fraction_bounds:
                    return 8;
                #endregion

                case field_type._field_tag:
                    return 4;
                case field_type._field_tag_reference:
                case field_type._field_block:
                case field_type._field_data:
                    return 8;

                case field_type._field_vertex_buffer:
                    return 32;

                case field_type._field_moonfish_ident:
                    return Marshal.SizeOf(typeof(Moonfish.Tags.TagIdent));

                //case field_type._field_pad:
                //case field_type._field_skip:
                //case field_type._field_struct:

                case field_type._field_useless_pad:
                case field_type._field_array_start:
                case field_type._field_array_end:
                case field_type._field_explanation:
                case field_type._field_terminator:
                case field_type._field_custom:
                    return 0;
            }
            throw new Exception();
        }

        protected static string ValidateFieldName(string fieldName)
        {
            using (var provider = new CSharpCodeProvider())
            {
                if (!provider.IsValidIdentifier(fieldName))
                {
                    var huh = provider.CreateValidIdentifier(fieldName);
                    fieldName = string.Format("invalidName_{0}", fieldName);
                }
            }
            return fieldName;
        }

        protected virtual string PostProcessFieldName(string fieldName, Dictionary<string, int> fieldNames)
        {
            if (fieldNames.ContainsKey(fieldName))
            {
                fieldName = fieldName + fieldNames[fieldName]++;
            }
            else
            {
                fieldNames[fieldName] = 0;
            }
            return ValidateFieldName(fieldName);
        }

        protected virtual string ResolveFieldName(ref tag_field field, string fallbackFieldName)
        {
            var fieldName = ToMemberName(field.Name);
            return fieldName == "invalidName_" ? fallbackFieldName : fieldName;
        }

        protected virtual string FormatTypeString(ref tag_field field)
        {
            return field.type.ToString();
        }

        protected static string ToTypeName(string value)
        {
            TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
            var indices = new List<int>();
            for(int i = 0; i < value.Length; ++i)
            {
                if( Char.IsUpper( value[i] ) ) indices.Add( i );
            }
            value.Where(x => Char.IsUpper(x)).Select(x=>value.IndexOf(x)).ToList();
            var typeName = new StringBuilder(value.Replace('_', ' '));
            typeName = typeName.Replace('-', ' ');
            typeName = new StringBuilder(textInfo.ToTitleCase(typeName.ToString()));
            Regex r = new Regex("[^a-zA-Z0-9 -]");
            typeName = new StringBuilder(r.Replace(typeName.ToString(), " "));
            indices.ForEach(x => typeName[x] = Char.ToUpperInvariant(typeName[x]));
            typeName = typeName.Replace(" ", "");
            typeName = new StringBuilder(ValidateFieldName(typeName.ToString()));
            return typeName.ToString();
        }

        protected static string ToMemberName(string value)
        {
            if (string.Empty == ToTypeName(value)) return string.Empty;
            StringBuilder memberName = new StringBuilder(ToTypeName(value));
            var firstChar = char.ToLower(memberName[0]);
            memberName[0] = firstChar;
            return memberName.ToString();
        }

        public static string ReadString(BinaryReader reader, int address)
        {
            string str = "";

            // Check if address is smaller than the base address of the executable.
            if (address < BaseAddress)
            {
                // The string is stored in the h2 language library.
                StringBuilder sb = new StringBuilder(0x1000);
                LoadString(h2LangLib, (uint)address, sb, sb.Capacity);
                str = sb.ToString();
            }
            else if (address > BaseAddress && (address - BaseAddress) < (int)reader.BaseStream.Length)
            {
                // Seek to the string address.
                reader.BaseStream.Position = address - BaseAddress;

                // Read the string from the executable.
                char b;
                while ((b = reader.ReadChar()) != '\0')
                    str += b;
            }

            // Return the string buffer.
            return str;
        }
    }
}
