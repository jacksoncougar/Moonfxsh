// ReSharper disable All

using Moonfish.Model;

using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Moonfish.Guerilla.Tags
{
    public partial class ScenarioChildScenarioBlock : ScenarioChildScenarioBlockBase
    {
        public ScenarioChildScenarioBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 24, Alignment = 4)]
    public class ScenarioChildScenarioBlockBase : GuerillaBlock
    {
        [TagReference("scnr")] internal Moonfish.Tags.TagReference childScenario;
        internal byte[] invalidName_;

        public override int SerializedSize
        {
            get { return 24; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public ScenarioChildScenarioBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            childScenario = binaryReader.ReadTagReference();
            invalidName_ = binaryReader.ReadBytes(16);
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
                binaryWriter.Write(childScenario);
                binaryWriter.Write(invalidName_, 0, 16);
                return nextAddress;
            }
        }
    };
}