namespace Moonfish
{
    public struct ResourcePointer
    {
        private readonly int _value;

        private ResourcePointer(int value)
        {
            _value = value;
        }

        public static implicit operator ResourcePointer(int value)
        {
            return new ResourcePointer(value);
        }

        public static implicit operator int(ResourcePointer pointer)
        {
            return pointer._value;
        }

        public Halo2.ResourceSource Source
        {
            get { return (Halo2.ResourceSource) ((_value & 0xC0000000) >> 30); }
        }

        public int Address
        {
            get { return (int) (_value & ~0xC0000000); }
        }
    }
}