using Moonfish.Guerilla.Tags;

namespace Moonfish.Graphics
{
    internal struct BitmapMapping
    {
        public readonly byte SourceIndex;
        public readonly byte DesinationIndex;

        public BitmapMapping(byte sourceIndex, byte destinationIndex )
        {
            SourceIndex = sourceIndex;
            DesinationIndex = destinationIndex;
        }

        public BitmapMapping( ShaderTemplatePostprocessRemappingNewBlock remappingBlock )
        {
            SourceIndex = remappingBlock.SourceIndex;
            DesinationIndex = remappingBlock.DestinationIndex;
        }

        public static implicit operator ShaderTemplatePostprocessRemappingNewBlock( BitmapMapping mapping )
        {
            return new ShaderTemplatePostprocessRemappingNewBlock( )
            {
                DestinationIndex = mapping.DesinationIndex,
                SourceIndex = mapping.SourceIndex
            };
        }
    }
}