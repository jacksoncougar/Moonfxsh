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
    public partial class ModelAnimationRuntimeDataStructBlock : ModelAnimationRuntimeDataStructBlockBase
    {
        public ModelAnimationRuntimeDataStructBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 80, Alignment = 4)]
    public class ModelAnimationRuntimeDataStructBlockBase : GuerillaBlock
    {
        internal InheritedAnimationBlock[] inheritenceListBBAAAA;
        internal WeaponClassLookupBlock[] weaponListBBAAAA;
        internal byte[] invalidName_;
        internal byte[] invalidName_0;

        public override int SerializedSize
        {
            get { return 80; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public ModelAnimationRuntimeDataStructBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<InheritedAnimationBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<WeaponClassLookupBlock>(binaryReader));
            invalidName_ = binaryReader.ReadBytes(32);
            invalidName_0 = binaryReader.ReadBytes(32);
            return blamPointers;
        }

        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            inheritenceListBBAAAA = ReadBlockArrayData<InheritedAnimationBlock>(binaryReader, blamPointers.Dequeue());
            weaponListBBAAAA = ReadBlockArrayData<WeaponClassLookupBlock>(binaryReader, blamPointers.Dequeue());
        }

        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
            using (binaryWriter.BaseStream.Pin())
            {
                nextAddress = Guerilla.WriteBlockArray<InheritedAnimationBlock>(binaryWriter, inheritenceListBBAAAA,
                    nextAddress);
                nextAddress = Guerilla.WriteBlockArray<WeaponClassLookupBlock>(binaryWriter, weaponListBBAAAA,
                    nextAddress);
                binaryWriter.Write(invalidName_, 0, 32);
                binaryWriter.Write(invalidName_0, 0, 32);
                return nextAddress;
            }
        }
    };
}