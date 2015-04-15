using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.CSharp;
using Moonfish.Tags;
using OpenTK.Audio;

namespace Moonfish.Guerilla
{

    public static class Test
    {
        public static MoonfishTagDefinition MakeNewDefinition( )
        {
            var fields = new List<MoonfishTagField>
            {
                new MoonfishTagField(MoonfishFieldType.FieldTagReference, "Sound")
            };
            MoonfishTagDefinition definition = new MoonfishTagDefinition("Sounds (Obsolete)", fields);
            return definition;
        }
    }

    public class MoonfishTagGroup
    {
        private string _name;
        private TagClass _tagClass;
        private TagClass _parentTagClass;
        private MoonfishTagDefinition _definition;

        public MoonfishTagGroup(GuerillaTagGroup guerillaTag)
        {
            _name = guerillaTag.Name;
            _tagClass = guerillaTag.Class;
            _parentTagClass = guerillaTag.ParentClass;
            _definition = new MoonfishTagDefinition(guerillaTag.Definition);
        }
    }

    public class MoonfishTagStruct
    {
        private string _name;
        private TagClass _tagClass;
        private MoonfishTagDefinition _definition;

        public MoonfishTagStruct( tag_struct_definition definition )
        {
            _name = definition.Name;
            _tagClass = definition.Class;
            _definition = new MoonfishTagDefinition( (TagBlockDefinition)definition.Definition );
        }
    }

    public class MoonfishTagDefinition
    {
        private string _name;
        private List<MoonfishTagField> _fields;
        private int _maximumElementCount;
        private string _displayName;

        private const int MaximumElementCount = short.MaxValue;

        private MoonfishTagDefinition()
        {
            _fields = new List<MoonfishTagField>( 0 );
            _maximumElementCount = MaximumElementCount;
        }

        public MoonfishTagDefinition( string displayName, List<MoonfishTagField> fieldList ) : this( )
        {
            _displayName = displayName;
            using ( var cSharpCode = new CSharpCodeProvider( ) )
            {
                var token = displayName;
                token = new string(token.ToCharArray().Where(char.IsLetterOrDigit).ToArray());
                token = cSharpCode.CreateValidIdentifier(token);
                _name = token;
            }
            _fields = fieldList;
        }

        public MoonfishTagDefinition( TagBlockDefinition definition )
        {
            _name = definition.Name;
            _displayName = definition.DisplayName;
            _maximumElementCount = definition.maximum_element_count;

            var definitionFields = definition.LatestFieldSet.Fields;
            _fields = new List<MoonfishTagField>( definitionFields.Count );
            foreach ( var field in definitionFields )
            {
                var moonfishField = new MoonfishTagField( ( MoonfishFieldType ) field.type, field.Name );

                if ( field.Definition is TagBlockDefinition )
                {
                    var fieldDefinition = ( TagBlockDefinition ) field.Definition;
                    moonfishField.AssignDefinition( new MoonfishTagDefinition( fieldDefinition ) );
                }
                if ( field.Definition is enum_definition )
                {
                    var fieldDefinition = ( enum_definition ) field.Definition;
                    moonfishField.AssignDefinition( new MoonfishTagEnumDefinition( fieldDefinition ) );
                }
                if ( field.Definition is tag_struct_definition )
                {
                    var fieldDefinition = ( tag_struct_definition ) field.Definition;
                    moonfishField.AssignDefinition( new MoonfishTagStruct( fieldDefinition ) );
                }
                if ( field.Definition is tag_data_definition )
                {
                    var fieldDefinition = ( tag_data_definition ) field.Definition;
                    moonfishField.AssignDefinition( new MoonfishTagDataDefinition( fieldDefinition ) );
                }

                _fields.Add( moonfishField );
            }
            _fields = new List<MoonfishTagField>( Guerilla.PostProcess( _name, _fields ) );

        }
    }

    public class MoonfishTagEnumDefinition
    {
        private List<string> _names;

        public MoonfishTagEnumDefinition( enum_definition definition )
        {
            _names = definition.Options;
        }
    }

    public class MoonfishTagDataDefinition
    {
        private string _name;
        private int _alignment;
        private int _maximumSize;

        public MoonfishTagDataDefinition( tag_data_definition definition )
        {
            _name = definition.Name;
            _alignment = definition.Alignment;
            _maximumSize = definition.maximumSize;
        }
    }

    public class MoonfishTagField
    {
        private MoonfishFieldType _type;
        private string _name;
        private object _definition;

        public void AssignDefinition(MoonfishTagEnumDefinition definition)
        {
            _definition = definition;
        }
        public void AssignDefinition(MoonfishTagDataDefinition definition)
        {
            _definition = definition;
        }
        public void AssignDefinition(MoonfishTagStruct definition)
        {
            _definition = definition;
        }
        public void AssignDefinition(MoonfishTagDefinition definition)
        {
            _definition = definition;
        }

        public MoonfishTagField(MoonfishFieldType fieldType, string fieldName)
        {
            _type = fieldType;
            _name = fieldName;
        }
    }



    public class GuerillaTagGroup : IReadDefinition
    {
        public int[] childGroupTags;
        public short childsCount;
        public int defaultTagPathAddress;
        public int definitionAddress;
        public int flags;
        public int groupTag;
        public byte initialized;
        public int nameAddress;
        public int parentGroupTag;
        public int postprocessForSyncProc;
        public int postprocessProc;
        public int savePostprocessProc;
        public short version;

        public GuerillaTagGroup(BinaryReader reader)
        {
            Read(reader);
        }

        public TagClass Class
        {
            get { return new TagClass(groupTag); }
        }

        public string DefaultPath { get; set; }
        public dynamic Definition { get; set; }
        public string Name { get; private set; }

        public TagClass ParentClass
        {
            get { return new TagClass(parentGroupTag); }
        }

        private void Read(BinaryReader reader)
        {
            var stream = reader.BaseStream;

            nameAddress = reader.ReadInt32();
            flags = reader.ReadInt32();
            groupTag = reader.ReadInt32();
            parentGroupTag = reader.ReadInt32();
            version = reader.ReadInt16();
            initialized = reader.ReadByte();

            stream.Seek(1, SeekOrigin.Current);

            postprocessProc = reader.ReadInt32();
            savePostprocessProc = reader.ReadInt32();
            postprocessForSyncProc = reader.ReadInt32();

            stream.Seek(4, SeekOrigin.Current);

            definitionAddress = reader.ReadInt32();
            childGroupTags = new int[16];
            for (var i = 0; i < 16; i++)
                childGroupTags[i] = reader.ReadInt32();
            childsCount = reader.ReadInt16();

            stream.Seek(2, SeekOrigin.Current);

            defaultTagPathAddress = reader.ReadInt32();


            Name = Guerilla.ReadString(reader, nameAddress);

            DefaultPath = Guerilla.ReadString(reader, defaultTagPathAddress);
            stream.Seek(definitionAddress, SeekOrigin.Begin);
            Definition = reader.ReadFieldDefinition<TagBlockDefinition>();
        }

        void IReadDefinition.Read(BinaryReader reader)
        {
            Read(reader);
        }
    }
}