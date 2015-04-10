using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class UiCampaignBlock : UiCampaignBlockBase
    {
        public  UiCampaignBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 2884)]
    public class UiCampaignBlockBase
    {
        internal int campaignID;
        internal byte[] invalidName_;
        internal byte[] invalidName_0;
        internal  UiCampaignBlockBase(BinaryReader binaryReader)
        {
            this.campaignID = binaryReader.ReadInt32();
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
