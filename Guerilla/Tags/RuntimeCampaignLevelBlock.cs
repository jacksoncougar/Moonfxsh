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
        public  RuntimeCampaignLevelBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 264, Alignment = 4)]
    public class RuntimeCampaignLevelBlockBase  : IGuerilla
    {
        internal int campaignID;
        internal int mapID;
        internal Moonfish.Tags.String256 path;
        internal  RuntimeCampaignLevelBlockBase(BinaryReader binaryReader)
        {
            campaignID = binaryReader.ReadInt32();
            mapID = binaryReader.ReadInt32();
            path = binaryReader.ReadString256();
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(campaignID);
                binaryWriter.Write(mapID);
                binaryWriter.Write(path);
                return nextAddress = (int)binaryWriter.BaseStream.Position;
            }
        }
    };
}
