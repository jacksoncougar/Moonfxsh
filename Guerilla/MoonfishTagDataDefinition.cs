namespace Moonfish.Guerilla
{
    public class MoonfishTagDataDefinition
    {
        public string Name { get; private set; }
        public int Alignment { get; private set; }
        public int MaximumSize { get; private set; }
        public int DataElementSize { get; set; }

        private MoonfishTagDataDefinition( )
        {
            DataElementSize = 1;
        }

        public MoonfishTagDataDefinition( tag_data_definition definition )
            : this( )
        {
            Name = definition.Name;
            Alignment = definition.Alignment;
            MaximumSize = definition.maximumSize;
        }
    }
}