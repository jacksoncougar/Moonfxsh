// ReSharper disable All
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
    [LayoutAttribute(Size = 2884, Alignment = 4)]
    public class UiCampaignBlockBase  : IGuerilla
    {
        internal int campaignID;
        internal byte[] invalidName_;
        internal byte[] invalidName_0;
        internal  UiCampaignBlockBase(BinaryReader binaryReader)
        {
            campaignID = binaryReader.ReadInt32();
            invalidName_ = binaryReader.ReadBytes(576);
            invalidName_0 = binaryReader.ReadBytes(2304);
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(campaignID);
                binaryWriter.Write(invalidName_, 0, 576);
                binaryWriter.Write(invalidName_0, 0, 2304);
                return nextAddress = (int)binaryWriter.BaseStream.Position;
            }
        }
    };
}
