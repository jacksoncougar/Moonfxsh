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
    public partial class ModelVariantRegionBlock : ModelVariantRegionBlockBase
    {
        public ModelVariantRegionBlock() : base()
        {
        }
    };
    [LayoutAttribute(Size = 20, Alignment = 4)]
    public class ModelVariantRegionBlockBase : GuerillaBlock
    {
        internal Moonfish.Tags.StringIdent regionNameMustMatchRegionNameInRenderModel;
        internal byte[] invalidName_;
        internal byte[] invalidName_0;
        internal Moonfish.Tags.ShortBlockIndex1 parentVariant;
        internal ModelVariantPermutationBlock[] permutations;
        /// <summary>
        /// negative values mean closer to the camera
        /// </summary>
        internal SortOrderNegativeValuesMeanCloserToTheCamera sortOrder;
        internal byte[] invalidName_1;
        public override int SerializedSize { get { return 20; } }
        public override int Alignment { get { return 4; } }
        public ModelVariantRegionBlockBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            regionNameMustMatchRegionNameInRenderModel = binaryReader.ReadStringID();
            invalidName_ = binaryReader.ReadBytes(1);
            invalidName_0 = binaryReader.ReadBytes(1);
            parentVariant = binaryReader.ReadShortBlockIndex1();
            blamPointers.Enqueue(ReadBlockArrayPointer<ModelVariantPermutationBlock>(binaryReader));
            sortOrder = (SortOrderNegativeValuesMeanCloserToTheCamera)binaryReader.ReadInt16();
            invalidName_1 = binaryReader.ReadBytes(2);
            return blamPointers;
        }
        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            invalidName_[0].ReadPointers(binaryReader, blamPointers);
            invalidName_0[0].ReadPointers(binaryReader, blamPointers);
            permutations = ReadBlockArrayData<ModelVariantPermutationBlock>(binaryReader, blamPointers.Dequeue());
            invalidName_1[0].ReadPointers(binaryReader, blamPointers);
            invalidName_1[1].ReadPointers(binaryReader, blamPointers);
        }
        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(regionNameMustMatchRegionNameInRenderModel);
                binaryWriter.Write(invalidName_, 0, 1);
                binaryWriter.Write(invalidName_0, 0, 1);
                binaryWriter.Write(parentVariant);
                nextAddress = Guerilla.WriteBlockArray<ModelVariantPermutationBlock>(binaryWriter, permutations, nextAddress);
                binaryWriter.Write((Int16)sortOrder);
                binaryWriter.Write(invalidName_1, 0, 2);
                return nextAddress;
            }
        }
        internal enum SortOrderNegativeValuesMeanCloserToTheCamera : short
        {
            NoSorting = 0,
            Minus5Closest = 1,
            Minus4 = 2,
            Minus3 = 3,
            Minus2 = 4,
            Minus1 = 5,
            NoBiasSameAsModel = 6,
            Plus1 = 7,
            Plus2 = 8,
            Plus3 = 9,
            Plus4 = 10,
            Plus5Farthest = 11,
        };
    };
}
