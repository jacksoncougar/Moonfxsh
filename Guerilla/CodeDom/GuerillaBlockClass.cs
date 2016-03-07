using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Text;
using Fasterflect;
using Microsoft.CSharp;
using Moonfish.Guerilla.Reflection;
using Moonfish.Tags;

namespace Moonfish.Guerilla.CodeDom
{
    [SuppressMessage("ReSharper", "BitwiseOperatorOnEnumWithoutFlags")]
    internal class GuerillaBlockClass : GuerillaBlockClassBase
    {
        private readonly string _outputFileName;

        public GuerillaBlockClass(MoonfishTagGroup tag, IList<MoonfishTagGroup> tagGroups = null)
            : this(tag.Definition.Name.ToPascalCase().ToAlphaNumericToken())
        {
            Size = tag.Definition.CalculateSizeOfFieldSet();
            var hasParent = tagGroups != null && tagGroups.Any(x => x.Class == tag.ParentClass);
            if (hasParent)
            {
                var parentTag = tagGroups.First(x => x.Class == tag.ParentClass);
                var parentClass = new GuerillaBlockClass(parentTag, tagGroups);
                parentClass.GenerateCSharpCode(Path.Combine(Local.ProjectDirectory, "Guerilla\\Tags.Generated\\"));
                TokenDictionary = new TokenDictionary(parentClass.TokenDictionary);
                TargetClass.BaseTypes[0] = new CodeTypeReference(parentClass.TargetClass.Name);

                Size += parentClass.Size;
            }
            TargetClass.CustomAttributes.Add(
                new CodeAttributeDeclaration(new CodeTypeReference(typeof(TagClassAttribute).Name()),
                    new CodeAttributeArgument(new CodePrimitiveExpression(tag.Class.ToString()))));

            TargetClass.CustomAttributes.Add(
                new CodeAttributeDeclaration( new CodeTypeReference( typeof ( TagBlockOriginalNameAttribute ).Name( ) ),
                    new CodeAttributeArgument( new CodePrimitiveExpression( tag.Definition.Name ) ) ) );

            var codeNamespace = new CodeNamespace("Moonfish.Tags");
            codeNamespace.Types.Add(new CodeTypeDeclaration(typeof (TagClass).Name())
            {
                IsPartial = true,
                IsStruct = true,
                Members =
                {
                    new CodeMemberField(typeof (TagClass).Name(), tag.Class.ToTokenString().ToPascalCase())
                    {
                        Attributes = MemberAttributes.Public | MemberAttributes.Static,
                        InitExpression =
                            new CodeCastExpression(typeof (TagClass).Name(),
                                new CodePrimitiveExpression(tag.Class.ToString()))
                    }
                }
            });
            TargetUnit.Namespaces.Add(codeNamespace);
            TargetClass.IsPartial = true;

            Initialize(tag.Definition.Fields, Size, tag.Definition.Alignment);
        }

        public GuerillaBlockClass(MoonfishTagDefinition definition)
            : this( definition.Name.ToPascalCase().ToAlphaNumericToken())
        {
            Size = definition.CalculateSizeOfFieldSet();
            TargetClass.IsPartial = true;
            TargetClass.CustomAttributes.Add(
                new CodeAttributeDeclaration(new CodeTypeReference(typeof(TagBlockOriginalNameAttribute).Name()),
                    new CodeAttributeArgument(new CodePrimitiveExpression(definition.Name))));
            Initialize(definition.Fields, Size, definition.Alignment);
        }

        private GuerillaBlockClass(string className) : base(className)
        {
            _outputFileName = string.Format("{0}.generated.cs", className);
            TargetClass.IsClass = true;
            TargetClass.BaseTypes.Clear();
            TargetClass.BaseTypes.AddRange(new[]
            {
                new CodeTypeReference(typeof (GuerillaBlock).Name()), 
                new CodeTypeReference(typeof (IWriteQueueable).Name)
            });
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

            if (!TargetClass.BaseTypes.Contains(new CodeTypeReference(typeof (GuerillaBlock))))
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

            foreach (CodeObject codeObject in TargetClass.Members)
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
                        var readBlamPointerMethodName =
                            StaticReflection.GetMemberName(
                                (BinaryReader @class) => @class.ReadBlamPointer(0));
                        var queueMethodName =
                            StaticReflection.GetMemberName(
                                (Queue<BlamPointer> item) => item.Enqueue(new BlamPointer()));

                        method.Statements.Add(new CodeMethodInvokeExpression(pointerQueueVariable, queueMethodName,
                            new CodeMethodInvokeExpression(binaryReaderArgument, readBlamPointerMethodName,
                                new CodePrimitiveExpression(2))));
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
                        TargetClass.Members.OfType<CodeTypeDeclaration>().Single(x => x.Name == field.Type.BaseType);
                    var baseType = Type.GetType(typeDeclaration.BaseTypes[0].BaseType);

                    var methodName = BinaryIOReflection.GetBinaryReaderMethodName(baseType);

                    method.Statements.Add(new CodeAssignStatement(fieldReference,
                        new CodeCastExpression(field.Type.BaseType,
                            new CodeMethodInvokeExpression(binaryReaderArgument, methodName,
                                new CodeArgumentReferenceExpression()))));
                }
            }
            method.Statements.Add(new CodeMethodReturnStatement(pointerQueueVariable));
            TargetClass.Members.Add(method);
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

            foreach (CodeObject codeObject in TargetClass.Members)
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
            TargetClass.Members.Add(method);
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

            foreach (CodeObject codeObject in TargetClass.Members)
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
            TargetClass.Members.Add(method);
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

            foreach (CodeObject codeObject in TargetClass.Members)
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
                        TargetClass.Members.OfType<CodeTypeDeclaration>().Single(x => x.Name == field.Type.BaseType);
                    var baseType = Type.GetType(typeDeclaration.BaseTypes[0].BaseType);

                    var methodName = BinaryIOReflection.GetBinaryWriterMethodName(baseType);

                    method.Statements.Add(new CodeMethodInvokeExpression(queueableBinaryWriterArgument, methodName,
                        new CodeCastExpression(baseType, fieldReference)));
                }
            }
            TargetClass.Members.Add(method);
        }

        private void GenerateFields(List<MoonfishTagField> fields)
        {
            foreach (var field in fields)
            {
                switch (field.Type)
                {
                    case MoonfishFieldType.FieldTagReference:
                    {
                        var member = new CodeMemberField(typeof (TagReference), GenerateFieldName(field));
                        member.CustomAttributes.Add(
                            new CodeAttributeDeclaration(new CodeTypeReference(typeof (TagReferenceAttribute)),
                                new CodeAttributeArgument(new CodePrimitiveExpression(field.Definition.Class.ToString()))));
                        GenerateSummary(member);
                        member.Attributes = MemberAttributes.Public;
                        TargetClass.Members.Add(member);
                        break;
                    }
                    case MoonfishFieldType.FieldBlock:
                    {
                        var fieldBlockClass = new GuerillaBlockClass(field.Definition);
                        fieldBlockClass.GenerateCSharpCode(Path.Combine(Local.ProjectDirectory, "Guerilla\\Tags.Generated\\"));
                        var typeName = fieldBlockClass.TargetClass.Name;
                        var member = new CodeMemberField(typeName + "[]", GenerateFieldName(field));
                        GenerateSummary(member);
                        member.Attributes = MemberAttributes.Public;
                        member.UserData[0] = fieldBlockClass.Size;
                        member.UserData["GuerillaBlock"] = true;
                        member.InitExpression =
                            new CodeArrayCreateExpression(
                                new CodeTypeReference(fieldBlockClass.TargetClass.Name, 1), 0);
                        TargetClass.Members.Add(member);
                        break;
                    }
                    case MoonfishFieldType.FieldStruct:
                    {
                        var fieldBlockClass = new GuerillaBlockClass(field.Definition.Definition);
                        fieldBlockClass.GenerateCSharpCode(Path.Combine(Local.ProjectDirectory, "Guerilla\\Tags.Generated\\"));
                        var member = new CodeMemberField(fieldBlockClass.TargetClass.Name, GenerateFieldName(field));
                        GenerateSummary(member);
                        member.Attributes = MemberAttributes.Public;
                        member.UserData[0] = fieldBlockClass.Size;
                        member.UserData["GuerillaBlock"] = true;
                        member.InitExpression = new CodeObjectCreateExpression(fieldBlockClass.TargetClass.Name);
                        TargetClass.Members.Add(member);
                        break;
                    }
                    case MoonfishFieldType.FieldData:
                    {
                        var type = ((MoonfishTagDataDefinition) field.Definition).DataElementSize == 1
                            ? typeof (byte[])
                            : typeof (short[]);
                        var member = new CodeMemberField(type, GenerateFieldName(field));
                        GenerateSummary(member);
                        member.Attributes = MemberAttributes.Public;
                        TargetClass.Members.Add(member);
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
                        TargetClass.Members.Add(member);
                    }
                        break;
                    case MoonfishFieldType.FieldWordBlockFlags:
                    {
                        var member = GenerateCodeMemberField<BlockFlags16>(field);
                        TargetClass.Members.Add(member);
                    }
                        break;
                    case MoonfishFieldType.FieldLongBlockFlags:
                    {
                        var member = GenerateCodeMemberField<BlockFlags32>(field);
                        TargetClass.Members.Add(member);
                    }
                        break;
                    case MoonfishFieldType.FieldCharBlockIndex1:
                    {
                        var member = GenerateCodeMemberField<ByteBlockIndex1>(field);
                        TargetClass.Members.Add(member);
                    }
                        break;
                    case MoonfishFieldType.FieldShortBlockIndex1:
                    {
                        var member = GenerateCodeMemberField<ShortBlockIndex1>(field);
                        TargetClass.Members.Add(member);
                    }
                        break;
                    case MoonfishFieldType.FieldLongBlockIndex1:
                    {
                        var member = GenerateCodeMemberField<LongBlockIndex1>(field);
                        TargetClass.Members.Add(member);
                    }
                        break;
                    case MoonfishFieldType.FieldCharBlockIndex2:
                    {
                        var member = GenerateCodeMemberField<ByteBlockIndex2>(field);
                        TargetClass.Members.Add(member);
                    }
                        break;
                    case MoonfishFieldType.FieldShortBlockIndex2:
                    {
                        var member = GenerateCodeMemberField<ShortBlockIndex2>(field);
                        TargetClass.Members.Add(member);
                    }
                        break;
                    case MoonfishFieldType.FieldLongBlockIndex2:
                    {
                        var member = GenerateCodeMemberField<LongBlockIndex2>(field);
                        TargetClass.Members.Add(member);
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
                                arrayStruct.TargetClass.Name + "[]",
                                TokenDictionary.GenerateValidToken(GenerateFieldName(field)));
                        GenerateSummary(member);
                        member.Attributes = MemberAttributes.Public;
                        member.UserData[0] = arrayStruct.Size;
                        member.UserData["GuerillaBlock"] = true;
                        member.InitExpression = new CodeArrayCreateExpression(member.Type.BaseType, field.Count);

                        if (!Contains(arrayStruct.TargetClass))
                            TargetClass.Members.Add(arrayStruct.TargetClass);
                        TargetClass.Members.Add(member);

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
                        TargetClass.Members.Add(member);
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
                        var member = new CodeMemberField(ValueTypeDictionary[field.Type],
                            GenerateFieldName(field))
                        {
                            Attributes = MemberAttributes.Public
                        };
                        GenerateSummary(member);

                        TargetClass.Members.Add(member);
                        break;
                    }
                }
            }
        }

        private void GenerateEnumField(MoonfishTagField field)
        {
            var enumBlockClass = new GuerillaEnumBlockClass(this, field);
            var fieldMember = new CodeMemberField(
                new CodeTypeReference(enumBlockClass.TargetClass.Name),
                GenerateName(MemberAttributes.Public, null, false, field.Strings.Name, TargetClass.Name.Replace("Block", "") + enumBlockClass.GetFieldName())
                )
            {
                Attributes = MemberAttributes.Public
            };
            if (!Contains(enumBlockClass.TargetClass))
                TargetClass.Members.Add(enumBlockClass.TargetClass);
            TargetClass.Members.Add(fieldMember);
        }

        private bool Contains(CodeTypeDeclaration targetClass)
        {
            return
                TargetClass.Members.OfType<CodeTypeDeclaration>()
                    .Any(typeDeclaration => typeDeclaration.Name == targetClass.Name);
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
            var member = new CodeMemberField(typeof (T), GenerateFieldName(field, attributes))
            {
                Attributes = attributes
            };
            GenerateSummary(member);
            return member;
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

            TargetClass.Members.Add(serializedSizeProperty);
        }

        public void GenerateCSharpCode(string directory)
        {
            var provider = new CSharpCodeProvider();
            var options = new CodeGeneratorOptions
            {
                BracingStyle = "C",
                BlankLinesBetweenMembers = false,
                VerbatimOrder = false
            };
            var filename = Path.Combine(directory, _outputFileName);
            using (var streamWriter = new StreamWriter(File.Create(filename)))
            {
                provider.GenerateCodeFromCompileUnit(TargetUnit, streamWriter, options);
            }
        }
    };
}