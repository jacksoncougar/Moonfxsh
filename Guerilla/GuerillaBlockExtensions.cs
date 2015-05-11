using System;

namespace Moonfish.Guerilla
{
    public static class GuerillaBlockExtensions
    {
        public static int GetElementSize(this GuerillaBlock[] guerillaBlocks)
        {
            return guerillaBlocks.Length > 0
                ? guerillaBlocks[0].SerializedSize
                : ((GuerillaBlock) (Activator.CreateInstance(
                guerillaBlocks.GetType().GetElementType()))).SerializedSize;
        }

        public static int GetAlignment(this GuerillaBlock[] guerillaBlocks)
        {
            return guerillaBlocks.Length > 0
                ? guerillaBlocks[0].Alignment
                : ((GuerillaBlock)(Activator.CreateInstance(
                guerillaBlocks.GetType().GetElementType()))).Alignment;
        }

        public static int CalculateSizeOfGraphData(this GuerillaBlock[] guerillaBlocks)
        {
            var size = 0;
            for (var i = 0; i < guerillaBlocks.Length; ++i)
            {
                size += guerillaBlocks[i].CalculateSizeOfGraphData();
            }
            return size;
        }
    }
}