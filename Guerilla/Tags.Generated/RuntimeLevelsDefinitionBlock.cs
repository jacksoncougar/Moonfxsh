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
    public partial class RuntimeLevelsDefinitionBlock : RuntimeLevelsDefinitionBlockBase
    {
        public RuntimeLevelsDefinitionBlock() : base()
        {
        }
    };
    [LayoutAttribute(Size = 8, Alignment = 4)]
    public class RuntimeLevelsDefinitionBlockBase : GuerillaBlock
    {
        internal RuntimeCampaignLevelBlock[] campaignLevels;
        public override int SerializedSize { get { return 8; } }
        public override int Alignment { get { return 4; } }
        public RuntimeLevelsDefinitionBlockBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<RuntimeCampaignLevelBlock>(binaryReader));
            return blamPointers;
        }
        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            campaignLevels = ReadBlockArrayData<RuntimeCampaignLevelBlock>(binaryReader, blamPointers.Dequeue());
        }
        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
using(binaryWriter.BaseStream.Pin())
            {
                nextAddress = Guerilla.WriteBlockArray<RuntimeCampaignLevelBlock>(binaryWriter, campaignLevels, nextAddress);
                return nextAddress;
            }
        }
    };
}
