namespace Moonfish
{
    /// <summary>
    /// An address to a raw resource stream.
    /// </summary>
    public struct ResourcePointer
    {
        private const uint Mask = 0xC0000000;
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

        public int Location => (int)((value & Mask) >> 30);

        public int Address => (int) (value & ~Mask);

        public override string ToString()
        {
            return value.ToString();
        }
    }
}