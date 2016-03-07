using System.Runtime.InteropServices;
using Moonfish.Guerilla;

namespace Moonfish.Tags
{
    [GuerillaType( MoonfishFieldType.FieldStringId )]
    [GuerillaType( MoonfishFieldType.FieldOldStringId )]
    [StructLayout( LayoutKind.Explicit, Size = 4 )]
    public struct StringIdent
    {
        private bool Equals( StringIdent other )
        {
            return Length == other.Length && Index == other.Index;
        }

        public override bool Equals( object obj )
        {
            if ( ReferenceEquals( null, obj ) ) return false;
            return obj is StringIdent && Equals( ( StringIdent ) obj );
        }

        public override int GetHashCode( )
        {
            return (int)this;
        }

        [FieldOffset( 0 )] public readonly sbyte Length;
        [FieldOffset( 2 )] public readonly short Index;

        public StringIdent( int interleavedValue )
        {
            Length = ( sbyte ) ( interleavedValue >> 24 );
            Index = ( short ) ( interleavedValue & 0x0000FFFF );
        }

        public StringIdent( short index, sbyte length )
        {
            Index = index;
            Length = length;
        }

        public static explicit operator int( StringIdent stringIdent )
        {
            return ( stringIdent.Length << 24 ) | byte.MinValue | ( ushort ) stringIdent.Index;
        }

        public static explicit operator StringIdent( int i )
        {
            return new StringIdent( i );
        }

        public static bool operator ==( StringIdent first, StringIdent second )
        {
            return first.Index == second.Index && first.Length == second.Length;
        }

        public static bool operator !=( StringIdent first, StringIdent second )
        {
            return !( first == second );
        }

        public static StringIdent Zero => new StringIdent( 0, 0 );

        public override string ToString( )
        {
            var value = Halo2.Strings[ this ];
            return value;
        }
    }
}