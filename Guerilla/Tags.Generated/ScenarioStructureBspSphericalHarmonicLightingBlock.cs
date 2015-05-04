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
    public partial class ScenarioStructureBspSphericalHarmonicLightingBlock :
        ScenarioStructureBspSphericalHarmonicLightingBlockBase
    {
        public ScenarioStructureBspSphericalHarmonicLightingBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 16, Alignment = 4)]
    public class ScenarioStructureBspSphericalHarmonicLightingBlockBase : GuerillaBlock
    {
        [TagReference("sbsp")] internal Moonfish.Tags.TagReference bSP;
        internal ScenarioSphericalHarmonicLightingPoint[] lightingPoints;

        public override int SerializedSize
        {
            get { return 16; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public ScenarioStructureBspSphericalHarmonicLightingBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            bSP = binaryReader.ReadTagReference();
            blamPointers.Enqueue(ReadBlockArrayPointer<ScenarioSphericalHarmonicLightingPoint>(binaryReader));
            return blamPointers;
        }

        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            lightingPoints = ReadBlockArrayData<ScenarioSphericalHarmonicLightingPoint>(binaryReader,
                blamPointers.Dequeue());
        }

        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
            using (binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(bSP);
                nextAddress = Guerilla.WriteBlockArray<ScenarioSphericalHarmonicLightingPoint>(binaryWriter,
                    lightingPoints, nextAddress);
                return nextAddress;
            }
        }
    };
}