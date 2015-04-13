using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using Microsoft.CSharp;
using Moonfish.Tags;
using OpenTK;

namespace Moonfish.Guerilla
{
    public class GuerillaCs : Guerilla
    {
        private readonly Dictionary<string, ClassInfo> _definitionsDictionary = new Dictionary<string, ClassInfo>();
        private readonly Dictionary<field_type, Type> _valueTypeDictionary;

        static GuerillaCs()
        {
            BinaryIO.CacheMethods();
            InitializeNamespaceDictionary();
        }

        public GuerillaCs(string guerillaExecutablePath)
            : base(guerillaExecutablePath)
        {
            BinaryIO.CacheMethods();
            var assembly = typeof(StringID).Assembly;
            var query = from type in assembly.GetTypes()
                        where type.GetCustomAttributes(typeof(GuerillaTypeAttribute), false).Any()
                        select type;
            var valueTypes = query.ToArray();
            _valueTypeDictionary = new Dictionary<field_type, Type>(valueTypes.Count());
            foreach (var type in valueTypes)
            {
                var guerillaTypeAttributes =
                    (GuerillaTypeAttribute[])type.GetCustomAttributes(typeof(GuerillaTypeAttribute), false);
                foreach (var guerillaType in guerillaTypeAttributes)
                {
                    _valueTypeDictionary.Add(guerillaType.FieldType, type);
                }
            }
            _valueTypeDictionary.Add(field_type._field_angle, typeof(float));
            _valueTypeDictionary.Add(field_type._field_real_euler_angles_3d, typeof(Vector3));
            _valueTypeDictionary.Add(field_type._field_char_integer, typeof(byte));
            _valueTypeDictionary.Add(field_type._field_short_integer, typeof(short));
            _valueTypeDictionary.Add(field_type._field_short_bounds, typeof(int));
            _valueTypeDictionary.Add(field_type._field_long_integer, typeof(int));
            _valueTypeDictionary.Add(field_type._field_real, typeof(float));
            _valueTypeDictionary.Add(field_type._field_real_fraction, typeof(float));
            _valueTypeDictionary.Add(field_type._field_real_fraction_bounds, typeof(Vector2));
            _valueTypeDictionary.Add(field_type._field_real_vector_3d, typeof(Vector3));
            _valueTypeDictionary.Add(field_type._field_real_vector_2d, typeof(Vector2));
            _valueTypeDictionary.Add(field_type._field_real_point_2d, typeof(Vector2));
            _valueTypeDictionary.Add(field_type._field_real_point_3d, typeof(Vector3));
            _valueTypeDictionary.Add(field_type._field_real_euler_angles_2d, typeof(Vector2));
            _valueTypeDictionary.Add(field_type._field_real_plane_2d, typeof(Vector3));
            _valueTypeDictionary.Add(field_type._field_real_plane_3d, typeof(Vector4));
            _valueTypeDictionary.Add(field_type._field_real_quaternion, typeof(Quaternion));
            _valueTypeDictionary.Add(field_type._field_real_argb_color, typeof(Vector4));
            _valueTypeDictionary.Add(field_type._field_rectangle_2d, typeof(Vector2));
        }

        private static List<string> Namespaces { get; set; }

        public ClassInfo BeginProcessTagBlockDefinition(TagBlockDefinition block, int address, string groupTag = "",
            string className = "")
        {
            var size = CalculateSizeOfFieldSet(block.LatestFieldSet.Fields);
            var alignment = block.LatestFieldSet.Alignment;

#if DEBUG
            System.Diagnostics.Debug.Assert(alignment > 0 && alignment % 2 == 0);
#endif

            var @class = new ClassInfo
            {
                AccessModifiers = AccessModifiers.Public,
                Value = className == string.Empty ? ToTypeName(block.Name) : ToTypeName(className),
                Attributes =
                {
                    new AttributeInfo(typeof(LayoutAttribute), 
                        StaticReflection.GetMemberName((LayoutAttribute layout) => layout.Size), size, 
                        StaticReflection.GetMemberName((LayoutAttribute layout) => layout.Alignment),  alignment
                        )
                }
            };



            ProcessFields(block.LatestFieldSet.Fields, @class);
            @class.Format();
            return @class;
        }

        public void DumpTagLayout(GuerillaTagGroup tag, string folder)
        {
            _definitionsDictionary.Clear();

            var info = (ClassInfo)BeginProcessTagBlockDefinition(tag.Definition, tag.definitionAddress,
                tag.Class.ToString(), "");

            using (var stream = new FileStream(Path.Combine(folder, info.Value.Name + ".cs"), FileMode.Create,
                FileAccess.Write, FileShare.ReadWrite))
            {
                var parentTag = h2Tags.SingleOrDefault(x => x.Class == tag.ParentClass);
                if (parentTag != null)
                {
                    info.BaseClass = new ClassInfo.TokenDictionary().GenerateValidToken(
                        ToTypeName(parentTag.Definition.Name));
                }
                info.Attributes.Add(new AttributeInfo(typeof(TagClassAttribute))
                {
                    Parameters = { "\"" + tag.Class + "\"" }
                });
                var streamWriter = new StreamWriter(stream);
                info.Generate();
                GenerateOutputForClass(info, streamWriter);
            }

            var localDefinitions = _definitionsDictionary.Select(x => x.Value);


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

        public static string[] SplitNameDescription(string fieldName)
        {
            var items = fieldName.Split('#');
            return new[] { items.Length > 0 ? items[0] : null, items.Length > 1 ? items[1] : null };
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

        public new static string ToMemberName(string value)
        {
            return Guerilla.ToMemberName(value);
        }

        public new static string ToTypeName(string value)
        {
            return Guerilla.ToTypeName(value);
        }

        protected override string FormatAttributeString(string attributeString)
        {
            return string.Format("[{0}]", attributeString);
        }

        protected override string FormatTypeString(ref tag_field field)
        {
            var csType = _valueTypeDictionary[field.type];
            return FormatTypeReference(csType);
        }

        private void GenerateOutputForClass(ClassInfo classInfo, StreamWriter streamWriter, bool subClass = false,
            int tabCount = 0)
        {
            if ( !subClass )
            {
                var wrapperClassInfo = classInfo.GenerateWrapper( classInfo.Value.Name, classInfo.Value.Name + "Base" );
                classInfo.Value.Name += "Base";
                classInfo.Generate( );

                foreach ( var item in classInfo.Usings )
                {
                    streamWriter.WriteLine( item );
                }

                if (wrapperClassInfo.Attributes.Any(x => x.AttributeType == typeof(TagClassAttribute)))
                {
                    streamWriter.WriteLine();
                    streamWriter.WriteLine( "namespace Moonfish.Tags".Tab( ref tabCount ) );
                    streamWriter.WriteLine( "{".Tab( ref tabCount ) );
                    var @class =
                        wrapperClassInfo.Attributes.First(x => x.AttributeType == typeof(TagClassAttribute)).Parameters[0
                            ].Trim( '"' );
                    streamWriter.WriteLine(
                        string.Format("public partial struct {0}", typeof(TagClass).Name).Tab(ref tabCount));
                    streamWriter.WriteLine( "{".Tab( ref tabCount ) );

                    var tagClass = ( TagClass ) @class ;
                    var titleCase = CultureInfo.CurrentCulture.TextInfo.ToTitleCase( tagClass.ToSafeString(  ) );
                    streamWriter.WriteLine(
                        string.Format( @"public static readonly {0} {1}Class = ({0})""{2}"";", typeof ( TagClass ).Name,
                            titleCase, @class ).Tab( ref tabCount ) );
                    streamWriter.WriteLine( "};".Tab( ref tabCount ) );
                    streamWriter.WriteLine( "};".Tab( ref tabCount ) );
                }

                streamWriter.WriteLine( );
                streamWriter.WriteLine( classInfo.NamespaceDeclaration.Tab( ref tabCount ) );
                streamWriter.WriteLine( "{".Tab( ref tabCount ) );

                GenerateOutputForSubclass( wrapperClassInfo, streamWriter, tabCount );
            }
            classInfo.Attributes.ForEach(x => streamWriter.WriteLine(x.ToString().Tab(ref tabCount)));
            streamWriter.WriteLine(classInfo.ClassDeclaration.Tab(ref tabCount));
            streamWriter.WriteLine("{".Tab(ref tabCount));

            if (!subClass)
            {
                classInfo.Value.Name = classInfo.Value.Name.Remove(classInfo.Value.Name.LastIndexOf("Base", StringComparison.Ordinal), 4);
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

        private void GenerateOutputForSubclass(ClassInfo item, StreamWriter streamWriter, int tabCount)
        {
            GenerateOutputForClass(item, streamWriter, true, tabCount);
        }

        private static void InitializeNamespaceDictionary()
        {
            const string globalNamespace = "global";
            const string globalGeometryNamespace = "global_geometry";
            const string structureNamespace = "structure";
            const string structureBspNamespace = "structure_bsp";

            Namespaces = new List<string>(new[]
            {
                globalNamespace,
                globalGeometryNamespace,
                structureNamespace,
                structureBspNamespace
            });

            Namespaces.Sort();
            Namespaces.Reverse();
        }

        private static bool IsValidFieldName(string value)
        {
            string[] invalidNames =
            {
                "EMPTY_STRING",
                "EMPTYSTRING",
                "",
                "YOUR MOM"
            };
            return !invalidNames.Any(value.Equals);
        }

        private ClassInfo ProcessArrayFields(List<tag_field> fields)
        {
            var arrayClass = new ClassInfo
            {
                Value = ToTypeName(fields[0].Name),
                AccessModifiers = AccessModifiers.Public
            };
            fields.RemoveAt(0);
            ProcessFields(fields, arrayClass);

            return arrayClass;
        }

        private static string ProcessFieldName(string fieldName, Dictionary<string, int> fieldNames)
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

        private void ProcessFields(List<tag_field> fields, ClassInfo @class)
        {
            foreach (var field in fields)
            {
                FieldInfo fieldInfo;
                switch (field.type)
                {
                    case field_type._field_tag_reference:
                        {
                            fieldInfo = new FieldInfo
                            {
                                Attributes =
                            {
                                new AttributeInfo(typeof (TagReference), null,
                                    "\"" + field.Definition.Class.ToString() + "\"")
                            },
                                AccessModifiers = AccessModifiers.Internal,
                                Value = field.Name,
                                FieldTypeName = _valueTypeDictionary[field.type].FullName
                            };
                            @class.Fields.Add(fieldInfo);
                            break;
                        }
                    case field_type._field_block:
                        {
                            fieldInfo = new FieldInfo
                            {
                                Value = IsValidFieldName(field.Name.ToUpper()) ? field.Name : field.Definition.DisplayName,
                                AccessModifiers = AccessModifiers.Internal
                            };

                            if (!_definitionsDictionary.ContainsKey(field.Definition.Name))
                            {
                                _definitionsDictionary[field.Definition.Name] =
                                    BeginProcessTagBlockDefinition(field.Definition, field.definition);
                            }

                            fieldInfo.FieldTypeName = _definitionsDictionary[field.Definition.Name].Value.Name;
                            fieldInfo.IsArray = true;
                            @class.Fields.Add(fieldInfo);
                            break;
                        }
                    case field_type._field_struct:
                        {
                            fieldInfo = new FieldInfo
                            {
                                Value =
                                    IsValidFieldName(field.Name.ToUpper())
                                        ? field.Name
                                        : field.Definition.Definition.DisplayName,
                                AccessModifiers = AccessModifiers.Internal
                            };

                            if (!_definitionsDictionary.ContainsKey(field.Definition.name))
                            {
                                _definitionsDictionary[field.Definition.name] =
                                    BeginProcessTagBlockDefinition(field.Definition.Definition,
                                        field.Definition.block_definition_address);
                            }

                            fieldInfo.FieldTypeName = _definitionsDictionary[field.Definition.Name].Value.Name;
                            @class.Fields.Add(fieldInfo);
                            break;
                        }
                    case field_type._field_data:
                        {
                            fieldInfo = new FieldInfo
                            {
                                Value = field.Name,
                                AccessModifiers = AccessModifiers.Internal,
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
                            var enumInfo = new EnumInfo
                            {
                                Value = ToTypeName(field.Name),
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
                            fieldInfo = new FieldInfo
                            {
                                Value = field.Name,
                                AccessModifiers = AccessModifiers.Internal,
                                FieldTypeName = ToTypeName(enumInfo.Value)
                            };

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
                            fieldInfo = new FieldInfo
                            {
                                Value = field.Name,
                                AccessModifiers = AccessModifiers.Internal,
                                FieldTypeName = _valueTypeDictionary[field.type].FullName
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

                            fieldInfo = new FieldInfo
                            {
                                Value = field.Name,
                                AccessModifiers = AccessModifiers.Internal,
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
                            fieldInfo = new FieldInfo
                            {
                                Value = field.Name,
                                AccessModifiers = AccessModifiers.Internal,
                                FieldTypeName = typeof(Byte).FullName,
                                ArraySize = field.definition,
                                IsArray = true
                            };
                            @class.Fields.Add(fieldInfo);
                            break;
                        }
                    case field_type._field_skip:
                        {
                            fieldInfo = new FieldInfo
                            {
                                Value = field.Name,
                                AccessModifiers = AccessModifiers.Internal,
                                FieldTypeName = typeof(Byte).FullName,
                                ArraySize = field.definition,
                                IsArray = true
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
                            fieldInfo = new FieldInfo
                            {
                                Value = field.Name,
                                AccessModifiers = AccessModifiers.Internal,
                                FieldTypeName = _valueTypeDictionary[field.type].AssemblyQualifiedName
                            };
                            @class.Fields.Add(fieldInfo);
                            break;
                        }
                }
            }
        }

        private static int ProcessLines(StreamWriter streamWriter, int tabCount, object item)
        {
            var subItems = item.ToString().Split(new[] { Environment.NewLine }, StringSplitOptions.None).ToList();
            subItems.ForEach(x => { streamWriter.WriteLine(x.ToString().Tab(ref tabCount)); });
            return tabCount;
        }

        private delegate void ActionRef<T>(ref T item);
    }
}