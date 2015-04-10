using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class ShapeGroupReferenceBlock : ShapeGroupReferenceBlockBase
    {
        public  ShapeGroupReferenceBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 24)]
    public class ShapeGroupReferenceBlockBase
    {
        internal ShapeBlockReferenceBlock[] shapes;
        internal UiModelSceneReferenceBlock[] modelSceneBlocks;
        internal BitmapBlockReferenceBlock[] bitmapBlocks;
        internal  ShapeGroupReferenceBlockBase(BinaryReader binaryReader)
        {
            this.shapes = ReadShapeBlockReferenceBlockArray(binaryReader);
            this.modelSceneBlocks = ReadUiModelSceneReferenceBlockArray(binaryReader);
            this.bitmapBlocks = ReadBitmapBlockReferenceBlockArray(binaryReader);
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
        internal  virtual ShapeBlockReferenceBlock[] ReadShapeBlockReferenceBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ShapeBlockReferenceBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ShapeBlockReferenceBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ShapeBlockReferenceBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual UiModelSceneReferenceBlock[] ReadUiModelSceneReferenceBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(UiModelSceneReferenceBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new UiModelSceneReferenceBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new UiModelSceneReferenceBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual BitmapBlockReferenceBlock[] ReadBitmapBlockReferenceBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(BitmapBlockReferenceBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new BitmapBlockReferenceBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new BitmapBlockReferenceBlock(binaryReader);
                }
            }
            return array;
        }
    };
}
