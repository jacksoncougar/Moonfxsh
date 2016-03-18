using System;
using System.Collections.Generic;
using System.IO;

namespace Moonfish.Graphics
{
    public static class VertexAttributeTypeExtensions
    {
        public static byte GetSize(this VertexAttributeType attributeType)
        {
            var value = (short) attributeType;
            var size = (byte) (value & 0x00FF);
            return size;
        }

        public static VertexAttributeType ReadVertexAttributeType(this BinaryReader binaryReader)
        {
            var msb = binaryReader.ReadByte();
            var lsb = binaryReader.ReadByte();
            var type = (VertexAttributeType) (msb << 8 | lsb);
            return type;
        }

        static Dictionary<VertexAttributeType, int> IdLookup =new Dictionary<VertexAttributeType, int>();

        static VertexAttributeTypeExtensions( )
        {
            var values = Enum.GetValues( typeof ( VertexAttributeType ) );
            int index = 1;
            foreach ( var value in values )
            {
                if ( !IdLookup.ContainsKey( ( VertexAttributeType ) value ) )
                {
                    IdLookup.Add( ( VertexAttributeType ) value, index <<= 1 );
                }
            }
        }

        public static int GetVertexAttributesId(this VertexAttributeType[] attributes )
        {
            var id = 0;
            foreach ( var vertexAttributeType in attributes )
            {
                id |= IdLookup.ContainsKey( vertexAttributeType ) ? IdLookup[ vertexAttributeType ] : 0;
            }
            return id;
        }
    }
    
    public enum VertexAttributeType : short
    {
        None = 0x0000,
        CoordinateFloat = 0x010C,
        CoordinateCompressed = 0x0206,
        CoordinateWithSingleNode = 0x0408,
        CoordinateWithDoubleNode = 0x060C,
        CoordinateWithTripleNode = 0x080C,

        TextureCoordinateFloatPc = 0x1708,
        TextureCoordinateFloat = 0x1808,
        TextureCoordinateCompressed = 0x1904,

        TangentSpaceUnitVectorsFloat = 0x1924,
        TangentSpaceUnitVectorsCompressed = 0x1B0C,

        LightmapUvCoordinateOne = 0x1F08,
        LightmapUVCoordinateOneXbox = 0x1F04,
        LightmapUvCoordinateTwo = 0x3008,
        LightmapUVCoordinateTwoXbox = 0x3004,

        DiffuseColour = 0x350C,

        UnpackedWorldCoordinateData = 0x2120,
        UnpackedTextureCoordinateData = 0x2208,
        UnpackedLightingData = 0x2324,
    }
}