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
    public partial class PlatformSoundEffectTemplateBlock : PlatformSoundEffectTemplateBlockBase
    {
        public PlatformSoundEffectTemplateBlock() : base()
        {
        }
    };
    [LayoutAttribute(Size = 24, Alignment = 4)]
    public class PlatformSoundEffectTemplateBlockBase : GuerillaBlock
    {
        internal Moonfish.Tags.StringIdent inputDspEffectName;
        internal byte[] invalidName_;
        internal PlatformSoundEffectTemplateComponentBlock[] components;
        public override int SerializedSize { get { return 24; } }
        public override int Alignment { get { return 4; } }
        public PlatformSoundEffectTemplateBlockBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            inputDspEffectName = binaryReader.ReadStringID();
            invalidName_ = binaryReader.ReadBytes(12);
            blamPointers.Enqueue(ReadBlockArrayPointer<PlatformSoundEffectTemplateComponentBlock>(binaryReader));
            return blamPointers;
        }
        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            invalidName_[0].ReadPointers(binaryReader, blamPointers);
            invalidName_[1].ReadPointers(binaryReader, blamPointers);
            invalidName_[2].ReadPointers(binaryReader, blamPointers);
            invalidName_[3].ReadPointers(binaryReader, blamPointers);
            invalidName_[4].ReadPointers(binaryReader, blamPointers);
            invalidName_[5].ReadPointers(binaryReader, blamPointers);
            invalidName_[6].ReadPointers(binaryReader, blamPointers);
            invalidName_[7].ReadPointers(binaryReader, blamPointers);
            invalidName_[8].ReadPointers(binaryReader, blamPointers);
            invalidName_[9].ReadPointers(binaryReader, blamPointers);
            invalidName_[10].ReadPointers(binaryReader, blamPointers);
            invalidName_[11].ReadPointers(binaryReader, blamPointers);
            components = ReadBlockArrayData<PlatformSoundEffectTemplateComponentBlock>(binaryReader, blamPointers.Dequeue());
        }
        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(inputDspEffectName);
                binaryWriter.Write(invalidName_, 0, 12);
                nextAddress = Guerilla.WriteBlockArray<PlatformSoundEffectTemplateComponentBlock>(binaryWriter, components, nextAddress);
                return nextAddress;
            }
        }
    };
}
