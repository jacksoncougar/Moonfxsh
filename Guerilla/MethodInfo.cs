using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Moonfish.Guerilla
{
    public static class StringExtensions
    {
        public static string Tab( this string value, ref int tabCount, int tabSize = 4 )
        {
            var openingBraceCount = value.Trim( ).Count( x => x == '{' );
            var closingBraceCount = value.Trim( ).Count( x => x == '}' );
            var netTab = openingBraceCount - closingBraceCount;
            tabCount = netTab < 0 ? tabCount + netTab : tabCount;
            var tab = new string( ' ', tabCount * tabSize );
            tabCount = netTab > 0 ? tabCount + netTab : tabCount;
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
        Override = 128,
        Any = Private | Protected | Internal | Public | Abstract | Virtual | Partial | Override
    }

    public static class AccessModifiersExtensions
    {
        public static string ToTokenString(this AccessModifiers items)
        {
            if ( ( items & AccessModifiers.Any ) == 0 ) return "";
            var value = new StringBuilder( );
            var values = items.ToString( ).Split( ',' ).ToList( );
            values.TakeWhile( x => x != values.Last( ) )
                .ToList( )
                .ForEach( x => value.Append( string.Format( "{0} ", x.ToLower( ) ) ) );
            value.Append( string.Format( "{0}", values.LastOrDefault( ) == null ? "" : values.Last( ).ToLower( ) ) );

            return value.ToString( ).Trim( );
        }
    }

    public class GuerillaName
    {
        public string Name
        {
            get { return GuerillaCs.SplitNameDescription( Value )[ 0 ]; }
            set
            {
                if ( HasName )
                    Value = Value.Replace( GuerillaCs.SplitNameDescription( Value )[ 0 ], value );
                else
                    Value = Value.Insert( 0, value );
            }
        }

        public string Description
        {
            get { return GuerillaCs.SplitNameDescription( Value )[ 1 ]; }
            set
            {
                if ( HasDescription )
                    Value = Value.Replace( GuerillaCs.SplitNameDescription( Value )[ 1 ], value );
                else
                    Value = Value.Insert( Name.Length, "#" + value );
            }
        }

        public bool HasName
        {
            get { return !string.IsNullOrEmpty( Name ); }
        }

        public bool HasDescription
        {
            get { return !string.IsNullOrEmpty( Description ); }
        }

        private string Value;

        public GuerillaName( string value )
        {
            Value = value;
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
            for ( int i = 0; i < ValueNames.Count; i++ )
            {
                ValueNames[ i ] = tokenDictionary.GenerateValidToken( GuerillaCs.ToTypeName( ValueNames[ i ] ) );
            }
        }

        public override string ToString( )
        {
            var stringBuilder = new StringBuilder( );
            foreach ( var attribute in Attributes )
            {
                stringBuilder.AppendLine( attribute.ToString( ) );
            }
            stringBuilder.AppendLine( string.Format( "{0} enum {1} : {2}",
                AccessModifiers.ToTokenString(  ), Value.Name,
                BaseType.ToString( ).ToLowerInvariant( ) ).Trim( ) );
            stringBuilder.AppendLine( "{" );

            var isFlags = Attributes.Any( x => x.AttributeType == typeof ( FlagsAttribute ) );
            var value = isFlags ? 1 : 0;
            foreach ( var item in ValueNames )
            {
                if ( item.HasDescription ) stringBuilder.AppendSummary( item.Description );
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
            var count = namedParameters.Length % 2 == 0
                ? namedParameters.Length / 2
                : ( namedParameters.Length - 1 ) / 2;
            NamedParameters = new List<Tuple<string, string>>( count );
            Parameters = new List<string>( count );
            for ( int i = 0; i < count * 2; i += 2 )
            {
                if ( namedParameters[ i ] == null )
                    Parameters.Add( namedParameters[ i + 1 ].ToString( ) );
                else
                    NamedParameters.Add( new Tuple<string, string>( namedParameters[ i ].ToString( ),
                        namedParameters[ i + 1 ].ToString( ) ) );
            }
            AttributeType = attributeType;
        }

        public Type AttributeType { get; set; }
        public List<Tuple<string, string>> NamedParameters { get; set; }
        public List<string> Parameters { get; set; }

        public override string ToString( )
        {
            using ( var code = new Microsoft.CSharp.CSharpCodeProvider( ) )
            {
                var hasParameters = NamedParameters.Count > 0 || Parameters.Count > 0;
                var parametersString = new StringBuilder( );
                if ( hasParameters && Parameters.Count > 0 )
                {
                    Parameters.TakeWhile( x => Parameters.Last( ) != x )
                        .ToList( )
                        .ForEach( x => parametersString.Append( string.Format( "{0}, ", x ) ) );
                    parametersString.Append( Parameters.Last( ) );
                }
                if ( hasParameters && NamedParameters.Count > 0 )
                {
                    NamedParameters.TakeWhile( x => NamedParameters.Last( ) != x )
                        .ToList( )
                        .ForEach( x => parametersString.Append( string.Format( "{0} = {1}, ", x.Item1, x.Item2 ) ) );
                    parametersString.Append( string.Format( "{0} = {1}", NamedParameters.Last( ).Item1,
                        NamedParameters.Last( ).Item2 ) );
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
            if ( Value.HasDescription ) stringBuilder.AppendSummary( Value.Description );
            // write Attributes
            foreach ( var attribute in Attributes )
                stringBuilder.AppendLine( attribute.ToString( ) );

            var typeString = GetTypeOutput( );

            // write Field
            stringBuilder.AppendLine( string.Format( "{0} {1}{2} {3};",
                AccessModifiers.ToTokenString(  ),
                typeString, IsArray ? "[]" : "", Value.Name ) );

            return stringBuilder.ToString( ).Trim( );
        }

        private string GetTypeOutput( )
        {
            var type = Type.GetType( FieldTypeName );
            if ( type != null )
            {
                using ( var code = new Microsoft.CSharp.CSharpCodeProvider( ) )
                {
                    return code.GetTypeOutput( new System.CodeDom.CodeTypeReference( type.FullName ) );
                }
            }
            else return FieldTypeName;
        }
    }

    public class PropertyInfo
    {
        public AccessModifiers AccessModifiers { get; set; }
        public string Name { get; set; }
        public string Returns { get; set; }
        public string SetBody { get; set; }
        public string GetBody { get; set; }

        public string GetDefinition( )
        {
            var hasSetter = SetBody == null;
            var hasGetter = GetBody == null;

            var builder =
                new StringBuilder( string.Format( "{0} {1} {2}", AccessModifiers.ToTokenString( ), Returns, Name ) );
            var indent = 0;
            builder.Append( "{".Tab( ref indent ) );
            if ( hasGetter )
            {
                var auto = string.IsNullOrWhiteSpace( GetBody );
                if ( auto ) builder.Append( "get;" );
                else
                {
                    builder.Append( "get {".Tab( ref indent ) );
                    builder.Append( GetBody );
                    builder.Append( "}".Tab( ref indent ) );
                }
            }
            if ( hasSetter )
            {
                var auto = string.IsNullOrWhiteSpace( SetBody );
                if ( auto ) builder.Append( "set;" );
                else
                {
                    builder.Append( "set {".Tab( ref indent ) );
                    builder.Append( SetBody );
                    builder.Append( "}".Tab( ref indent ) );
                }
            }
            builder.Append( "}".Tab( ref indent ) );
            return builder.ToString( );
        }
    }

    public class MethodInfo
    {
        public MethodInfo( )
        {
            Arguments = new List<ParameterInfo>( );
        }

        public AccessModifiers AccessModifiers { get; set; }
        public string ClassName { get; set; }
        public List<ParameterInfo> Arguments { get; set; }
        public string Body { get; set; }
        public string Returns { get; set; }
        public bool Wrapper { get; set; }

        public string GetMethodCallSignature( params ParameterInfo[] parameters )
        {
            return GetMethodCallSignatureFormat( "", GetArguments( parameters ) );
        }

        public string GetMethodSignature( )
        {
            return GetMethodSignatureFormat( "" );
        }

        public string GetMethodSignatureFormat( string methodName )
        {
            return GetMethodCallSignatureFormat( methodName, GetSignature( Arguments ) );
        }

        public string GetMethodCallSignatureFormat( string methodName, StringBuilder argumentString )
        {
            return string.Format( "{0}{1}", String.Format( ClassName, methodName ),
                string.Format( "({0})", argumentString ) );
        }

        private static StringBuilder GetSignature( IList<ParameterInfo> arguments )
        {
            var argumentStringBuilder = new StringBuilder( );
            if ( arguments.Any( ) )
            {
                arguments.TakeWhile( x => x != arguments.Last( ) )
                    .ToList( )
                    .ForEach(
                        x =>
                            argumentStringBuilder.AppendFormat( "{0} {1}, ", x.ParameterType, x.Name ) );
                var arg = arguments.Last( );
                argumentStringBuilder.Append(
                    string.Format( "{0} {1} {2}", arg.Modifier.GetSignatureModifier( ), arg.ParameterType.Name, arg.Name )
                        .TrimStart( ) );
            }
            return argumentStringBuilder;
        }

        private static StringBuilder GetArguments( IList<ParameterInfo> arguments )
        {
            var argumentStringBuilder = new StringBuilder( );
            if ( arguments.Any( ) )
            {
                arguments.TakeWhile( x => x != arguments.Last( ) )
                    .ToList( )
                    .ForEach( x => argumentStringBuilder.AppendFormat( "{0}, ", x.Name ) );
                var arg = arguments.Last( );
                argumentStringBuilder.AppendFormat( "{0}", arg.Name );
            }
            return argumentStringBuilder;
        }

        public MethodInfo MakeFromTemplate( params string[] args )
        {
            return new MethodInfo( )
            {
                Arguments = Arguments,
                AccessModifiers = AccessModifiers,
                ClassName = string.Format( ClassName, args ),
                Body = string.Format( Body, args ),
                Returns = string.Format( Returns, args ),
            };
        }

        public override string ToString( )
        {
            var methodStringBuilder = new StringBuilder( );
            var modifiersString = AccessModifiers.ToTokenString();
            methodStringBuilder.AppendFormat( "{0} {1} {2}", modifiersString, Returns, GetMethodSignature( ) );
            if ( Wrapper )
            {
                methodStringBuilder.AppendFormat( ": base({0})", GetArguments( Arguments ) );
            }
            methodStringBuilder.AppendLine( );
            methodStringBuilder.AppendLine( "{" );
            methodStringBuilder.Append( Body );
            methodStringBuilder.AppendLine( );
            methodStringBuilder.AppendLine( "}" );
            return methodStringBuilder.ToString( ).Trim( );
        }

        internal MethodInfo MakeWrapper( string className )
        {
            return new MethodInfo
            {
                Arguments = Arguments,
                AccessModifiers = AccessModifiers.Public,
                Wrapper = true,
                ClassName = className,
                Body = "",
                Returns = Returns,
            };
        }
    }
}