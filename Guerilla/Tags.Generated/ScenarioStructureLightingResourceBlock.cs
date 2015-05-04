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
        public static readonly TagClass Sslt = (TagClass) "sslt";
    };
} ;

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("sslt")]
    public partial class ScenarioStructureLightingResourceBlock : ScenarioStructureLightingResourceBlockBase
    {
        public ScenarioStructureLightingResourceBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 8, Alignment = 4)]
    public class ScenarioStructureLightingResourceBlockBase : GuerillaBlock
    {
        internal ScenarioStructureBspSphericalHarmonicLightingBlock[] structureLighting;

        public override int SerializedSize
        {
            get { return 8; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public ScenarioStructureLightingResourceBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<ScenarioStructureBspSphericalHarmonicLightingBlock>(binaryReader));
            return blamPointers;
        }

        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            structureLighting = ReadBlockArrayData<ScenarioStructureBspSphericalHarmonicLightingBlock>(binaryReader,
                blamPointers.Dequeue());
        }

        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
            using (binaryWriter.BaseStream.Pin())
            {
                nextAddress = Guerilla.WriteBlockArray<ScenarioStructureBspSphericalHarmonicLightingBlock>(
                    binaryWriter, structureLighting, nextAddress);
                return nextAddress;
            }
        }
    };
}