using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
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
                new UsingInfo("System.IO"),
                new UsingInfo("System.Collections.Generic"),
                new UsingInfo("System.Linq")
            };  
            Attributes = new List<AttributeInfo>();
            Fields = new List<FieldInfo>();
            Properties = new List<PropertyInfo>();
            Constructors = new List<MethodInfo>();
            EnumDefinitions = new List<EnumInfo>();
            ClassDefinitions = new List<ClassInfo>();
            Methods = new List<MethodInfo>();
            MethodTemplates = new List<MethodInfo>();
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
                var hasInterfaces = !string.IsNullOrWhiteSpace(Interfaces);
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
        public List<MethodInfo> MethodTemplates { get; set; }
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
            if (Guerilla.SplitNamespaceFromFieldName(_value.Name, out name, out @namespace))
            {
                Name = tokenDictionary.GenerateValidToken(Guerilla.ToTypeName(name));
                Namespace = new NamespaceInfo(Guerilla.ToTypeName(@namespace));
            }
            else
            {
                Name = tokenDictionary.GenerateValidToken(Guerilla.ToTypeName(_value.Name));
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
            MethodTemplates.Clear();
            Methods.Clear();
            Constructors.Clear();

            Methods.AddRange(new[]
            {
                MethodInfoFactory.GenerateReadFieldsMethod(this),
                MethodInfoFactory.GenerateReadPointersMethod(this)
            });

            GenerateWriteMethod();
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


            var baseMethodCall = string.Format("base.{0};\n", writeMethod.GetMethodCallSignature());

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
                var token = tokenDictionary.GenerateValidToken(Guerilla.ToMemberName(item.Value.Name));
                item.Value.Name = token;
            }

            foreach (var item in Methods)
            {
                var token = tokenDictionary.GenerateValidToken(Guerilla.ToMemberName(item.ClassName));
                item.ClassName = token;
            }

            foreach (var item in EnumDefinitions)
            {
                var token = tokenDictionary.GenerateValidToken(Guerilla.ToTypeName(item.Value.Name));
                item.Value.Name = token;
            }
        }
    }
}