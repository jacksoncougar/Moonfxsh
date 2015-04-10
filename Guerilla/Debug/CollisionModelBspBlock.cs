// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class CollisionModelBspBlock : CollisionModelBspBlockBase
    {
        public  CollisionModelBspBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 68)]
    public class CollisionModelBspBlockBase
    {
        internal short nodeIndex;
        internal byte[] invalidName_;
        internal GlobalCollisionBspStructBlock bsp;
        internal  CollisionModelBspBlockBase(System.IO.BinaryReader binaryReader)
        {
            nodeIndex = binaryReader.ReadInt16();
            invalidName_ = binaryReader.ReadBytes(2);
            bsp = new GlobalCollisionBspStructBlock(binaryReader);
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
                binaryWriter.Write(invalidName_, 0, 2);
                bsp.Write(binaryWriter);
            }
        }
    };
}
