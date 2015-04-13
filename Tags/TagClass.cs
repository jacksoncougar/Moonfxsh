using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using Moonfish.Guerilla;

namespace Moonfish.Tags
{
    [GuerillaType( field_type._field_tag )]
    [StructLayout( LayoutKind.Sequential, Size = 4 )]
    public partial struct TagClass : IEquatable<TagClass>, IEquatable<string>
    {
        private readonly byte a;
        private readonly byte b;
        private readonly byte c;
        private readonly byte d;

        public TagClass( params byte[] bytes )
        {
            a = default( byte );
            b = default( byte );
            c = default( byte );
            d = default( byte );
            switch ( bytes.Length )
            {
                case 4:
                    d = bytes[ 3 ];
                    goto case 3;
                case 3:
                    c = bytes[ 2 ];
                    goto case 2;
                case 2:
                    b = bytes[ 1 ];
                    goto case 1;
                case 1:
                    a = bytes[ 0 ];
                    break;
                case 0: // Check if there are no bytes passed
                    break;
                default: // The defualt case is now byte.Length > 4 so goto case 4 and truncate
                    goto case 4;
            }
        }

        public TagClass( int value )
            : this( BitConverter.GetBytes( value ) )
        {
        }

        public static explicit operator TagClass( string str )
        {
            return new TagClass( Encoding.UTF8.GetBytes( new string( str.ToCharArray( ).Reverse( ).ToArray( ) ) ) );
        }

        public static explicit operator string( TagClass tagclass )
        {
            return tagclass.ToString( );
        }

        public static explicit operator TagClass( int integer )
        {
            return new TagClass( integer );
        }

        public static explicit operator int( TagClass type )
        {
            return BitConverter.ToInt32( new[] {type.a, type.b, type.c, type.d}, 0 );
        }

        public static bool operator ==( TagClass object1, TagClass object2 )
        {
            return ( int ) object1 == ( int ) object2;
        }

        public static bool operator !=( TagClass object1, TagClass object2 )
        {
            return ( int ) object1 != ( int ) object2;
        }

        public override bool Equals( object obj )
        {
            if ( !( obj is TagClass ) ) return false;
            return this == ( TagClass ) obj;
        }

        public override int GetHashCode( )
        {
            var i = ( int ) this;
            return i.GetHashCode( );
        }

        public override string ToString( )
        {
            if ( a == 0xFF && b == 0xFF && c == 0xFF && d == 0xFF ) return "null";
            return Encoding.UTF8.GetString( new [] {d, c, b, a} );
        }

        bool IEquatable<TagClass>.Equals( TagClass other )
        {
            return this == other;
        }

        bool IEquatable<string>.Equals( string other )
        {
            return this == ( TagClass ) other;
        }

        public string ToSafeString( )
        {
            var value = ToString( );
            var illegalChars = new List<char>( new[] {'<', '>', '!', '*', '#', '+', ' '} );
            illegalChars.ForEach( x => { value = value.Replace( x, '_' ); } );
            illegalChars = Path.GetInvalidFileNameChars( ).ToList( );
            illegalChars.ForEach( x => { value = value.Replace( x.ToString( ), string.Empty ); } );
            return value.Trim( );
        }

        public static readonly TagClass Null = new TagClass( 0xFF, 0xFF, 0xFF, 0xFF );
    }
}