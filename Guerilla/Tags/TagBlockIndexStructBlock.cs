namespace Moonfish.Guerilla.Tags
{
    partial class TagBlockIndexStructBlock
    {
        public byte Length
        {
            get { return (byte) ((BlockIndexData & 0xFF00) >> 9); }
        }

        public byte Index
        {
            get { return (byte) (BlockIndexData & 0xFF); }
        }
    }
}