using System;
using System.CodeDom;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Fasterflect;
using Microsoft.CSharp;
using Moonfish.Tags;

namespace Moonfish.Guerilla.Reflection
{
    public class ClassInfo
    {
        private GuerillaName _value;

        public ClassInfo()
        {
            Usings = new List<string>
            {
                "// ReSharper disable All",
                new UsingInfo("Moonfish.Model"),
                new UsingInfo("Moonfish.Tags.BlamExtension"),
                new UsingInfo("Moonfish.Tags"),
                new UsingInfo("OpenTK"),
                new UsingInfo("System"),
                new UsingInfo("System.IO")
            };
            Attributes = new List<AttributeInfo>();
            Fields = new List<FieldInfo>();
            Properties = new List<PropertyInfo>();
            Constructors = new List<MethodInfo>();
            EnumDefinitions = new List<EnumInfo>();
            ClassDefinitions = new List<ClassInfo>();
            Methods = new List<MethodInfo>();
            MethodsTemplates = new List<MethodInfo>();
            _value = new GuerillaName("");
            Name = "";
            Namespace = new NamespaceInfo();
        }

        public ClassInfo(string name) : this()
        {
            Name = name;
        }

        public AccessModifiers AccessModifiers { get; set; }
        public List<AttributeInfo> Attributes { get; set; }
        public ClassInfo BaseClass { get; set; }

        public string Interfaces
        {
            get { return ""; }
        }

        private string InheritanceDeclaration
        {
            get
            {
                var hasBaseClass = HasBaseClass;
                var hasInterfaces = string.IsNullOrWhiteSpace(Interfaces);
                return hasBaseClass || hasInterfaces
                    ? string.Format(": {0}{1}{2}", BaseClass.Name, hasBaseClass ? " " : "", Interfaces)
                    : "";
            }
        }

        public string ClassDeclaration
        {
            get
            {
                return
                    string.Format("{0} class {1} {2}",
                        AccessModifiers.ToTokenString(),
                        Name,
                        InheritanceDeclaration
                        ).Trim();
            }
        }

        public List<ClassInfo> ClassDefinitions { get; set; }
        public List<MethodInfo> Constructors { get; set; }
        public List<EnumInfo> EnumDefinitions { get; set; }
        public List<FieldInfo> Fields { get; set; }
        public List<PropertyInfo> Properties { get; set; }
        public List<MethodInfo> Methods { get; set; }
        public List<MethodInfo> MethodsTemplates { get; set; }
        public NamespaceInfo Namespace { get; set; }
        public List<string> Usings { get; set; }

        public string Name
        {
            get { return _value.Name; }
            set { _value.Name = value; }
        }

        public string Description
        {
            get { return _value.Description; }
            set { _value.Description = value; }
        }

        private bool HasBaseClass
        {
            get { return BaseClass != null && !string.IsNullOrWhiteSpace(BaseClass.Name); }
        }

        public TokenDictionary Format()
        {
            var tokenDictionary = HasBaseClass ? new TokenDictionary(BaseClass.Format()) : new TokenDictionary();
            
            string name, @namespace;
            if (GuerillaCs.SplitNamespaceFromFieldName(_value.Name, out name, out @namespace))
            {
                Name = tokenDictionary.GenerateValidToken(GuerillaCs.ToTypeName(name));
                Namespace = new NamespaceInfo(GuerillaCs.ToTypeName(@namespace));
            }
            else
            {
                Name = tokenDictionary.GenerateValidToken(GuerillaCs.ToTypeName(_value.Name));
            }

            FormatFieldNames(tokenDictionary);
            foreach (var item in EnumDefinitions)
            {
                item.Format();
            }
            foreach (var item in ClassDefinitions)
            {
                item.Format();
            }
            return tokenDictionary;
        }

        public void Generate()
        {
            MethodsTemplates.Clear();
            Methods.Clear();
            Constructors.Clear();

            GenerateBinaryReaderMethod();
            GenerateReadPointersMethod();

            GenerateDefaultConstructor();

            GenerateWriteBlockTemplateMethod();
            GenerateWriteArrayMethod();
            GenerateWriteDataMethod();
            GenerateWriteMethod();
        }

        private void GenerateDefaultConstructor()
        {
            Constructors.Add(new MethodInfo
            {
                ClassName = Name,
                AccessModifiers = AccessModifiers.Public,
                Wrapper = HasBaseClass
            });
        }

        public void GenerateBinaryReaderConstructor()
        {
            Constructors.Add(new MethodInfo
            {
                ClassName = Name,
                AccessModifiers = AccessModifiers.Public,
                Arguments = new List<ParameterInfo>
                {
                    new ParameterInfo(typeof (BinaryReader))
                },
                Wrapper = HasBaseClass,
            });
            var body = new StringBuilder();

            var count =
                Fields.Select(item => Type.GetType(item.FieldTypeName))
                    .Count(fieldType => fieldType != null && fieldType.IsSubclassOf(typeof(GuerillaBlock)));

            body.AppendFormatLine("var blamPointers = new List<BlamPointer>({0})", count);

            foreach (var item in Fields)
            {
                if (item.IsArray)
                {
                    // fixed byte array like padding or skip arrays
                    if (item.ArraySize > 0 && Type.GetType(item.FieldTypeName) == typeof(byte))
                    {
                        body.AppendLine(string.Format("{0} = binaryReader.ReadBytes({1});", item.Value.Name,
                            item.ArraySize));
                    }
                    // variable byte array (data)
                    else if (Type.GetType(item.FieldTypeName) == typeof(byte))
                    {
                        body.AppendFormatLine(
                            "blamPointers.Add(Guerilla.ReadBlockArrayPointer<{0}>(binaryReader), 1)", item.FieldTypeName);
                    }
                    // variable short array (data)
                    else if (Type.GetType(item.FieldTypeName) == typeof(short))
                    {
                        body.AppendFormatLine(
                            "blamPointers.Add(Guerilla.ReadBlockArrayPointer<{0}>(binaryReader), 2)", item.FieldTypeName);
                    }
                    // inline array
                    else if (item.ArraySize > 0)
                    {
                        var initializer = "";
                        for (var i = 0; i <= item.ArraySize - 1; i++)
                        {
                            initializer += string.Format("new {0}(binaryReader){1}", item.FieldTypeName,
                                i == item.ArraySize ? "" : ", ");
                        }
                        body.AppendLine(string.Format("{0} = new []{{ {1} }};", item.Value.Name, initializer));
                    }
                    // assume a TagBlock
                    else
                    {
                        var type = Type.GetType(item.FieldTypeName);
                        if (type == null) continue;
                        var instance = Activator.CreateInstance(type) as GuerillaBlock;
                        if (instance == null) continue;

                        body.AppendFormatLine(
                            "blamPointers.Add(Guerilla.ReadBlockArrayPointer<{0}>(binaryReader, {1}))", item.FieldTypeName, instance.SerializedSize);
                    }
                }
                else
                {
                    if (EnumDefinitions.Any(x => x.Value.Name == item.FieldTypeName))
                    {
                        var enumDefinition = EnumDefinitions.First(x => x.Value.Name == item.FieldTypeName);
                        var type = enumDefinition.BaseType == EnumInfo.Type.Byte
                            ? "Byte"
                            : enumDefinition.BaseType == EnumInfo.Type.Short ? "Int16" : "Int32";
                        body.AppendLine(string.Format("{0} = ({1})binaryReader.Read{2}();", item.Value.Name,
                            item.FieldTypeName, type));
                    }
                    else if (Type.GetType(item.FieldTypeName) == null)
                    {
                        body.AppendLine(string.Format("{0} = new {1}(binaryReader);", item.Value.Name,
                            item.FieldTypeName));
                    }
                    else
                    {
                        var value = BinaryIOReflection.GetBinaryReaderMethodName(Type.GetType(item.FieldTypeName));
                        body.AppendLine(string.Format("{0} = binaryReader.{1}();", item.Value.Name, value));
                    }
                }
            }
            body.AppendLine("return blamPointers;");
            Constructors.Last().Body = body.ToString().TrimEnd();
        }

        public void GenerateReadPointersMethod()
        {
            Methods.Add(new MethodInfo
            {
                ClassName = "ReadPointers",
                AccessModifiers = AccessModifiers.Public | AccessModifiers.Override,
                Arguments = new List<ParameterInfo>
                {
                    new ParameterInfo(typeof (BinaryReader)),
                    new ParameterInfo(typeof (Queue<BlamPointer>), "blamPointers"),
                },
                Returns = typeof(void).Name()
            });

            var body = new StringBuilder();
            var method = Methods.Last();
            body.AppendFormatLine("base.{0};", method.GetMethodCallSignature());

            foreach (var item in Fields)
            {
                if (!item.IsArray||item.ArraySize > 0) continue;
                // variable byte array (data)
                if (Type.GetType(item.FieldTypeName) == typeof (byte))
                {
                    body.AppendFormatLine(
                        "{0} = ReadDataByteArray(binaryReader, blamPointers.Dequeue())", item.Value.Name);
                }
                // variable short array (data)
                else if (Type.GetType(item.FieldTypeName) == typeof (short))
                {
                    body.AppendFormatLine(
                        "{0} = ReadDataShortArray(binaryReader, blamPointers.Dequeue())", item.Value.Name);
                }
                // assume a TagBlock
                else if (item.ArraySize == 0)
                {

                    body.AppendFormatLine(
                        "{1} = ReadBlockArrayData<{0}>(binaryReader, blamPointers.Dequeue())",
                        item.FieldTypeName, item.Value.Name);
                }
            }
            Methods.Last().Body = body.ToString().TrimEnd();
        }
        
        public void GenerateBinaryReaderMethod()
        {
            Methods.Add(new MethodInfo
            {
                ClassName = "ReadFields",
                AccessModifiers = AccessModifiers.Public | AccessModifiers.Override,
                Arguments = new List<ParameterInfo>
                {
                    new ParameterInfo(typeof (BinaryReader))
                },
                Returns = typeof (Queue<BlamPointer>).Name()
            });
            var body = new StringBuilder();
            var count =
                Fields.Select(item => Type.GetType(item.FieldTypeName))
                    .Count(fieldType => fieldType != null && fieldType.IsSubclassOf(typeof(GuerillaBlock)));

            body.AppendFormatLine("var blamPointers = new Queue<BlamPointer>(base.{0});", Methods.Last().GetMethodCallSignature());

            foreach (var item in Fields)
            {
                if (item.IsArray)
                {
                    // fixed byte array like padding or skip arrays
                    if (item.ArraySize > 0 && Type.GetType(item.FieldTypeName) == typeof(byte))
                    {
                        body.AppendLine(string.Format("{0} = binaryReader.ReadBytes({1});", item.Value.Name,
                            item.ArraySize));
                    }
                    // variable byte array (data)
                    else if (Type.GetType(item.FieldTypeName) == typeof(byte))
                    {
                        body.AppendFormatLine(
                            "blamPointers.Enqueue(ReadBlockArrayPointer<{0}>(binaryReader), 1)", item.FieldTypeName);
                    }
                    // variable short array (data)
                    else if (Type.GetType(item.FieldTypeName) == typeof(short))
                    {
                        body.AppendFormatLine(
                            "blamPointers.Enqueue(ReadBlockArrayPointer<{0}>(binaryReader), 2)", item.FieldTypeName);
                    }
                    // inline array
                    else if (item.ArraySize > 0)
                    {
                        var initializer = "";
                        for (var i = 0; i <= item.ArraySize - 1; i++)
                        {
                            initializer += string.Format("new {0}(binaryReader){1}", item.FieldTypeName,
                                i == item.ArraySize ? "" : ", ");
                        }
                        body.AppendLine(string.Format("{0} = new []{{ {1} }};", item.Value.Name, initializer));
                    }
                    // assume a TagBlock
                    else
                    {
                        body.AppendFormatLine(
                            "blamPointers.Enqueue(ReadBlockArrayPointer<{0}>(binaryReader))", item.FieldTypeName);
                    }
                }
                else
                {
                    if (EnumDefinitions.Any(x => x.Value.Name == item.FieldTypeName))
                    {
                        var enumDefinition = EnumDefinitions.First(x => x.Value.Name == item.FieldTypeName);
                        var type = enumDefinition.BaseType == EnumInfo.Type.Byte
                            ? "Byte"
                            : enumDefinition.BaseType == EnumInfo.Type.Short ? "Int16" : "Int32";
                        body.AppendLine(string.Format("{0} = ({1})binaryReader.Read{2}();", item.Value.Name,
                            item.FieldTypeName, type));
                    }
                    else if (Type.GetType(item.FieldTypeName) == null)
                    {
                        body.AppendLine(string.Format("{0} = new {1}(binaryReader);", item.Value.Name,
                            item.FieldTypeName));
                    }
                    else
                    {
                        var value = BinaryIOReflection.GetBinaryReaderMethodName(Type.GetType(item.FieldTypeName));
                        body.AppendLine(string.Format("{0} = binaryReader.{1}();", item.Value.Name, value));
                    }
                }
            }
            body.AppendLine("return blamPointers;");

            Methods.Last().Body = body.ToString().TrimEnd();
        }

        public void GenerateReadBlockTemplateMethod()
        {
            MethodsTemplates.Add(new MethodInfo
            {
                Arguments = new List<ParameterInfo> {new ParameterInfo(typeof (BinaryReader))},
                AccessModifiers = AccessModifiers.Internal | AccessModifiers.Virtual,
                ClassName = "Read{0}Array",
                Body =
                    @"var elementSize = Deserializer.SizeOf(typeof({0}));
var blamPointer = binaryReader.ReadBlamPointer(elementSize);
var array = new {0}[blamPointer.count];
using (binaryReader.BaseStream.Pin())
{{
    for (int i = 0; i < blamPointer.count; ++i)
    {{
        binaryReader.BaseStream.Position = blamPointer[i];
        array[i] = new {0}(binaryReader);
    }}
}}
return array;",
                Returns = "{0}[]"
            });
        }

        public void GenerateReadDataMethod()
        {
//            Methods.Add(new MethodInfo
//            {
//                Arguments = new List<ParameterInfo> { new ParameterInfo(typeof(BinaryReader)) },
//                AccessModifiers = AccessModifiers.Internal | AccessModifiers.Virtual,
//                ClassName = "ReadData",
//                Body =
//                    @"var blamPointer = binaryReader.ReadBlamPointer(1);
//var data = new byte[blamPointer.count];
//if(blamPointer.count > 0)
//{
//    using (binaryReader.BaseStream.Pin())
//    {
//        binaryReader.BaseStream.Position = blamPointer[0];
//        data = binaryReader.ReadBytes(blamPointer.count);
//    }
//}
//return data;",
//                Returns = "byte[]"
//            });
        }

        public ClassInfo GenerateWrapper(string wrapperName, string baseName)
        {
            var tagClassAttribute = Attributes.SingleOrDefault(x => x.AttributeType == typeof (TagClassAttribute));
            var hasTagClassAttribute = tagClassAttribute != null;
            if (hasTagClassAttribute)
                Attributes.Remove(tagClassAttribute);
            var wrapperClassInfo = new ClassInfo
            {
                AccessModifiers = AccessModifiers.Public | AccessModifiers.Partial,
                Constructors = Constructors.Select(x => x.MakeWrapper(wrapperName)).ToList(),
                Namespace = Namespace,
                Usings = Usings,
                _value = new GuerillaName(_value),
                BaseClass = new ClassInfo(baseName)
            };
            if (hasTagClassAttribute)
                wrapperClassInfo.Attributes.Add(tagClassAttribute);
            wrapperClassInfo.Name = wrapperName;
            return wrapperClassInfo;
        }

        public void GenerateWriteBlockTemplateMethod()
        {
            MethodsTemplates.Add(new MethodInfo
            {
                Arguments = new List<ParameterInfo> {new ParameterInfo(typeof (BinaryWriter))},
                AccessModifiers = AccessModifiers.Internal | AccessModifiers.Virtual,
                ClassName = "Write{0}Array",
                Body = "",
                Returns = "void"
            });
        }

        public void GenerateWriteDataMethod()
        {
//            var binaryWriterParam = new ParameterInfo(typeof(BinaryWriter), "binaryWriter");
//            var dataParam = new ParameterInfo(typeof(byte[]), "data");
//            var addressParam = new ParameterInfo(typeof(long), "nextAddress") { Modifier = ParameterModifier.Ref };

//            Methods.Add(new MethodInfo
//            {
//                Arguments = new List<ParameterInfo>
//                {
//                    binaryWriterParam,
//                    dataParam,
//                    addressParam
//                },
//                AccessModifiers = AccessModifiers.Internal | AccessModifiers.Virtual,
//                ClassName = "WriteData",
//                Body = string.Format(
//@"using ({0}.BaseStream.Pin())
//{{
//    {0}.BaseStream.Position = {2};
//    {0}.BaseStream.Pad(4);
//    {0}.Write({1});
//    {0}.BaseStream.Pad(4);
//    {2} = {0}.BaseStream.Position;
//}}", binaryWriterParam.Name, dataParam.Name, addressParam.Name),
//                Returns = "void"
//            });
        }

        public void GenerateWriteArrayMethod()
        {
        }

        public void GenerateWriteMethod()
        {
            var tab = 0;
            var writeMethod = new MethodInfo
            {
                AccessModifiers = AccessModifiers.Public | AccessModifiers.Override,
                Arguments = new List<ParameterInfo>
                {
                    new ParameterInfo(typeof (BinaryWriter)),
                    new ParameterInfo(typeof (int), "nextAddress")
                },
                ClassName = "Write",
                Returns = "int"
            };
            var binaryWriter = writeMethod.Arguments.First();
            var addressParam = writeMethod.Arguments[1];
            var bodyBuilder = new StringBuilder();
            bodyBuilder.AppendLine(string.Format("using({0})",
                StaticReflection.GetMemberName((BinaryWriter b) => b.BaseStream.Pin(), binaryWriter)));
            bodyBuilder.AppendLine("{".Tab(ref tab));
            foreach (var item in Fields)
            {
                if (item.IsArray)
                {
                    // fixed byte array like padding or skip arrays
                    if (item.ArraySize > 0 && Type.GetType(item.FieldTypeName) == typeof (byte))
                    {
                        bodyBuilder.AppendLine(string.Format("{0}.Write({1}, 0, {2});", binaryWriter.Name,
                            item.Value.Name, item.ArraySize));
                    }
                    // variable byte array (data)
                    else if (Type.GetType(item.FieldTypeName) == typeof (byte))
                    {
                        bodyBuilder.AppendLine(string.Format("{1} = Guerilla.WriteData({0}, {2}, {1});",
                            binaryWriter.Name, addressParam.Name, item.Value.Name));
                    }
                    // variable short array (data)
                    else if (Type.GetType(item.FieldTypeName) == typeof (short))
                    {
                        bodyBuilder.AppendLine(string.Format("{1} = Guerilla.WriteData({0}, {2}, {1});",
                            binaryWriter.Name, addressParam.Name, item.Value.Name));
                    }
                    // inline array
                    else if (item.ArraySize > 0)
                    {
                        for (var i = 0; i < item.ArraySize; i++)
                        {
                            bodyBuilder.AppendLine(string.Format("{0}[{1}].Write({2});", item.Value.Name, i,
                                binaryWriter.Name));
                        }
                    }
                    // assume a TagBlock
                    else
                    {
                        var format = string.Format("{3} = Guerilla.WriteBlockArray<{1}>({2}, {0}, {3});",
                            item.Value.Name, item.FieldTypeName, binaryWriter.Name, addressParam.Name);
                        bodyBuilder.AppendLine(format);
                    }
                }
                else
                {
                    if (EnumDefinitions.Any(x => x.Value.Name == item.FieldTypeName))
                    {
                        var enumDefinition = EnumDefinitions.First(x => x.Value.Name == item.FieldTypeName);
                        var type = enumDefinition.BaseType == EnumInfo.Type.Byte
                            ? "Byte"
                            : enumDefinition.BaseType == EnumInfo.Type.Short ? "Int16" : "Int32";

                        bodyBuilder.AppendLine(string.Format("{0}.Write(({1}){2});", binaryWriter.Name, type,
                            item.Value.Name));
                    }
                    else if (Type.GetType(item.FieldTypeName) == null)
                    {
                        bodyBuilder.AppendLine(string.Format("{0}.Write({1});", item.Value.Name, binaryWriter.Name));
                    }
                    else
                    {
                        bodyBuilder.AppendLine(string.Format("{0}.Write({1});", binaryWriter.Name, item.Value.Name));
                    }
                }
            }

            bodyBuilder.AppendLine(string.Format("return {0};", writeMethod.Arguments[1].Name));
            bodyBuilder.AppendLine("}".Tab(ref tab));


            var baseMethodCall = string.Format("base.{0};\n", writeMethod.GetMethodSignature());

            writeMethod.Body = baseMethodCall + bodyBuilder.ToString().Trim();
            Methods.Add(writeMethod);
        }

        public override string ToString()
        {
            return string.Format("{0}:{1}", "Class",
                string.IsNullOrEmpty(Namespace) ? _value.Name : string.Format("{0}.{1}", Namespace, _value.Name));
        }

        private void FormatFieldNames(TokenDictionary tokenDictionary)
        {
            foreach (var item in Fields)
            {
                var token = tokenDictionary.GenerateValidToken(GuerillaCs.ToMemberName(item.Value.Name));
                item.Value.Name = token;
            }

            foreach (var item in Methods)
            {
                var token = tokenDictionary.GenerateValidToken(GuerillaCs.ToMemberName(item.ClassName));
                item.ClassName = token;
            }

            foreach (var item in EnumDefinitions)
            {
                var token = tokenDictionary.GenerateValidToken(GuerillaCs.ToTypeName(item.Value.Name));
                item.Value.Name = token;
            }
        }
    }
}