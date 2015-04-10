using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class RuntimeCampaignLevelBlock : RuntimeCampaignLevelBlockBase
    {
        public  RuntimeCampaignLevelBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 264)]
    public class RuntimeCampaignLevelBlockBase
    {
        internal int campaignID;
        internal int mapID;
        internal Moonfish.Tags.String256 path;
        internal  RuntimeCampaignLevelBlockBase(BinaryReader binaryReader)
        {
            this.campaignID = binaryReader.ReadInt32();
            this.mapID = binaryReader.ReadInt32();
            this.path = binaryReader.ReadString256();
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
