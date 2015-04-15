// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class GlobalDetailObjectCountsBlock : GlobalDetailObjectCountsBlockBase
    {
        public  GlobalDetailObjectCountsBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 2, Alignment = 4)]
    public class GlobalDetailObjectCountsBlockBase  : IGuerilla
    {
        internal short invalidName_;
        internal  GlobalDetailObjectCountsBlockBase(BinaryReader binaryReader)
        {
            invalidName_ = binaryReader.ReadInt16();
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(invalidName_);
                return nextAddress;
            }
        }
    };
}
