using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class Bsp2dNodesBlock : Bsp2dNodesBlockBase
    {
        public  Bsp2dNodesBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 16)]
    public class Bsp2dNodesBlockBase
    {
        internal OpenTK.Vector3 plane;
        internal short leftChild;
        internal short rightChild;
        internal  Bsp2dNodesBlockBase(BinaryReader binaryReader)
        {
            this.plane = binaryReader.ReadVector3();
            this.leftChild = binaryReader.ReadInt16();
            this.rightChild = binaryReader.ReadInt16();
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
    };
}
