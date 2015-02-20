using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using Moonfish.Tags;
using System.Globalization;
using OpenTK;
using Microsoft.CSharp;
using System.CodeDom;
using System.Xml;

namespace Moonfish.Guerilla
{
    public class GuerillaToEnt : Guerilla
    {
        //public List<tag_group> h2Tags;
        public void DumpTagLayout(string folder)
        {
            foreach (var tag in h2Tags)
            {
                //if (tag.Class.ToString() != "snd!") continue;

                Dictionary<string, string> definitionDictitonary = new Dictionary<string, string>();

                XmlWriterSettings xmlWriterSettings = new XmlWriterSettings();
                xmlWriterSettings.Indent = true;
                var outputName = GetEntityCompatibleName(tag);
                XmlWriter writer = XmlWriter.Create(new FileStream(string.Format("{0}\\{1}.ent", folder, outputName), FileMode.Create, FileAccess.Write, FileShare.Read), xmlWriterSettings);

                root = true;
                ProcessTag(h2Tags, folder, null, writer, tag);

                // Close the tag layout writer.
                writer.Close();

                //yield return tag;
            }
        }

        bool root;
        private void ProcessTag(IEnumerable<tag_group> h2Tags, string folder, BinaryReader reader, XmlWriter writer, tag_group tag)
        {
            const int @null = -1;
            List<tag_field> fields = null;
            if (tag.parent_group_tag != @null)
            {
                fields = new List<tag_field>();
                var parent = h2Tags.Where(x => x.group_tag == tag.parent_group_tag).Single();
                if (parent.parent_group_tag != @null)
                {
                    var @base = h2Tags.Where(x => x.group_tag == parent.parent_group_tag).Single();
                    fields.AddRange(ExtractFields(h2Tags, reader, @base));
                }
                fields.AddRange(ExtractFields(h2Tags, reader, parent));
                fields.AddRange(ExtractFields(h2Tags, reader, tag));
            }

            // Process the tag_group definition.
            var fieldOffset = 0;
            ProcessTagBlockDefinition(tag.Definition, writer, tag.definition_address, ref fieldOffset, tag.Class.ToString(), "", root, false, fields);
            root = root ? false : false;

            writer.Flush();

            //File.WriteAllText(string.Format("{0}\\{1}.cs", folder, readTag.Name), writer.ToString());
            return;
        }

        private static IList<tag_field> ExtractFields(IEnumerable<tag_group> h2Tags, BinaryReader reader, tag_group tag)
        {
            var definition = ( TagBlockDefinition)tag.Definition;
            return definition.LatestFieldSet.Fields;
        }

        private static string GetEntityCompatibleName(tag_group tag)
        {
            var outputName = tag.Class.ToString().Trim();

            Regex r = new Regex("[^a-zA-Z0-9!+++<> -]");
            outputName = r.Replace(outputName, "");
            outputName = outputName.Replace('<', '_');
            outputName = outputName.Replace('>', '_');
            outputName.Trim();
            return outputName;
        }

        Dictionary<field_type, Tuple<Type, int>> valueTypeDictionary;
        public GuerillaToEnt(string guerillaExecutablePath)
            : base(guerillaExecutablePath)
        {
            valueTypeDictionary = new Dictionary<field_type, Tuple<Type, int>>();
            valueTypeDictionary.Add(field_type._field_angle, new Tuple<Type, int>(typeof(float), 1));
            valueTypeDictionary.Add(field_type._field_angle_bounds, new Tuple<Type, int>(typeof(float), 2));
            valueTypeDictionary.Add(field_type._field_argb_color, new Tuple<Type, int>(typeof(byte), 4));
            valueTypeDictionary.Add(field_type._field_array_end, new Tuple<Type, int>(null, 0));
            valueTypeDictionary.Add(field_type._field_array_start, new Tuple<Type, int>(null, 0));
            valueTypeDictionary.Add(field_type._field_block, new Tuple<Type, int>(null, 8));
            valueTypeDictionary.Add(field_type._field_byte_block_flags, new Tuple<Type, int>(typeof(byte), 1));
            valueTypeDictionary.Add(field_type._field_byte_flags, new Tuple<Type, int>(typeof(byte), 1));
            valueTypeDictionary.Add(field_type._field_char_block_index1, new Tuple<Type, int>(typeof(byte), 1));
            valueTypeDictionary.Add(field_type._field_char_block_index2, new Tuple<Type, int>(typeof(byte), 1));
            valueTypeDictionary.Add(field_type._field_char_enum, new Tuple<Type, int>(typeof(byte), 1));
            valueTypeDictionary.Add(field_type._field_char_integer, new Tuple<Type, int>(typeof(byte), 1));
            valueTypeDictionary.Add(field_type._field_custom, new Tuple<Type, int>(null, 0));
            valueTypeDictionary.Add(field_type._field_data, new Tuple<Type, int>(typeof(byte), 8));
            valueTypeDictionary.Add(field_type._field_enum, new Tuple<Type, int>(typeof(short), 1));
            valueTypeDictionary.Add(field_type._field_explanation, new Tuple<Type, int>(null, 0));
            valueTypeDictionary.Add(field_type._field_long_block_flags, new Tuple<Type, int>(typeof(int), 1));
            valueTypeDictionary.Add(field_type._field_long_block_index1, new Tuple<Type, int>(typeof(int), 1));
            valueTypeDictionary.Add(field_type._field_long_block_index2, new Tuple<Type, int>(typeof(int), 1));
            valueTypeDictionary.Add(field_type._field_long_enum, new Tuple<Type, int>(typeof(int), 1));
            valueTypeDictionary.Add(field_type._field_long_flags, new Tuple<Type, int>(typeof(int), 1));
            valueTypeDictionary.Add(field_type._field_long_integer, new Tuple<Type, int>(typeof(int), 1));
            valueTypeDictionary.Add(field_type._field_long_string, new Tuple<Type, int>(typeof(byte), 256));
            valueTypeDictionary.Add(field_type._field_old_string_id, new Tuple<Type, int>(typeof(Moonfish.Tags.StringID), 1));
            valueTypeDictionary.Add(field_type._field_point_2d, new Tuple<Type, int>(typeof(short), 2));
            valueTypeDictionary.Add(field_type._field_real, new Tuple<Type, int>(typeof(float), 1));
            valueTypeDictionary.Add(field_type._field_real_ahsv_color, new Tuple<Type, int>(typeof(float), 4));
            valueTypeDictionary.Add(field_type._field_real_argb_color, new Tuple<Type, int>(typeof(float), 4));
            valueTypeDictionary.Add(field_type._field_real_bounds, new Tuple<Type, int>(typeof(float), 2));
            valueTypeDictionary.Add(field_type._field_real_euler_angles_2d, new Tuple<Type, int>(typeof(float), 2));
            valueTypeDictionary.Add(field_type._field_real_euler_angles_3d, new Tuple<Type, int>(typeof(float), 3));
            valueTypeDictionary.Add(field_type._field_real_fraction, new Tuple<Type, int>(typeof(float), 1));
            valueTypeDictionary.Add(field_type._field_real_fraction_bounds, new Tuple<Type, int>(typeof(float), 2));
            valueTypeDictionary.Add(field_type._field_real_hsv_color, new Tuple<Type, int>(typeof(float), 3));
            valueTypeDictionary.Add(field_type._field_real_plane_2d, new Tuple<Type, int>(typeof(float), 3));
            valueTypeDictionary.Add(field_type._field_real_plane_3d, new Tuple<Type, int>(typeof(float), 4));
            valueTypeDictionary.Add(field_type._field_real_point_2d, new Tuple<Type, int>(typeof(float), 2));
            valueTypeDictionary.Add(field_type._field_real_point_3d, new Tuple<Type, int>(typeof(float), 3));
            valueTypeDictionary.Add(field_type._field_real_quaternion, new Tuple<Type, int>(typeof(float), 4));
            valueTypeDictionary.Add(field_type._field_real_rgb_color, new Tuple<Type, int>(typeof(float), 3));
            valueTypeDictionary.Add(field_type._field_real_vector_2d, new Tuple<Type, int>(typeof(float), 2));
            valueTypeDictionary.Add(field_type._field_real_vector_3d, new Tuple<Type, int>(typeof(float), 3));
            valueTypeDictionary.Add(field_type._field_rectangle_2d, new Tuple<Type, int>(typeof(short), 4));
            valueTypeDictionary.Add(field_type._field_rgb_color, new Tuple<Type, int>(typeof(byte), 3));
            valueTypeDictionary.Add(field_type._field_short_block_index1, new Tuple<Type, int>(typeof(short), 1));
            valueTypeDictionary.Add(field_type._field_short_block_index2, new Tuple<Type, int>(typeof(short), 1));
            valueTypeDictionary.Add(field_type._field_short_bounds, new Tuple<Type, int>(typeof(short), 2));
            valueTypeDictionary.Add(field_type._field_short_integer, new Tuple<Type, int>(typeof(short), 1));
            valueTypeDictionary.Add(field_type._field_string, new Tuple<Type, int>(typeof(byte), 32));
            valueTypeDictionary.Add(field_type._field_string_id, new Tuple<Type, int>(typeof(Moonfish.Tags.StringID), 1));
            valueTypeDictionary.Add(field_type._field_tag, new Tuple<Type, int>(typeof(byte), 4));
            valueTypeDictionary.Add(field_type._field_tag_reference, new Tuple<Type, int>(typeof(int), 2));
            valueTypeDictionary.Add(field_type._field_vertex_buffer, new Tuple<Type, int>(typeof(byte), 32));
            valueTypeDictionary.Add(field_type._field_word_block_flags, new Tuple<Type, int>(typeof(short), 1));
            valueTypeDictionary.Add(field_type._field_word_flags, new Tuple<Type, int>(typeof(short), 1));
            valueTypeDictionary.Add(field_type._field_terminator, new Tuple<Type, int>(null, 0));
            valueTypeDictionary.Add(field_type._field_useless_pad, new Tuple<Type, int>(null, 0));

            valueTypeDictionary.Add(field_type._field_moonfish_ident, new Tuple<Type, int>(typeof(int), 1));
            foreach (var value in valueTypeDictionary)
            {
                if (value.Value.Item1 == null) continue;
                var fieldSize = Marshal.SizeOf(value.Value.Item1) * value.Value.Item2;
                if (Guerilla.GetFieldSize(value.Key) != fieldSize)
                    throw new InvalidDataException();

            }
        }

        private void ProcessTagBlockDefinition(TagBlockDefinition tagBlock, XmlWriter writer, int address, ref int fieldOffset, string group_tag = "", string className = "", bool root = false, bool inline = false, IList<tag_field> fieldOverride = null)
        {
            IList<tag_field> fields = tagBlock.LatestFieldSet.Fields;
            if (fieldOverride != null)
            {
                fields = fieldOverride;
            }

            var size = CalculateSizeOfFieldSet(fields);

            if (size == 0)
            {
                if (!inline)
                {
                    WritePaddingField(writer, 8, fieldOffset);
                }
                return;
            }

            if (root)
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("plugin");
                writer.WriteAttributeString("class", group_tag);
                writer.WriteAttributeString("author", "Moonfish");
                writer.WriteAttributeString("headersize", size.ToString());
            }
            else if (!inline)
            {
                writer.WriteStartElement("struct");
                WriteNameAndDescriptionAttributes(writer, className == string.Empty ? tagBlock.DisplayName : className);
                writer.WriteAttributeString("type", tagBlock.Name);
                writer.WriteAttributeString("offset", fieldOffset.ToString());
                writer.WriteAttributeString("size", size.ToString());
                writer.WriteAttributeString("maxelements", tagBlock.maximum_element_count.ToString());
                writer.WriteAttributeString("padalign", tagBlock.LatestFieldSet.Alignment.ToString());
                writer.WriteAttributeString("visible", "false");
            }

            var i = 0;
            var offset = !inline ? 0 : fieldOffset;

            ProcessFields(tagBlock, writer, fields, ref i, ref offset);


            // Finish the tag_field_set struct.
            if (!inline)
            {
                writer.WriteEndElement();
            }
        }

        private void ProcessFields(TagBlockDefinition tagBlock, XmlWriter writer, IList<tag_field> fields, ref int i, ref int fieldOffset)
        {
            writer.Flush();
            for (; i < fields.Count; ++i)
            {
                var field = fields[i];
                // Check the field type.
                switch (field.type)
                {
                    case field_type._field_tag_reference:
                        {
                            WriteField(writer, "tag", field.Name, fieldOffset + 0);
                            WriteField(writer, "id", field.Name, fieldOffset + 4);
                            break;
                        }
                    case field_type._field_block:
                        {
                            ProcessTagBlockDefinition(field.Definition, writer, field.definition, ref fieldOffset, "", field.Name);
                            break;
                        }
                    case field_type._field_struct:
                        {
                            tag_struct_definition struct_definition = (tag_struct_definition)field.Definition;
                            var fieldType = ToTypeName(struct_definition.name);

                            ProcessTagBlockDefinition(struct_definition.Definition, writer, struct_definition.block_definition_address, ref fieldOffset, "", field.Name, false, true);

                            break;
                        }
                    case field_type._field_data:
                        {
                            {
                                writer.WriteStartElement("struct");
                                writer.WriteAttributeString("name", field.Name);
                                writer.WriteAttributeString("offset", fieldOffset.ToString());
                                writer.WriteAttributeString("size", 1.ToString());
                                writer.WriteAttributeString("maxelements", ((tag_data_definition)field.Definition).maximumSize.ToString());
                                writer.WriteAttributeString("padalign", ((tag_data_definition)field.Definition).Alignment.ToString());
                                writer.WriteStartElement("byte");
                                writer.WriteAttributeString("name", "data");
                                writer.WriteAttributeString("offset", 1.ToString());
                                writer.WriteAttributeString("visible", "false");
                                writer.WriteEndElement();
                                writer.WriteEndElement();
                            }
                            break;
                        }
                    case field_type._field_explanation:
                        {
                            //// Check if there is sub-text for this explaination.
                            //string subtext = "";
                            //if (field.definition != 0)
                            //    subtext = Guerilla.ReadString(reader, field.definition);

                            // Write the field info to the output file.
                            //writer.WriteComment(string.Format("FIELD_EXPLAINATION(\"{0}\", \"{1}\"),", field.Name, subtext.Replace("\n", "<lb>")));
                            break;
                        }
                    case field_type._field_byte_flags:
                    case field_type._field_long_flags:
                    case field_type._field_word_flags:
                    case field_type._field_char_enum:
                    case field_type._field_enum:
                    case field_type._field_long_enum:
                        {
                            WriteEnumElement(writer, field.Definition, ref field, fieldOffset);
                            break;
                        }
                    case field_type._field_byte_block_flags:
                    case field_type._field_word_block_flags:
                    case field_type._field_long_block_flags:
                    case field_type._field_char_block_index1:
                    case field_type._field_short_block_index1:
                    case field_type._field_long_block_index1:
                        {
                            WriteField(writer, field, fieldOffset);
                            break;
                        }

                    case field_type._field_char_block_index2:
                    case field_type._field_short_block_index2:
                    case field_type._field_long_block_index2:
                        {
                            WriteField(writer, field, fieldOffset);
                            break;
                        }
                    case field_type._field_array_start:
                        {
                            ProcessArrayFields(tagBlock, writer, fields, ref field, ref i, ref fieldOffset);
                            break;
                        }
                    case field_type._field_array_end:
                        {
                            return;
                        }
                    case field_type._field_string:
                        {
                            WriteField(writer, "string32", field.Name, fieldOffset + 0);
                        } break;
                    case field_type._field_long_string:
                        {
                            WriteField(writer, "string256", field.Name, fieldOffset + 0);
                        } break;
                    case field_type._field_pad:
                        {
                            WritePaddingField(writer, field.definition, fieldOffset, tagBlock.DisplayName);
                            break;
                        }
                    case field_type._field_skip:
                        {
                            WritePaddingField(writer, field.definition, fieldOffset);
                            break;
                        }
                    case field_type._field_useless_pad:
                    case field_type._field_terminator:
                    case field_type._field_custom:
                        {
                            break;
                        }
                    default:
                        {
                            //attributeString.Append("TagField");
                            WriteField(writer, field, fieldOffset);
                            break;
                        }
                }
                fieldOffset += CalculateSizeOfField(field);
            }
        }

        private void WriteTagBlockIndex(XmlWriter writer, tag_field field)
        {
            writer.WriteStartElement("byte");
            writer.WriteAttributeString("name", field.Name + "-index?");
            writer.WriteEndElement();
            writer.WriteStartElement("byte");
            writer.WriteAttributeString("name", field.Name + "-data?");
            writer.WriteEndElement();
        }

        private void WritePaddingField(XmlWriter writer, int paddingLength, int fieldOffset, string name = "")
        {
            writer.WriteStartElement("unused");
            writer.WriteAttributeString("name", name);
            writer.WriteAttributeString("size", paddingLength.ToString());
            writer.WriteAttributeString("offset", fieldOffset.ToString());
            writer.WriteAttributeString("visible", "false");
            writer.WriteEndElement();
        }

        private void WriteField(XmlWriter writer, tag_field field, int fieldOffset)
        {
            var count = 0;
            string[] postfixes;
            var typeString = FormatTypeString(ref field, out count, out postfixes).ToLower();
            var fieldName = field.Name == string.Empty ? field.group_tag.ToString() : field.Name;
            if (count > 1)
            {
                for (int i = 0; i < count; ++i)
                {
                    WriteField(writer, typeString, fieldName + ":" + postfixes[i], fieldOffset);
                }
            }
            else
            {
                WriteField(writer, typeString, fieldName, fieldOffset);
            }
        }

        private void WriteField(XmlWriter writer, string typeString, string fieldNameString, int offset)
        {
            writer.WriteStartElement(typeString);
            WriteNameAndDescriptionAttributes(writer, fieldNameString);
            writer.WriteAttributeString("offset", offset.ToString());
            writer.WriteEndElement();
        }

        private void WriteNameAndDescriptionAttributes(XmlWriter writer, string fieldNameString)
        {

            string name, description;
            SplitNameDescription(fieldNameString, out name, out description);
            writer.WriteAttributeString("name", Format(name));
            if (!string.IsNullOrEmpty(description))
                writer.WriteAttributeString("description", description);
        }

        private string Format(string fieldName)
        {
            var items = fieldName.Split(':');
            var name = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(items[0].Replace("_", " ")).Replace("Color", "Colour");

            var unit = items.Length > 1 ? string.IsNullOrWhiteSpace(items[1]) == false ? items[1] : null : null;
            if (unit != null)
                return string.Format("{0} ({1})", name, unit.ToLower());
            else return name;
        }

        private void SplitNameDescription(string fieldName, out string name, out string description)
        {
            var items = fieldName.Split('#');
            name = items[0];
            description = items.Length > 1 ? String.IsNullOrEmpty(items[1]) ? string.Empty : items[1] : string.Empty;
        }

        private void ProcessArrayFields(TagBlockDefinition definition, XmlWriter writer, IList<tag_field> fields, ref tag_field field, ref int i, ref int offset)
        {
            var name = field.Name;
            ++i;    //move past field_type._field_array_start
            for (int index = 0; index < field.definition; ++index)
            {
                int startindex = i;
                ProcessFields(definition, writer, fields, ref startindex, ref offset);
            }
            ++i;    // move past field_type._field_array_end
        }

        protected override string ResolveFieldName(ref tag_field field, string fallbackFieldName)
        {
            var fieldName = ToMemberName(field.Name);
            return fieldName == string.Empty ? fallbackFieldName : fieldName;
        }

        private string FormatTypeString(ref tag_field field, out int count, out string[] postfixes)
        {
            var type = valueTypeDictionary[field.type];
            count = type.Item2;
            postfixes = new string[count];
            var typeName = FormatTypeReference(type.Item1);
            switch (field.type)
            {
                case field_type._field_angle_bounds:
                case field_type._field_real_fraction_bounds:
                case field_type._field_short_bounds:
                case field_type._field_real_bounds:
                    {
                        postfixes = new string[] { "min", "max" };
                    } break;
                case field_type._field_argb_color:
                case field_type._field_real_argb_color:
                    {
                        postfixes = new string[] { "alpha", "red", "green", "blue" };
                    } break;
                case field_type._field_real_rgb_color:
                case field_type._field_rgb_color:
                    {
                        postfixes = new string[] { "red", "green", "blue" };
                    } break;
                case field_type._field_real_vector_3d:
                case field_type._field_real_point_3d:
                    {
                        postfixes = new string[] { "x", "y", "z" };
                    } break;
                case field_type._field_real_point_2d:
                case field_type._field_real_vector_2d:
                case field_type._field_point_2d:
                    {
                        postfixes = new string[] { "x", "y", };
                    } break;
                case field_type._field_real_euler_angles_2d:
                    {
                        postfixes = new string[] { "pitch", "roll" };
                    } break;
                case field_type._field_real_euler_angles_3d:
                    {
                        postfixes = new string[] { "pitch", "roll", "yaw" };
                    } break;
                case field_type._field_real_quaternion:
                    {
                        postfixes = new string[] { "i", "j", "k", "w" };
                    } break;
                default: break;
            }
            return typeName;
        }

        private string FormatTypeReference(Type type)
        {
            using (var provider = new CSharpCodeProvider())
            {
                var typeRef = new CodeTypeReference(type);
                var typeName = provider.GetTypeOutput(typeRef);

                typeName = typeName.Substring(typeName.LastIndexOf('.') + 1);
                return typeName;
            }
        }

        private string FormatEnumReference(Type type, bool flags)
        {
            var typeString = flags ? "bitmask" : "enum";
            if (type == typeof(byte)) typeString += 8;
            if (type == typeof(short)) typeString += 16;
            if (type == typeof(int)) typeString += 32;
            return typeString;
        }

        private void WriteEnumElement(XmlWriter writer, enum_definition enumDefinition, ref tag_field field, int fieldOffset)
        {
            switch (field.type)
            {
                case field_type._field_byte_flags:
                    WriteEnumElement(writer, ref field, fieldOffset, enumDefinition.Options, typeof(byte), new ActionRef<int>(IncrementFlags), true);
                    break;
                case field_type._field_word_flags:
                    WriteEnumElement(writer, ref field, fieldOffset, enumDefinition.Options, typeof(short), new ActionRef<int>(IncrementFlags), true);
                    break;
                case field_type._field_long_flags:
                    WriteEnumElement(writer, ref field, fieldOffset, enumDefinition.Options, typeof(int), new ActionRef<int>(IncrementFlags), true);
                    break;
                case field_type._field_char_enum:
                    WriteEnumElement(writer, ref field, fieldOffset, enumDefinition.Options, typeof(byte), new ActionRef<int>(IncrementEnum));
                    break;
                case field_type._field_enum:
                    WriteEnumElement(writer, ref field, fieldOffset, enumDefinition.Options, typeof(short), new ActionRef<int>(IncrementEnum));
                    break;
                case field_type._field_long_enum:
                    WriteEnumElement(writer, ref field, fieldOffset, enumDefinition.Options, typeof(int), new ActionRef<int>(IncrementEnum));
                    break;

            }
        }

        delegate void ActionRef<T>(ref T item);

        private void WriteEnumElement(XmlWriter writer, ref tag_field field, int fieldOffset, List<string> options, Type baseType, ActionRef<int> incrementMethod, bool isFlags = false)
        {
            Dictionary<string, int> optionDictionary = new Dictionary<string, int>();

            var baseTypeString = FormatEnumReference(baseType, isFlags);

            string name, description;
            SplitNameDescription(field.Name, out name, out description);

            writer.WriteStartElement(baseTypeString);
            writer.WriteAttributeString("name", Format(name));
            if (!string.IsNullOrEmpty(description))
                writer.WriteAttributeString("description", description);
            writer.WriteAttributeString("offset", fieldOffset.ToString());

            var index = isFlags ? 0 : 0;
            foreach (string option in options)
            {
                if (option != string.Empty)
                {
                    SplitNameDescription(option, out name, out description);

                    writer.WriteStartElement("option");
                    writer.WriteAttributeString("name", Format(name));
                    if (!string.IsNullOrEmpty(description))
                        writer.WriteAttributeString("description", description);
                    writer.WriteAttributeString("value", index.ToString());
                    writer.WriteEndElement();
                }
                incrementMethod(ref index);
            }

            writer.WriteEndElement();
        }

        void IncrementEnum(ref int index)
        {
            index++;
        }

        void IncrementFlags(ref int index)
        {
            index++;
        }
    }
}
