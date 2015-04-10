// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class ModelVariantBlock : ModelVariantBlockBase
    {
        public  ModelVariantBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
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
        internal  ModelVariantBlockBase(System.IO.BinaryReader binaryReader)
        {
            name = binaryReader.ReadStringID();
            invalidName_ = binaryReader.ReadBytes(16);
            ReadModelVariantRegionBlockArray(binaryReader);
            ReadModelVariantObjectBlockArray(binaryReader);
            invalidName_0 = binaryReader.ReadBytes(8);
            dialogueSoundEffect = binaryReader.ReadStringID();
            dialogue = binaryReader.ReadTagReference();
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
        internal  virtual ModelVariantRegionBlock[] ReadModelVariantRegionBlockArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual ModelVariantObjectBlock[] ReadModelVariantObjectBlockArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteModelVariantRegionBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteModelVariantObjectBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(name);
                binaryWriter.Write(invalidName_, 0, 16);
                WriteModelVariantRegionBlockArray(binaryWriter);
                WriteModelVariantObjectBlockArray(binaryWriter);
                binaryWriter.Write(invalidName_0, 0, 8);
                binaryWriter.Write(dialogueSoundEffect);
                binaryWriter.Write(dialogue);
            }
        }
    };
}
