// ReSharper disable All

using Moonfish.Model;

using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Moonfish.Tags
{
    public partial struct TagClass
    {
        public static readonly TagClass Trg = (TagClass) "trg*";
    };
} ;

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("trg*")]
    public partial class ScenarioTriggerVolumesResourceBlock : ScenarioTriggerVolumesResourceBlockBase
    {
        public ScenarioTriggerVolumesResourceBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 16, Alignment = 4)]
    public class ScenarioTriggerVolumesResourceBlockBase : GuerillaBlock
    {
        internal ScenarioTriggerVolumeBlock[] killTriggerVolumes;
        internal ScenarioObjectNamesBlock[] objectNames;

        public override int SerializedSize
        {
            get { return 16; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public ScenarioTriggerVolumesResourceBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<ScenarioTriggerVolumeBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<ScenarioObjectNamesBlock>(binaryReader));
            return blamPointers;
        }

        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            killTriggerVolumes = ReadBlockArrayData<ScenarioTriggerVolumeBlock>(binaryReader, blamPointers.Dequeue());
            objectNames = ReadBlockArrayData<ScenarioObjectNamesBlock>(binaryReader, blamPointers.Dequeue());
        }

        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
            using (binaryWriter.BaseStream.Pin())
            {
                nextAddress = Guerilla.WriteBlockArray<ScenarioTriggerVolumeBlock>(binaryWriter, killTriggerVolumes,
                    nextAddress);
                nextAddress = Guerilla.WriteBlockArray<ScenarioObjectNamesBlock>(binaryWriter, objectNames, nextAddress);
                return nextAddress;
            }
        }
    };
}