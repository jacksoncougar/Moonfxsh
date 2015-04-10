// ReSharper disable All
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
        public  GlobalUiCampaignLevelBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
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
        internal  GlobalUiCampaignLevelBlockBase(System.IO.BinaryReader binaryReader)
        {
            campaignID = binaryReader.ReadInt32();
            mapID = binaryReader.ReadInt32();
            bitmap = binaryReader.ReadTagReference();
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
                binaryWriter.Write(mapID);
                binaryWriter.Write(bitmap);
                binaryWriter.Write(invalidName_, 0, 576);
                binaryWriter.Write(invalidName_0, 0, 2304);
            }
        }
    };
}
