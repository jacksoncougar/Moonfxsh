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
            DesinationIndex = remappingBlock.fieldskip[ 0 ];
        }

        public static implicit operator ShaderTemplatePostprocessRemappingNewBlock( BitmapMapping mapping )
        {
            return new ShaderTemplatePostprocessRemappingNewBlock( )
            {
                fieldskip = new byte[] {mapping.DesinationIndex, 0, 0},
                SourceIndex = mapping.SourceIndex
            };
        }
    }
}