// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Moonfish.Guerilla.Tags
{
    public partial class RuntimeCampaignLevelBlock : RuntimeCampaignLevelBlockBase
    {
        public RuntimeCampaignLevelBlock() : base()
        {
        }
    };
    [LayoutAttribute(Size = 264, Alignment = 4)]
    public class RuntimeCampaignLevelBlockBase : GuerillaBlock
    {
        internal int campaignID;
        internal int mapID;
        internal Moonfish.Tags.String256 path;
        public override int SerializedSize { get { return 264; } }
        public override int Alignment { get { return 4; } }
        public RuntimeCampaignLevelBlockBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            campaignID = binaryReader.ReadInt32();
            mapID = binaryReader.ReadInt32();
            path = binaryReader.ReadString256();
            return blamPointers;
        }
        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
        }
        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(campaignID);
                binaryWriter.Write(mapID);
                binaryWriter.Write(path);
                return nextAddress;
            }
        }
    };
}
