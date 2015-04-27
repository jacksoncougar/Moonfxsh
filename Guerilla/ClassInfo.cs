using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.CSharp;
using Moonfish.Tags;

namespace Moonfish.Guerilla
{
    public class ClassInfo
    {
        public readonly string namespaceBase = "Moonfish.Guerilla.Tags";

        public ClassInfo( )
        {
            Usings = new List<string>
            {
                "// ReSharper disable All",
                "using Moonfish.Model;",
                "using Moonfish.Tags.BlamExtension;",
                "using Moonfish.Tags;",
                "using OpenTK;",
                "using System;",
                "using System.IO;"
            };
            Attributes = new List<AttributeInfo>( );
            Fields = new List<FieldInfo>( );
            Constructors = new List<MethodInfo>( );
            EnumDefinitions = new List<EnumInfo>( );
            ClassDefinitions = new List<ClassInfo>( );
            Methods = new List<MethodInfo>( );
            MethodsTemplates = new List<MethodInfo>( );
        }

        public AccessModifiers AccessModifiers { get; set; }
        public List<AttributeInfo> Attributes { get; set; }
        public string BaseClass { get; set; }

        public string Interfaces
        {
            get { return "GuerillaBlock"; }
        }

        public string BaseClassDeclaration
        {
            get
            {
                return ( String.IsNullOrWhiteSpace( BaseClass ) ? "" : string.Format( ": {0}", BaseClass ) ).Trim( );
            }
        }

        public string ClassDeclaration
        {
            get
            {
                return
                    string.Format( "{0} class {1} {2} {3}", AccessModifiersExtensions.ToString( AccessModifiers ),
                        Value.Name,
                        BaseClassDeclaration.Trim( ),
                        string.IsNullOrWhiteSpace( BaseClassDeclaration.Trim( ) )
                            ? string.Format( ": {0}", Interfaces )
                            : ""
                        );
            }
        }

        public List<ClassInfo> ClassDefinitions { get; set; }
        public List<MethodInfo> Constructors { get; set; }
        public List<EnumInfo> EnumDefinitions { get; set; }
        public List<FieldInfo> Fields { get; set; }
        public List<MethodInfo> Methods { get; set; }
        public List<MethodInfo> MethodsTemplates { get; set; }
        public string Namespace { get; set; }

        public string NamespaceDeclaration
        {
            get
            {
                return string.Format( "namespace {0}",
                    string.IsNullOrWhiteSpace( Namespace ) ? namespaceBase : namespaceBase + "." + Namespace );
            }
        }

        public List<string> Usings { get; set; }
        public GuerillaName Value { get; set; }

        public void Format( )
        {
            var tokenDictionary = new TokenDictionary( );
            string name, @namespace;
            if ( GuerillaCs.SplitNamespaceFromFieldName( Value.Name, out name, out @namespace ) )
            {
                Value.Name = tokenDictionary.GenerateValidToken( GuerillaCs.ToTypeName( name ) );
                Namespace = GuerillaCs.ToTypeName( @namespace );
            }
            else
            {
                Value.Name = tokenDictionary.GenerateValidToken( GuerillaCs.ToTypeName( Value.Name ) );
            }

            FormatFieldNames( tokenDictionary );
            foreach ( var item in EnumDefinitions )
            {
                item.Format( );
            }
            foreach ( var item in ClassDefinitions )
            {
                item.Format( );
            }
        }

        public void Generate( )
        {
            MethodsTemplates.Clear( );
            Methods.Clear( );
            Constructors.Clear( );

            GenerateReadBlockTemplateMethod( );
            GenerateReadDataMethod( );
            GenerateBinaryReaderConstructor( );

            GenerateWriteBlockTemplateMethod( );
            GenerateWriteArrayMethod( );
            GenerateWriteDataMethod( );
            GenerateWriteMethod( );
        }

        public void GenerateBinaryReaderConstructor( )
        {
            Constructors.Add( new MethodInfo
            {
                ClassName = Value.Name,
                AccessModifiers = AccessModifiers.Internal,
                Arguments = new List<ParameterInfo>
                {
                    new ParameterInfo( typeof ( BinaryReader ) )
                },
                Wrapper = !string.IsNullOrWhiteSpace( BaseClass )
            } );
            var stringBuilder = new StringBuilder( );
            foreach ( var item in Fields )
            {
                if ( item.IsArray )
                {
                    // fixed byte array like padding or skip arrays
                    if ( item.ArraySize > 0 && Type.GetType( item.FieldTypeName ) == typeof ( byte ) )
                    {
                        stringBuilder.AppendLine( string.Format( "{0} = binaryReader.ReadBytes({1});", item.Value.Name,
                            item.ArraySize ) );
                    }
                    // variable byte array (data)
                    else if ( Type.GetType( item.FieldTypeName ) == typeof ( byte ) )
                    {
                        stringBuilder.AppendLine( string.Format( "{0} = Guerilla.ReadData(binaryReader);",
                            item.Value.Name ) );
                    }
                    // variable short array (data)
                    else if ( Type.GetType( item.FieldTypeName ) == typeof ( short ) )
                    {
                        stringBuilder.AppendLine( string.Format( "{0} = Guerilla.ReadShortData(binaryReader);",
                            item.Value.Name ) );
                    }
                    // inline array
                    else if ( item.ArraySize > 0 )
                    {
                        var initializer = "";
                        for ( var i = 0; i <= item.ArraySize - 1; i++ )
                        {
                            initializer += string.Format( "new {0}(binaryReader){1}", item.FieldTypeName,
                                i == item.ArraySize ? "" : ", " );
                        }
                        stringBuilder.AppendLine( string.Format( "{0} = new []{{ {1} }};", item.Value.Name, initializer ) );
                    }
                    // assume a TagBlock
                    else
                    {
                        var format = string.Format( "{0} = Guerilla.ReadBlockArray<{1}>(binaryReader);", item.Value.Name,
                            item.FieldTypeName );
                        stringBuilder.AppendLine( format );
                    }
                }
                else
                {
                    if ( EnumDefinitions.Any( x => x.Value.Name == item.FieldTypeName ) )
                    {
                        var enumDefinition = EnumDefinitions.First( x => x.Value.Name == item.FieldTypeName );
                        var type = enumDefinition.BaseType == EnumInfo.Type.Byte
                            ? "Byte"
                            : enumDefinition.BaseType == EnumInfo.Type.Short ? "Int16" : "Int32";
                        stringBuilder.AppendLine( string.Format( "{0} = ({1})binaryReader.Read{2}();", item.Value.Name,
                            item.FieldTypeName, type ) );
                    }
                    else if ( Type.GetType( item.FieldTypeName ) == null )
                    {
                        stringBuilder.AppendLine( string.Format( "{0} = new {1}(binaryReader);", item.Value.Name,
                            item.FieldTypeName ) );
                    }
                    else
                    {
                        var value = BinaryIO.GetBinaryReaderMethodName( Type.GetType( item.FieldTypeName ) );
                        stringBuilder.AppendLine( string.Format( "{0} = binaryReader.{1}();", item.Value.Name, value ) );
                    }
                }
            }
            Constructors.Last( ).Body = stringBuilder.ToString( ).TrimEnd( );
        }

        public void GenerateReadBlockTemplateMethod( )
        {
            MethodsTemplates.Add( new MethodInfo
            {
                Arguments = new List<ParameterInfo> {new ParameterInfo( typeof ( BinaryReader ) )},
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
            } );
        }

        public void GenerateReadDataMethod( )
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

        public ClassInfo GenerateWrapper( string wrapperName, string baseName )
        {
            var tagClassAttribute = Attributes.SingleOrDefault( x => x.AttributeType == typeof ( TagClassAttribute ) );
            var hasTagClassAttribute = tagClassAttribute != null;
            if ( hasTagClassAttribute )
                Attributes.Remove( tagClassAttribute );
            var wrapperClassInfo = new ClassInfo
            {
                AccessModifiers = AccessModifiers.Public | AccessModifiers.Partial,
                Constructors = Constructors.Select( x => x.MakeWrapper( wrapperName ) ).ToList( ),
                Namespace = Namespace,
                Usings = Usings,
                Value = new GuerillaName( Value ),
                BaseClass = baseName
            };
            if ( hasTagClassAttribute )
                wrapperClassInfo.Attributes.Add( tagClassAttribute );
            wrapperClassInfo.Value.Name = wrapperName;
            return wrapperClassInfo;
        }

        public void GenerateWriteBlockTemplateMethod( )
        {
            MethodsTemplates.Add( new MethodInfo
            {
                Arguments = new List<ParameterInfo> {new ParameterInfo( typeof ( BinaryWriter ) )},
                AccessModifiers = AccessModifiers.Internal | AccessModifiers.Virtual,
                ClassName = "Write{0}Array",
                Body = "",
                Returns = "void"
            } );
        }

        public void GenerateWriteDataMethod( )
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

        public void GenerateWriteArrayMethod( )
        {
        }

        public void GenerateWriteMethod( )
        {
            var tab = 0;
            var writeMethod = new MethodInfo
            {
                AccessModifiers = AccessModifiers.Public,
                Arguments = new List<ParameterInfo>
                {
                    new ParameterInfo( typeof ( BinaryWriter ) ),
                    new ParameterInfo( typeof ( int ), "nextAddress" )
                },
                ClassName = "Write",
                Returns = "int"
            };
            var binaryWriter = writeMethod.Arguments.First( );
            var addressParam = writeMethod.Arguments[ 1 ];
            var bodyBuilder = new StringBuilder( );
            bodyBuilder.AppendLine( string.Format( "using({0})",
                StaticReflection.GetMemberName( ( BinaryWriter b ) => b.BaseStream.Pin( ), binaryWriter ) ) );
            bodyBuilder.AppendLine( "{".Tab( ref tab ) );
            foreach ( var item in Fields )
            {
                if ( item.IsArray )
                {
                    // fixed byte array like padding or skip arrays
                    if ( item.ArraySize > 0 && Type.GetType( item.FieldTypeName ) == typeof ( byte ) )
                    {
                        bodyBuilder.AppendLine( string.Format( "{0}.Write({1}, 0, {2});", binaryWriter.Name,
                            item.Value.Name, item.ArraySize ) );
                    }
                    // variable byte array (data)
                    else if ( Type.GetType( item.FieldTypeName ) == typeof ( byte ) )
                    {
                        bodyBuilder.AppendLine( string.Format( "{1} = Guerilla.WriteData({0}, {2}, {1});",
                            binaryWriter.Name, addressParam.Name, item.Value.Name ) );
                    }
                    // variable short array (data)
                    else if ( Type.GetType( item.FieldTypeName ) == typeof ( short ) )
                    {
                        bodyBuilder.AppendLine( string.Format( "{1} = Guerilla.WriteData({0}, {2}, {1});",
                            binaryWriter.Name, addressParam.Name, item.Value.Name ) );
                    }
                    // inline array
                    else if ( item.ArraySize > 0 )
                    {
                        for ( var i = 0; i < item.ArraySize; i++ )
                        {
                            bodyBuilder.AppendLine( string.Format( "{0}[{1}].Write({2});", item.Value.Name, i,
                                binaryWriter.Name ) );
                        }
                    }
                    // assume a TagBlock
                    else
                    {
                        var format = string.Format( "{3} = Guerilla.WriteBlockArray<{1}>({2}, {0}, {3});",
                            item.Value.Name, item.FieldTypeName, binaryWriter.Name, addressParam.Name );
                        bodyBuilder.AppendLine( format );
                    }
                }
                else
                {
                    if ( EnumDefinitions.Any( x => x.Value.Name == item.FieldTypeName ) )
                    {
                        var enumDefinition = EnumDefinitions.First( x => x.Value.Name == item.FieldTypeName );
                        var type = enumDefinition.BaseType == EnumInfo.Type.Byte
                            ? "Byte"
                            : enumDefinition.BaseType == EnumInfo.Type.Short ? "Int16" : "Int32";

                        bodyBuilder.AppendLine( string.Format( "{0}.Write(({1}){2});", binaryWriter.Name, type,
                            item.Value.Name ) );
                    }
                    else if ( Type.GetType( item.FieldTypeName ) == null )
                    {
                        bodyBuilder.AppendLine( string.Format( "{0}.Write({1});", item.Value.Name, binaryWriter.Name ) );
                    }
                    else
                    {
                        bodyBuilder.AppendLine( string.Format( "{0}.Write({1});", binaryWriter.Name, item.Value.Name ) );
                    }
                }
            }

            bodyBuilder.AppendLine( string.Format( "return {0};", writeMethod.Arguments[ 1 ].Name ) );
            bodyBuilder.AppendLine( "}".Tab( ref tab ) );
            writeMethod.Body = bodyBuilder.ToString( ).Trim( );
            Methods.Add( writeMethod );
        }

        public override string ToString( )
        {
            return string.Format( "{0}:{1}", "Class",
                String.IsNullOrEmpty( Namespace ) ? Value.Name : string.Format( "{0}.{1}", Namespace, Value.Name ) );
        }

        private void FormatFieldNames( TokenDictionary tokenDictionary )
        {
            foreach ( var item in Fields )
            {
                var token = tokenDictionary.GenerateValidToken( GuerillaCs.ToMemberName( item.Value.Name ) );
                item.Value.Name = token;
            }

            foreach ( var item in Methods )
            {
                var token = tokenDictionary.GenerateValidToken( GuerillaCs.ToMemberName( item.ClassName ) );
                item.ClassName = token;
            }

            foreach ( var item in EnumDefinitions )
            {
                var token = tokenDictionary.GenerateValidToken( GuerillaCs.ToTypeName( item.Value.Name ) );
                item.Value.Name = token;
            }
        }

        internal class TokenDictionary
        {
            public TokenDictionary( )
            {
                Tokens = new HashSet<string>( );
            }

            private HashSet<string> Tokens { get; set; }

            public string GenerateValidToken( string token )
            {
                using ( var code = new CSharpCodeProvider( ) )
                {
                    var validToken = "";
                    var salt = 0;
                    do
                    {
                        if ( Tokens.Contains( token ) )
                        {
                            validToken = string.Format( "{0}{1}", token, salt );
                        }
                        else validToken = code.CreateValidIdentifier( token );
                        salt++;
                    } while ( Tokens.Contains( validToken ) );
                    Tokens.Add( validToken );
                    return validToken;
                }
            }
        }
    }
}