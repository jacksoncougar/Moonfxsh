namespace Moonfish.Guerilla.Tags
{
    partial class StructureBspClusterBlock : IResourceBlock
    {
        public ResourcePointer GetResourcePointer(int index = 0)
        {
            return GeometryBlockInfo.BlockOffset;
        }

        public int GetResourceLength(int index = 0)
        {
            return GeometryBlockInfo.BlockSize;
        }

        public void SetResourcePointer(ResourcePointer pointer, int index = 0)
        {
            GeometryBlockInfo.BlockOffset = pointer;
        }

        public void SetResourceLength(int length, int index = 0)
        {
            GeometryBlockInfo.BlockSize = length;
        }

        public void LoadSectionData()
        {
            ClusterData = new[] {new StructureBspClusterDataBlockNew {Section = GeometryBlockInfo.LoadSectionData()}};
        }
    }
}