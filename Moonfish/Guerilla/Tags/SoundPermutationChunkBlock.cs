using JetBrains.Annotations;

namespace Moonfish.Guerilla.Tags
{
    [UsedImplicitly]
    public partial class SoundPermutationChunkBlock : IResourceBlock
    {
        public ResourcePointer GetResourcePointer(int index = 0)
        {
            return FileOffset;
        }

        public int GetResourceLength(int index = 0)
        {
            return FieldLongInteger & 0x7FFFFFF;
        }

        public void SetResourcePointer(ResourcePointer pointer, int index = 0)
        {
            FileOffset = pointer; 
        }

        public void SetResourceLength(int length, int index = 0)
        {
            FieldLongInteger = (int)(FieldLongInteger & 0x80000000) | (length & 0x7FFFFFFF);
        }
    }
}
