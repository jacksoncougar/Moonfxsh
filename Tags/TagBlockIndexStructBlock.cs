namespace Moonfish.Guerilla.Tags
{
    partial class TagBlockIndexStructBlock
    {
        public byte Length
        {
            get { return ( byte ) ( this.length >> 1 ); }
        }

        public byte Index
        {
            get { return this.index; }
        }
    }
}