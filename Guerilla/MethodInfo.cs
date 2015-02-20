using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using OpenTK;

namespace Moonfish.Guerilla
{
    public static class StringExtensions
    {
        public static string Tab( this string value, ref int tabCount, int tabSize = 4 )
        {
            var openingBraceCount = value.Trim( ).Count( x => x == '{' );
            var closingBraceCount = value.Trim( ).Count( x => x == '}' );
            var netTab = openingBraceCount - closingBraceCount;
            tabCount = netTab < 0 ? tabCount += netTab : tabCount;
            string tab = new string( ' ', tabCount * tabSize );
            tabCount = netTab > 0 ? tabCount += netTab : tabCount;
            return tab + value.Trim( );
        }
    }
    public static class StringBuilderExtensions
    {
        public static void AppendSummary( this StringBuilder stringBuilder, string value )
        {
            stringBuilder.AppendLine( "/// <summary>" );
            stringBuilder.AppendLine( string.Format( "/// {0}", value ) );
            stringBuilder.AppendLine( "/// </summary>" );
        }
    }

    [Flags]
    public enum AccessModifiers
    {
        Private = 1,
        Protected = 2,
        Internal = 4,
        Public = 8,
        Abstract = 16,
        Virtual = 32,
        Partial = 64,
        Any = Private | Protected | Internal | Public | Abstract | Virtual | Partial
    }

    public static class AccessModifiersExtensions
    {
        public static string ToString( this AccessModifiers items )
        {
            if( ( items & AccessModifiers.Any ) == 0 ) return "";
            var value = new StringBuilder( );
            var values = items.ToString( ).Split( ',' ).ToList( );
            values.TakeWhile( x => x != values.Last( ) ).ToList( ).ForEach( x => value.Append( string.Format( "{0} ", x.ToLower( ) ) ) );
            value.Append( string.Format( "{0}", values.LastOrDefault( ) == null ? "" : values.Last( ).ToLower( ) ) );

            return value.ToString( ).Trim( );
        }
    }

    public class GuerillaName
    {
        public string Name
        {
            get { return GuerillaCs.SplitNameDescription( this.Value )[0]; }
            set
            {
                if( HasName )
                    this.Value = this.Value.Replace( GuerillaCs.SplitNameDescription( this.Value )[0], value );
                else
                    this.Value = this.Value.Insert( 0, value );
            }
        }
        public string Description
        {
            get { return GuerillaCs.SplitNameDescription( this.Value )[1]; }
            set
            {
                if( HasDescription )
                    this.Value = this.Value.Replace( GuerillaCs.SplitNameDescription( this.Value )[1], value );
                else
                    this.Value = this.Value.Insert( this.Name.Length, "#" + value );
            }
        }

        public bool HasName { get { return !string.IsNullOrEmpty( this.Name ); } }

        public bool HasDescription { get { return !string.IsNullOrEmpty( this.Description ); } }

        string Value;

        public GuerillaName( string value )
        {
            this.Value = value;
        }

        public static implicit operator GuerillaName( string value )
        {
            return new GuerillaName( value );
        }

        public static implicit operator string( GuerillaName guerillaName )
        {
            return guerillaName.Value;
        }
    }

    public class EnumInfo
    {
        public Type BaseType { get; set; }
        public List<AttributeInfo> Attributes { get; set; }
        public AccessModifiers AccessModifiers { get; set; }
        public GuerillaName Value { get; set; }
        public List<GuerillaName> ValueNames { get; set; }

        public enum Type
        {
            Byte,
            Short,
            Int,
        }

        public EnumInfo( )
        {
            Attributes = new List<AttributeInfo>( );
            ValueNames = new List<GuerillaName>( );
        }

        public void Format( )
        {
            var tokenDictionary = new ClassInfo.TokenDictionary( );
            for( int i = 0; i < ValueNames.Count; i++ )
            {
                ValueNames[i] = tokenDictionary.GenerateValidToken( GuerillaCs.ToTypeName( ValueNames[i] ) );
            }
        }

        public override string ToString( )
        {
            var stringBuilder = new StringBuilder
                (
                
                );
            foreach( var attribute in this.Attributes )
            {
                stringBuilder.AppendLine( attribute.ToString() );
            }
            stringBuilder.AppendLine( string.Format( "{0} enum {1} : {2}", 
                AccessModifiersExtensions.ToString( AccessModifiers ), Value.Name, BaseType.ToString( ).ToLowerInvariant( ) ).Trim( ) );
            stringBuilder.AppendLine( );
            stringBuilder.AppendLine( "{" );

            var isFlags = Attributes.Any( x => x.AttributeType == typeof( FlagsAttribute ) );
            var value = isFlags ? 1 : 0;
            foreach( var item in ValueNames )
            {
                if( item.HasDescription ) stringBuilder.AppendSummary( item.Description );
                stringBuilder.AppendLine( string.Format( "{0} = {1},", GuerillaCs.ToTypeName( item.Name ), value ) );
                value = isFlags ? value << 1 : ++value;
            }
            stringBuilder.AppendLine( "};" );
            return stringBuilder.ToString( ).Trim( );
        }
    }

    public class AttributeInfo
    {
        public AttributeInfo( Type attributeType, params object[] namedParameters )
        {
            var count = namedParameters.Length % 2 == 0 ?
                namedParameters.Length / 2 : ( namedParameters.Length - 1 ) / 2;
            this.NamedParameters = new List<Tuple<string, string>>( count );
            this.Parameters = new List<string>( count );
            for( int i = 0; i < count; i += 2 )
            {
                if( namedParameters[i] == null )
                    Parameters.Add( namedParameters[i + 1].ToString( ) );
                else
                    NamedParameters.Add( new Tuple<string, string>( namedParameters[i].ToString( ), namedParameters[i + 1].ToString( ) ) );
            }
            this.AttributeType = attributeType;
        }

        public Type AttributeType { get; set; }
        public List<Tuple<string, string>> NamedParameters { get; set; }
        public List<string> Parameters { get; set; }

        public override string ToString( )
        {
            using( var code = new Microsoft.CSharp.CSharpCodeProvider( ) )
            {
                var hasParameters = NamedParameters.Count > 0 || Parameters.Count > 0;
                var parametersString = new StringBuilder( );
                if( hasParameters && Parameters.Count > 0 )
                {
                    Parameters.TakeWhile( x => Parameters.Last( ) != x ).ToList( ).ForEach( x => parametersString.Append( string.Format( "{0}, ", x ) ) );
                    parametersString.Append( Parameters.Last( ) );
                }
                if( hasParameters && NamedParameters.Count > 0 )
                {
                    NamedParameters.TakeWhile( x => NamedParameters.Last( ) != x ).ToList( ).ForEach( x => parametersString.Append( string.Format( "{0} = {1}, ", x.Item1, x.Item2 ) ) );
                    parametersString.Append( string.Format( "{0} = {1}", NamedParameters.Last( ).Item1, NamedParameters.Last( ).Item2 ) );
                }

                var retval = string.Format( "[{0}{1}]", AttributeType.Name,
                    hasParameters ? string.Format( "({0})", parametersString ) : "" );
                return retval;
            }
        }
    }

    public class FieldInfo
    {
        public FieldInfo( )
        {
            Attributes = new List<AttributeInfo>( );
        }
        public List<AttributeInfo> Attributes { get; set; }
        public AccessModifiers AccessModifiers { get; set; }
        public string FieldTypeName { get; set; }
        public GuerillaName Value { get; set; }
        public bool IsArray { get; set; }
        public int ArraySize { get; set; }

        public override string ToString( )
        {
            StringBuilder stringBuilder = new StringBuilder( );
            // write Summary
            if( Value.HasDescription ) stringBuilder.AppendSummary( Value.Description );
            // write Attributes
            foreach( var attribute in Attributes )
                stringBuilder.AppendLine( attribute.ToString( ) );

            var typeString = GetTypeOutput( );

            // write Field
            stringBuilder.AppendLine( string.Format( "{0} {1}{2} {3};", AccessModifiersExtensions.ToString( AccessModifiers ),
                typeString, IsArray ? "[]" : "", this.Value.Name ) );

            return stringBuilder.ToString( ).Trim( );
        }

        private string GetTypeOutput( )
        {
            var type = Type.GetType( FieldTypeName );
            if( type != null )
            {
                using( var code = new Microsoft.CSharp.CSharpCodeProvider( ) )
                {
                    return code.GetTypeOutput( new System.CodeDom.CodeTypeReference( type.FullName ) );
                }
            }
            else return FieldTypeName;
        }
    }

    public class MethodInfo
    {
        public MethodInfo( )
        {
            Arguments = new List<string>( );
        }
        public AccessModifiers AccessModifiers { get; set; }
        public string ClassName { get; set; }
        public List<string> Arguments { get; set; }
        public string Body { get; set; }
        public string Returns { get; set; }
        public bool Wrapper { get; set; }

        public string GetMethodCallSignature( params string[] arguments )
        {
            return GetMethodCallSignatureFormat( "", arguments );
        }

        public string GetMethodSignature( )
        {
            return GetMethodSignatureFormat( "" );
        }

        public string GetMethodSignatureFormat( string methodName )
        {
            return GetMethodCallSignatureFormat( methodName, this.Arguments.ToArray( ) );
        }

        public string GetMethodCallSignatureFormat( string methodName, params string[] arguments )
        {

            var argumentStringBuilder = GetArguments( arguments );
            return string.Format( "{0}{1}", String.Format( ClassName, methodName ), string.Format( "({0})", arguments.Any( ) ? argumentStringBuilder.ToString( ) : "" ) );
        }

        private static StringBuilder GetArguments( string[] arguments )
        {
            var argumentStringBuilder = new StringBuilder( );
            if( arguments.Any( ) )
            {
                arguments.TakeWhile( x => x != arguments.Last( ) ).ToList( ).ForEach( x => argumentStringBuilder.AppendFormat( "{0}, ", x ) );
                argumentStringBuilder.Append( arguments.Last( ) );
            }
            return argumentStringBuilder;
        }

        public MethodInfo MakeFromTemplate( params string[] args )
        {
            return new MethodInfo( )
            {
                Arguments = this.Arguments,
                AccessModifiers = this.AccessModifiers,
                ClassName = string.Format( this.ClassName, args ),
                Body = string.Format( this.Body, args ),
                Returns = string.Format( this.Returns, args ),
            };
        }

        public override string ToString( )
        {
            StringBuilder methodStringBuilder = new StringBuilder( );
            var modifiersString = AccessModifiersExtensions.ToString( AccessModifiers );
            methodStringBuilder.AppendFormat( "{0} {1} {2}", modifiersString, Returns, GetMethodSignature( ) );
            if( Wrapper )
            {
                var arguments = this.Arguments.SelectMany( x => x.Split( ' ' ) ).Where( ( x, i ) => i % 2 == 1 ).ToArray( );
                methodStringBuilder.AppendFormat( ": base({0})", GetArguments( arguments ) );
            }
            methodStringBuilder.AppendLine( );
            methodStringBuilder.AppendLine( "{" );
            methodStringBuilder.Append( this.Body );
            methodStringBuilder.AppendLine( );
            methodStringBuilder.AppendLine( "}" );
            return methodStringBuilder.ToString( ).Trim( );
        }

        internal MethodInfo MakeWrapper( string className )
        {
            return new MethodInfo( )
            {
                Arguments = this.Arguments,
                AccessModifiers = AccessModifiers.Public,
                Wrapper = true,
                ClassName = className,
                Body = "",
                Returns = this.Returns,
            };
        }
    }
}
