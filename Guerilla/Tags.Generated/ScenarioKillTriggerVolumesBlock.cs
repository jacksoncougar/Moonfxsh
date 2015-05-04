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
    public partial class ScenarioKillTriggerVolumesBlock : ScenarioKillTriggerVolumesBlockBase
    {
        public ScenarioKillTriggerVolumesBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 2, Alignment = 4)]
    public class ScenarioKillTriggerVolumesBlockBase : GuerillaBlock
    {
        internal Moonfish.Tags.ShortBlockIndex1 triggerVolume;

        public override int SerializedSize
        {
            get { return 2; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public ScenarioKillTriggerVolumesBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            triggerVolume = binaryReader.ReadShortBlockIndex1();
            return blamPointers;
        }

        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
        }

        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
            using (binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(triggerVolume);
                return nextAddress;
            }
        }
    };
}