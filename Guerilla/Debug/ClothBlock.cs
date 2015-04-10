// ReSharper disable All
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
        public  ClothBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
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
        internal  ClothBlockBase(System.IO.BinaryReader binaryReader)
        {
            flags = (Flags)binaryReader.ReadInt32();
            markerAttachmentName = binaryReader.ReadStringID();
            shader = binaryReader.ReadTagReference();
            gridXDimension = binaryReader.ReadInt16();
            gridYDimension = binaryReader.ReadInt16();
            gridSpacingX = binaryReader.ReadSingle();
            gridSpacingY = binaryReader.ReadSingle();
            properties = new ClothPropertiesBlock(binaryReader);
            ReadClothVerticesBlockArray(binaryReader);
            ReadClothIndicesBlockArray(binaryReader);
            ReadClothIndicesBlockArray(binaryReader);
            ReadClothLinksBlockArray(binaryReader);
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
        internal  virtual ClothVerticesBlock[] ReadClothVerticesBlockArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual ClothIndicesBlock[] ReadClothIndicesBlockArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual ClothLinksBlock[] ReadClothLinksBlockArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteClothVerticesBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteClothIndicesBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteClothLinksBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write((Int32)flags);
                binaryWriter.Write(markerAttachmentName);
                binaryWriter.Write(shader);
                binaryWriter.Write(gridXDimension);
                binaryWriter.Write(gridYDimension);
                binaryWriter.Write(gridSpacingX);
                binaryWriter.Write(gridSpacingY);
                properties.Write(binaryWriter);
                WriteClothVerticesBlockArray(binaryWriter);
                WriteClothIndicesBlockArray(binaryWriter);
                WriteClothIndicesBlockArray(binaryWriter);
                WriteClothLinksBlockArray(binaryWriter);
            }
        }
        [FlagsAttribute]
        internal enum Flags : int
        
        {
            DoesntUseWind = 1,
            UsesGridAttachTop = 2,
        };
    };
}
