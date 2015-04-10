// ReSharper disable All
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
        public  LeavesBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 4)]
    public class LeavesBlockBase
    {
        internal Flags flags;
        internal byte bSP2DReferenceCount;
        internal short firstBSP2DReference;
        internal  LeavesBlockBase(System.IO.BinaryReader binaryReader)
        {
            flags = (Flags)binaryReader.ReadByte();
            bSP2DReferenceCount = binaryReader.ReadByte();
            firstBSP2DReference = binaryReader.ReadInt16();
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
                binaryWriter.Write((Byte)flags);
                binaryWriter.Write(bSP2DReferenceCount);
                binaryWriter.Write(firstBSP2DReference);
            }
        }
        [FlagsAttribute]
        internal enum Flags : byte
        
        {
            ContainsDoubleSidedSurfaces = 1,
        };
    };
}
