namespace Moonfish
{
    /// <summary>
    /// An address to a raw resource stream.
    /// </summary>
    public struct ResourcePointer
    {
        private readonly int value;

        private ResourcePointer(int value)
        {
            this.value = value;
        }

        public static implicit operator ResourcePointer(int value)
        {
            return new ResourcePointer(value);
        }

        public static implicit operator int(ResourcePointer pointer)
        {
            return pointer.value;
        }

        public int Address
        {
            get { return (int) (value & ~0xC0000000); }
        }

        public override string ToString()
        {
            return value.ToString();
        }
    }
}