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
    public partial class AnimationGraphContentsStructBlock : AnimationGraphContentsStructBlockBase
    {
        public AnimationGraphContentsStructBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 24, Alignment = 4)]
    public class AnimationGraphContentsStructBlockBase : GuerillaBlock
    {
        internal AnimationModeBlock[] modesAABBCC;
        internal VehicleSuspensionBlock[] vehicleSuspensionCCAABB;
        internal ObjectAnimationBlock[] objectOverlaysCCAABB;

        public override int SerializedSize
        {
            get { return 24; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public AnimationGraphContentsStructBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<AnimationModeBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<VehicleSuspensionBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<ObjectAnimationBlock>(binaryReader));
            return blamPointers;
        }

        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            modesAABBCC = ReadBlockArrayData<AnimationModeBlock>(binaryReader, blamPointers.Dequeue());
            vehicleSuspensionCCAABB = ReadBlockArrayData<VehicleSuspensionBlock>(binaryReader, blamPointers.Dequeue());
            objectOverlaysCCAABB = ReadBlockArrayData<ObjectAnimationBlock>(binaryReader, blamPointers.Dequeue());
        }

        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
            using (binaryWriter.BaseStream.Pin())
            {
                nextAddress = Guerilla.WriteBlockArray<AnimationModeBlock>(binaryWriter, modesAABBCC, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<VehicleSuspensionBlock>(binaryWriter, vehicleSuspensionCCAABB,
                    nextAddress);
                nextAddress = Guerilla.WriteBlockArray<ObjectAnimationBlock>(binaryWriter, objectOverlaysCCAABB,
                    nextAddress);
                return nextAddress;
            }
        }
    };
}