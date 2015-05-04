using Moonfish.Tags;

namespace Moonfish.Guerilla
{
    public class MoonfishTagReferenceDefinition
    {
        public TagClass Class { get; private set; }

        public MoonfishTagReferenceDefinition(tag_reference_definition definition)
        {
            Class = definition.Class;
        }

        public MoonfishTagReferenceDefinition(TagClass tagClass)
        {
            Class = tagClass;
        }
    }
}