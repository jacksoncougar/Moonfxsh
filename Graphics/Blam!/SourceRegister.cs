using System.ComponentModel;

namespace Moonfish.Graphics
{
    /// <summary>
    ///     Controls mapping from registers into instructions
    /// </summary>
    public class SourceRegister
    {
        /// <summary>
        ///     Determines from what register to source data from
        /// </summary>
        public enum SourceType
        {
            /// <summary>
            ///     Temporary register
            ///     ( ie: r0, r1, .., r14 )
            /// </summary>
            Temporary = 1,

            /// <summary>
            ///     Vertex attribute register
            ///     ( ie: oPos, oD0, oTC0... )
            /// </summary>
            Attribute = 2,

            /// <summary>
            ///     Constant register
            ///     ( ie: c0, c1, ..., c96 )
            /// </summary>
            Constant = 3
        };

        public SourceRegister( int bits )
        {
            Type = ( SourceType ) ( ( bits >> 0 ) & 0x3 );
            TempID = ( byte ) ( ( bits >> 2 ) & 0xF );
            Swizzle = new SwizzleSuffix( ( byte ) ( ( bits >> 6 ) & 0xFF ) );
            Negate = ( ( bits >> 14 ) & 0x1 ) == 1;
        }

        /// <summary>
        /// Determines if source is negated
        /// </summary>
        public bool Negate { get; }

        /// <summary>
        /// Returns '-' if Negate property is true, else an empty string
        /// </summary>
        public string NegationPrefix => Negate ? "-" : "";

        /// <summary>
        /// Determines mapping of components from register used in source
        /// </summary>
        [TypeConverter( typeof ( ExpandableObjectConverter ) )]
        public SwizzleSuffix Swizzle { get; }
        public byte TempID { get; }
        public SourceType Type { get; }
    }
}