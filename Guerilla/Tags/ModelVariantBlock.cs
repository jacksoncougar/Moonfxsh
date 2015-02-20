using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    [LayoutAttribute(Size = 56)]
    public  partial class ModelVariantBlock : ModelVariantBlockBase
    {
        public  ModelVariantBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 56)]
    public class ModelVariantBlockBase
    {
        internal Moonfish.Tags.StringID name;
        internal byte[] invalidName_;
        internal ModelVariantRegionBlock[] regions;
        internal ModelVariantObjectBlock[] objects;
        internal byte[] invalidName_0;
        internal Moonfish.Tags.StringID dialogueSoundEffect;
        [TagReference("udlg")]
        internal Moonfish.Tags.TagReference dialogue;
        internal  ModelVariantBlockBase(BinaryReader binaryReader)
        {
            this.name = binaryReader.ReadStringID();
            this.invalidName_ = binaryReader.ReadBytes(16);
            this.regions = ReadModelVariantRegionBlockArray(binaryReader);
            this.objects = ReadModelVariantObjectBlockArray(binaryReader);
            this.invalidName_0 = binaryReader.ReadBytes(8);
            this.dialogueSoundEffect = binaryReader.ReadStringID();
            this.dialogue = binaryReader.ReadTagReference();
        }
        internal  virtual byte[] ReadData(BinaryReader binaryReader)
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
        internal  virtual ModelVariantRegionBlock[] ReadModelVariantRegionBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ModelVariantRegionBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ModelVariantRegionBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ModelVariantRegionBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual ModelVariantObjectBlock[] ReadModelVariantObjectBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ModelVariantObjectBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ModelVariantObjectBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ModelVariantObjectBlock(binaryReader);
                }
            }
            return array;
        }
    };
}
