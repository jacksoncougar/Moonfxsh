// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class GlobalGeometryBlockResourceBlock : GlobalGeometryBlockResourceBlockBase
    {
        public  GlobalGeometryBlockResourceBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 16)]
    public class GlobalGeometryBlockResourceBlockBase
    {
        internal Type type;
        internal byte[] invalidName_;
        internal short primaryLocator;
        internal short secondaryLocator;
        internal int resourceDataSize;
        internal int resourceDataOffset;
        internal  GlobalGeometryBlockResourceBlockBase(System.IO.BinaryReader binaryReader)
        {
            type = (Type)binaryReader.ReadByte();
            invalidName_ = binaryReader.ReadBytes(3);
            primaryLocator = binaryReader.ReadInt16();
            secondaryLocator = binaryReader.ReadInt16();
            resourceDataSize = binaryReader.ReadInt32();
            resourceDataOffset = binaryReader.ReadInt32();
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
                binaryWriter.Write((Byte)type);
                binaryWriter.Write(invalidName_, 0, 3);
                binaryWriter.Write(primaryLocator);
                binaryWriter.Write(secondaryLocator);
                binaryWriter.Write(resourceDataSize);
                binaryWriter.Write(resourceDataOffset);
            }
        }
        internal enum Type : byte
        
        {
            TagBlock = 0,
            TagData = 1,
            VertexBuffer = 2,
        };
    };
}
