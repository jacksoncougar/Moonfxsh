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
    public partial class UiLevelsDefinitionBlock : UiLevelsDefinitionBlockBase
    {
        public UiLevelsDefinitionBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 24, Alignment = 4)]
    public class UiLevelsDefinitionBlockBase : GuerillaBlock
    {
        internal UiCampaignBlock[] campaigns;
        internal GlobalUiCampaignLevelBlock[] campaignLevels;
        internal GlobalUiMultiplayerLevelBlock[] multiplayerLevels;

        public override int SerializedSize
        {
            get { return 24; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public UiLevelsDefinitionBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<UiCampaignBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<GlobalUiCampaignLevelBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<GlobalUiMultiplayerLevelBlock>(binaryReader));
            return blamPointers;
        }

        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            campaigns = ReadBlockArrayData<UiCampaignBlock>(binaryReader, blamPointers.Dequeue());
            campaignLevels = ReadBlockArrayData<GlobalUiCampaignLevelBlock>(binaryReader, blamPointers.Dequeue());
            multiplayerLevels = ReadBlockArrayData<GlobalUiMultiplayerLevelBlock>(binaryReader, blamPointers.Dequeue());
        }

        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
            using (binaryWriter.BaseStream.Pin())
            {
                nextAddress = Guerilla.WriteBlockArray<UiCampaignBlock>(binaryWriter, campaigns, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<GlobalUiCampaignLevelBlock>(binaryWriter, campaignLevels,
                    nextAddress);
                nextAddress = Guerilla.WriteBlockArray<GlobalUiMultiplayerLevelBlock>(binaryWriter, multiplayerLevels,
                    nextAddress);
                return nextAddress;
            }
        }
    };
}