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
    public partial class SoundGestaltExtraInfoBlock : SoundGestaltExtraInfoBlockBase
    {
        public SoundGestaltExtraInfoBlock() : base()
        {
        }
    };
    [LayoutAttribute(Size = 44, Alignment = 4)]
    public class SoundGestaltExtraInfoBlockBase : GuerillaBlock
    {
        internal SoundEncodedDialogueSectionBlock[] encodedPermutationSection;
        internal GlobalGeometryBlockInfoStructBlock geometryBlockInfo;
        public override int SerializedSize { get { return 44; } }
        public override int Alignment { get { return 4; } }
        public SoundGestaltExtraInfoBlockBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<SoundEncodedDialogueSectionBlock>(binaryReader));
            geometryBlockInfo = new GlobalGeometryBlockInfoStructBlock();
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(geometryBlockInfo.ReadFields(binaryReader)));
            return blamPointers;
        }
        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            encodedPermutationSection = ReadBlockArrayData<SoundEncodedDialogueSectionBlock>(binaryReader, blamPointers.Dequeue());
            geometryBlockInfo.ReadPointers(binaryReader, blamPointers);
        }
        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
using(binaryWriter.BaseStream.Pin())
            {
                nextAddress = Guerilla.WriteBlockArray<SoundEncodedDialogueSectionBlock>(binaryWriter, encodedPermutationSection, nextAddress);
                geometryBlockInfo.Write(binaryWriter);
                return nextAddress;
            }
        }
    };
}
