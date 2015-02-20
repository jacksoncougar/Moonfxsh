using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class LeavesBlock : LeavesBlockBase
    {
        public  LeavesBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 4)]
    public class LeavesBlockBase
    {
        internal Flags flags;
        internal byte bSP2DReferenceCount;
        internal short firstBSP2DReference;
        internal  LeavesBlockBase(BinaryReader binaryReader)
        {
            this.flags = (Flags)binaryReader.ReadByte();
            this.bSP2DReferenceCount = binaryReader.ReadByte();
            this.firstBSP2DReference = binaryReader.ReadInt16();
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
        internal enum Flags : byte
        {
            ContainsDoubleSidedSurfaces = 1,
        };
    };
}
