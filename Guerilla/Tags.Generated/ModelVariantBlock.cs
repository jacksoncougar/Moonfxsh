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
    public partial class ModelVariantBlock : ModelVariantBlockBase
    {
        public ModelVariantBlock() : base()
        {
        }
    };
    [LayoutAttribute(Size = 56, Alignment = 4)]
    public class ModelVariantBlockBase : GuerillaBlock
    {
        internal Moonfish.Tags.StringIdent name;
        internal byte[] invalidName_;
        internal ModelVariantRegionBlock[] regions;
        internal ModelVariantObjectBlock[] objects;
        internal byte[] invalidName_0;
        internal Moonfish.Tags.StringIdent dialogueSoundEffect;
        [TagReference("udlg")]
        internal Moonfish.Tags.TagReference dialogue;
        public override int SerializedSize { get { return 56; } }
        public override int Alignment { get { return 4; } }
        public ModelVariantBlockBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            name = binaryReader.ReadStringID();
            invalidName_ = binaryReader.ReadBytes(16);
            blamPointers.Enqueue(ReadBlockArrayPointer<ModelVariantRegionBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<ModelVariantObjectBlock>(binaryReader));
            invalidName_0 = binaryReader.ReadBytes(8);
            dialogueSoundEffect = binaryReader.ReadStringID();
            dialogue = binaryReader.ReadTagReference();
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
            invalidName_[12].ReadPointers(binaryReader, blamPointers);
            invalidName_[13].ReadPointers(binaryReader, blamPointers);
            invalidName_[14].ReadPointers(binaryReader, blamPointers);
            invalidName_[15].ReadPointers(binaryReader, blamPointers);
            regions = ReadBlockArrayData<ModelVariantRegionBlock>(binaryReader, blamPointers.Dequeue());
            objects = ReadBlockArrayData<ModelVariantObjectBlock>(binaryReader, blamPointers.Dequeue());
            invalidName_0[0].ReadPointers(binaryReader, blamPointers);
            invalidName_0[1].ReadPointers(binaryReader, blamPointers);
            invalidName_0[2].ReadPointers(binaryReader, blamPointers);
            invalidName_0[3].ReadPointers(binaryReader, blamPointers);
            invalidName_0[4].ReadPointers(binaryReader, blamPointers);
            invalidName_0[5].ReadPointers(binaryReader, blamPointers);
            invalidName_0[6].ReadPointers(binaryReader, blamPointers);
            invalidName_0[7].ReadPointers(binaryReader, blamPointers);
        }
        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(name);
                binaryWriter.Write(invalidName_, 0, 16);
                nextAddress = Guerilla.WriteBlockArray<ModelVariantRegionBlock>(binaryWriter, regions, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<ModelVariantObjectBlock>(binaryWriter, objects, nextAddress);
                binaryWriter.Write(invalidName_0, 0, 8);
                binaryWriter.Write(dialogueSoundEffect);
                binaryWriter.Write(dialogue);
                return nextAddress;
            }
        }
    };
}
