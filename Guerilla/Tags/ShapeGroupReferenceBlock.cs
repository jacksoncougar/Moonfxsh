// ReSharper disable All
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
    [LayoutAttribute(Size = 24, Alignment = 4)]
    public class ShapeGroupReferenceBlockBase  : IGuerilla
    {
        internal ShapeBlockReferenceBlock[] shapes;
        internal UiModelSceneReferenceBlock[] modelSceneBlocks;
        internal BitmapBlockReferenceBlock[] bitmapBlocks;
        internal  ShapeGroupReferenceBlockBase(BinaryReader binaryReader)
        {
            shapes = Guerilla.ReadBlockArray<ShapeBlockReferenceBlock>(binaryReader);
            modelSceneBlocks = Guerilla.ReadBlockArray<UiModelSceneReferenceBlock>(binaryReader);
            bitmapBlocks = Guerilla.ReadBlockArray<BitmapBlockReferenceBlock>(binaryReader);
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                nextAddress = Guerilla.WriteBlockArray<ShapeBlockReferenceBlock>(binaryWriter, shapes, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<UiModelSceneReferenceBlock>(binaryWriter, modelSceneBlocks, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<BitmapBlockReferenceBlock>(binaryWriter, bitmapBlocks, nextAddress);
                return nextAddress = (int)binaryWriter.BaseStream.Position;
            }
        }
    };
}
