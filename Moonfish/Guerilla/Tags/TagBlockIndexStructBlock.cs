namespace Moonfish.Guerilla.Tags
{
    partial class TagBlockIndexStructBlock
    {
        public TagBlockIndexStructBlock() { }

        public TagBlockIndexStructBlock( byte index, byte length )
        {
            BlockIndexData = ( short ) ( ( length << 9 ) & 0xFF00 | index & 0xFF );
        }

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