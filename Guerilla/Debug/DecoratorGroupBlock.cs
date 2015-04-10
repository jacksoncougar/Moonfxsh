// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class DecoratorGroupBlock : DecoratorGroupBlockBase
    {
        public  DecoratorGroupBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 24)]
    public class DecoratorGroupBlockBase
    {
        internal Moonfish.Tags.ByteBlockIndex1 decoratorSet;
        internal DecoratorType decoratorType;
        internal byte shaderIndex;
        internal byte compressedRadius;
        internal short cluster;
        internal Moonfish.Tags.ShortBlockIndex1 cacheBlock;
        internal short decoratorStartIndex;
        internal short decoratorCount;
        internal short vertexStartOffset;
        internal short vertexCount;
        internal short indexStartOffset;
        internal short indexCount;
        internal int compressedBoundingCenter;
        internal  DecoratorGroupBlockBase(System.IO.BinaryReader binaryReader)
        {
            decoratorSet = binaryReader.ReadByteBlockIndex1();
            decoratorType = (DecoratorType)binaryReader.ReadByte();
            shaderIndex = binaryReader.ReadByte();
            compressedRadius = binaryReader.ReadByte();
            cluster = binaryReader.ReadInt16();
            cacheBlock = binaryReader.ReadShortBlockIndex1();
            decoratorStartIndex = binaryReader.ReadInt16();
            decoratorCount = binaryReader.ReadInt16();
            vertexStartOffset = binaryReader.ReadInt16();
            vertexCount = binaryReader.ReadInt16();
            indexStartOffset = binaryReader.ReadInt16();
            indexCount = binaryReader.ReadInt16();
            compressedBoundingCenter = binaryReader.ReadInt32();
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
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(decoratorSet);
                binaryWriter.Write((Byte)decoratorType);
                binaryWriter.Write(shaderIndex);
                binaryWriter.Write(compressedRadius);
                binaryWriter.Write(cluster);
                binaryWriter.Write(cacheBlock);
                binaryWriter.Write(decoratorStartIndex);
                binaryWriter.Write(decoratorCount);
                binaryWriter.Write(vertexStartOffset);
                binaryWriter.Write(vertexCount);
                binaryWriter.Write(indexStartOffset);
                binaryWriter.Write(indexCount);
                binaryWriter.Write(compressedBoundingCenter);
            }
        }
        internal enum DecoratorType : byte
        
        {
            Model = 0,
            FloatingDecal = 1,
            ProjectedDecal = 2,
            ScreenFacingQuad = 3,
            AxisRotatingQuad = 4,
            CrossQuad = 5,
        };
    };
}
