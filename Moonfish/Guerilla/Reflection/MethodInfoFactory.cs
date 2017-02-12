using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Fasterflect;
using Moonfish.Tags;

namespace Moonfish.Guerilla.Reflection
{
    public class MethodInfoFactory
    {
        public static MethodInfo GenerateReadPointersMethod(ClassInfo classInfo)
        {
            var method = new MethodInfo
            {
                ClassName = "ReadPointers",
                AccessModifiers = AccessModifiers.Public | AccessModifiers.Override,
                Arguments = new List<ParameterInfo>
                {
                    new ParameterInfo(typeof (BinaryReader)),
                    new ParameterInfo(typeof (Queue<BlamPointer>), "blamPointers"),
                },
                Returns = typeof (void).Name()
            };

            var body = new StringBuilder();
            body.AppendFormatLine("base.{0};", method.GetMethodCallSignature());

            foreach (var item in classInfo.Fields)
            {
                if (item.IsArray)
                {
                    // inline array
                    if (item.ArraySize > 0 && Type.GetType(item.FieldTypeName) == typeof (byte))
                    {
                        continue;
                    }
                    // variable byte array (data)
                    else if (Type.GetType(item.FieldTypeName) == typeof (byte))
                    {
                        body.AppendFormatLine(
                            "{0} = ReadDataByteArray(binaryReader, blamPointers.Dequeue());", item.Value.Name);
                    }
                    // variable short array (data)
                    else if (Type.GetType(item.FieldTypeName) == typeof (short))
                    {
                        body.AppendFormatLine(
                            "{0} = ReadDataShortArray(binaryReader, blamPointers.Dequeue());", item.Value.Name);
                    }
                    // inline array
                    else if (item.ArraySize > 0)
                    {
                        for (var i = 0; i < item.ArraySize; i++)
                        {
                            body.AppendFormatLine("{0}[{1}].ReadPointers(binaryReader, blamPointers);", item.Value.Name,
                                i);
                        }
                    }
                    // assume a TagBlock
                    else
                    {
                        body.AppendFormatLine(
                            "{1} = ReadBlockArrayData<{0}>(binaryReader, blamPointers.Dequeue());",
                            item.FieldTypeName, item.Value.Name);
                    }
                }
                else
                {
                    if (Type.GetType(item.FieldTypeName) == null && classInfo.EnumDefinitions.All(x => x.Value.Name != item.FieldTypeName))
                    {
                        body.AppendFormatLine("{0}.ReadPointers(binaryReader, blamPointers);", item.Value.Name);
                    }
                }
            }
            method.Body = body.ToString().TrimEnd();
            return method;
        }

        public static MethodInfo GenerateReadFieldsMethod(ClassInfo classInfo)
        {


















            var method = new MethodInfo
            {
                ClassName = "ReadFields",
                AccessModifiers = AccessModifiers.Public | AccessModifiers.Override,
                Arguments = new List<ParameterInfo>
                {
                    new ParameterInfo(typeof (BinaryReader))
                },
                Returns = typeof(Queue<BlamPointer>).Name()
            };
            var body = new StringBuilder();

            body.AppendFormatLine("var blamPointers = new Queue<BlamPointer>(base.{0});", method.GetMethodCallSignature());

            foreach (var item in classInfo.Fields)
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
                            "blamPointers.Enqueue(ReadBlockArrayPointer(binaryReader, 1));", item.FieldTypeName);
                    }
                    // variable short array (data)
                    else if (Type.GetType(item.FieldTypeName) == typeof(short))
                    {
                        body.AppendFormatLine(
                            "blamPointers.Enqueue(ReadBlockArrayPointer(binaryReader, 2));", item.FieldTypeName);
                    }
                    // inline array
                    else if (item.ArraySize > 0)
                    {
                        var initializer = "";
                        for (var i = 0; i < item.ArraySize; i++)
                        {
                            initializer += string.Format("new {0}(){1}", item.FieldTypeName,
                                i == item.ArraySize - 1 ? "" : ", ");
                        }
                        body.AppendLine(string.Format("{0} = new []{{ {1} }};", item.Value.Name, initializer));

                        for (var i = 0; i < item.ArraySize; i++)
                        {
                            body.AppendFormatLine(
                                "blamPointers = new Queue<BlamPointer>(blamPointers.Concat({0}[{1}].ReadFields(binaryReader)));",
                                item.Value.Name, i);
                        }
                    }
                    // assume a TagBlock
                    else
                    {
                        body.AppendFormatLine(
                            "blamPointers.Enqueue(ReadBlockArrayPointer<{0}>(binaryReader));", item.FieldTypeName);
                    }
                }
                else
                {
                    if (classInfo.EnumDefinitions.Any(x => x.Value.Name == item.FieldTypeName))
                    {
                        var enumDefinition = classInfo.EnumDefinitions.First(x => x.Value.Name == item.FieldTypeName);
                        var type = enumDefinition.BaseType == EnumInfo.Type.Byte
                            ? "Byte"
                            : enumDefinition.BaseType == EnumInfo.Type.Short ? "Int16" : "Int32";
                        body.AppendLine(string.Format("{0} = ({1})binaryReader.Read{2}();", item.Value.Name,
                            item.FieldTypeName, type));
                    }
                    else if (Type.GetType(item.FieldTypeName) == null)
                    {
                        body.AppendFormatLine("{0} = new {1}();", item.Value.Name,
                            item.FieldTypeName);
                        body.AppendFormatLine(
                            "blamPointers = new Queue<BlamPointer>(blamPointers.Concat({0}.ReadFields(binaryReader)));",
                            item.Value.Name);
                    }
                    else
                    {
                        var value = BinaryIOReflection.GetBinaryReaderMethodName(Type.GetType(item.FieldTypeName));
                        body.AppendLine(string.Format("{0} = binaryReader.{1}();", item.Value.Name, value));
                    }
                }
            }
            body.AppendLine("return blamPointers;");
            method.Body = body.ToString();
            return method;
        }


    }
}