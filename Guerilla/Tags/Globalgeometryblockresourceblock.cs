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
        public  GlobalGeometryBlockResourceBlock(BinaryReader binaryReader): base(binaryReader)
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
        internal  GlobalGeometryBlockResourceBlockBase(BinaryReader binaryReader)
        {
            this.type = (Type)binaryReader.ReadByte();
            this.invalidName_ = binaryReader.ReadBytes(3);
            this.primaryLocator = binaryReader.ReadInt16();
            this.secondaryLocator = binaryReader.ReadInt16();
            this.resourceDataSize = binaryReader.ReadInt32();
            this.resourceDataOffset = binaryReader.ReadInt32();
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
        internal enum Type : byte
        
        {
            TagBlock = 0,
            TagData = 1,
            VertexBuffer = 2,
        };
    };
}
