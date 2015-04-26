using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using Microsoft.CSharp;
using Moonfish.Tags;
using OpenTK;

namespace Moonfish.Guerilla
{
    public class GuerillaCs : Guerilla
    {
        private readonly Dictionary<string, ClassInfo> _definitionsDictionary = new Dictionary<string, ClassInfo>( );
        private readonly Dictionary<MoonfishFieldType, Type> _valueTypeDictionary;

        static GuerillaCs( )
        {
            BinaryIO.CacheMethods( );
            InitializeNamespaceDictionary( );
        }

        public GuerillaCs( string guerillaExecutablePath )
            : base( guerillaExecutablePath )
        {
            BinaryIO.CacheMethods( );
            var assembly = typeof ( StringID ).Assembly;
            var query = from type in assembly.GetTypes( )
                where type.GetCustomAttributes( typeof ( GuerillaTypeAttribute ), false ).Any( )
                select type;
            var valueTypes = query.ToArray( );
            _valueTypeDictionary = new Dictionary<MoonfishFieldType, Type>( valueTypes.Count( ) );
            foreach ( var type in valueTypes )
            {
                var guerillaTypeAttributes =
                    ( GuerillaTypeAttribute[] ) type.GetCustomAttributes( typeof ( GuerillaTypeAttribute ), false );
                foreach ( var guerillaType in guerillaTypeAttributes )
                {
                    _valueTypeDictionary.Add( guerillaType.FieldType, type );
                }
            }
            _valueTypeDictionary.Add( MoonfishFieldType.FieldAngle, typeof ( float ) );
            _valueTypeDictionary.Add( MoonfishFieldType.FieldRealEulerAngles_3D, typeof ( Vector3 ) );
            _valueTypeDictionary.Add( MoonfishFieldType.FieldCharInteger, typeof ( byte ) );
            _valueTypeDictionary.Add( MoonfishFieldType.FieldShortInteger, typeof ( short ) );
            _valueTypeDictionary.Add( MoonfishFieldType.FieldShortBounds, typeof ( int ) );
            _valueTypeDictionary.Add( MoonfishFieldType.FieldLongInteger, typeof ( int ) );
            _valueTypeDictionary.Add( MoonfishFieldType.FieldReal, typeof ( float ) );
            _valueTypeDictionary.Add( MoonfishFieldType.FieldRealFraction, typeof ( float ) );
            _valueTypeDictionary.Add( MoonfishFieldType.FieldRealFractionBounds, typeof ( Vector2 ) );
            _valueTypeDictionary.Add( MoonfishFieldType.FieldRealPoint_2D, typeof ( Vector2 ) );
            _valueTypeDictionary.Add( MoonfishFieldType.FieldRealVector_3D, typeof ( Vector3 ) );
            _valueTypeDictionary.Add( MoonfishFieldType.FieldRealVector_2D, typeof ( Vector2 ) );
            _valueTypeDictionary.Add( MoonfishFieldType.FieldRealPoint_3D, typeof ( Vector3 ) );
            _valueTypeDictionary.Add( MoonfishFieldType.FieldRealEulerAngles_2D, typeof ( Vector2 ) );
            _valueTypeDictionary.Add( MoonfishFieldType.FieldRealPlane_2D, typeof ( Vector3 ) );
            _valueTypeDictionary.Add( MoonfishFieldType.FieldRealPlane_3D, typeof ( Vector4 ) );
            _valueTypeDictionary.Add( MoonfishFieldType.FieldRealQuaternion, typeof ( Quaternion ) );
            _valueTypeDictionary.Add( MoonfishFieldType.FieldRealArgbColor, typeof ( Vector4 ) );
            _valueTypeDictionary.Add( MoonfishFieldType.FieldRectangle_2D, typeof ( Vector2 ) );
        }

        private static List<string> Namespaces { get; set; }

        private ClassInfo BeginProcessTagBlockDefinition( MoonfishTagDefinition block,
            string className = "" )
        {
            var size = block.CalculateSizeOfFieldSet( );
            var alignment = block.Alignment;

#if DEBUG
            System.Diagnostics.Debug.Assert( alignment > 0 && alignment % 2 == 0 );
#endif

            var @class = new ClassInfo
            {
                AccessModifiers = AccessModifiers.Public,
                Value = className == string.Empty ? ToTypeName( block.Name ) : ToTypeName( className ),
                Attributes =
                {
                    new AttributeInfo( typeof ( LayoutAttribute ),
                        StaticReflection.GetMemberName( ( LayoutAttribute layout ) => layout.Size ), size,
                        StaticReflection.GetMemberName( ( LayoutAttribute layout ) => layout.Alignment ), alignment
                        )
                }
            };


            ProcessFields( block.Fields, @class );
            @class.Format( );
            return @class;
        }

        public void DumpTagLayout( MoonfishTagGroup tag, string folder )
        {
            _definitionsDictionary.Clear( );

            var info = BeginProcessTagBlockDefinition( tag.Definition );

            using ( var stream = new FileStream( Path.Combine( folder, info.Value.Name + ".cs" ), FileMode.Create,
                FileAccess.Write, FileShare.ReadWrite ) )
            {
                var parentTag = h2Tags.SingleOrDefault( x => x.Class == tag.ParentClass );
                if ( parentTag != null )
                {
                    info.BaseClass = new ClassInfo.TokenDictionary( ).GenerateValidToken(
                        ToTypeName( parentTag.Definition.Name ) );
                }
                info.Attributes.Add( new AttributeInfo( typeof ( TagClassAttribute ) )
                {
                    Parameters = {"\"" + tag.Class + "\""}
                } );
                var streamWriter = new StreamWriter( stream );
                info.Generate( );
                GenerateOutputForClass( info, streamWriter );
            }

            var localDefinitions = _definitionsDictionary.Select( x => x.Value );


            foreach ( var item in localDefinitions )
            {
                using ( var stream = new FileStream( Path.Combine( folder, item.Value.Name + ".cs" ), FileMode.Create,
                    FileAccess.Write, FileShare.ReadWrite ) )
                {
                    item.Generate( );
                    GenerateOutputForClass( item, new StreamWriter( stream ) );
                }
            }
        }

        private static string FormatTypeReference( Type type )
        {
            using ( var provider = new CSharpCodeProvider( ) )
            {
                var typeRef = new CodeTypeReference( type );
                var typeName = provider.GetTypeOutput( typeRef );

                typeName = typeName.Substring( typeName.LastIndexOf( '.' ) + 1 );
                return typeName;
            }
        }

        public static string[] SplitNameDescription( string fieldName )
        {
            var items = fieldName.Split( '#' );
            return new[] {items.Length > 0 ? items[ 0 ] : null, items.Length > 1 ? items[ 1 ] : null};
        }

        public static bool SplitNamespaceFromFieldName( string longFieldName, out string name, out string @namespace )
        {
            foreach ( var item in Namespaces )
            {
                if ( longFieldName.StartsWith( item ) )
                {
                    name = longFieldName.Remove( 0, item.Length );
                    @namespace = item;
                    return true;
                }
            }
            name = longFieldName;
            @namespace = string.Empty;
            return false;
        }

        public new static string ToMemberName( string value )
        {
            return Guerilla.ToMemberName( value );
        }

        public new static string ToTypeName( string value )
        {
            return Guerilla.ToTypeName( value );
        }

        protected override string FormatAttributeString( string attributeString )
        {
            return string.Format( "[{0}]", attributeString );
        }

        private void GenerateOutputForClass( ClassInfo classInfo, StreamWriter streamWriter, bool subClass = false,
            int tabCount = 0 )
        {
            if ( !subClass )
            {
                var wrapperClassInfo = classInfo.GenerateWrapper( classInfo.Value.Name, classInfo.Value.Name + "Base" );
                classInfo.Value.Name += "Base";
                classInfo.Generate( );

                foreach ( var item in classInfo.Usings )
                {
                    streamWriter.WriteLine( item );
                }

                if ( wrapperClassInfo.Attributes.Any( x => x.AttributeType == typeof ( TagClassAttribute ) ) )
                {
                    streamWriter.WriteLine( );
                    streamWriter.WriteLine( "namespace Moonfish.Tags".Tab( ref tabCount ) );
                    streamWriter.WriteLine( "{".Tab( ref tabCount ) );
                    var @class =
                        wrapperClassInfo.Attributes.First( x => x.AttributeType == typeof ( TagClassAttribute ) )
                            .Parameters[ 0
                            ].Trim( '"' );
                    streamWriter.WriteLine(
                        string.Format( "public partial struct {0}", typeof ( TagClass ).Name ).Tab( ref tabCount ) );
                    streamWriter.WriteLine( "{".Tab( ref tabCount ) );

                    var tagClass = ( TagClass ) @class;
                    var titleCase = CultureInfo.CurrentCulture.TextInfo.ToTitleCase( tagClass.ToTokenString( ) );
                    streamWriter.WriteLine(
                        string.Format( @"public static readonly {0} {1} = ({0})""{2}"";", typeof ( TagClass ).Name,
                            titleCase, @class ).Tab( ref tabCount ) );
                    streamWriter.WriteLine( "};".Tab( ref tabCount ) );
                    streamWriter.WriteLine( "};".Tab( ref tabCount ) );
                }

                streamWriter.WriteLine( );
                streamWriter.WriteLine( classInfo.NamespaceDeclaration.Tab( ref tabCount ) );
                streamWriter.WriteLine( "{".Tab( ref tabCount ) );

                GenerateOutputForSubclass( wrapperClassInfo, streamWriter, tabCount );
            }
            classInfo.Attributes.ForEach( x => streamWriter.WriteLine( x.ToString( ).Tab( ref tabCount ) ) );
            streamWriter.WriteLine( classInfo.ClassDeclaration.Tab( ref tabCount ) );
            streamWriter.WriteLine( "{".Tab( ref tabCount ) );

            if ( !subClass )
            {
                classInfo.Value.Name =
                    classInfo.Value.Name.Remove( classInfo.Value.Name.LastIndexOf( "Base", StringComparison.Ordinal ), 4 );
            }

            foreach ( var item in classInfo.Fields )
            {
                tabCount = ProcessLines( streamWriter, tabCount, item );
            }

            foreach ( var item in classInfo.Constructors )
            {
                tabCount = ProcessLines( streamWriter, tabCount, item );
            }

            foreach ( var item in classInfo.Methods )
            {
                tabCount = ProcessLines( streamWriter, tabCount, item );
            }

            foreach ( var item in classInfo.EnumDefinitions )
            {
                tabCount = ProcessLines( streamWriter, tabCount, item );
            }

            foreach ( var item in classInfo.ClassDefinitions )
            {
                item.Generate( );
                GenerateOutputForSubclass( item, streamWriter, tabCount );
            }

            streamWriter.WriteLine( "};".Tab( ref tabCount ) );

            if ( !subClass )
            {
                streamWriter.WriteLine( "}".Tab( ref tabCount ) );
            }
            streamWriter.Flush( );
        }

        private void GenerateOutputForSubclass( ClassInfo item, StreamWriter streamWriter, int tabCount )
        {
            GenerateOutputForClass( item, streamWriter, true, tabCount );
        }

        private static void InitializeNamespaceDictionary( )
        {
            const string globalNamespace = "global";
            const string globalGeometryNamespace = "global_geometry";
            const string structureNamespace = "structure";
            const string structureBspNamespace = "structure_bsp";

            Namespaces = new List<string>( new[]
            {
                globalNamespace,
                globalGeometryNamespace,
                structureNamespace,
                structureBspNamespace
            } );

            Namespaces.Sort( );
            Namespaces.Reverse( );
        }

        private static bool IsValidFieldName( string value )
        {
            string[] invalidNames =
            {
                "EMPTY_STRING",
                "EMPTYSTRING",
                "",
                "YOUR MOM"
            };
            return !invalidNames.Any( value.Equals );
        }

        private ClassInfo ProcessArrayFields( List<MoonfishTagField> fields )
        {
            var arrayClass = new ClassInfo
            {
                Attributes =
                {
                    new AttributeInfo( typeof ( LayoutAttribute ),
                        StaticReflection.GetMemberName( ( LayoutAttribute layout ) => layout.Size ),
                        MoonfishTagDefinition.CalculateSizeOfFieldSet( fields.GetRange( 1, fields.Count - 2 ) ),
                        StaticReflection.GetMemberName( ( LayoutAttribute layout ) => layout.Alignment ), 1)
                },
                Value = ToTypeName( fields[ 0 ].Name ),
                AccessModifiers = AccessModifiers.Public
            };
            fields.RemoveAt( 0 );
            ProcessFields( fields, arrayClass );

            return arrayClass;
        }

        private static string ProcessFieldName( string fieldName, Dictionary<string, int> fieldNames )
        {
            if ( fieldNames.ContainsKey( fieldName ) )
            {
                fieldName = fieldName + fieldNames[ fieldName ]++;
            }
            else
            {
                fieldNames[ fieldName ] = 0;
            }
            return ValidateFieldName( fieldName );
        }

        private void ProcessFields( List<MoonfishTagField> fields, ClassInfo @class )
        {
            foreach ( var field in fields )
            {
                FieldInfo fieldInfo;
                switch ( field.Type )
                {
                    case MoonfishFieldType.FieldTagReference:
                    {
                        fieldInfo = new FieldInfo
                        {
                            Attributes =
                            {
                                new AttributeInfo( typeof ( TagReference ), null,
                                    "\"" + field.Definition.Class + "\"" )
                            },
                            AccessModifiers = AccessModifiers.Internal,
                            Value = field.Name,
                            FieldTypeName = _valueTypeDictionary[ field.Type ].FullName
                        };
                        @class.Fields.Add( fieldInfo );
                        break;
                    }
                    case MoonfishFieldType.FieldBlock:
                    {
                        fieldInfo = new FieldInfo
                        {
                            Value =
                                IsValidFieldName( field.Name.ToUpper( ) ) ? field.Name : field.Definition.DisplayName,
                            AccessModifiers = AccessModifiers.Internal
                        };

                        if ( !_definitionsDictionary.ContainsKey( field.Definition.Name ) )
                        {
                            _definitionsDictionary[ field.Definition.Name ] =
                                BeginProcessTagBlockDefinition( field.Definition );
                        }

                        fieldInfo.FieldTypeName = _definitionsDictionary[ field.Definition.Name ].Value.Name;
                        fieldInfo.IsArray = true;
                        @class.Fields.Add( fieldInfo );
                        break;
                    }
                    case MoonfishFieldType.FieldStruct:
                    {
                        fieldInfo = new FieldInfo
                        {
                            Value =
                                IsValidFieldName( field.Name.ToUpper( ) )
                                    ? field.Name
                                    : field.Definition.Definition.DisplayName,
                            AccessModifiers = AccessModifiers.Internal
                        };

                        if ( !_definitionsDictionary.ContainsKey( field.Definition.Name ) )
                        {
                            _definitionsDictionary[ field.Definition.Name ] =
                                BeginProcessTagBlockDefinition( field.Definition.Definition );
                        }

                        fieldInfo.FieldTypeName = _definitionsDictionary[ field.Definition.Name ].Value.Name;
                        @class.Fields.Add( fieldInfo );
                        break;
                    }
                    case MoonfishFieldType.FieldData:
                    {
                        fieldInfo = new FieldInfo
                        {
                            Value = field.Name,
                            AccessModifiers = AccessModifiers.Internal,
                            FieldTypeName =
                                ( ( MoonfishTagDataDefinition ) field.Definition ).DataElementSize == 1
                                    ? typeof ( Byte ).FullName
                                    : typeof ( short ).FullName,
                            IsArray = true
                        };
                        @class.Fields.Add( fieldInfo );
                        break;
                    }
                    case MoonfishFieldType.FieldExplanation:
                    {
                        //// Check if there is sub-text for this explaination.
                        //string subtext = "";
                        //if (field.definition != 0)
                        //    subtext = ReadString(reader, field.definition);

                        //// Write the field info to the output file.
                        //writer.WriteLine("//FIELD_EXPLAINATION(\"{0}\", \"{1}\"),", field.Name, subtext.Replace("\n", "<lb>"));
                        break;
                    }
                    case MoonfishFieldType.FieldByteFlags:
                    case MoonfishFieldType.FieldLongFlags:
                    case MoonfishFieldType.FieldWordFlags:
                    case MoonfishFieldType.FieldCharEnum:
                    case MoonfishFieldType.FieldEnum:
                    case MoonfishFieldType.FieldLongEnum:
                    {
                        var enumInfo = new EnumInfo
                        {
                            Value = ToTypeName( field.Name ),
                            AccessModifiers = AccessModifiers.Internal
                        };
                        var enumDefinition = ( MoonfishTagEnumDefinition ) field.Definition;
                        enumInfo.ValueNames.AddRange( enumDefinition.Names.Select( x => ( GuerillaName ) x ) );
                        switch ( field.Type )
                        {
                            case MoonfishFieldType.FieldByteFlags:
                                enumInfo.BaseType = EnumInfo.Type.Byte;
                                enumInfo.Attributes.Add( new AttributeInfo( typeof ( FlagsAttribute ) ) );
                                break;
                            case MoonfishFieldType.FieldWordFlags:
                                enumInfo.BaseType = EnumInfo.Type.Short;
                                enumInfo.Attributes.Add( new AttributeInfo( typeof ( FlagsAttribute ) ) );
                                break;
                            case MoonfishFieldType.FieldLongFlags:
                                enumInfo.BaseType = EnumInfo.Type.Int;
                                enumInfo.Attributes.Add( new AttributeInfo( typeof ( FlagsAttribute ) ) );
                                break;
                            case MoonfishFieldType.FieldCharEnum:
                                enumInfo.BaseType = EnumInfo.Type.Byte;
                                break;
                            case MoonfishFieldType.FieldEnum:
                                enumInfo.BaseType = EnumInfo.Type.Short;
                                break;
                            case MoonfishFieldType.FieldLongEnum:
                                enumInfo.BaseType = EnumInfo.Type.Int;
                                break;
                        }
                        @class.EnumDefinitions.Add( enumInfo );
                        fieldInfo = new FieldInfo
                        {
                            Value = field.Name,
                            AccessModifiers = AccessModifiers.Internal,
                            FieldTypeName = ToTypeName( enumInfo.Value )
                        };

                        @class.Fields.Add( fieldInfo );
                        break;
                    }
                    case MoonfishFieldType.FieldByteBlockFlags:
                    case MoonfishFieldType.FieldWordBlockFlags:
                    case MoonfishFieldType.FieldLongBlockFlags:
                    case MoonfishFieldType.FieldCharBlockIndex1:
                    case MoonfishFieldType.FieldShortBlockIndex1:
                    case MoonfishFieldType.FieldLongBlockIndex1:
                    case MoonfishFieldType.FieldCharBlockIndex2:
                    case MoonfishFieldType.FieldShortBlockIndex2:
                    case MoonfishFieldType.FieldLongBlockIndex2:
                    {
                        fieldInfo = new FieldInfo
                        {
                            Value = field.Name,
                            AccessModifiers = AccessModifiers.Internal,
                            FieldTypeName = _valueTypeDictionary[ field.Type ].FullName
                        };
                        @class.Fields.Add( fieldInfo );
                        break;
                    }
                    case MoonfishFieldType.FieldArrayStart:
                    {
                        var startIndex = fields.IndexOf( field );
                        int endIndex = startIndex;
                        int depth = 0;
                        for ( int i = startIndex + 1; i < fields.Count; i++ )
                        {
                            if ( fields[ i ].Type == MoonfishFieldType.FieldArrayStart ) depth++;
                            if ( fields[ i ].Type == MoonfishFieldType.FieldArrayEnd )
                            {
                                if (depth == 0) { endIndex = i + 1; break; }
                                depth--;
                            }
                        }
                        var count = endIndex - startIndex;
                        if ( count < 1 ) throw new Exception( );

                        var arrayFieldSubSet = fields.GetRange( startIndex, count );
                        @class.ClassDefinitions.Add( ProcessArrayFields( arrayFieldSubSet ) );

                        fieldInfo = new FieldInfo
                        {
                            Value = field.Name,
                            AccessModifiers = AccessModifiers.Internal,
                            FieldTypeName = @class.ClassDefinitions.Last( ).Value,
                            ArraySize = field.Count,
                            IsArray = true
                        };

                        @class.Fields.Add( fieldInfo );
                        var remainingFields = fields.GetRange( endIndex, fields.Count - endIndex );
                        ProcessFields( remainingFields, @class );
                        return;
                    }
                    case MoonfishFieldType.FieldArrayEnd:
                    {
                        return;
                    }
                    case MoonfishFieldType.FieldPad:
                    {
                        fieldInfo = new FieldInfo
                        {
                            Value = field.Name,
                            AccessModifiers = AccessModifiers.Internal,
                            FieldTypeName = typeof ( Byte ).FullName,
                            ArraySize = field.Count,
                            IsArray = true
                        };
                        @class.Fields.Add( fieldInfo );
                        break;
                    }
                    case MoonfishFieldType.FieldSkip:
                    {
                        fieldInfo = new FieldInfo
                        {
                            Value = field.Name,
                            AccessModifiers = AccessModifiers.Internal,
                            FieldTypeName = typeof ( Byte ).FullName,
                            ArraySize = field.Count,
                            IsArray = true
                        };
                        @class.Fields.Add( fieldInfo );
                        break;
                    }
                    case MoonfishFieldType.FieldUselessPad:
                    case MoonfishFieldType.FieldTerminator:
                    case MoonfishFieldType.FieldCustom:
                    {
                        break;
                    }
                    default:
                    {
                        fieldInfo = new FieldInfo
                        {
                            Value = field.Name,
                            AccessModifiers = AccessModifiers.Internal,
                            FieldTypeName = _valueTypeDictionary[ field.Type ].AssemblyQualifiedName
                        };
                        @class.Fields.Add( fieldInfo );
                        break;
                    }
                }
            }
        }

        private static int ProcessLines( StreamWriter streamWriter, int tabCount, object item )
        {
            var subItems = item.ToString( ).Split( new[] {Environment.NewLine}, StringSplitOptions.None ).ToList( );
            subItems.ForEach( x => { streamWriter.WriteLine( x.ToString( ).Tab( ref tabCount ) ); } );
            return tabCount;
        }

        private delegate void ActionRef<T>( ref T item );
    }
}