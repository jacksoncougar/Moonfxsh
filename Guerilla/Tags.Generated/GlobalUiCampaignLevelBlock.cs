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
        public  GlobalUiCampaignLevelBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  GlobalUiCampaignLevelBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 2896, Alignment = 4)]
    public class GlobalUiCampaignLevelBlockBase : GuerillaBlock
    {
        internal int campaignID;
        internal int mapID;
        [TagReference("bitm")]
        internal Moonfish.Tags.TagReference bitmap;
        internal byte[] invalidName_;
        internal byte[] invalidName_0;
        
        public override int SerializedSize{get { return 2896; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  GlobalUiCampaignLevelBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            campaignID = binaryReader.ReadInt32();
            mapID = binaryReader.ReadInt32();
            bitmap = binaryReader.ReadTagReference();
            invalidName_ = binaryReader.ReadBytes(576);
            invalidName_0 = binaryReader.ReadBytes(2304);
        }
        public  GlobalUiCampaignLevelBlockBase(): base()
        {
            
        }
        public override void Read(BinaryReader binaryReader)
        {
            campaignID = binaryReader.ReadInt32();
            mapID = binaryReader.ReadInt32();
            bitmap = binaryReader.ReadTagReference();
            invalidName_ = binaryReader.ReadBytes(576);
            invalidName_0 = binaryReader.ReadBytes(2304);
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(campaignID);
                binaryWriter.Write(mapID);
                binaryWriter.Write(bitmap);
                binaryWriter.Write(invalidName_, 0, 576);
                binaryWriter.Write(invalidName_0, 0, 2304);
                return nextAddress;
            }
        }
    };
}
