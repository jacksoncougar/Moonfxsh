namespace Moonfish.Graphics
{
    public static class BitExtensions
    {
        public static int GetBit(this int word, int index )
        {
            return word & ( 1 << index ) >> index;
        }

        public static int GetBits(this uint dword, int mask, int shift)
        {
            return (int)((dword & mask) >> shift);
        }

        /// <summary>
        ///     Returns a value that is split between int boundaries
        /// </summary>
        /// <param name="dword0">The lower addressed int</param>
        /// <param name="dword1">The higher addressed int</param>
        /// <param name="msbMask">Mask for bits in dword0 (Mask should be pre-shifted because it is applied first)</param>
        /// <param name="msbShift">Number of bits to right-shift msbs</param>
        /// <param name="lsbMask">Mask for bits in dword1 (Mask should be pre=shifted because it is applied first)</param>
        /// <param name="lsbShift">Number of bits to right-shift lsbs</param>
        /// <param name="lsbLength">Number of lsbs</param>
        /// <returns></returns>
        public static int GetSplitBits(uint dword0, uint dword1, int msbMask, int msbShift, int lsbMask, int lsbShift,
            int lsbLength)
        {
            //DWORD0..DWORD1
            //...MSB..LSB...
            var MsbBits = (dword0 & msbMask) >> msbShift;
            var LsbBits = (dword1 & lsbMask) >> lsbShift;
            var Bits = (int)(MsbBits << lsbLength | LsbBits);
            return Bits;
        }
    };
}