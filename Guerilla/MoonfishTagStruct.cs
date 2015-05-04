using Moonfish.Tags;

namespace Moonfish.Guerilla
{
    public class MoonfishTagStruct
    {
        public string Name { get; private set; }
        public TagClass Class { get; private set; }
        public MoonfishTagDefinition Definition { get; private set; }

        public MoonfishTagStruct(tag_struct_definition definition)
        {
            Name = definition.Name;
            Class = definition.Class;
            Definition = new MoonfishTagDefinition((TagBlockDefinition) definition.Definition);
        }
    }
}