// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class UNUSEDStructureBspNodeBlock : UNUSEDStructureBspNodeBlockBase
    {
        public  UNUSEDStructureBspNodeBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 6, Alignment = 4)]
    public class UNUSEDStructureBspNodeBlockBase  : IGuerilla
    {
        internal byte[] invalidName_;
        internal  UNUSEDStructureBspNodeBlockBase(BinaryReader binaryReader)
        {
            invalidName_ = binaryReader.ReadBytes(6);
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(invalidName_, 0, 6);
                return nextAddress = (int)binaryWriter.BaseStream.Position;
            }
        }
    };
}
