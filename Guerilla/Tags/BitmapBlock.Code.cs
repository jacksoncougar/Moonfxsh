namespace Moonfish.Guerilla.Tags
{
    partial class BitmapBlock : IResourceBlock
    {
        void IResourceBlock.LoadRawResources()
        {
            foreach (var bitmapDataBlock in Bitmaps)
            {
                bitmapDataBlock.LoadRawResources();
            }
        }


        byte[] IResourceBlock.GetRawResourceBytes()
        {
            foreach (var bitmapDataBlock in Bitmaps)
            {
                bitmapDataBlock.LoadRawResources();
            }
            return null;
        }
    }
}