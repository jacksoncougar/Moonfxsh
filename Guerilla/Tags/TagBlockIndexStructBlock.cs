namespace Moonfish.Guerilla.Tags
{
    partial class TagBlockIndexStructBlock
    {
        public byte Length
        {
            get { return (byte) ((blockIndexData & 0xFF00) >> 9); }
        }

        public byte Index
        {
            get { return (byte) (blockIndexData & 0xFF); }
        }
    }
}