// ReSharper disable All
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
        public  ObjectSpaceNodeDataBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 28)]
    public class ObjectSpaceNodeDataBlockBase
    {
        internal short nodeIndex;
        internal ComponentFlags componentFlags;
        internal QuantizedOrientationStructBlock orientation;
        internal  ObjectSpaceNodeDataBlockBase(System.IO.BinaryReader binaryReader)
        {
            nodeIndex = binaryReader.ReadInt16();
            componentFlags = (ComponentFlags)binaryReader.ReadInt16();
            orientation = new QuantizedOrientationStructBlock(binaryReader);
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
                binaryWriter.Write(nodeIndex);
                binaryWriter.Write((Int16)componentFlags);
                orientation.Write(binaryWriter);
            }
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
