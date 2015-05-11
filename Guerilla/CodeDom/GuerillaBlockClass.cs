using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using Microsoft.CSharp;
using Moonfish.Guerilla.Reflection;
using Moonfish.Tags;
using OpenTK;

namespace Moonfish.Guerilla.CodeDom
{
    internal class GuerillaBlockClass
    {
        private static readonly Dictionary<MoonfishFieldType, Type> ValueTypeDictionary;
        private static GuerillaCommentCollection _comments = new GuerillaCommentCollection();
        private readonly string _outputFileName;
        private readonly CodeTypeDeclaration _targetClass;
        private readonly CodeCompileUnit _targetUnit;
        private readonly TokenDictionary _tokenDictionary;

        static GuerillaBlockClass()
        {
            BinaryIOReflection.CacheMethods();
            var assembly = typeof (StringIdent).Assembly;
            var query = from type in assembly.GetTypes()
                where type.GetCustomAttributes(typeof (GuerillaTypeAttribute), false).Any()
                select type;
            var valueTypes = query.ToArray();
            ValueTypeDictionary = new Dictionary<MoonfishFieldType, Type>(valueTypes.Count());
            foreach (var type in valueTypes)
            {
                var guerillaTypeAttributes =
                    (GuerillaTypeAttribute[]) type.GetCustomAttributes(typeof (GuerillaTypeAttribute), false);
                foreach (var guerillaType in guerillaTypeAttributes)
                {
                    ValueTypeDictionary.Add(guerillaType.FieldType, type);
                }
            }
            ValueTypeDictionary.Add(MoonfishFieldType.FieldAngle, typeof (float));
            ValueTypeDictionary.Add(MoonfishFieldType.FieldRealEulerAngles_3D, typeof (Vector3));
            ValueTypeDictionary.Add(MoonfishFieldType.FieldCharInteger, typeof (byte));
            ValueTypeDictionary.Add(MoonfishFieldType.FieldShortInteger, typeof (short));
            ValueTypeDictionary.Add(MoonfishFieldType.FieldShortBounds, typeof (int));
            ValueTypeDictionary.Add(MoonfishFieldType.FieldLongInteger, typeof (int));
            ValueTypeDictionary.Add(MoonfishFieldType.FieldReal, typeof (float));
            ValueTypeDictionary.Add(MoonfishFieldType.FieldRealFraction, typeof (float));
            ValueTypeDictionary.Add(MoonfishFieldType.FieldRealFractionBounds, typeof (Vector2));
            ValueTypeDictionary.Add(MoonfishFieldType.FieldRealPoint_2D, typeof (Vector2));
            ValueTypeDictionary.Add(MoonfishFieldType.FieldRealVector_3D, typeof (Vector3));
            ValueTypeDictionary.Add(MoonfishFieldType.FieldRealVector_2D, typeof (Vector2));
            ValueTypeDictionary.Add(MoonfishFieldType.FieldRealPoint_3D, typeof (Vector3));
            ValueTypeDictionary.Add(MoonfishFieldType.FieldRealEulerAngles_2D, typeof (Vector2));
            ValueTypeDictionary.Add(MoonfishFieldType.FieldRealPlane_2D, typeof (Vector3));
            ValueTypeDictionary.Add(MoonfishFieldType.FieldRealPlane_3D, typeof (Vector4));
            ValueTypeDictionary.Add(MoonfishFieldType.FieldRealQuaternion, typeof (Quaternion));
            ValueTypeDictionary.Add(MoonfishFieldType.FieldRealArgbColor, typeof (Vector4));
            ValueTypeDictionary.Add(MoonfishFieldType.FieldRectangle_2D, typeof (Vector2));
        }

        public GuerillaBlockClass(MoonfishTagGroup tag, IList<MoonfishTagGroup> tagGroups = null)
            : this(tag.Definition.Name.ToPascalCase().ToAlphaNumericToken())
        {
            Size = tag.Definition.CalculateSizeOfFieldSet();
            var hasParent = tagGroups != null && tagGroups.Any(x => x.Class == tag.ParentClass);
            if (hasParent)
            {
                var parentTag = tagGroups.First(x => x.Class == tag.ParentClass);
                var parentClass = new GuerillaBlockClass(parentTag, tagGroups);
                parentClass.GenerateCSharpCode();
                _tokenDictionary = new TokenDictionary(parentClass._tokenDictionary);
                _targetClass.BaseTypes[0] = new CodeTypeReference(parentClass._targetClass.Name);

                Size += parentClass.Size;
            }

            Initialize(tag.Definition.Fields, Size, tag.Definition.Alignment);
        }

        public GuerillaBlockClass(MoonfishTagDefinition definition)
            : this(definition.Name.ToPascalCase().ToAlphaNumericToken())
        {
            Size = definition.CalculateSizeOfFieldSet();
            Initialize(definition.Fields, Size, definition.Alignment);
        }

        private GuerillaBlockClass(string className)
        {
            _outputFileName = string.Format("{0}.generated.cs", className);

            _tokenDictionary = new TokenDictionary();
            _targetUnit = new CodeCompileUnit();
            var t = new CSharpCodeProvider();
            var tagsCodeNamespace = new CodeNamespace("Moonfish.Guerilla.Tags.Experimental");
            tagsCodeNamespace.Imports.Add(new CodeNamespaceImport("Moonfish.Tags"));
            tagsCodeNamespace.Imports.Add(new CodeNamespaceImport("Moonfish.Model"));
            tagsCodeNamespace.Imports.Add(new CodeNamespaceImport("System.IO"));
            tagsCodeNamespace.Imports.Add(new CodeNamespaceImport("System.Collections.Generic"));
            tagsCodeNamespace.Imports.Add(new CodeNamespaceImport("System.Linq"));
            _targetClass = new CodeTypeDeclaration(className)
            {
                IsClass = true,
                TypeAttributes = TypeAttributes.Public,
                BaseTypes = {new CodeTypeReference(typeof (GuerillaBlock)), new CodeTypeReference(typeof(IWriteQueueable).Name)}
            };
            tagsCodeNamespace.Types.Add(_targetClass);
            _targetUnit.Namespaces.Add(tagsCodeNamespace);
        }

        private GuerillaBlockClass(string className, List<MoonfishTagField> fields) : this(className)
        {
            Size = MoonfishTagDefinition.CalculateSizeOfFieldSet(fields);
            Initialize(fields, Size, 1);
        }

        public int Size { get; private set; }

        private void Initialize(List<MoonfishTagField> fields, int size, int alignment)
        {
            AddReadOnlyIntProperty(StaticReflection.GetMemberName((GuerillaBlock block) => block.SerializedSize), size);
            AddReadOnlyIntProperty(StaticReflection.GetMemberName((GuerillaBlock block) => block.Alignment),
                alignment);
            GenerateFields(fields);
            GenerateReadFieldsMethod();
            GenerateReadInstancesMethod();
            GenerateIWriteQueueableQueueWritesMethod();
            GenerateWriteMethod();
        }

        private void GenerateReadFieldsMethod()
        {
            var method = new CodeMemberMethod
            {
                Name = "ReadFields",
                Attributes = MemberAttributes.Override | MemberAttributes.Public,
                ReturnType = new CodeTypeReference(typeof (Queue<BlamPointer>))
            };

            //  loop iterator 
            var loopVariable = new CodeVariableReferenceExpression("i");
            var loopVariableDeclaration = new CodeVariableDeclarationStatement(typeof (int),
                loopVariable.VariableName);

            //  BinaryReader binaryReader = new BinaryReader();
            const string binaryReader = "binaryReader";
            var binaryReaderReference = new CodeTypeReference(typeof (BinaryReader));

            var binaryReaderParameterExpression = new CodeParameterDeclarationExpression(binaryReaderReference,
                binaryReader);

            var binaryReaderArgument = new CodeArgumentReferenceExpression(binaryReader);
            method.Parameters.Add(binaryReaderParameterExpression);

            //  Queue<BlamPointer> pointerQueue = new Queue<BlamPointer>();
            const string pointerQueue = "pointerQueue";
            var pointerQueueReference = new CodeTypeReference(typeof (Queue<BlamPointer>));
            var pointerQueueVariable = new CodeVariableReferenceExpression(pointerQueue);

            var concatMethodName =
                StaticReflection.GetMemberName((Queue<BlamPointer> item) => item.Concat(new Queue<BlamPointer>()));

            if (!_targetClass.BaseTypes.Contains(new CodeTypeReference(typeof (GuerillaBlock))))
            {
                method.Statements.Add(
                    new CodeVariableDeclarationStatement(pointerQueueReference, pointerQueue,
                        new CodeObjectCreateExpression(pointerQueueReference,
                            new CodeMethodInvokeExpression(new CodeBaseReferenceExpression(), method.Name,
                                binaryReaderArgument))));
            }
            else
            {
                method.Statements.Add(new CodeVariableDeclarationStatement(pointerQueueReference,
                    pointerQueue, new CodeObjectCreateExpression(pointerQueueReference)));
            }

            foreach (CodeObject codeObject in _targetClass.Members)
            {
                if (!(codeObject is CodeMemberField)) continue;
                var field = (CodeMemberField) codeObject;

                var fieldReference = new CodeFieldReferenceExpression(new CodeThisReferenceExpression(),
                    field.Name);
                var systemType = ReflectionMethods.GetType(field.Type.BaseType);
                //  Single dimensional arrays
                if (field.Type.ArrayRank == 1)
                {
                    var fieldInitializer = (CodeArrayCreateExpression) field.InitExpression;
                    var arraySize = fieldInitializer == null ? 0 : fieldInitializer.Size;
                    //  fixed byte array like padding or skip data
                    if (systemType == typeof (byte) && arraySize > 0)
                    {
                        var methodName = StaticReflection.GetMemberName((BinaryReader item) => item.ReadBytes(0));
                        method.Statements.Add(new CodeAssignStatement(fieldReference,
                            new CodeMethodInvokeExpression(binaryReaderArgument, methodName,
                                new CodePrimitiveExpression(arraySize))));
                    }
                    // fixed struct array
                    else if (field.UserData.Contains("GuerillaBlock") && arraySize > 0)
                    {
                        var methodName =
                            StaticReflection.GetMemberName(
                                (GuerillaBlock item) => item.ReadFields(default(BinaryReader)));

                        if (!method.Statements.Contains(loopVariableDeclaration))
                            method.Statements.Add(loopVariableDeclaration);
                        method.Statements.Add(new CodeIterationStatement(
                            new CodeAssignStatement(loopVariable, new CodePrimitiveExpression(0)),
                            new CodeBinaryOperatorExpression(loopVariable, CodeBinaryOperatorType.LessThan,
                                new CodePrimitiveExpression(arraySize)),
                            new CodeAssignStatement(loopVariable,
                                new CodeBinaryOperatorExpression(loopVariable, CodeBinaryOperatorType.Add,
                                    new CodePrimitiveExpression(1))),
                            // create new element
                            new CodeAssignStatement(new CodeArrayIndexerExpression(fieldReference, loopVariable),
                                new CodeObjectCreateExpression(field.Type.BaseType)),
                            new CodeAssignStatement(pointerQueueVariable,
                                new CodeObjectCreateExpression(pointerQueueReference,
                                    new CodeMethodInvokeExpression(pointerQueueVariable, concatMethodName,
                                        new CodeMethodInvokeExpression(
                                            new CodeArrayIndexerExpression(fieldReference, loopVariable),
                                            methodName, binaryReaderArgument))))));
                    }
                    //  instanced byte array like data
                    else if (systemType == typeof (byte))
                    {
                        var readBlamPointerMethodName =
                            StaticReflection.GetMemberName(
                                (BinaryReader @class) => @class.ReadBlamPointer(0));
                        var queueMethodName =
                            StaticReflection.GetMemberName(
                                (Queue<BlamPointer> item) => item.Enqueue(new BlamPointer()));

                        method.Statements.Add(new CodeMethodInvokeExpression(pointerQueueVariable, queueMethodName,
                            new CodeMethodInvokeExpression(binaryReaderArgument, readBlamPointerMethodName,
                                new CodePrimitiveExpression(1))));
                    }
                    //  instanced Int16 array like data
                    else if (systemType == typeof (short))
                    {
                        var methodName = StaticReflection.GetMemberName((BinaryReader item) => item.ReadInt16());

                        if (!method.Statements.Contains(loopVariableDeclaration))
                            method.Statements.Add(loopVariableDeclaration);

                        method.Statements.Add(new CodeIterationStatement(
                            new CodeAssignStatement(loopVariable, new CodePrimitiveExpression(0)),
                            new CodeBinaryOperatorExpression(loopVariable, CodeBinaryOperatorType.LessThan,
                                new CodePrimitiveExpression(arraySize)),
                            new CodeAssignStatement(loopVariable,
                                new CodeBinaryOperatorExpression(loopVariable, CodeBinaryOperatorType.Add,
                                    new CodePrimitiveExpression(1))), new CodeAssignStatement(
                                        new CodeArrayIndexerExpression(fieldReference, loopVariable),
                                        new CodeMethodInvokeExpression(binaryReaderArgument, methodName,
                                            new CodeArgumentReferenceExpression()))));
                    }
                    //  tagBlock array
                    else
                    {
                        var enqueueMethodName =
                            StaticReflection.GetMemberName(
                                (Queue<BlamPointer> @class) => @class.Enqueue(new BlamPointer()));
                        var methodName =
                            StaticReflection.GetMemberName((BinaryReader item) => item.ReadBlamPointer(default(int)));
                        var elementSize = (int) field.UserData[0];

                        method.Statements.Add(new CodeMethodInvokeExpression(pointerQueueVariable, enqueueMethodName,
                            new CodeMethodInvokeExpression(binaryReaderArgument, methodName,
                                new CodePrimitiveExpression(elementSize))));
                    }
                }
                //  like an inline struct where T : GuerillaBlock
                else if (field.UserData.Contains("GuerillaBlock"))
                {
                    var methodName =
                        StaticReflection.GetMemberName((GuerillaBlock item) => item.ReadFields(default(BinaryReader)));

                    method.Statements.Add(new CodeAssignStatement(pointerQueueVariable,
                        new CodeObjectCreateExpression(pointerQueueReference,
                            new CodeMethodInvokeExpression(pointerQueueVariable, concatMethodName,
                                new CodeMethodInvokeExpression(fieldReference, methodName, binaryReaderArgument)))));
                }
                //  like a simple value (int, byte, TagClass, TagIdent, etc.)
                else if (systemType != null)
                {
                    var methodName = BinaryIOReflection.GetBinaryReaderMethodName(systemType);

                    method.Statements.Add(new CodeAssignStatement(fieldReference,
                        new CodeMethodInvokeExpression(binaryReaderArgument, methodName,
                            new CodeArgumentReferenceExpression())));
                }
                //  like an enum or flag value
                else
                {
                    var typeDeclaration =
                        _targetClass.Members.OfType<CodeTypeDeclaration>().Single(x => x.Name == field.Type.BaseType);
                    var baseType = Type.GetType(typeDeclaration.BaseTypes[0].BaseType);

                    var methodName = BinaryIOReflection.GetBinaryReaderMethodName(baseType);

                    method.Statements.Add(new CodeAssignStatement(fieldReference,
                        new CodeCastExpression(field.Type.BaseType,
                            new CodeMethodInvokeExpression(binaryReaderArgument, methodName,
                                new CodeArgumentReferenceExpression()))));
                }
            }
            method.Statements.Add(new CodeMethodReturnStatement(pointerQueueVariable));
            _targetClass.Members.Add(method);
        }

        private void GenerateReadInstancesMethod()
        {
            var method = new CodeMemberMethod
            {
                Name = "ReadInstances",
                Attributes = MemberAttributes.Override | MemberAttributes.Public,
                ReturnType = new CodeTypeReference(typeof (void))
            };

            //  loop iterator 
            var loopVariable = new CodeVariableReferenceExpression("i");
            var loopVariableDeclaration = new CodeVariableDeclarationStatement(typeof (int),
                loopVariable.VariableName);

            //  BinaryReader binaryReader = new BinaryReader();
            const string binaryReader = "binaryReader";
            var binaryReaderParameterExpression =
                new CodeParameterDeclarationExpression(new CodeTypeReference(typeof (BinaryReader)),
                    binaryReader);
            var binaryReaderArgument = new CodeArgumentReferenceExpression(binaryReader);
            method.Parameters.Add(binaryReaderParameterExpression);

            //  Queue<BlamPointer> pointerQueue = new Queue<BlamPointer>();
            const string pointerQueue = "pointerQueue";
            var pointerQueueParameterDeclaration =
                new CodeParameterDeclarationExpression(new CodeTypeReference(typeof (Queue<BlamPointer>)),
                    pointerQueue);
            var pointerQueueArgument = new CodeArgumentReferenceExpression(pointerQueue);
            method.Parameters.Add(pointerQueueParameterDeclaration);

            method.Statements.Add(new CodeMethodInvokeExpression(new CodeBaseReferenceExpression(), method.Name,
                binaryReaderArgument, pointerQueueArgument));

            foreach (CodeObject codeObject in _targetClass.Members)
            {
                if (!(codeObject is CodeMemberField)) continue;
                var field = (CodeMemberField) codeObject;

                var fieldReference = new CodeFieldReferenceExpression(new CodeThisReferenceExpression(),
                    field.Name);

                var systemType = ReflectionMethods.GetType(field.Type.BaseType);
                //  Single dimensional arrays
                if (field.Type.ArrayRank == 1)
                {
                    var fieldInitializer = (CodeArrayCreateExpression) field.InitExpression;
                    var arraySize = fieldInitializer == null ? 0 : fieldInitializer.Size;
                    //  fixed byte array like padding or skip data
                    if (systemType == typeof (byte) && arraySize > 0)
                    {
                        continue;
                    }
                    // fixed struct array
                    if (field.UserData.Contains("GuerillaBlock") && arraySize > 0)
                    {
                        var methodName =
                            StaticReflection.GetMemberName(
                                (GuerillaBlock item) =>
                                    item.ReadInstances(default(BinaryReader), new Queue<BlamPointer>()));

                        //  add loop iterator variable if needed
                        if (!method.Statements.Contains(loopVariableDeclaration))
                            method.Statements.Add(loopVariableDeclaration);

                        method.Statements.Add(new CodeIterationStatement(
                            new CodeAssignStatement(loopVariable, new CodePrimitiveExpression(0)),
                            new CodeBinaryOperatorExpression(loopVariable, CodeBinaryOperatorType.LessThan,
                                new CodePrimitiveExpression(arraySize)),
                            new CodeAssignStatement(loopVariable,
                                new CodeBinaryOperatorExpression(loopVariable, CodeBinaryOperatorType.Add,
                                    new CodePrimitiveExpression(1))), new CodeExpressionStatement(
                                        new CodeMethodInvokeExpression(
                                            new CodeArrayIndexerExpression(fieldReference, loopVariable), methodName,
                                            binaryReaderArgument, pointerQueueArgument))));
                    }
                    //  instanced byte array like data
                    else if (systemType == typeof (byte))
                    {
                        var readDataMethodName =
                            StaticReflection.GetMemberName(
                                (GuerillaBlock @class) =>
                                    @class.ReadDataByteArray(new BinaryReader(Stream.Null), new BlamPointer()));

                        var dequeueMethodName =
                            StaticReflection.GetMemberName(
                                (Queue<BlamPointer> item) => item.Dequeue());

                        method.Statements.Add(new CodeAssignStatement(fieldReference,
                            new CodeMethodInvokeExpression(new CodeBaseReferenceExpression(), readDataMethodName,
                                binaryReaderArgument,
                                new CodeMethodInvokeExpression(pointerQueueArgument, dequeueMethodName))));
                    }
                    //  instanced Int16 array like data
                    else if (systemType == typeof (short))
                    {
                        var readDataMethodName =
                            StaticReflection.GetMemberName(
                                (GuerillaBlock @class) =>
                                    @class.ReadDataShortArray(new BinaryReader(Stream.Null), new BlamPointer()));

                        var dequeueMethodName =
                            StaticReflection.GetMemberName(
                                (Queue<BlamPointer> item) => item.Dequeue());

                        method.Statements.Add(new CodeAssignStatement(fieldReference,
                            new CodeMethodInvokeExpression(new CodeBaseReferenceExpression(), readDataMethodName,
                                binaryReaderArgument,
                                new CodeMethodInvokeExpression(pointerQueueArgument, dequeueMethodName))));
                    }
                    //  tagBlock array
                    else
                    {
                        var readDataMethodName =
                            StaticReflection.GetMemberName((GuerillaBlock item) =>
                                item.ReadBlockArrayData<GuerillaBlock>(new BinaryReader(Stream.Null), new BlamPointer())
                                );

                        var dequeueMethodName =
                            StaticReflection.GetMemberName(
                                (Queue<BlamPointer> item) => item.Dequeue());

                        method.Statements.Add(new CodeAssignStatement(fieldReference, new CodeMethodInvokeExpression(
                            new CodeMethodReferenceExpression(new CodeBaseReferenceExpression(), readDataMethodName,
                                new CodeTypeReference(field.Type.BaseType)), binaryReaderArgument,
                            new CodeMethodInvokeExpression(pointerQueueArgument, dequeueMethodName))));
                    }
                }
                //  like an inline struct where T : GuerillaBlock
                else if (field.UserData.Contains("GuerillaBlock"))
                {
                    var readInstancesMethodName = StaticReflection.GetMemberName((GuerillaBlock item) =>
                        item.ReadInstances(new BinaryReader(Stream.Null), new Queue<BlamPointer>()));

                    method.Statements.Add(new CodeMethodInvokeExpression(fieldReference, readInstancesMethodName,
                        binaryReaderArgument,
                        pointerQueueArgument));
                }
            }
            _targetClass.Members.Add(method);
        }

        private void GenerateIWriteQueueableQueueWritesMethod()
        {
            var method = new CodeMemberMethod
            {
                Name = "QueueWrites",
                Attributes = MemberAttributes.Override | MemberAttributes.Public,
                ReturnType = new CodeTypeReference(typeof (void)),
            };

            //  loop iterator 
            var loopVariable = new CodeVariableReferenceExpression("i");
            var loopVariableDeclaration = new CodeVariableDeclarationStatement(typeof (int),
                loopVariable.VariableName);

            //  add QueueableBinaryWriter parameter
            const string queueableBinaryWriter = "queueableBinaryWriter";
            var queueableBinaryWriterParameterDeclaration =
                new CodeParameterDeclarationExpression(new CodeTypeReference(typeof (QueueableBinaryWriter)),
                    queueableBinaryWriter);
            var queueableBinaryWriterArgument = new CodeArgumentReferenceExpression(queueableBinaryWriter);

            method.Parameters.Add(queueableBinaryWriterParameterDeclaration);

            //  add base.Invoke call
            method.Statements.Add(new CodeMethodInvokeExpression(new CodeBaseReferenceExpression(), method.Name,
                queueableBinaryWriterArgument));

            foreach (CodeObject codeObject in _targetClass.Members)
            {
                if (!(codeObject is CodeMemberField)) continue;
                var field = (CodeMemberField) codeObject;

                //  get the field as a variable
                var fieldReference = new CodeFieldReferenceExpression(new CodeThisReferenceExpression(),
                    field.Name);
                var systemType = ReflectionMethods.GetType(field.Type.BaseType);

                //  Single dimensional arrays
                if (field.Type.ArrayRank == 1)
                {
                    var fieldInitializer = (CodeArrayCreateExpression) field.InitExpression;
                    var arraySize = fieldInitializer == null ? 0 : fieldInitializer.Size;

                    //  fixed byte array like padding or skip data
                    if (systemType == typeof (byte) && arraySize > 0)
                    {
                        // this is not an instance field so ignore it
                        continue;
                    }
                    // fixed struct array
                    else if (field.UserData.Contains("GuerillaBlock") && arraySize > 0)
                    {
                        var methodName =
                            StaticReflection.GetMemberName(
                                (IWriteQueueable item) => item.QueueWrites(null));

                        //  add loop iterator variable if needed
                        if (!method.Statements.Contains(loopVariableDeclaration))
                            method.Statements.Add(loopVariableDeclaration);

                        //  loop through the array and call the method on each item
                        method.Statements.Add(new CodeIterationStatement(
                            new CodeAssignStatement(loopVariable, new CodePrimitiveExpression(0)),
                            new CodeBinaryOperatorExpression(loopVariable, CodeBinaryOperatorType.LessThan,
                                new CodePrimitiveExpression(arraySize)),
                            new CodeAssignStatement(loopVariable,
                                new CodeBinaryOperatorExpression(loopVariable, CodeBinaryOperatorType.Add,
                                    new CodePrimitiveExpression(1))), new CodeExpressionStatement(
                                        new CodeMethodInvokeExpression(new CodeArrayIndexerExpression(fieldReference, loopVariable), methodName,
                                            queueableBinaryWriterArgument))));
                    }
                    //  instanced byte array like data
                    else if (systemType == typeof (byte))
                    {
                        var methodName =
                            StaticReflection.GetMemberName(
                                (QueueableBinaryWriter item) => item.QueueWrite(new byte[0]));

                        method.Statements.Add(new CodeMethodInvokeExpression(queueableBinaryWriterArgument, methodName,
                            fieldReference));
                    }
                    //  instanced Int16 array like data
                    else if (systemType == typeof (short))
                    {
                        var methodName =
                            StaticReflection.GetMemberName(
                                (QueueableBinaryWriter item) => item.QueueWrite(new short[0]));

                        method.Statements.Add(new CodeMethodInvokeExpression(queueableBinaryWriterArgument, methodName,
                            fieldReference));
                    }
                    //  tagBlock array
                    else
                    {
                        var methodName =
                            StaticReflection.GetMemberName(
                                (QueueableBinaryWriter item) => item.QueueWrite(new GuerillaBlock[0]));

                        method.Statements.Add(new CodeMethodInvokeExpression(queueableBinaryWriterArgument, methodName,
                                fieldReference));
                    }
                }
                //  like an inline struct where T : GuerillaBlock
                else if (field.UserData.Contains("GuerillaBlock"))
                {
                    var methodName =
                        StaticReflection.GetMemberName(
                            (IWriteQueueable item) => item.QueueWrites(null));

                    method.Statements.Add(new CodeMethodInvokeExpression(fieldReference, methodName,
                        queueableBinaryWriterArgument));
                }
            }
            _targetClass.Members.Add(method);
        }

        private void GenerateWriteMethod()
        {
            var method = new CodeMemberMethod
            {
                Name = "Write_",
                Attributes = MemberAttributes.Override | MemberAttributes.Public,
                ReturnType = new CodeTypeReference(typeof (void)),
            };

            //  loop iterator 
            var loopVariable = new CodeVariableReferenceExpression("i");
            var loopVariableDeclaration = new CodeVariableDeclarationStatement(typeof (int),
                loopVariable.VariableName);

            //  add QueueableBinaryWriter parameter
            const string queueableBinaryWriter = "queueableBinaryWriter";
            var queueableBinaryWriterParameterDeclaration =
                new CodeParameterDeclarationExpression(new CodeTypeReference(typeof (QueueableBinaryWriter)),
                    queueableBinaryWriter);
            var queueableBinaryWriterArgument = new CodeArgumentReferenceExpression(queueableBinaryWriter);

            method.Parameters.Add(queueableBinaryWriterParameterDeclaration);

            //  add base.Invoke call
            method.Statements.Add(new CodeMethodInvokeExpression(new CodeBaseReferenceExpression(), method.Name,
                queueableBinaryWriterArgument));

            foreach (CodeObject codeObject in _targetClass.Members)
            {
                if (!(codeObject is CodeMemberField)) continue;
                var field = (CodeMemberField) codeObject;

                //  get the field as a variable
                var fieldReference = new CodeFieldReferenceExpression(new CodeThisReferenceExpression(),
                    field.Name);
                var systemType = ReflectionMethods.GetType(field.Type.BaseType);

                //  Single dimensional arrays
                if (field.Type.ArrayRank == 1)
                {
                    var fieldInitializer = (CodeArrayCreateExpression) field.InitExpression;
                    var arraySize = fieldInitializer == null ? 0 : fieldInitializer.Size;

                    //  fixed byte array like padding or skip data
                    if (systemType == typeof (byte) && arraySize > 0)
                    {
                        var methodName =
                            StaticReflection.GetMemberName((QueueableBinaryWriter item) => item.Write(new byte[0]));

                        method.Statements.Add(new CodeMethodInvokeExpression(queueableBinaryWriterArgument, methodName,
                            fieldReference));
                    }
                    // fixed struct array
                    else if (field.UserData.Contains("GuerillaBlock") && arraySize > 0)
                    {
                        var methodName =
                            StaticReflection.GetMemberName((GuerillaBlock item) => item.Write_(null));

                        //  add loop iterator variable if needed
                        if (!method.Statements.Contains(loopVariableDeclaration))
                            method.Statements.Add(loopVariableDeclaration);

                        //  loop through the array and call the method on each item
                        method.Statements.Add(new CodeIterationStatement(
                            new CodeAssignStatement(loopVariable, new CodePrimitiveExpression(0)),
                            new CodeBinaryOperatorExpression(loopVariable, CodeBinaryOperatorType.LessThan,
                                new CodePrimitiveExpression(arraySize)),
                            new CodeAssignStatement(loopVariable,
                                new CodeBinaryOperatorExpression(loopVariable, CodeBinaryOperatorType.Add,
                                    new CodePrimitiveExpression(1))), new CodeExpressionStatement(
                                        new CodeMethodInvokeExpression(
                                            new CodeArrayIndexerExpression(fieldReference, loopVariable), methodName,
                                            queueableBinaryWriterArgument))));
                    }
                    //  instanced byte array like data
                    else if (systemType == typeof (byte))
                    {
                        var writePointerMethodName =
                            StaticReflection.GetMemberName(
                                (QueueableBinaryWriter item) => item.WritePointer(new byte[0]));

                        method.Statements.Add(new CodeMethodInvokeExpression(queueableBinaryWriterArgument,
                            writePointerMethodName,
                            fieldReference));
                    }
                    //  instanced Int16 array like data
                    else if (systemType == typeof (short))
                    {
                        var writePointerMethodName =
                            StaticReflection.GetMemberName(
                                (QueueableBinaryWriter item) => item.WritePointer(new short[0]));

                        method.Statements.Add(new CodeMethodInvokeExpression(queueableBinaryWriterArgument,
                            writePointerMethodName,
                            fieldReference));
                    }
                    //  tagBlock array
                    else
                    {
                        var writePointerMethodName =
                            StaticReflection.GetMemberName(
                                (QueueableBinaryWriter item) => item.WritePointer(new GuerillaBlock[0]));

                        method.Statements.Add(new CodeMethodInvokeExpression(queueableBinaryWriterArgument,
                            writePointerMethodName,
                            fieldReference));
                    }
                }
                //  like an inline struct where T : GuerillaBlock
                else if (field.UserData.Contains("GuerillaBlock"))
                {
                    var methodName =
                        StaticReflection.GetMemberName(
                            (GuerillaBlock item) => item.Write_(null));

                    method.Statements.Add(new CodeMethodInvokeExpression(fieldReference, methodName,
                        queueableBinaryWriterArgument));
                }
                //  like a simple value (int, byte, TagClass, TagIdent, etc.)
                else if (systemType != null)
                {
                    var methodName = BinaryIOReflection.GetBinaryWriterMethodName(systemType);

                    method.Statements.Add(new CodeMethodInvokeExpression(queueableBinaryWriterArgument, methodName,
                        fieldReference));
                }
                //  like an enum or flag value
                else
                {
                    var typeDeclaration =
                        _targetClass.Members.OfType<CodeTypeDeclaration>().Single(x => x.Name == field.Type.BaseType);
                    var baseType = Type.GetType(typeDeclaration.BaseTypes[0].BaseType);

                    var methodName = BinaryIOReflection.GetBinaryWriterMethodName(baseType);

                    method.Statements.Add(new CodeMethodInvokeExpression(queueableBinaryWriterArgument, methodName,
                        new CodeCastExpression(baseType, fieldReference)));
                }
            }
            _targetClass.Members.Add(method);
        }

        private void GenerateFields(List<MoonfishTagField> fields)
        {
            foreach (var field in fields)
            {
                switch (field.Type)
                {
                    case MoonfishFieldType.FieldTagReference:
                    {
                        var member = new CodeMemberField(typeof (TagReference),
                            _tokenDictionary.GenerateValidToken(GenerateFieldName(field)));
                        member.CustomAttributes.Add(
                            new CodeAttributeDeclaration(new CodeTypeReference(typeof (TagReferenceAttribute)),
                                new CodeAttributeArgument(new CodePrimitiveExpression(field.Definition.Class.ToString()))));
                        GenerateSummary(member);
                        member.Attributes = MemberAttributes.Public;
                        _targetClass.Members.Add(member);
                        break;
                    }
                    case MoonfishFieldType.FieldBlock:
                    {
                        var fieldBlockClass = new GuerillaBlockClass(field.Definition);
                        fieldBlockClass.GenerateCSharpCode();
                        var typeName = fieldBlockClass._targetClass.Name;
                        var member = new CodeMemberField(typeName + "[]",
                            _tokenDictionary.GenerateValidToken(GenerateFieldName(field)));
                        GenerateSummary(member);
                        member.Attributes = MemberAttributes.Public;
                        member.UserData[0] = fieldBlockClass.Size;
                        member.UserData["GuerillaBlock"] = true;
                        member.InitExpression =
                            new CodeArrayCreateExpression(
                                new CodeTypeReference(fieldBlockClass._targetClass.Name, 1), 0);
                        _targetClass.Members.Add(member);
                        break;
                    }
                    case MoonfishFieldType.FieldStruct:
                    {
                        var fieldBlockClass = new GuerillaBlockClass(field.Definition.Definition);
                        fieldBlockClass.GenerateCSharpCode();
                        var member =
                            new CodeMemberField(
                                fieldBlockClass._targetClass.Name,
                                _tokenDictionary.GenerateValidToken(GenerateFieldName(field)));
                        GenerateSummary(member);
                        member.Attributes = MemberAttributes.Public;
                        member.UserData[0] = fieldBlockClass.Size;
                        member.UserData["GuerillaBlock"] = true;
                        member.InitExpression = new CodeObjectCreateExpression(fieldBlockClass._targetClass.Name);
                        _targetClass.Members.Add(member);
                        break;
                    }
                    case MoonfishFieldType.FieldData:
                    {
                        var type = ((MoonfishTagDataDefinition) field.Definition).DataElementSize == 1
                            ? typeof (byte[])
                            : typeof (short[]);
                        var member = new CodeMemberField(type,
                            _tokenDictionary.GenerateValidToken(GenerateFieldName(field)));
                        GenerateSummary(member);
                        member.Attributes = MemberAttributes.Public;
                        _targetClass.Members.Add(member);
                        break;
                    }
                    case MoonfishFieldType.FieldExplanation:
                    {
                        var value = field.Definition as string;
                        if (string.IsNullOrWhiteSpace(value)) continue;
                        PushComments(value);
                        break;
                    }
                    case MoonfishFieldType.FieldByteFlags:
                    case MoonfishFieldType.FieldLongFlags:
                    case MoonfishFieldType.FieldWordFlags:
                    case MoonfishFieldType.FieldCharEnum:
                    case MoonfishFieldType.FieldEnum:
                    case MoonfishFieldType.FieldLongEnum:
                    {
                        GenerateEnumField(field);
                        break;
                    }
                    case MoonfishFieldType.FieldByteBlockFlags:
                    {
                        var member = GenerateCodeMemberField<BlockFlags8>(field);
                        _targetClass.Members.Add(member);
                    }
                        break;
                    case MoonfishFieldType.FieldWordBlockFlags:
                    {
                        var member = GenerateCodeMemberField<BlockFlags16>(field);
                        _targetClass.Members.Add(member);
                    }
                        break;
                    case MoonfishFieldType.FieldLongBlockFlags:
                    {
                        var member = GenerateCodeMemberField<BlockFlags32>(field);
                        _targetClass.Members.Add(member);
                    }
                        break;
                    case MoonfishFieldType.FieldCharBlockIndex1:
                    {
                        var member = GenerateCodeMemberField<ByteBlockIndex1>(field);
                        _targetClass.Members.Add(member);
                    }
                        break;
                    case MoonfishFieldType.FieldShortBlockIndex1:
                    {
                        var member = GenerateCodeMemberField<ShortBlockIndex1>(field);
                        _targetClass.Members.Add(member);
                    }
                        break;
                    case MoonfishFieldType.FieldLongBlockIndex1:
                    {
                        var member = GenerateCodeMemberField<LongBlockIndex1>(field);
                        _targetClass.Members.Add(member);
                    }
                        break;
                    case MoonfishFieldType.FieldCharBlockIndex2:
                    {
                        var member = GenerateCodeMemberField<ByteBlockIndex2>(field);
                        _targetClass.Members.Add(member);
                    }
                        break;
                    case MoonfishFieldType.FieldShortBlockIndex2:
                    {
                        var member = GenerateCodeMemberField<ShortBlockIndex2>(field);
                        _targetClass.Members.Add(member);
                    }
                        break;
                    case MoonfishFieldType.FieldLongBlockIndex2:
                    {
                        var member = GenerateCodeMemberField<LongBlockIndex2>(field);
                        _targetClass.Members.Add(member);
                    }
                        break;
                    case MoonfishFieldType.FieldArrayStart:
                    {
                        var startIndex = fields.IndexOf(field) + 1;
                        var endIndex = FindArrayEndIndex(fields, startIndex) - 1;

                        var arrayFields = fields.GetRange(startIndex, endIndex - startIndex);
                        var arrayStruct = new GuerillaBlockClass(GenerateFieldName(field) + "Block", arrayFields);

                        var member =
                            new CodeMemberField(
                                arrayStruct._targetClass.Name + "[]",
                                _tokenDictionary.GenerateValidToken(GenerateFieldName(field)));
                        GenerateSummary(member);
                        member.Attributes = MemberAttributes.Public;
                        member.UserData[0] = arrayStruct.Size;
                        member.UserData["GuerillaBlock"] = true;
                        member.InitExpression = new CodeArrayCreateExpression(member.Type.BaseType, field.Count);
                        _targetClass.Members.Add(member);
                        _targetClass.Members.Add(arrayStruct._targetClass);

                        var remainingFields = fields.GetRange(endIndex + 1, fields.Count - endIndex - 1);

                        GenerateFields(remainingFields);
                        return;
                    }
                    case MoonfishFieldType.FieldArrayEnd:
                    {
                        return;
                    }
                    case MoonfishFieldType.FieldSkip:
                    case MoonfishFieldType.FieldPad:
                    {
                        var member = GenerateCodeMemberField<byte[]>(field, MemberAttributes.Private);

                        member.InitExpression = new CodeArrayCreateExpression(member.Type, field.Count);
                        _targetClass.Members.Add(member);
                    }
                        break;
                    case MoonfishFieldType.FieldUselessPad:
                    case MoonfishFieldType.FieldTerminator:
                    case MoonfishFieldType.FieldCustom:
                    {
                        break;
                    }
                    default:
                    {
                        var generateFieldName = GenerateFieldName(field);
                        var member = new CodeMemberField(ValueTypeDictionary[field.Type],
                            _tokenDictionary.GenerateValidToken(generateFieldName))
                        {
                            Attributes = MemberAttributes.Public
                        };
                        GenerateSummary(member);

                        _targetClass.Members.Add(member);
                        break;
                    }
                }
            }
        }

        private void GenerateEnumField(MoonfishTagField field)
        {
            var nameToken = new StringBuilder(field.Strings.Name.ToPascalCase().ToAlphaNumericToken());
            var typeToken = "";
            switch (field.Type)
            {
                case MoonfishFieldType.FieldCharEnum:
                case MoonfishFieldType.FieldEnum:
                case MoonfishFieldType.FieldLongEnum:
                    typeToken = "Enum";
                    break;
            }
            var fieldTypeName =
                _tokenDictionary.Contains(nameToken.ToString())
                    ? _targetClass.Name.Replace("Block", "") + nameToken + typeToken
                    : nameToken + typeToken;
            _tokenDictionary.Add(fieldTypeName);
            var fieldName = string.IsNullOrWhiteSpace(typeToken) ? fieldTypeName : fieldTypeName.Replace(typeToken, "");
            CodeTypeDeclaration typeDeclaration;
            var flagsAttributeDeclaration = new CodeAttributeDeclaration(new CodeTypeReference(typeof (FlagsAttribute)));
            switch (field.Type)
            {
                case MoonfishFieldType.FieldByteFlags:
                    typeDeclaration = new CodeTypeDeclaration(fieldTypeName)
                    {
                        IsEnum = true,
                        BaseTypes = {new CodeTypeReference(typeof (byte))}
                    };
                    typeDeclaration.CustomAttributes.Add(
                        flagsAttributeDeclaration);
                    break;
                case MoonfishFieldType.FieldWordFlags:
                    typeDeclaration = new CodeTypeDeclaration(fieldTypeName)
                    {
                        IsEnum = true,
                        BaseTypes = {new CodeTypeReference(typeof (short))}
                    };
                    typeDeclaration.CustomAttributes.Add(
                        flagsAttributeDeclaration);
                    break;
                case MoonfishFieldType.FieldLongFlags:
                    typeDeclaration = new CodeTypeDeclaration(fieldTypeName)
                    {
                        IsEnum = true,
                        BaseTypes = {new CodeTypeReference(typeof (int))}
                    };
                    typeDeclaration.CustomAttributes.Add(
                        flagsAttributeDeclaration);
                    break;
                case MoonfishFieldType.FieldCharEnum:
                    typeDeclaration = new CodeTypeDeclaration(fieldTypeName)
                    {
                        IsEnum = true,
                        BaseTypes = {new CodeTypeReference(typeof (byte))}
                    };
                    break;
                case MoonfishFieldType.FieldEnum:
                    typeDeclaration = new CodeTypeDeclaration(fieldTypeName)
                    {
                        IsEnum = true,
                        BaseTypes = {new CodeTypeReference(typeof (short))}
                    };
                    break;
                case MoonfishFieldType.FieldLongEnum:
                    typeDeclaration = new CodeTypeDeclaration(fieldTypeName)
                    {
                        IsEnum = true,
                        BaseTypes = {new CodeTypeReference(typeof (int))}
                    };
                    break;
                default:
                    return;
            }
            var isFlags = typeDeclaration.CustomAttributes.Contains(flagsAttributeDeclaration);

            var comments = PullComments();
            var memberComments = comments.Descriptions.ToList();
            var enumDefintion = (MoonfishTagEnumDefinition) field.Definition;
            var enumTokenDictionary = new TokenDictionary();
            if (isFlags)
                typeDeclaration.Members.Add(new CodeMemberField
                {
                    Name = "None",
                    InitExpression = new CodePrimitiveExpression(0)
                });
            for (var index = 0; index < enumDefintion.Names.Count; index++)
            {
                var value = enumDefintion.Names[index];
                var comment = index < memberComments.Count ? memberComments[index] : null;
                var member = new CodeMemberField
                {
                    Name = enumTokenDictionary.GenerateValidToken(GenerateFieldName(value))
                };
                if (comment != null)
                    member.Comments.AddRange(
                        new[]
                        {
                            new CodeCommentStatement("<summary>", true),
                            new CodeCommentStatement(comment.Trim(), true),
                            new CodeCommentStatement("</summary>", true)
                        });
                member.InitExpression = new CodePrimitiveExpression(isFlags ? 1 << index : index);
                typeDeclaration.Members.Add(member);
            }
            var fieldMember = new CodeMemberField(new CodeTypeReference(typeDeclaration.Name),
                _tokenDictionary.GenerateValidToken(fieldName));
            if (comments.HasSummary)
                typeDeclaration.Comments.AddRange(new[]
                {
                    new CodeCommentStatement("<summary>", true),
                    new CodeCommentStatement(comments.Summary.Trim(), true),
                    new CodeCommentStatement("</summary>", true)
                });
            fieldMember.Attributes = MemberAttributes.Public;
            _targetClass.Members.Add(typeDeclaration);
            _targetClass.Members.Add(fieldMember);
        }

        private static int FindArrayEndIndex(IList<MoonfishTagField> fields, int startIndex)
        {
            var endIndex = startIndex;
            var depth = 0;
            for (var i = startIndex + 1; i < fields.Count; i++)
            {
                if (fields[i].Type == MoonfishFieldType.FieldArrayStart) depth++;
                if (fields[i].Type != MoonfishFieldType.FieldArrayEnd) continue;
                if (depth == 0)
                {
                    endIndex = i + 1;
                    break;
                }
                depth--;
            }
            return endIndex;
        }

        private CodeMemberField GenerateCodeMemberField<T>(MoonfishTagField field,
            MemberAttributes attributes = MemberAttributes.Public)
        {
            var member = new CodeMemberField(typeof (T),
                _tokenDictionary.GenerateValidToken(GenerateFieldName(field, attributes)))
            {
                Attributes = attributes
            };
            GenerateSummary(member);
            return member;
        }

        private static string GenerateFieldName(string name, MemberAttributes attributes = MemberAttributes.Public)
        {
            var token = name.IsValidIdentifier() ? name : "_invalid Name";

            return attributes.HasFlag(MemberAttributes.Public)
                ? token.ToPascalCase().ToAlphaNumericToken()
                : token.ToCamelCase().ToAlphaNumericToken();
        }

        private static string GenerateFieldName(MoonfishTagField field,
            MemberAttributes attributes = MemberAttributes.Public)
        {
            string token;
            try
            {
                token = field.Strings.Name.ToAlphaNumericToken().IsValidIdentifier()
                    ? field.Strings.Name
                    : field.Definition != null
                        ? ((string) field.Definition.Name).ToAlphaNumericToken().IsValidIdentifier()
                            ? field.Definition.Name
                            : "_invalid Name"
                        : "_invalid Name";
            }
            catch (Exception e)
            {
                token = "_invalid Name";
            }
            return attributes.HasFlag(MemberAttributes.Public)
                ? token.ToPascalCase().ToAlphaNumericToken()
                : token.ToCamelCase().ToAlphaNumericToken();
        }

        private static void GenerateSummary(CodeTypeMember member)
        {
            var comment = PullComments();
            if (comment.HasSummary)
                member.Comments.AddRange(
                    new[]
                    {
                        new CodeCommentStatement("<summary>", true),
                        new CodeCommentStatement(comment.Summary.Trim(), true),
                        new CodeCommentStatement("</summary>", true)
                    });
        }

        private static void PushComments(string value)
        {
            _comments = new GuerillaCommentCollection(value);
        }

        private static GuerillaCommentCollection PullComments()
        {
            var copy = _comments.CreateCopy();
            _comments = new GuerillaCommentCollection();
            return copy;
        }

        public void AddReadOnlyIntProperty(string name, int value)
        {
            var serializedSizeProperty = new CodeMemberProperty
            {
                Attributes = MemberAttributes.Public | MemberAttributes.Override,
                Name = name.ToPascalCase(),
                HasGet = true,
                Type = new CodeTypeReference(typeof (int))
            };
            serializedSizeProperty.GetStatements.Add(
                new CodeMethodReturnStatement(new CodePrimitiveExpression(value)));

            _targetClass.Members.Add(serializedSizeProperty);
        }

        public void GenerateCSharpCode()
        {
            var provider = new CSharpCodeProvider();
            var options = new CodeGeneratorOptions
            {
                BracingStyle = "C",
                BlankLinesBetweenMembers = false,
                VerbatimOrder = false
            };
            var filename = Path.Combine(Local.ProjectDirectory, Path.Combine("Guerilla\\Debug\\", _outputFileName));
            using (var streamWriter = new StreamWriter(File.Create(filename)))
            {
                provider.GenerateCodeFromCompileUnit(_targetUnit, streamWriter, options);
            }
        }
    };
}