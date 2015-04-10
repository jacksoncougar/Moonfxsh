using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class ObjectSpaceNodeDataBlock : ObjectSpaceNodeDataBlockBase
    {
        public  ObjectSpaceNodeDataBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 28)]
    public class ObjectSpaceNodeDataBlockBase
    {
        internal short nodeIndex;
        internal ComponentFlags componentFlags;
        internal QuantizedOrientationStructBlock orientation;
        internal  ObjectSpaceNodeDataBlockBase(BinaryReader binaryReader)
        {
            this.nodeIndex = binaryReader.ReadInt16();
            this.componentFlags = (ComponentFlags)binaryReader.ReadInt16();
            this.orientation = new QuantizedOrientationStructBlock(binaryReader);
        }
        internal  virtual byte[] ReadData(BinaryReader binaryReader)
        {
            var blamPointer = binaryReader.ReadBlamPointer(1);
            var data = new byte[blamPointer.count];
            if(blamPointer.count > 0)
            {
                using (binaryReader.BaseStream.Pin())
                {
                    binaryReader.BaseStream.Position = blamPointer[0];
                    data = binaryReader.ReadBytes(blamPointer.count);
                }
            }
            return data;
        }
        [FlagsAttribute]
        internal enum ComponentFlags : short
        
        {
            Rotation = 1,
            Translation = 2,
            Scale = 4,
        };
    };
}
