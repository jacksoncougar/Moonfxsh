using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

using Fasterflect;
using System.Reflection;
using System.Reflection.Emit;
using Microsoft.CSharp;

namespace Moonfish.Tags
{

    static class Deserializer
    {
        static Dictionary<Type, Tuple<MethodInfo, bool>> ExtensionMethodDictionary;
        static Dictionary<Type, Fasterflect.MethodInvoker> ReadTypeMethods;
        static Assembly ExecutingAssembly;
        static MapStream Source;

        static Deserializer()
        {
            ExtensionMethodDictionary = new Dictionary<Type, Tuple<MethodInfo, bool>>();
            ExecutingAssembly = System.Reflection.Assembly.GetExecutingAssembly();
            CacheBinaryReaderMethods();
        }

        public static dynamic Deserialize(this MapStream source, Type type)
        {
            var sourceReader = new BinaryReader(source);
            Source = source;
            PostProcessQueue = new List<Tuple<FieldInfo, object, MethodInvoker>>();

            var constructor = (from constructors in type.GetConstructors(BindingFlags.Public | BindingFlags.Instance)
                               where constructors.HasParameterSignature(new Type[]{typeof(BinaryReader)})
                               select constructors).FirstOrDefault();
            if (constructor != null)
            {
                return constructor.Invoke(new[] { sourceReader });
            }

            var returnValue = Deserialize(sourceReader, type);
            for (var i = 0; i < PostProcessQueue.Count; ++i)
            {
                var field = PostProcessQueue[i].Item1;
                var item = PostProcessQueue[i].Item2;
                var methodInfo = PostProcessQueue[i].Item3;

                methodInfo(item, sourceReader, item, field);
            }
            return returnValue;
        }

        private static object DeserializeArray(BinaryReader sourceReader, Type elementType, int elementSize, int elementCount)
        {
            var arrayDataAddress = sourceReader.BaseStream.Position;

            var fields = elementType.Fields(
                 Flags.Public |
                 Flags.NonPublic |
                 Flags.Instance);


            List<FieldDelegateInformation> fieldMethods;


            var item = elementType.CreateInstance();
            ProcessFieldTypes(fields, out fieldMethods);


            var array = elementType.MakeArrayType().CreateInstance(elementCount);

            for (var i = 0; i < elementCount; ++i)
            {
                var element = elementType.CreateInstance();
                sourceReader.BaseStream.Position = arrayDataAddress + i * elementSize;
                InvokeFields(sourceReader, element, fields, fieldMethods);
                array.SetElement(i, element);
            }
            return array;
        }
        static void DeserializeTag(this BinaryReader sourceReader, object item, FieldInfo field)
        {
            var reference = sourceReader.ReadTagReference();
            Source.Position = Source[reference.Ident].Meta.VirtualAddress;

            field.SetValue(item, Deserialize(sourceReader, Halo2.GetTypeOf(reference.Class)));
        }

        static void Deserialize(this BinaryReader sourceReader, object item, FieldInfo field)
        {
            field.SetValue(item, Deserialize(sourceReader, field.FieldType));
        }

        public static dynamic Deserialize(this BinaryReader sourceReader, Type type)
        {
            var streamPosition = sourceReader.BaseStream.Position;

            var item = type.CreateInstance();

            var fields = type.Fields(
                 Flags.Public |
                 Flags.NonPublic |
                 Flags.Instance);

            List<FieldDelegateInformation> fieldMethods;

            ProcessFieldTypes(fields, out fieldMethods);

            InvokeFields(sourceReader, item, fields, fieldMethods);

            return item;
        }

        struct FieldDelegateInformation
        {
            public readonly FieldInfo Callee;
            public readonly Delegate MethodDelegate;
            public readonly object[] Parameters;
            public readonly int StreamOffset;

            public FieldDelegateInformation(FieldInfo callee, Delegate methodDelegate, int streamOffset)
            {
                this.Callee = callee;
                this.MethodDelegate = methodDelegate;
                this.StreamOffset = streamOffset;
                Parameters = new object[] { };
            }

            public FieldDelegateInformation(FieldInfo callee, Delegate methodDelegate, int streamOffset, params object[] parameters)
            {
                this.Callee = callee;
                this.MethodDelegate = methodDelegate;
                this.StreamOffset = streamOffset;
                this.Parameters = parameters;
            }
        }

        private static void ProcessFieldTypes(IList<FieldInfo> fields, out List<FieldDelegateInformation> fieldMethodInfo)
        {
            fieldMethodInfo = new List<FieldDelegateInformation>(fields.Count);
            var fieldOffset = 0;
            foreach (var field in fields)
            {
                var tagFieldAttribute = field.Attributes<TagFieldAttribute>().FirstOrDefault();

                if (tagFieldAttribute != null)
                {
                    if (tagFieldAttribute.UsesFieldOffset)
                    {
                        fieldOffset = tagFieldAttribute.Offset;
                    }
                    if (tagFieldAttribute.UsesCustomFunction)
                    {
                        fieldMethodInfo.Add(new FieldDelegateInformation(field, new ProcessFieldInfo(PostProcessField), fieldOffset));
                        fieldOffset += SizeOf(field);
                        continue;
                    }
                }
                if (field.FieldType.IsArray)
                {
                    var elementType = field.FieldType.GetElementType();
                    var elementSize = 0;
                    try
                    {
                        elementSize = SizeOf(elementType);
                    }
                    catch (ArgumentException)
                    {
                        var layoutAttribute = elementType.Attribute(typeof(LayoutAttribute)) as LayoutAttribute;
                        if (layoutAttribute != null)
                            elementSize = layoutAttribute.Size;
                    }

                    if (field.IsDefined(typeof(TagBlockFieldAttribute), false))
                    {
                        fieldMethodInfo.Add(new FieldDelegateInformation(field, new ProcessFieldInfo(ProcessTagBlockArray), fieldOffset));
                    }
                    else if (field.IsDefined(typeof(MarshalAsAttribute), false))
                    {
                        var marhsalAsAttribute = field.Attribute(typeof(MarshalAsAttribute)) as MarshalAsAttribute;
                        if (marhsalAsAttribute.Value == UnmanagedType.ByValArray)
                        {
                            var count = marhsalAsAttribute.SizeConst;

                            var basicTypes = new List<Type>()
                            {
                                typeof(sbyte),
                                typeof(byte),
                                typeof(short),
                                typeof(ushort),
                                typeof(int),
                                typeof(uint),
                                typeof(float),
                            };
                            if (basicTypes.Any(x => x == elementType))
                            {
                                fieldMethodInfo.Add(new FieldDelegateInformation(field, new ProcessFieldInfo(ReadFixedArrayField), fieldOffset));
                            }
                            else
                            {
                                var deserializeMethod = typeof(Deserializer).Method("ProcessFixedStructArray", new Type[] { typeof(BinaryReader), typeof(Object), typeof(FieldInfo) }, Flags.Static | Flags.NonPublic | Flags.Public);
                                fieldMethodInfo.Add(new FieldDelegateInformation(field, ProcessFieldInfo.CreateDelegate(typeof(ProcessFieldInfo), deserializeMethod), fieldOffset));
                            }
                        }
                        else throw new MarshalDirectiveException();
                    }
                }
                else if (field.IsDefined(typeof(TagReferenceAttribute), false) && field.FieldType != typeof(TagReference))
                {
                    var deserializeMethod = typeof(Deserializer).Method("DeserializeTag", new Type[] { typeof(BinaryReader), typeof(Object), typeof(FieldInfo) }, Flags.Static | Flags.NonPublic | Flags.Public);
                    fieldMethodInfo.Add(new FieldDelegateInformation(field, ProcessFieldInfo.CreateDelegate(typeof(ProcessFieldInfo), deserializeMethod), fieldOffset));
                }
                else if (field.IsDefined(typeof(TagStructFieldAttribute), false))
                {
                    var deserializeMethod = typeof(Deserializer).Method("Deserialize", new Type[] { typeof(BinaryReader), typeof(Object), typeof(FieldInfo) }, Flags.Static | Flags.NonPublic | Flags.Public);
                    fieldMethodInfo.Add(new FieldDelegateInformation(field, ProcessFieldInfo.CreateDelegate(typeof(ProcessFieldInfo), deserializeMethod), fieldOffset));
                }
                else if (field.FieldType.IsEnum)
                {
                    var readEnumMethod = typeof(Deserializer).Method("ReadEnum", Flags.Static | Flags.NonPublic | Flags.Public);
                    fieldMethodInfo.Add(new FieldDelegateInformation(field, ProcessFieldInfo.CreateDelegate(typeof(ProcessFieldInfo), readEnumMethod), fieldOffset));
                }
                else
                {
                    var readFieldMethod = typeof(Deserializer).Method("ReadField", new Type[] { typeof(BinaryReader), typeof(Object), typeof(FieldInfo) }, Flags.Static | Flags.NonPublic | Flags.Public);
                    fieldMethodInfo.Add(new FieldDelegateInformation(field, ProcessFieldInfo.CreateDelegate(typeof(ProcessFieldInfo), readFieldMethod), fieldOffset));
                }
                fieldOffset += SizeOf(field);
            }
        }

        private static void InvokeFields(BinaryReader binaryReader, object item, IList<FieldInfo> fields, List<FieldDelegateInformation> fieldsMethodInfo)
        {
            var fieldSetDataAddress = binaryReader.BaseStream.Position;
            for (var i = 0; i < fields.Count; ++i)
            {
                var field = fields[i];
                var fieldMethodInfo = fieldsMethodInfo[i];

                binaryReader.BaseStream.Position = fieldSetDataAddress + fieldMethodInfo.StreamOffset;
                ProcessFieldInfo fieldDeletegate = (ProcessFieldInfo)fieldMethodInfo.MethodDelegate;
                fieldDeletegate(binaryReader, item, field);
            }
        }

        public delegate void PreprocessFieldDelegate(BinaryReader sourceReader, FieldInfo field);
        public static PreprocessFieldDelegate PreprocessField;

        public delegate void ProcessTagBlockArrayDelegate(BinaryReader sourceReader, object item, FieldInfo field);
        public static ProcessTagBlockArrayDelegate ProcessTagBlockArray = new ProcessTagBlockArrayDelegate(DefaultProcessTagBlockArray);

        private static void DefaultProcessTagBlockArray(BinaryReader sourceReader, object item, FieldInfo field)
        {
            Type elementType = field.FieldType.GetElementType();
            int elementSize = SizeOf(elementType);

            var count = sourceReader.ReadInt32();
            var address = sourceReader.ReadInt32();

            sourceReader.BaseStream.Position = address;

            var array = Deserializer.DeserializeArray(sourceReader, elementType, elementSize, count);
            field.Set(item, array);
        }

        public static int SizeOf(Type elementType)
        {
            var elementSize = 0;
            var layoutAttribute = elementType.Attribute(typeof(LayoutAttribute)) as LayoutAttribute;
            if (layoutAttribute != null)
                elementSize = layoutAttribute.Size;
            else elementSize = Marshal.SizeOf(elementType);
            return elementSize;
        }
        private static void ProcessFixedStructArray(BinaryReader sourceReader, object item, FieldInfo field)
        {
            Type elementType = field.FieldType.GetElementType();
            int elementSize = SizeOf(elementType);

            var marhsalAsAttribute = field.Attribute<MarshalAsAttribute>();
            var count = marhsalAsAttribute.SizeConst;

            var array = Deserializer.DeserializeArray(sourceReader, elementType, elementSize, count);
            field.Set(item, array);
        }

        static void ReadFixedArrayField(BinaryReader binaryReader, object item, FieldInfo field)
        {
            var marhsalAsAttribute = field.Attribute<MarshalAsAttribute>();
            var elementType = field.FieldType.GetElementType();
            if (marhsalAsAttribute.Value == UnmanagedType.ByValArray)
            {
                var count = marhsalAsAttribute.SizeConst;
                var array = Array.CreateInstance(elementType, count);
                if (elementType == typeof(byte))
                {
                    array = binaryReader.ReadBytes(count);
                }
                else
                {
                    for (int i = 0; i < count; ++i)
                    {
                        var element = ReadField(binaryReader, elementType);
                        ArrayExtensions.SetElement(array, i, element);
                    }
                }
                field.Set(item, array);
            }
        }
        static void PostProcessField(BinaryReader binaryReader, object item, FieldInfo field)
        {
            var customReadFieldMethod = (from method in item.GetType().GetMethods(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public)
                                         where method.HasParameterSignature(new Type[] { typeof(BinaryReader), typeof(Object), typeof(FieldInfo) })
                                         select method).FirstOrDefault();

            PostProcessQueue.Add(new Tuple<FieldInfo, object, MethodInvoker>(field, item, customReadFieldMethod.DelegateForCallMethod()));
        }
        private static void ReadField(BinaryReader binaryReader, object item, FieldInfo field) { field.SetValue(item, ReadField(binaryReader, field.FieldType)); }

        private static object ReadField(BinaryReader binaryReader, Type type)
        {
            var methodInfo = ReadTypeMethods[type];
            return methodInfo(binaryReader, new[] { binaryReader });
        }
        static void CacheBinaryReaderMethods()
        {
            var types = ExecutingAssembly.GetTypes();
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
                ReadTypeMethods = new Dictionary<Type, MethodInvoker>(totalMethods.Count());
                foreach (var item in totalMethods)
                {
                    ReadTypeMethods[item.type] = item.method.DelegateForCallMethod();
                }
            }
        }

        private static void ReadEnum(BinaryReader binaryReader, object item, FieldInfo field)
        {
            var enumType = Enum.GetUnderlyingType(field.FieldType);
            if (enumType == typeof(byte))
            {
                var enumValue = Enum.ToObject(field.FieldType, binaryReader.ReadByte());
                field.SetValue(item, enumValue);
            }
            else if (enumType == typeof(short))
            {
                var enumValue = Enum.ToObject(field.FieldType, binaryReader.ReadInt16());
                field.SetValue(item, enumValue);
            }
            else if (enumType == typeof(int))
            {
                var enumValue = Enum.ToObject(field.FieldType, binaryReader.ReadInt32());
                field.SetValue(item, enumValue);
            }
            else throw new InvalidDataException();
        }
        
        delegate void ProcessFieldInfo(BinaryReader binaryReader, Object item, FieldInfo field);

        static List<Tuple<FieldInfo, object, MethodInvoker>> PostProcessQueue;

        private static int SizeOf(FieldInfo field)
        {

            if (field.IsDefined(typeof(TagBlockFieldAttribute), false)) { return 8; }
            if (field.IsDefined(typeof(TagReferenceAttribute), false)) { return 8; }
            else if (field.IsDefined(typeof(MarshalAsAttribute), false))
            {
                var marshalAsAttribute = field.GetCustomAttributes(typeof(MarshalAsAttribute), false)[0] as MarshalAsAttribute;
                if (marshalAsAttribute.Value == UnmanagedType.ByValArray)
                {
                    var elementSize = SizeOf(field.FieldType.GetElementType());
                    var count = marshalAsAttribute.SizeConst;
                    return elementSize * count;
                }
            }
            if (field.FieldType.IsEnum) return SizeOf(Enum.GetUnderlyingType(field.FieldType));
            return SizeOf(field.FieldType);
        }

        internal static int OffsetOf(Type type, string p)
        {

            var fields = type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            var fieldOffset = 0;

            foreach (var field in fields)
            {
                if (field.Name == p) return fieldOffset;

                fieldOffset += Deserializer.SizeOf(field);
            }

            throw new Exception(string.Format("Field \'{0}\' not found in Type \'{1}\'", p, type));
        }
    }
}
