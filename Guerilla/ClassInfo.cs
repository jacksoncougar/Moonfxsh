using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Moonfish.Guerilla
{

    public class ClassInfo
    {
        public ClassInfo( )
        {
            Usings = new List<string>( )
            {
                "using Moonfish.Model;",
                "using Moonfish.Tags.BlamExtension;",
                "using Moonfish.Tags;",
                "using OpenTK;",
                "using System;",
                "using System.IO;",
            };
            Attributes = new List<AttributeInfo>( );
            Fields = new List<FieldInfo>( );
            Constructors = new List<MethodInfo>( );
            EnumDefinitions = new List<EnumInfo>( );
            ClassDefinitions = new List<ClassInfo>( );
            Methods = new List<MethodInfo>( );
            MethodsTemplates = new List<MethodInfo>( );
        }

        public List<string> Usings { get; set; }
        public string BaseClass { get; set; }
        public string Namespace { get; set; }
        public List<AttributeInfo> Attributes { get; set; }
        public AccessModifiers AccessModifiers { get; set; }
        public GuerillaName Value { get; set; }
        public List<FieldInfo> Fields { get; set; }
        public List<MethodInfo> Constructors { get; set; }
        public List<EnumInfo> EnumDefinitions { get; set; }
        public List<ClassInfo> ClassDefinitions { get; set; }
        public List<MethodInfo> Methods { get; set; }
        public List<MethodInfo> MethodsTemplates { get; set; }

        public readonly string NamespaceBase = "Moonfish.Guerilla.Tags";
        public string NamespaceDeclaration
        {
            get { return string.Format( "namespace {0}", string.IsNullOrWhiteSpace( this.Namespace ) ? NamespaceBase : NamespaceBase + "." + this.Namespace ); }
        }
        public string ClassDeclaration
        {
            get { return string.Format( "{0} class {1} {2}", AccessModifiersExtensions.ToString( AccessModifiers ), Value.Name, BaseClassDeclaration ).Trim( ); }
        }
        public string BaseClassDeclaration
        {
            get { return ( String.IsNullOrWhiteSpace( BaseClass ) ? "" : string.Format( ": {0}", BaseClass ) ).Trim( ); }
        }

        internal class TokenDictionary
        {
            HashSet<string> Tokens { get; set; }

            public TokenDictionary( )
            {
                Tokens = new HashSet<string>( );
            }

            public string GenerateValidToken( string token )
            {
                using( var code = new Microsoft.CSharp.CSharpCodeProvider( ) )
                {
                    var validToken = "";
                    var salt = 0;
                    do
                    {
                        if( Tokens.Contains( token ) )
                        {
                            validToken = string.Format( "{0}{1}", token, salt );
                        }
                        else validToken = code.CreateValidIdentifier( token );
                        salt++;
                    } while( Tokens.Contains( validToken ) );
                    Tokens.Add( validToken );
                    return validToken;
                }
            }
        }

        public void Format( )
        {
            TokenDictionary tokenDictionary = new TokenDictionary( );
            string name, @namespace;
            if( GuerillaCs.SplitNamespaceFromFieldName( Value.Name, out name, out @namespace ) )
            {
                this.Value.Name = tokenDictionary.GenerateValidToken( GuerillaCs.ToTypeName( name ) );
                this.Namespace = GuerillaCs.ToTypeName( @namespace );
            }
            else
            {
                this.Value.Name = tokenDictionary.GenerateValidToken( GuerillaCs.ToTypeName( this.Value.Name ) );
            }

            FormatFieldNames( tokenDictionary );
            foreach( var item in EnumDefinitions )
            {
                item.Format( );
            }
            foreach( var item in ClassDefinitions )
            {
                item.Format( );
            }
        }

        void FormatFieldNames( TokenDictionary tokenDictionary )
        {
            using( var code = new Microsoft.CSharp.CSharpCodeProvider( ) )
            {
                foreach( var item in Fields )
                {
                    var token = tokenDictionary.GenerateValidToken( GuerillaCs.ToMemberName( item.Value.Name ) );
                    item.Value.Name = token;
                }

                foreach( var item in Methods )
                {
                    var token = tokenDictionary.GenerateValidToken( GuerillaCs.ToMemberName( item.ClassName ) );
                    item.ClassName = token;
                }

                foreach( var item in EnumDefinitions )
                {
                    var token = tokenDictionary.GenerateValidToken( GuerillaCs.ToTypeName( item.Value.Name ) );
                    item.Value.Name = token;
                }
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
        }

        public ClassInfo GenerateWrapper( string wrapperName, string baseName )
        {
            var tagClassAttribute = this.Attributes.Where( x => x.AttributeType == typeof( Moonfish.Tags.TagClassAttribute ) ).SingleOrDefault( );
            var hasTagClassAttribute = tagClassAttribute == null ? false : true;
            if( hasTagClassAttribute )
                this.Attributes.Remove( tagClassAttribute );
            ClassInfo wrapperClassInfo = new ClassInfo( )
            {
                AccessModifiers = AccessModifiers.Public | AccessModifiers.Partial,
                Constructors = this.Constructors.Select( x => x.MakeWrapper( wrapperName ) ).ToList( ),
                Namespace = this.Namespace,
                Usings = this.Usings,
                Value = new GuerillaName( this.Value ),
                BaseClass = baseName,
            };
            if(hasTagClassAttribute)
                wrapperClassInfo.Attributes.Add(tagClassAttribute);
            wrapperClassInfo.Value.Name = wrapperName;
            return wrapperClassInfo;
        }

        public void GenerateReadBlockTemplateMethod( )
        {
            MethodsTemplates.Add( new MethodInfo( )
            {
                Arguments = { "BinaryReader binaryReader" },
                AccessModifiers = AccessModifiers.Internal | AccessModifiers.Virtual,
                ClassName = "Read{0}Array",
                Body =
@"var elementSize = Deserializer.SizeOf(typeof({0}));
var blamPointer = binaryReader.ReadBlamPointer(elementSize);
var array = new {0}[blamPointer.Count];
using (binaryReader.BaseStream.Pin())
{{
    for (int i = 0; i < blamPointer.Count; ++i)
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
            Methods.Add( new MethodInfo( )
            {
                Arguments = { "BinaryReader binaryReader" },
                AccessModifiers = AccessModifiers.Internal | AccessModifiers.Virtual,
                ClassName = "ReadData",
                Body =
@"var blamPointer = binaryReader.ReadBlamPointer(1);
var data = new byte[blamPointer.Count];
if(blamPointer.Count > 0)
{
    using (binaryReader.BaseStream.Pin())
    {
        binaryReader.BaseStream.Position = blamPointer[0];
        data = binaryReader.ReadBytes(blamPointer.Count);
    }
}
return data;",
                Returns = "byte[]"
            } );
        }

        public void GenerateBinaryReaderConstructor( )
        {
            Constructors.Add( new MethodInfo( )
            {
                ClassName = this.Value.Name,
                Returns = "",
                AccessModifiers = AccessModifiers.Internal,
                Arguments = { "BinaryReader binaryReader" },
                Wrapper = string.IsNullOrWhiteSpace( BaseClass ) ? false : true
            } );
            StringBuilder stringBuilder = new StringBuilder( );
            foreach( var item in this.Fields )
            {
                if( item.IsArray )
                {
                    // fixed byte array like padding or skip arrays
                    if( item.ArraySize > 0 && Type.GetType( item.FieldTypeName ) == typeof( byte ) )
                    {
                        stringBuilder.AppendLine( string.Format( "this.{0} = binaryReader.ReadBytes({1});", item.Value.Name, item.ArraySize ) );
                    }
                    // variable byte array (data)
                    else if( Type.GetType( item.FieldTypeName ) == typeof( byte ) )
                    {
                        stringBuilder.AppendLine( string.Format( "this.{0} = ReadData(binaryReader);", item.Value.Name, item.ArraySize ) );
                    }
                    // inline array
                    else if( item.ArraySize > 0 )
                    {
                        string initializer = "";
                        for( int i = 0; i <= item.ArraySize - 1; i++ )
                        {
                            initializer += string.Format( "new {0}(binaryReader){1}", item.FieldTypeName, i == item.ArraySize ? "" : ", " );
                        }
                        stringBuilder.AppendLine( string.Format( "this.{0} = new []{{ {1} }};", item.Value.Name, initializer ) );
                    }
                    // assume an TagBlock
                    else
                    {
                        var methodInfo = this.MethodsTemplates.Where( x => x.ClassName == "Read{0}Array" ).First( );
                        stringBuilder.AppendLine( string.Format( "this.{0} = {1};",
                            item.Value.Name, methodInfo.GetMethodCallSignatureFormat( item.FieldTypeName, "binaryReader" ) ) );
                        var method = methodInfo.MakeFromTemplate( item.FieldTypeName );
                        if( !this.Methods.Where( x => x.ClassName == method.ClassName
                            && x.Arguments == method.Arguments
                            && x.Returns == method.Returns ).Any( ) )
                            this.Methods.Add( method );
                    }
                }
                else
                {
                    if( EnumDefinitions.Where( x => x.Value.Name == item.FieldTypeName ).Any( ) )
                    {
                        var enumDefinition = EnumDefinitions.Where( x => x.Value.Name == item.FieldTypeName ).First( );
                        string type = enumDefinition.BaseType == EnumInfo.Type.Byte ? "Byte"
                            : enumDefinition.BaseType == EnumInfo.Type.Short ? "Int16" : "Int32";
                        stringBuilder.AppendLine( string.Format( "this.{0} = ({1})binaryReader.Read{2}();", item.Value.Name, item.FieldTypeName, type ) );
                    }
                    else if( Type.GetType( item.FieldTypeName ) == null )
                    {
                        stringBuilder.AppendLine( string.Format( "this.{0} = new {1}(binaryReader);", item.Value.Name, item.FieldTypeName ) );
                    }
                    else
                    {

                        var value = GuerillaCs.GetBinaryReaderMethodName( Type.GetType( item.FieldTypeName ) );
                        stringBuilder.AppendLine( string.Format( "this.{0} = binaryReader.{1}();", item.Value.Name, value ) );
                    }
                }
            }
            Constructors.Last( ).Body = stringBuilder.ToString( ).TrimEnd( );
        }

        public override string ToString( )
        {
            return string.Format( "{0}:{1}", "Class",
                String.IsNullOrEmpty( Namespace ) ? Value.Name : string.Format( "{0}.{1}", Namespace, Value.Name ) );
        }
    }
}
