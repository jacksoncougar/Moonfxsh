// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class ModelVariantRegionBlock : ModelVariantRegionBlockBase
    {
        public  ModelVariantRegionBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 20)]
    public class ModelVariantRegionBlockBase
    {
        internal Moonfish.Tags.StringID regionNameMustMatchRegionNameInRenderModel;
        internal byte[] invalidName_;
        internal byte[] invalidName_0;
        internal Moonfish.Tags.ShortBlockIndex1 parentVariant;
        internal ModelVariantPermutationBlock[] permutations;
        /// <summary>
        /// negative values mean closer to the camera
        /// </summary>
        internal SortOrderNegativeValuesMeanCloserToTheCamera sortOrder;
        internal byte[] invalidName_1;
        internal  ModelVariantRegionBlockBase(System.IO.BinaryReader binaryReader)
        {
            regionNameMustMatchRegionNameInRenderModel = binaryReader.ReadStringID();
            invalidName_ = binaryReader.ReadBytes(1);
            invalidName_0 = binaryReader.ReadBytes(1);
            parentVariant = binaryReader.ReadShortBlockIndex1();
            ReadModelVariantPermutationBlockArray(binaryReader);
            sortOrder = (SortOrderNegativeValuesMeanCloserToTheCamera)binaryReader.ReadInt16();
            invalidName_1 = binaryReader.ReadBytes(2);
        }
        internal  virtual byte[] ReadData(System.IO.BinaryReader binaryReader)
        {
            var blamPointer = binaryReader.ReadBlamPointer(1);
            var data = new byte[blamPointer.Count];
            if(blamPointer.Count > 0)
            {
                using (binaryReader.BaseStream.Pin())
                {
                    binaryReader.BaseStream.Position = blamPointer[0];
                    data = binaryReader.ReadBytes(blamPointer.Count);
                }
            }
            return data;
        }
        internal  virtual ModelVariantPermutationBlock[] ReadModelVariantPermutationBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ModelVariantPermutationBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ModelVariantPermutationBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ModelVariantPermutationBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteModelVariantPermutationBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(regionNameMustMatchRegionNameInRenderModel);
                binaryWriter.Write(invalidName_, 0, 1);
                binaryWriter.Write(invalidName_0, 0, 1);
                binaryWriter.Write(parentVariant);
                WriteModelVariantPermutationBlockArray(binaryWriter);
                binaryWriter.Write((Int16)sortOrder);
                binaryWriter.Write(invalidName_1, 0, 2);
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
