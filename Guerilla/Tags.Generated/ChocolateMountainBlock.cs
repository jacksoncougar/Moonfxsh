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
        public static readonly TagClass Gldf = (TagClass) "gldf";
    };
} ;

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("gldf")]
    public partial class ChocolateMountainBlock : ChocolateMountainBlockBase
    {
        public ChocolateMountainBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 8, Alignment = 4)]
    public class ChocolateMountainBlockBase : GuerillaBlock
    {
        internal LightingVariablesBlock[] lightingVariables;

        public override int SerializedSize
        {
            get { return 8; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public ChocolateMountainBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<LightingVariablesBlock>(binaryReader));
            return blamPointers;
        }

        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            lightingVariables = ReadBlockArrayData<LightingVariablesBlock>(binaryReader, blamPointers.Dequeue());
        }

        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
            using (binaryWriter.BaseStream.Pin())
            {
                nextAddress = Guerilla.WriteBlockArray<LightingVariablesBlock>(binaryWriter, lightingVariables,
                    nextAddress);
                return nextAddress;
            }
        }
    };
}