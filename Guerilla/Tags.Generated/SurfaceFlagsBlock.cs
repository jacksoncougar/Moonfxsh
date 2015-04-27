// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class SurfaceFlagsBlock : SurfaceFlagsBlockBase
    {
        public  SurfaceFlagsBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  SurfaceFlagsBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 4, Alignment = 4)]
    public class SurfaceFlagsBlockBase : GuerillaBlock
    {
        internal int flags;
        
        public override int SerializedSize{get { return 4; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  SurfaceFlagsBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            flags = binaryReader.ReadInt32();
        }
        public  SurfaceFlagsBlockBase(): base()
        {
            
        }
        public void Read(BinaryReader binaryReader)
        {
            flags = binaryReader.ReadInt32();
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(flags);
                return nextAddress;
            }
        }
    };
}
