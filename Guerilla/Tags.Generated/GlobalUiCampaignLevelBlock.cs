// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class GlobalUiCampaignLevelBlock : GlobalUiCampaignLevelBlockBase
    {
        public GlobalUiCampaignLevelBlock( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 2896, Alignment = 4 )]
    public class GlobalUiCampaignLevelBlockBase : IGuerilla
    {
        internal int campaignID;
        internal int mapID;
        [TagReference( "bitm" )] internal Moonfish.Tags.TagReference bitmap;
        internal byte[] invalidName_;
        internal byte[] invalidName_0;

        internal GlobalUiCampaignLevelBlockBase( BinaryReader binaryReader )
        {
            campaignID = binaryReader.ReadInt32( );
            mapID = binaryReader.ReadInt32( );
            bitmap = binaryReader.ReadTagReference( );
            invalidName_ = binaryReader.ReadBytes( 576 );
            invalidName_0 = binaryReader.ReadBytes( 2304 );
        }

        public int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                binaryWriter.Write( campaignID );
                binaryWriter.Write( mapID );
                binaryWriter.Write( bitmap );
                binaryWriter.Write( invalidName_, 0, 576 );
                binaryWriter.Write( invalidName_0, 0, 2304 );
                return nextAddress;
            }
        }
    };
}