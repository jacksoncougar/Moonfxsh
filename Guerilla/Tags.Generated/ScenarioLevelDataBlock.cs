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
    public partial class ScenarioLevelDataBlock : ScenarioLevelDataBlockBase
    {
        public ScenarioLevelDataBlock() : base()
        {
        }
    };
    [LayoutAttribute(Size = 24, Alignment = 4)]
    public class ScenarioLevelDataBlockBase : GuerillaBlock
    {
        [TagReference("unic")]
        internal Moonfish.Tags.TagReference levelDescription;
        internal GlobalUiCampaignLevelBlock[] campaignLevelData;
        internal GlobalUiMultiplayerLevelBlock[] multiplayer;
        public override int SerializedSize { get { return 24; } }
        public override int Alignment { get { return 4; } }
        public ScenarioLevelDataBlockBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            levelDescription = binaryReader.ReadTagReference();
            blamPointers.Enqueue(ReadBlockArrayPointer<GlobalUiCampaignLevelBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<GlobalUiMultiplayerLevelBlock>(binaryReader));
            return blamPointers;
        }
        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            campaignLevelData = ReadBlockArrayData<GlobalUiCampaignLevelBlock>(binaryReader, blamPointers.Dequeue());
            multiplayer = ReadBlockArrayData<GlobalUiMultiplayerLevelBlock>(binaryReader, blamPointers.Dequeue());
        }
        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(levelDescription);
                nextAddress = Guerilla.WriteBlockArray<GlobalUiCampaignLevelBlock>(binaryWriter, campaignLevelData, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<GlobalUiMultiplayerLevelBlock>(binaryWriter, multiplayer, nextAddress);
                return nextAddress;
            }
        }
    };
}
