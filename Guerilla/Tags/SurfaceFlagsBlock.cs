// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class SurfaceFlagsBlock : SurfaceFlagsBlockBase
    {
        public  SurfaceFlagsBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 4, Alignment = 4)]
    public class SurfaceFlagsBlockBase  : IGuerilla
    {
        internal int flags;
        internal  SurfaceFlagsBlockBase(BinaryReader binaryReader)
        {
            flags = binaryReader.ReadInt32();
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(flags);
                return nextAddress = (int)binaryWriter.BaseStream.Position;
            }
        }
    };
}
