using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using Moonfish.Graphics;

namespace Moonfish.Debug
{
    public class DataTypes
    {
        public int shift;
        public int mask;
        public byte[] data = new byte[0];

        [DisplayName( @"int8" )]
        public sbyte? Int8
        {
            get { return data.Length >= sizeof ( sbyte ) ? ( sbyte? ) data[ 0 ] : null; }
            set
            {
                if ( data.Length >= sizeof ( sbyte ) && value.HasValue )
                    data[ 0 ] = ( byte ) value.Value;
            }
        }

        [DisplayName( @"uint8" )]
        public byte? UInt8
        {
            get { return data.Length >= sizeof ( byte ) ? data[ 0 ] : ( byte? ) null; }
            set
            {
                if ( data.Length >= sizeof ( byte ) && value.HasValue )
                    data[ 0 ] = value.Value;
            }
        }

        [DisplayName( @"int16" )]
        public short? Int16
        {
            get { return data.Length >= sizeof ( short ) ? BitConverter.ToInt16( data, 0 ) : ( short? ) null; }
        }

        [DisplayName( @"uint16" )]
        public ushort? UInt16
        {
            get { return data.Length >= sizeof ( ushort ) ? BitConverter.ToUInt16( data, 0 ) : ( ushort? ) null; }
        }

        [DisplayName( @"int32" )]
        public int? Int32
        {
            get { return data.Length >= sizeof ( int ) ? BitConverter.ToInt32( data, 0 ) : ( int? ) null; }
        }

        [DisplayName( @"uint32" )]
        public uint? UInt32
        {
            get { return data.Length >= sizeof ( uint ) ? BitConverter.ToUInt32( data, 0 ) : ( uint? ) null; }
        }

        [DisplayName( @"float" )]
        public float? Float
        {
            get { return data.Length >= sizeof ( float ) ? BitConverter.ToSingle( data, 0 ) : ( float? ) null; }
        }

        [DisplayName( @"double" )]
        public double? Double
        {
            get { return data.Length >= sizeof ( double ) ? BitConverter.ToDouble( data, 0 ) : ( double? ) null; }
        }


        [DisplayName( @"int : bitmask & shift" )]
        public int? Bitmasked
        {
            get
            {
                return data.Length >= sizeof ( int ) ? ( BitConverter.ToInt32( data, 0 ) >> shift ) & mask : ( int? ) null;
            }
        }

        [TypeConverter(typeof(ExpandableObjectConverter))]
        [DisplayName(@"NV Vertex Shader")]
        public VertexProgramInstruction BinaryBitmasked
        {
            get
            {
                return data.Length >= sizeof ( int ) * 4
                    ? new VertexProgramInstruction( data )
                    : null;
            }
        }

        [DisplayName( @"binary" )]
        public string Binary
        {
            get
            {
                var bitArray = new BitArray( data );
                return bitArray.ToString( );
            }
        }
    }
}