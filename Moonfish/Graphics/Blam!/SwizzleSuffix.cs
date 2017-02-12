namespace Moonfish.Graphics
{
    /// <summary>
    /// Instructions use either scalar source values or swizzled source
    /// values, indicated in the grammar.
    /// </summary>
    public struct SwizzleSuffix
    {
        /// <summary>
        /// Returns the swizzle-mask as a suffix
        /// </summary>
        /// <param name="withPeriod">adds a period before the channel masks</param>
        /// <param name="forceAllChannels">disables channel duplicate truncating</param>
        /// <returns>returns a suffix string, 
        /// or an empty string if foceAllChannels == false and the swizzle mask is "xyzw"</returns>
        public string GetSuffix( bool withPeriod = true, bool forceAllChannels = false )
        {
            var str = ToString( forceAllChannels );
            return str == string.Empty ? string.Empty : withPeriod ? "." + str : str;
        }

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

        private string ToString( bool forceAllChannels )
        {
            var swizzle = $@"{XSwizzle}{YSwizzle}{ZSwizzle}{WSwizzle}".ToLower( );

            //  1. return the entire suffix if requested
            if ( forceAllChannels ) return swizzle;
            
            //  2. else condense the suffix by removing redundant assignments

            //  if all channels are default, just ignore the swizzle mask.
            if (swizzle == "xyzw") return string.Empty;

            //  truncate duplicate channels assignments from the back of the suffix
            //  #redundant optimization probably: check if each pair of channels is equal using xor
            var XOR2and3 = swizzle[2] ^ swizzle[3];
            var XOR1and2 = swizzle[1] ^ swizzle[2];
            var XOR0and1 = swizzle[0] ^ swizzle[1];

            //  all four channels are equal
            if (XOR0and1 + XOR1and2 + XOR2and3 == 0)
                return swizzle[0].ToString();
            //  the last three channels equal
            if (XOR1and2 + XOR2and3 == 0)
                return swizzle.Substring(0, 2);
            //  the last two or equal, else, return the entire mask
            return XOR2and3 == 0 ? swizzle.Substring(0, 3) : swizzle;
        }

        public override string ToString( )
        {
            return ToString(true);
        }
    };
}