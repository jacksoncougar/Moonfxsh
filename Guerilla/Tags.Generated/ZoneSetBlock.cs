// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class ZoneSetBlock : ZoneSetBlockBase
    {
        public ZoneSetBlock( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 8, Alignment = 4 )]
    public class ZoneSetBlockBase : IGuerilla
    {
        internal AreaType areaType;
        internal byte[] invalidName_;
        internal Moonfish.Tags.ShortBlockIndex1 zone;
        internal Moonfish.Tags.ShortBlockIndex2 area;

        internal ZoneSetBlockBase( BinaryReader binaryReader )
        {
            areaType = ( AreaType ) binaryReader.ReadInt16( );
            invalidName_ = binaryReader.ReadBytes( 2 );
            zone = binaryReader.ReadShortBlockIndex1( );
            area = binaryReader.ReadShortBlockIndex2( );
        }

        public int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                binaryWriter.Write( ( Int16 ) areaType );
                binaryWriter.Write( invalidName_, 0, 2 );
                binaryWriter.Write( zone );
                binaryWriter.Write( area );
                return nextAddress;
            }
        }

        internal enum AreaType : short
        {
            Deault = 0,
            Search = 1,
            Goal = 2,
        };
    };
}