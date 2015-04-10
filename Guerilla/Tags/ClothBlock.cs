using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("clwd")]
    public  partial class ClothBlock : ClothBlockBase
    {
        public  ClothBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 108)]
    public class ClothBlockBase
    {
        internal Flags flags;
        internal Moonfish.Tags.StringID markerAttachmentName;
        [TagReference("shad")]
        internal Moonfish.Tags.TagReference shader;
        internal short gridXDimension;
        internal short gridYDimension;
        internal float gridSpacingX;
        internal float gridSpacingY;
        internal ClothPropertiesBlock properties;
        internal ClothVerticesBlock[] vertices;
        internal ClothIndicesBlock[] indices;
        internal ClothIndicesBlock[] stripIndices;
        internal ClothLinksBlock[] links;
        internal  ClothBlockBase(BinaryReader binaryReader)
        {
            this.flags = (Flags)binaryReader.ReadInt32();
            this.markerAttachmentName = binaryReader.ReadStringID();
            this.shader = binaryReader.ReadTagReference();
            this.gridXDimension = binaryReader.ReadInt16();
            this.gridYDimension = binaryReader.ReadInt16();
            this.gridSpacingX = binaryReader.ReadSingle();
            this.gridSpacingY = binaryReader.ReadSingle();
            this.properties = new ClothPropertiesBlock(binaryReader);
            this.vertices = ReadClothVerticesBlockArray(binaryReader);
            this.indices = ReadClothIndicesBlockArray(binaryReader);
            this.stripIndices = ReadClothIndicesBlockArray(binaryReader);
            this.links = ReadClothLinksBlockArray(binaryReader);
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
        internal  virtual ClothVerticesBlock[] ReadClothVerticesBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ClothVerticesBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ClothVerticesBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ClothVerticesBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual ClothIndicesBlock[] ReadClothIndicesBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ClothIndicesBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ClothIndicesBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ClothIndicesBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual ClothLinksBlock[] ReadClothLinksBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ClothLinksBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ClothLinksBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ClothLinksBlock(binaryReader);
                }
            }
            return array;
        }
        [FlagsAttribute]
        internal enum Flags : int
        
        {
            DoesntUseWind = 1,
            UsesGridAttachTop = 2,
        };
    };
}
