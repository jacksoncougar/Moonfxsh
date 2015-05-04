// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
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
        public static readonly TagClass Mply = (TagClass) "mply";
    };
} ;

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("mply")]
    public partial class MultiplayerScenarioDescriptionBlock : MultiplayerScenarioDescriptionBlockBase
    {
        public MultiplayerScenarioDescriptionBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 8, Alignment = 4)]
    public class MultiplayerScenarioDescriptionBlockBase : GuerillaBlock
    {
        internal ScenarioDescriptionBlock[] multiplayerScenarios;

        public override int SerializedSize
        {
            get { return 8; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public MultiplayerScenarioDescriptionBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<ScenarioDescriptionBlock>(binaryReader));
            return blamPointers;
        }

        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            multiplayerScenarios = ReadBlockArrayData<ScenarioDescriptionBlock>(binaryReader, blamPointers.Dequeue());
        }

        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
            using (binaryWriter.BaseStream.Pin())
            {
                nextAddress = Guerilla.WriteBlockArray<ScenarioDescriptionBlock>(binaryWriter, multiplayerScenarios,
                    nextAddress);
                return nextAddress;
            }
        }
    };
}