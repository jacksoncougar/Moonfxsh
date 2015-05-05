using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Microsoft.CSharp;

namespace Moonfish.Guerilla
{
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
            Fields = new List<MoonfishTagField>(0);
            MaximumElementCount = DefaultMaximumElementCount;
        }

        public MoonfishTagDefinition(string displayName, IEnumerable<MoonfishTagField> fieldList)
            : this()
        {
            DisplayName = displayName;
            using (var cSharpCode = new CSharpCodeProvider())
            {
                var token = displayName;
                token = new string(token.ToCharArray().Where(char.IsLetterOrDigit).ToArray());
                token = cSharpCode.CreateValidIdentifier(token);
                Name = token;
            }
            Fields = new List<MoonfishTagField>(fieldList);
        }

        public MoonfishTagDefinition(TagBlockDefinition definition)
            : this()
        {
            Name = definition.Name;
            DisplayName = definition.DisplayName;
            MaximumElementCount = definition.maximum_element_count;
            Alignment = definition.LatestFieldSet.Alignment;

            var definitionFields = definition.LatestFieldSet.Fields;
            Fields = new List<MoonfishTagField>(definitionFields.Count);
            foreach (var field in definitionFields)
            {
                var moonfishField = new MoonfishTagField((MoonfishFieldType) field.type, field.Name);

                moonfishField.AssignCount(field.definition);

                if (field.Definition is TagBlockDefinition)
                {
                    var fieldDefinition = (TagBlockDefinition) field.Definition;
                    moonfishField.AssignDefinition(new MoonfishTagDefinition(fieldDefinition));
                }
                if (field.Definition is enum_definition)
                {
                    var fieldDefinition = (enum_definition) field.Definition;
                    moonfishField.AssignDefinition(new MoonfishTagEnumDefinition(fieldDefinition));
                }
                if (field.Definition is tag_struct_definition)
                {
                    var fieldDefinition = (tag_struct_definition) field.Definition;
                    moonfishField.AssignDefinition(new MoonfishTagStruct(fieldDefinition));
                }
                if (field.Definition is tag_data_definition)
                {
                    var fieldDefinition = (tag_data_definition) field.Definition;
                    moonfishField.AssignDefinition(new MoonfishTagDataDefinition(fieldDefinition));
                }
                if (field.Definition is tag_reference_definition)
                {
                    var fieldDefinition = (tag_reference_definition) field.Definition;
                    moonfishField.AssignDefinition(new MoonfishTagReferenceDefinition(fieldDefinition));
                }
                if (field.Definition is string)
                {
                    moonfishField.AssignDefinition((string)field.Definition);
                }

                Fields.Add(moonfishField);
            }
            Fields = new List<MoonfishTagField>(Guerilla.PostProcess(Name, Fields));
        }

        public int CalculateSizeOfFieldSet()
        {
            return CalculateSizeOfFieldSet(Fields);
        }

        public static int CalculateOffsetOfField(List<MoonfishTagField> fields, MoonfishTagField field)
        {
            var count = fields.IndexOf(field);
            return CalculateSizeOfFieldSet(fields.GetRange(0, count));
        }

        public static int CalculateSizeOfField(MoonfishTagField field)
        {
            switch (field.Type)
            {
                case MoonfishFieldType.FieldStruct:
                {
                    var struct_definition = (MoonfishTagStruct) field.Definition;
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

        public static int CalculateSizeOfFieldSet(IReadOnlyList<MoonfishTagField> fields)
        {
            var totalFieldSetSize = 0;
            for (var i = 0; i < fields.Count; ++i)
            {
                var field = fields[i];
                var fieldSize = CalculateSizeOfField(field);
                if (field.Type == MoonfishFieldType.FieldArrayStart)
                {
                    fieldSize = ProcessArrayField(fields, ref i);
                }
                totalFieldSetSize += fieldSize;
            }
            return totalFieldSetSize;
        }

        private static int ProcessArrayField(IReadOnlyList<MoonfishTagField> fields, ref int i)
        {
            var field = fields[i];
            var arrayCount = field.Count;
            var elementSize = 0;
            do
            {
                field = fields[++i];
                if (field.Type == MoonfishFieldType.FieldArrayStart)
                {
                    elementSize += ProcessArrayField(fields, ref i);
                }
                else elementSize += CalculateSizeOfField(field);
            } while (field.Type != MoonfishFieldType.FieldArrayEnd);
            return elementSize*arrayCount;
        }
    }
}