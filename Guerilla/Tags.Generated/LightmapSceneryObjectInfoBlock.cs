// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class LightmapSceneryObjectInfoBlock : LightmapSceneryObjectInfoBlockBase
    {
        public LightmapSceneryObjectInfoBlock( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 12, Alignment = 4 )]
    public class LightmapSceneryObjectInfoBlockBase : IGuerilla
    {
        internal int uniqueID;
        internal short originBSPIndex;
        internal byte type;
        internal byte source;
        internal int renderModelChecksum;

        internal LightmapSceneryObjectInfoBlockBase( BinaryReader binaryReader )
        {
            uniqueID = binaryReader.ReadInt32( );
            originBSPIndex = binaryReader.ReadInt16( );
            type = binaryReader.ReadByte( );
            source = binaryReader.ReadByte( );
            renderModelChecksum = binaryReader.ReadInt32( );
        }

        public int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                binaryWriter.Write( uniqueID );
                binaryWriter.Write( originBSPIndex );
                binaryWriter.Write( type );
                binaryWriter.Write( source );
                binaryWriter.Write( renderModelChecksum );
                return nextAddress;
            }
        }
    };
}