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
        public  UiCampaignBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 2884)]
    public class UiCampaignBlockBase
    {
        internal int campaignID;
        internal byte[] invalidName_;
        internal byte[] invalidName_0;
        internal  UiCampaignBlockBase(System.IO.BinaryReader binaryReader)
        {
            campaignID = binaryReader.ReadInt32();
            invalidName_ = binaryReader.ReadBytes(576);
            invalidName_0 = binaryReader.ReadBytes(2304);
        }
        internal  virtual byte[] ReadData(System.IO.BinaryReader binaryReader)
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
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(campaignID);
                binaryWriter.Write(invalidName_, 0, 576);
                binaryWriter.Write(invalidName_0, 0, 2304);
            }
        }
    };
}
