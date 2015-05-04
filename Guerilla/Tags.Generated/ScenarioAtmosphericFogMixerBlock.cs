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
    public partial class ScenarioAtmosphericFogMixerBlock : ScenarioAtmosphericFogMixerBlockBase
    {
        public ScenarioAtmosphericFogMixerBlock() : base()
        {
        }
    };
    [LayoutAttribute(Size = 16, Alignment = 4)]
    public class ScenarioAtmosphericFogMixerBlockBase : GuerillaBlock
    {
        internal byte[] invalidName_;
        internal Moonfish.Tags.StringIdent atmosphericFogSourceFromScenarioAtmosphericFogPalette;
        internal Moonfish.Tags.StringIdent interpolatorFromScenarioInterpolators;
        internal byte[] invalidName_0;
        internal byte[] invalidName_1;
        public override int SerializedSize { get { return 16; } }
        public override int Alignment { get { return 4; } }
        public ScenarioAtmosphericFogMixerBlockBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            invalidName_ = binaryReader.ReadBytes(4);
            atmosphericFogSourceFromScenarioAtmosphericFogPalette = binaryReader.ReadStringID();
            interpolatorFromScenarioInterpolators = binaryReader.ReadStringID();
            invalidName_0 = binaryReader.ReadBytes(2);
            invalidName_1 = binaryReader.ReadBytes(2);
            return blamPointers;
        }
        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            invalidName_[0].ReadPointers(binaryReader, blamPointers);
            invalidName_[1].ReadPointers(binaryReader, blamPointers);
            invalidName_[2].ReadPointers(binaryReader, blamPointers);
            invalidName_[3].ReadPointers(binaryReader, blamPointers);
            invalidName_0[0].ReadPointers(binaryReader, blamPointers);
            invalidName_0[1].ReadPointers(binaryReader, blamPointers);
            invalidName_1[0].ReadPointers(binaryReader, blamPointers);
            invalidName_1[1].ReadPointers(binaryReader, blamPointers);
        }
        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(invalidName_, 0, 4);
                binaryWriter.Write(atmosphericFogSourceFromScenarioAtmosphericFogPalette);
                binaryWriter.Write(interpolatorFromScenarioInterpolators);
                binaryWriter.Write(invalidName_0, 0, 2);
                binaryWriter.Write(invalidName_1, 0, 2);
                return nextAddress;
            }
        }
    };
}
