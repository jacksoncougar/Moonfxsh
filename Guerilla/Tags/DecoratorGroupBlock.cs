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
        public  DecoratorGroupBlock(BinaryReader binaryReader): base(binaryReader)
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
        internal  DecoratorGroupBlockBase(BinaryReader binaryReader)
        {
            this.decoratorSet = binaryReader.ReadByteBlockIndex1();
            this.decoratorType = (DecoratorType)binaryReader.ReadByte();
            this.shaderIndex = binaryReader.ReadByte();
            this.compressedRadius = binaryReader.ReadByte();
            this.cluster = binaryReader.ReadInt16();
            this.cacheBlock = binaryReader.ReadShortBlockIndex1();
            this.decoratorStartIndex = binaryReader.ReadInt16();
            this.decoratorCount = binaryReader.ReadInt16();
            this.vertexStartOffset = binaryReader.ReadInt16();
            this.vertexCount = binaryReader.ReadInt16();
            this.indexStartOffset = binaryReader.ReadInt16();
            this.indexCount = binaryReader.ReadInt16();
            this.compressedBoundingCenter = binaryReader.ReadInt32();
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
