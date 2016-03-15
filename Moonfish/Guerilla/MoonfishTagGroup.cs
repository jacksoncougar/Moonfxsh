using Moonfish.Tags;

namespace Moonfish.Guerilla
{
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
}