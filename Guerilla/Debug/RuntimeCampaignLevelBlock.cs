// ReSharper disable All
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
        public  RuntimeCampaignLevelBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 264)]
    public class RuntimeCampaignLevelBlockBase
    {
        internal int campaignID;
        internal int mapID;
        internal Moonfish.Tags.String256 path;
        internal  RuntimeCampaignLevelBlockBase(System.IO.BinaryReader binaryReader)
        {
            campaignID = binaryReader.ReadInt32();
            mapID = binaryReader.ReadInt32();
            path = binaryReader.ReadString256();
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
                binaryWriter.Write(path);
            }
        }
    };
}
