using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class SectorBsp2dNodesBlock : SectorBsp2dNodesBlockBase
    {
        public  SectorBsp2dNodesBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 20)]
    public class SectorBsp2dNodesBlockBase
    {
        internal OpenTK.Vector3 plane;
        internal int leftChild;
        internal int rightChild;
        internal  SectorBsp2dNodesBlockBase(BinaryReader binaryReader)
        {
            this.plane = binaryReader.ReadVector3();
            this.leftChild = binaryReader.ReadInt32();
            this.rightChild = binaryReader.ReadInt32();
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
