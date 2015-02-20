using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Globalization;
using Microsoft.CSharp;
using System.CodeDom;
using System.Reflection;
using System.Runtime.CompilerServices;
using Moonfish.Tags;
using OpenTK;

namespace Moonfish.Guerilla
{
    public class GuerillaCs : Guerilla
    {
        Dictionary<field_type, Type> valueTypeDictionary;
        static Dictionary<Type, string> Methods;
        Dictionary<string, ClassInfo> DefinitionsDictionary = new Dictionary<string, ClassInfo>();

        static List<string> Namespaces { get; set; }

        static GuerillaCs()
        {
            CacheBinaryReaderMethods();
            InitializeNamespaceDictionary();
        }

        static void InitializeNamespaceDictionary()
        {
            const string GlobalNamespace = "global";
            const string GlobalGeometryNamespace = "global_geometry";
            const string StructureNamespace = "structure";
            const string StructureBSPNamespace = "structure_bsp";

            Namespaces = new List<string>(new[] { 
            GlobalNamespace,
            GlobalGeometryNamespace,
            StructureNamespace,
            StructureBSPNamespace,
            });

            Namespaces.Sort();
            Namespaces.Reverse();
        }

        static void CacheBinaryReaderMethods()
        {
            var types = Assembly.GetExecutingAssembly().GetTypes();
            // get BinaryReader extension methods from the executing assembly 
            var extensionMethods = (from type in types
                                    where type.IsSealed && !type.IsGenericType && !type.IsNested
                                    from method in type.GetMethods(BindingFlags.Static
                                        | BindingFlags.Public | BindingFlags.NonPublic)
                                    where method.IsDefined(typeof(ExtensionAttribute), false)
                                    where method.GetParameters()[0].ParameterType == typeof(BinaryReader)
                                    select new { method = method, type = method.ReturnType }).ToList();

            // trim this down further to one of each return type
            extensionMethods = (from method in extensionMethods
                                group method by method.type into g
                                select g.First()).ToList();

            using (var provider = new CSharpCodeProvider())
            {
                var test = provider.CreateValidIdentifier(typeof(int).ToString());
                var binaryReaderMethods = (from method in typeof(BinaryReader).GetMethods()
                                           where method.ReturnType != typeof(void)
                                           select new { method = method, type = method.ReturnType }).ToList().Where(x =>
                                           {
                                               var typeString = provider.CreateValidIdentifier((x.type).ToString());
                                               typeString = typeString.Split('.').Last();
                                               return x.method.Name.ToLower().Contains(typeString.ToLower());
                                           }).ToList();


                binaryReaderMethods = (from method in binaryReaderMethods
                                       group method by method.type into g
                                       select g.First()).ToList();

                var totalMethods = binaryReaderMethods.Union(extensionMethods);
                Methods = new Dictionary<Type, string>(totalMethods.Count());
                foreach (var item in totalMethods)
                {
                    Methods[item.type] = item.method.Name;
                }
            }
        }

        string GetBinaryReaderMethodName(tag_field field)
        {
            var method = (from m in Methods
                          where m.Key == valueTypeDictionary[field.type]
                          where m.Value.ToLower().Contains(valueTypeDictionary[field.type].Name.Split('.').Last().ToLower())
                          select m).First();
            return method.Value;
        }

        public static string GetBinaryReaderMethodName(Type type)
        {
            var method = (from m in Methods
                          where m.Key == type
                          where m.Value.ToLower().Contains(type.Name.Split('.').Last().ToLower())
                          select m.Value).FirstOrDefault();
            return method;
        }

        public static bool SplitNamespaceFromFieldName(string longFieldName, out string name, out string @namespace)
        {
            foreach (var item in Namespaces)
            {
                if (longFieldName.StartsWith(item))
                {
                    name = longFieldName.Remove(0, item.Length);
                    @namespace = item;
                    return true;
                }
            }
            name = longFieldName;
            @namespace = string.Empty;
            return false;
        }

        public void DumpTagLayout(string folder, string tagClassName, string outputClassName)
        {
            var readTag = h2Tags.Where(x => x.Class.ToString() == tagClassName).First();

            var info = (ClassInfo)BeginProcessTagBlockDefinition(readTag.Definition, readTag.definition_address,
                readTag.Class.ToString(), "");

            using (var stream = new FileStream(Path.Combine(folder, info.Value.Name + ".cs"), FileMode.Create,
                   FileAccess.Write, FileShare.ReadWrite))
            {
                var parentTag = h2Tags.Where(x => x.Class == readTag.ParentClass);
                if (parentTag.Any())
                {
                    info.BaseClass = new ClassInfo.TokenDictionary().GenerateValidToken(
                        GuerillaCs.ToTypeName(parentTag.Single().Definition.Name));
                }
                info.Attributes.Add(new AttributeInfo(typeof(TagClassAttribute)) { Parameters = { "\"" + readTag.Class.ToString() + "\"" } });
                var streamWriter = new StreamWriter(stream);
                info.Generate();
                GenerateOutputForClass(info, streamWriter);
            }

            var localDefinitions = DefinitionsDictionary.Select(x => x.Value);


            foreach (var item in localDefinitions)
            {
                using (var stream = new FileStream(Path.Combine(folder, item.Value.Name + ".cs"), FileMode.Create,
                    FileAccess.Write, FileShare.ReadWrite))
                {
                    item.Generate();
                    GenerateOutputForClass(item, new StreamWriter(stream));
                }
            }
        }


        private void GenerateOutputForClass(ClassInfo classInfo, StreamWriter streamWriter, bool subClass = false, int tabCount = 0)
        {
            if (!subClass)
            {
                var wrapperClassInfo = classInfo.GenerateWrapper(classInfo.Value.Name, classInfo.Value.Name + "Base");
                classInfo.Value.Name += "Base";
                classInfo.Generate();

                foreach (var item in classInfo.Usings)
                {
                    streamWriter.WriteLine(item);
                }
                streamWriter.WriteLine();
                streamWriter.WriteLine(classInfo.NamespaceDeclaration.Tab(ref tabCount));
                streamWriter.WriteLine("{".Tab(ref tabCount));

                GenerateOutputForSubclass(wrapperClassInfo, streamWriter, tabCount);
            }
            classInfo.Attributes.ForEach(x => streamWriter.WriteLine(x.ToString().Tab(ref tabCount)));
            streamWriter.WriteLine(classInfo.ClassDeclaration.Tab(ref tabCount));
            streamWriter.WriteLine("{".Tab(ref tabCount));

            if (!subClass)
            {
                classInfo.Value.Name = classInfo.Value.Name.Remove(classInfo.Value.Name.LastIndexOf("Base"), 4);
            }

            foreach (var item in classInfo.Fields)
            {
                tabCount = ProcessLines(streamWriter, tabCount, item);
            }

            foreach (var item in classInfo.Constructors)
            {
                tabCount = ProcessLines(streamWriter, tabCount, item);
            }

            foreach (var item in classInfo.Methods)
            {
                tabCount = ProcessLines(streamWriter, tabCount, item);
            }

            foreach (var item in classInfo.EnumDefinitions)
            {
                tabCount = ProcessLines(streamWriter, tabCount, item);
            }

            foreach (var item in classInfo.ClassDefinitions)
            {
                item.Generate();
                GenerateOutputForSubclass(item, streamWriter, tabCount);
            }

            streamWriter.WriteLine("};".Tab(ref tabCount));

            if (!subClass)
            {
                streamWriter.WriteLine("}".Tab(ref tabCount));
            }
            streamWriter.Flush();
        }

        private static int ProcessLines(StreamWriter streamWriter, int tabCount, object item)
        {
            var subItems = item.ToString().Split(new[] { Environment.NewLine }, StringSplitOptions.None).ToList();
            subItems.ForEach(x =>
            {
                streamWriter.WriteLine(x.ToString().Tab(ref tabCount));
            });
            return tabCount;
        }

        private void GenerateOutputForSubclass(ClassInfo item, StreamWriter streamWriter, int tabCount)
        {
            GenerateOutputForClass(item, streamWriter, true, tabCount);
        }

        public GuerillaCs(string guerillaExecutablePath)
            : base(guerillaExecutablePath)
        {
            CacheBinaryReaderMethods();
            var assembly = typeof(Moonfish.Tags.StringID).Assembly;
            var query = from type in assembly.GetTypes()
                        where type.GetCustomAttributes(typeof(GuerillaTypeAttribute), false).Count() > 0
                        select type;
            var valueTypes = query.ToArray();
            valueTypeDictionary = new Dictionary<field_type, Type>(valueTypes.Count());
            foreach (var type in valueTypes)
            {
                var guerillaTypeAttributes = (GuerillaTypeAttribute[])type.GetCustomAttributes(typeof(GuerillaTypeAttribute), false);
                foreach (var guerillaType in guerillaTypeAttributes)
                {
                    valueTypeDictionary.Add(guerillaType.FieldType, type);
                }
            }
            valueTypeDictionary.Add(field_type._field_angle, typeof(float));
            valueTypeDictionary.Add(field_type._field_real_euler_angles_3d, typeof(Vector3));
            valueTypeDictionary.Add(field_type._field_char_integer, typeof(byte));
            valueTypeDictionary.Add(field_type._field_short_integer, typeof(short));
            valueTypeDictionary.Add(field_type._field_short_bounds, typeof(int));
            valueTypeDictionary.Add(field_type._field_long_integer, typeof(int));
            valueTypeDictionary.Add(field_type._field_real, typeof(float));
            valueTypeDictionary.Add(field_type._field_real_fraction, typeof(float));
            valueTypeDictionary.Add(field_type._field_real_fraction_bounds, typeof(Vector2));
            valueTypeDictionary.Add(field_type._field_real_vector_3d, typeof(Vector3));
            valueTypeDictionary.Add(field_type._field_real_vector_2d, typeof(Vector2));
            valueTypeDictionary.Add(field_type._field_real_point_2d, typeof(Vector2));
            valueTypeDictionary.Add(field_type._field_real_point_3d, typeof(Vector3));
            valueTypeDictionary.Add(field_type._field_real_euler_angles_2d, typeof(Vector2));
            valueTypeDictionary.Add(field_type._field_real_plane_2d, typeof(Vector3));
            valueTypeDictionary.Add(field_type._field_real_plane_3d, typeof(Vector4));
            valueTypeDictionary.Add(field_type._field_real_quaternion, typeof(Quaternion));
            valueTypeDictionary.Add(field_type._field_real_argb_color, typeof(Vector4));
            valueTypeDictionary.Add(field_type._field_rectangle_2d, typeof(Vector2));

        }

        public ClassInfo BeginProcessTagBlockDefinition(TagBlockDefinition block, int address, string group_tag = "", string className = "")
        {
            var size = CalculateSizeOfFieldSet(block.LatestFieldSet.Fields);

            ClassInfo @class = new ClassInfo()
            {
                AccessModifiers = AccessModifiers.Public,
                Value = className == string.Empty ? GuerillaCs.ToTypeName(block.Name) : GuerillaCs.ToTypeName(className),
                Attributes = { new AttributeInfo(typeof(LayoutAttribute), "Size", size) }
            };

            ProcessFields(block.LatestFieldSet.Fields, @class);
            @class.Format();
            return @class;
        }

        void ProcessFields(List<tag_field> fields, ClassInfo @class)
        {
            foreach (var field in fields)
            {
                var fieldInfo = new FieldInfo();
                switch (field.type)
                {
                    case field_type._field_tag_reference:
                        {
                            fieldInfo = new FieldInfo()
                            {
                                Attributes = { new AttributeInfo(typeof(TagReference), null, "\"" + field.Definition.Class.ToString() + "\"") },
                                AccessModifiers = Moonfish.Guerilla.AccessModifiers.Internal,
                                Value = field.Name,
                                FieldTypeName = valueTypeDictionary[field.type].FullName,
                            };
                            @class.Fields.Add(fieldInfo);
                            break;
                        }
                    case field_type._field_block:
                        {
                            fieldInfo = new FieldInfo()
                            {
                                Value = IsValidFieldName(field.Name.ToUpper()) ? field.Name : field.Definition.DisplayName,
                                AccessModifiers = Moonfish.Guerilla.AccessModifiers.Internal,
                            };

                            if (!DefinitionsDictionary.ContainsKey(field.Definition.Name))
                            {
                                DefinitionsDictionary[field.Definition.Name] =
                                    BeginProcessTagBlockDefinition(field.Definition, field.definition);
                            }

                            fieldInfo.FieldTypeName = DefinitionsDictionary[field.Definition.Name].Value.Name;
                            fieldInfo.IsArray = true;
                            @class.Fields.Add(fieldInfo);
                            break;
                        }
                    case field_type._field_struct:
                        {
                            fieldInfo = new FieldInfo()
                            {
                                Value = IsValidFieldName(field.Name.ToUpper()) ? field.Name : field.Definition.DisplayName,
                                AccessModifiers = Moonfish.Guerilla.AccessModifiers.Internal,
                            };

                            if (!DefinitionsDictionary.ContainsKey(field.Definition.name))
                            {
                                DefinitionsDictionary[field.Definition.name] =
                                    BeginProcessTagBlockDefinition(field.Definition.Definition, field.Definition.block_definition_address);
                            }

                            fieldInfo.FieldTypeName = DefinitionsDictionary[field.Definition.Name].Value.Name;
                            @class.Fields.Add(fieldInfo);
                            break;
                        }
                    case field_type._field_data:
                        {
                            fieldInfo = new FieldInfo()
                            {
                                Value = field.Name,
                                AccessModifiers = Moonfish.Guerilla.AccessModifiers.Internal,
                                FieldTypeName = typeof(Byte).FullName,
                                IsArray = true
                            };
                            @class.Fields.Add(fieldInfo);
                            break;
                        }
                    case field_type._field_explanation:
                        {
                            //// Check if there is sub-text for this explaination.
                            //string subtext = "";
                            //if (field.definition != 0)
                            //    subtext = ReadString(reader, field.definition);

                            //// Write the field info to the output file.
                            //writer.WriteLine("//FIELD_EXPLAINATION(\"{0}\", \"{1}\"),", field.Name, subtext.Replace("\n", "<lb>"));
                            break;
                        }
                    case field_type._field_byte_flags:
                    case field_type._field_long_flags:
                    case field_type._field_word_flags:
                    case field_type._field_char_enum:
                    case field_type._field_enum:
                    case field_type._field_long_enum:
                        {
                            var enumInfo = new EnumInfo()
                            {
                                Value = GuerillaCs.ToTypeName(field.Name),
                                AccessModifiers = AccessModifiers.Internal
                            };
                            var enumDefinition = (enum_definition)field.Definition;
                            enumInfo.ValueNames.AddRange(enumDefinition.Options.Select(x => (GuerillaName)x));
                            switch (field.type)
                            {
                                case field_type._field_byte_flags:
                                    enumInfo.BaseType = EnumInfo.Type.Byte;
                                    enumInfo.Attributes.Add(new AttributeInfo(typeof(FlagsAttribute)));
                                    break;
                                case field_type._field_word_flags:
                                    enumInfo.BaseType = EnumInfo.Type.Short;
                                    enumInfo.Attributes.Add(new AttributeInfo(typeof(FlagsAttribute)));
                                    break;
                                case field_type._field_long_flags:
                                    enumInfo.BaseType = EnumInfo.Type.Int;
                                    enumInfo.Attributes.Add(new AttributeInfo(typeof(FlagsAttribute)));
                                    break;
                                case field_type._field_char_enum:
                                    enumInfo.BaseType = EnumInfo.Type.Byte;
                                    break;
                                case field_type._field_enum:
                                    enumInfo.BaseType = EnumInfo.Type.Short;
                                    break;
                                case field_type._field_long_enum:
                                    enumInfo.BaseType = EnumInfo.Type.Int;
                                    break;
                            }
                            @class.EnumDefinitions.Add(enumInfo);
                            fieldInfo = new FieldInfo()
                            {
                                Value = field.Name,
                                AccessModifiers = Moonfish.Guerilla.AccessModifiers.Internal,
                                FieldTypeName = GuerillaCs.ToTypeName(enumInfo.Value)
                            };

                            enumInfo.ToString();

                            @class.Fields.Add(fieldInfo);
                            break;
                        }
                    case field_type._field_byte_block_flags:
                    case field_type._field_word_block_flags:
                    case field_type._field_long_block_flags:
                    case field_type._field_char_block_index1:
                    case field_type._field_short_block_index1:
                    case field_type._field_long_block_index1:
                    case field_type._field_char_block_index2:
                    case field_type._field_short_block_index2:
                    case field_type._field_long_block_index2:
                        {
                            fieldInfo = new FieldInfo()
                            {
                                Value = field.Name,
                                AccessModifiers = Moonfish.Guerilla.AccessModifiers.Internal,
                                FieldTypeName = valueTypeDictionary[field.type].FullName,
                            };
                            @class.Fields.Add(fieldInfo);
                            break;
                        }
                    case field_type._field_array_start:
                        {
                            var startIndex = fields.IndexOf(field);
                            var endIndex = fields.FindIndex(
                                startIndex,
                                x => x.type == field_type._field_array_end) + 1;
                            var arrayFieldSubSet = fields.GetRange(startIndex, endIndex - startIndex);
                            @class.ClassDefinitions.Add(ProcessArrayFields(arrayFieldSubSet));

                            fieldInfo = new FieldInfo()
                            {
                                Value = field.Name,
                                AccessModifiers = Moonfish.Guerilla.AccessModifiers.Internal,
                                FieldTypeName = @class.ClassDefinitions.Last().Value,
                                ArraySize = field.Definition,
                                IsArray = true
                            };

                            @class.Fields.Add(fieldInfo);
                            var remainingFields = fields.GetRange(endIndex, fields.Count - endIndex);
                            ProcessFields(remainingFields, @class);
                            return;
                        }
                    case field_type._field_array_end:
                        {
                            return;
                        }
                    case field_type._field_pad:
                        {
                            fieldInfo = new FieldInfo()
                            {
                                Value = field.Name,
                                AccessModifiers = Moonfish.Guerilla.AccessModifiers.Internal,
                                FieldTypeName = typeof(Byte).FullName,
                                ArraySize = field.definition,
                                IsArray = true,
                            };
                            @class.Fields.Add(fieldInfo);
                            break;
                        }
                    case field_type._field_skip:
                        {
                            fieldInfo = new FieldInfo()
                            {
                                Value = field.Name,
                                AccessModifiers = Moonfish.Guerilla.AccessModifiers.Internal,
                                FieldTypeName = typeof(Byte).FullName,
                                ArraySize = field.definition,
                                IsArray = true,
                            };
                            @class.Fields.Add(fieldInfo);
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
                            fieldInfo = new FieldInfo()
                            {
                                Value = field.Name,
                                AccessModifiers = Moonfish.Guerilla.AccessModifiers.Internal,
                                FieldTypeName = valueTypeDictionary[field.type].AssemblyQualifiedName
                            };
                            @class.Fields.Add(fieldInfo);
                            break;
                        }
                }
            }
        }




        private static bool IsValidFieldName(string value)
        {
            string[] invalidNames = new[] 
            { 
                "EMPTY_STRING",
                "EMPTYSTRING", 
                "", 
                "YOUR MOM"
            };
            return !invalidNames.Any(x => value.Equals(x));
        }

        void WritePaddingField(StringWriter writer, ref tag_field field, Dictionary<string, int> fieldNames, out string fieldName, bool isSkip = false)
        {
            WritePaddingField(writer, ref field, fieldNames, out fieldName, field.definition, isSkip);
        }
        void WritePaddingField(StringWriter writer, ref tag_field field, Dictionary<string, int> fieldNames, out string fieldName, int paddingLength, bool isSkip = false)
        {
            var postFix = ProcessFieldName(ToMemberName(field.Name), fieldNames);
            var token = "invalidName_";
            postFix = postFix.Contains(token) ? postFix.Remove(postFix.IndexOf(token), token.Length) : postFix;
            var paddingType = (isSkip ? "skip" : "padding");
            fieldName = paddingType + postFix;
            var fieldType = "byte";

            writer.WriteLine(@"#region {0}", paddingType);
            WriteFieldValArray(writer, paddingLength, fieldName, fieldType, true);
            writer.WriteLine(@"#endregion");
        }
        void WriteFieldValArray(StringWriter writer, ref tag_field field, Dictionary<string, int> fieldNames, out string fieldName, out string fieldType, int arrayLength, bool isSkip = false)
        {
            fieldName = ProcessFieldName(ToMemberName(field.Name), fieldNames);
            fieldType = ToTypeName(field.Name);
            WriteFieldValArray(writer, arrayLength, fieldName, fieldType);
        }
        void WriteFieldValArray(StringWriter writer, int arrayLength, string fieldName, string fieldType, bool isPrivate = false)
        {
            if (arrayLength != 1)
            {
                writer.WriteLine("[TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = {0})]", arrayLength);
            }
            writer.WriteLine("{3} {0} {1}{2};", fieldType, arrayLength == 1 ? "" : "[]", fieldName, isPrivate ? "private" : "public");
        }

        void WriteField(StringWriter writer, tag_field field, Dictionary<string, int> fieldNames, out string fieldName, out string fieldType, string attributeString = "")
        {
            fieldType = FormatTypeString(ref field);
            fieldName = ProcessFieldName(ToMemberName(field.Name), fieldNames);
            WriteField(writer, fieldType, fieldName, attributeString);
        }
        void WriteField(StringWriter writer, string typeString, string fieldNameString, string attributesString, bool isArray = false)
        {
            if (!string.IsNullOrEmpty(attributesString))
            {
                attributesString = FormatAttributeString(attributesString);
                writer.WriteLine(attributesString);
            }
            writer.WriteLine("public {0}{1} {2};", typeString, isArray ? "[]" : string.Empty, fieldNameString);
        }

        protected override string FormatTypeString(ref tag_field field)
        {
            var csType = valueTypeDictionary[field.type];
            return FormatTypeReference(csType);
        }

        string ProcessFieldName(string fieldName, Dictionary<string, int> fieldNames)
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

        ClassInfo ProcessArrayFields(List<tag_field> fields)
        {
            ClassInfo arrayClass = new ClassInfo()
            {
                Value = GuerillaCs.ToTypeName(fields[0].Name),
                AccessModifiers = Moonfish.Guerilla.AccessModifiers.Public,
            };
            fields.RemoveAt(0);
            ProcessFields(fields, arrayClass);

            return arrayClass;
        }

        string ReadEnum(ref tag_field field)
        {
            switch (field.type)
            {
                case field_type._field_byte_flags:
                    return FormatEnum(ref field, field.Definition.Options, typeof(byte), new ActionRef<int>(IncrementFlags), true);
                case field_type._field_word_flags:
                    return FormatEnum(ref field, field.Definition.Options, typeof(short), new ActionRef<int>(IncrementFlags), true);
                case field_type._field_long_flags:
                    return FormatEnum(ref field, field.Definition.Options, typeof(int), new ActionRef<int>(IncrementFlags), true);
                case field_type._field_char_enum:
                    return FormatEnum(ref field, field.Definition.Options, typeof(byte), new ActionRef<int>(IncrementEnum));
                case field_type._field_enum:
                    return FormatEnum(ref field, field.Definition.Options, typeof(short), new ActionRef<int>(IncrementEnum));
                case field_type._field_long_enum:
                    return FormatEnum(ref field, field.Definition.Options, typeof(int), new ActionRef<int>(IncrementEnum));

            }
            throw new InvalidDataException();
        }

        delegate void ActionRef<T>(ref T item);

        void IncrementEnum(ref int enumIndex)
        {
            enumIndex++;
        }

        void IncrementFlags(ref int flagsIndex)
        {
            flagsIndex <<= 1;
        }

        public static string FormatTypeReference(Type type)
        {
            using (var provider = new CSharpCodeProvider())
            {
                var typeRef = new CodeTypeReference(type);
                var typeName = provider.GetTypeOutput(typeRef);

                typeName = typeName.Substring(typeName.LastIndexOf('.') + 1);
                return typeName;
            }
        }

        string FormatEnum(ref tag_field field, List<string> options, Type baseType, ActionRef<int> incrementMethod, bool isFlags = false)
        {
            StringWriter stringWriter = new StringWriter();
            Dictionary<string, int> optionDictionary = new Dictionary<string, int>();

            var baseTypeString = FormatTypeReference(baseType);

            if (isFlags)
                stringWriter.WriteLine("[Flags]");

            stringWriter.WriteLine(string.Format("public enum {0} : {1}", ToTypeName(field.Name), baseTypeString));
            stringWriter.WriteLine('{');

            var index = isFlags ? 1 : 0;
            foreach (string option in options)
            {
                if (option != string.Empty)
                {
                    stringWriter.WriteLine("{0} = {1},", ProcessFieldName(ToTypeName(option), optionDictionary), index);
                }
                incrementMethod(ref index);
            }

            stringWriter.WriteLine("}");
            return stringWriter.ToString();
        }

        protected override string FormatAttributeString(string attributeString)
        {
            return string.Format("[{0}]", attributeString);
        }

        public new static string ToMemberName(string value)
        {
            return Guerilla.ToMemberName(value);
        }

        public new static string ToTypeName(string value)
        {
            return Guerilla.ToTypeName(value);
        }

        public static string[] SplitNameDescription(string fieldName)
        {
            var items = fieldName.Split('#');
            return new[] { items.Length > 0 ? items[0] : null, items.Length > 1 ? items[1] : null };
        }
    }
}
