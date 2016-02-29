namespace Moonfish.Graphics
{
    /// <summary>
    /// Instructions use either scalar source values or swizzled source
    /// values, indicated in the grammar.
    /// </summary>
    public struct SwizzleSuffix
    {
        public enum Channel : byte
        {
            X = 0,
            Y = 1,
            Z = 2,
            W = 3
        }

        /// <summary>
        /// The first component 
        /// </summary>
        public Channel XSwizzle { get; }
        /// <summary>
        /// The second component
        /// </summary>
        public Channel YSwizzle { get; }
        /// <summary>
        /// The third component
        /// </summary>
        public Channel ZSwizzle { get; }
        /// <summary>
        /// The last component
        /// </summary>
        public Channel WSwizzle { get; }

        public SwizzleSuffix( byte data )
        {
            // Addressing:
            // 0 : xxyyzzww : 8

            const int channelMask = 0x3;
            XSwizzle = ( Channel ) ( ( data >> 6 ) & channelMask );
            YSwizzle = ( Channel ) ( ( data >> 4 ) & channelMask );
            ZSwizzle = ( Channel ) ( ( data >> 2 ) & channelMask );
            WSwizzle = ( Channel ) ( ( data >> 0 ) & channelMask );
        }
    };
}