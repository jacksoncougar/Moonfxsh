using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.CSharp;
using Moonfish.Tags;
using OpenTK.Audio;
using OpenTK.Graphics;

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
        public string Name { get; private set; }
        public TagClass Class { get; private set; }
        public TagClass ParentClass { get; private set; }
        public MoonfishTagDefinition Definition { get; private set; }

        public MoonfishTagGroup(GuerillaTagGroup guerillaTag)
        {
            Name = guerillaTag.Name;
            Class = guerillaTag.Class;
            ParentClass = guerillaTag.ParentClass;
            Definition = new MoonfishTagDefinition(guerillaTag.Definition);
        }
    }

    public class MoonfishTagStruct
    {
        public string Name { get; private set; }
        public TagClass Class { get; private set; }
        public MoonfishTagDefinition Definition { get; private set; }

        public MoonfishTagStruct( tag_struct_definition definition )
        {
            Name = definition.Name;
            Class = definition.Class;
            Definition = new MoonfishTagDefinition( (TagBlockDefinition)definition.Definition );
        }
    }

    public class MoonfishTagDefinition
    {
        public string Name { get; private set; }
        public int Alignment { get; private set; }
        public List<MoonfishTagField> Fields { get; private set; }
        public int MaximumElementCount { get; private set; }
        public string DisplayName { get; private set; }

        private const int DefaultMaximumElementCount = short.MaxValue;

        private MoonfishTagDefinition()
        {
            Alignment = 4;
            Fields = new List<MoonfishTagField>( 0 );
            MaximumElementCount = DefaultMaximumElementCount;
        }

        public MoonfishTagDefinition( string displayName, List<MoonfishTagField> fieldList ) 
            : this( )
        {
            DisplayName = displayName;
            using ( var cSharpCode = new CSharpCodeProvider( ) )
            {
                var token = displayName;
                token = new string(token.ToCharArray().Where(char.IsLetterOrDigit).ToArray());
                token = cSharpCode.CreateValidIdentifier(token);
                Name = token;
            }
            Fields = fieldList;
        }

        public MoonfishTagDefinition( TagBlockDefinition definition ) 
            : this()
        {
            Name = definition.Name;
            DisplayName = definition.DisplayName;
            MaximumElementCount = definition.maximum_element_count;
            Alignment = definition.LatestFieldSet.Alignment;

            var definitionFields = definition.LatestFieldSet.Fields;
            Fields = new List<MoonfishTagField>( definitionFields.Count );
            foreach ( var field in definitionFields )
            {
                var moonfishField = new MoonfishTagField( ( MoonfishFieldType ) field.type, field.Name );

                moonfishField.AssignCount( field.definition );

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
                if ( field.Definition is tag_reference_definition )
                {
                    var fieldDefinition = ( tag_reference_definition ) field.Definition;
                    moonfishField.AssignDefinition( new MoonfishTagReferenceDefinition( fieldDefinition ) );
                }

                Fields.Add( moonfishField );
            }
            Fields = new List<MoonfishTagField>( Guerilla.PostProcess( Name, Fields ) );

        }

        public int CalculateSizeOfFieldSet()
        {
           return CalculateSizeOfFieldSet(Fields);
        }

        private static int CalculateSizeOfField(MoonfishTagField field)
        {
            switch (field.Type)
            {
                case MoonfishFieldType.FieldStruct:
                    {
                        var struct_definition = (MoonfishTagStruct)field.Definition;
                        var blockDefinition = struct_definition.Definition;

                        return CalculateSizeOfFieldSet(blockDefinition.Fields);
                    }
                case MoonfishFieldType.FieldSkip:
                case MoonfishFieldType.FieldPad:
                    return field.Count;
                default:
                    return field.Type.GetFieldSize();
            }
        }

        private static int CalculateSizeOfFieldSet( IReadOnlyList<MoonfishTagField> fields )
        {
            var totalFieldSetSize = 0;
            for (var i = 0; i < fields.Count; ++i)
            {
                var field = fields[i];
                var fieldSize = CalculateSizeOfField(field);
                if (field.Type == MoonfishFieldType.FieldArrayStart)
                {
                    var arrayCount = field.Count;
                    var elementSize = 0;
                    do
                    {
                        field = fields[++i];
                        elementSize += CalculateSizeOfField(field);
                    } while (field.Type != MoonfishFieldType.FieldArrayEnd);
                    fieldSize += elementSize * arrayCount;
                }
                totalFieldSetSize += fieldSize;
            }
            return totalFieldSetSize;
        }
    }

    public class MoonfishTagEnumDefinition
    {
        public List<string> Names { get; private set; }

        public MoonfishTagEnumDefinition( enum_definition definition )
        {
            Names = definition.Options;
        }
    }

    public class MoonfishTagReferenceDefinition
    {
        public TagClass Class { get; private set; }

        public MoonfishTagReferenceDefinition(tag_reference_definition definition)
        {
            Class = definition.Class;
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
        public MoonfishFieldType Type { get; private set; }
        public string Name { get; private set; }
        public dynamic Definition { get; private set; }

        public int Count { get; private set; }

        public void AssignCount( int count )
        {
            Count = count;
        }

        public void AssignDefinition(MoonfishTagEnumDefinition definition)
        {
            Definition = definition;
        }
        public void AssignDefinition(MoonfishTagDataDefinition definition)
        {
            Definition = definition;
        }
        public void AssignDefinition(MoonfishTagStruct definition)
        {
            Definition = definition;
        }
        public void AssignDefinition(MoonfishTagDefinition definition)
        {
            Definition = definition;
        }

        public void AssignDefinition(MoonfishTagReferenceDefinition definition)
        {
            Definition = definition;
        }

        public MoonfishTagField(MoonfishFieldType fieldType, string fieldName)
        {
            Type = fieldType;
            Name = fieldName;
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