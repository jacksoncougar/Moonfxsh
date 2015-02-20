using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class GlobalUiCampaignLevelBlock : GlobalUiCampaignLevelBlockBase
    {
        public  GlobalUiCampaignLevelBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 2896)]
    public class GlobalUiCampaignLevelBlockBase
    {
        internal int campaignID;
        internal int mapID;
        [TagReference("bitm")]
        internal Moonfish.Tags.TagReference bitmap;
        internal byte[] invalidName_;
        internal byte[] invalidName_0;
        internal  GlobalUiCampaignLevelBlockBase(BinaryReader binaryReader)
        {
            this.campaignID = binaryReader.ReadInt32();
            this.mapID = binaryReader.ReadInt32();
            this.bitmap = binaryReader.ReadTagReference();
            this.invalidName_ = binaryReader.ReadBytes(576);
            this.invalidName_0 = binaryReader.ReadBytes(2304);
        }
        internal  virtual byte[] ReadData(BinaryReader binaryReader)
        {
            var blamPointer = binaryReader.ReadBlamPointer(1);
            var data = new byte[blamPointer.Count];
            if(blamPointer.Count > 0)
            {
                using (binaryReader.BaseStream.Pin())
                {
                    binaryReader.BaseStream.Position = blamPointer[0];
                    data = binaryReader.ReadBytes(blamPointer.Count);
                }
            }
            return data;
        }
    };
}
