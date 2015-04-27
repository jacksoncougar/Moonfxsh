// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Tags
{
    public partial struct TagClass
    {
        public static readonly TagClass Garb = (TagClass)"garb";
    };
};

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("garb")]
    public partial class GarbageBlock : GarbageBlockBase
    {
        public  GarbageBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  GarbageBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 168, Alignment = 4)]
    public class GarbageBlockBase : GuerillaBlock
    {
        internal byte[] invalidName_;
        
        public override int SerializedSize{get { return 168; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  GarbageBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            invalidName_ = binaryReader.ReadBytes(168);
        }
        public  GarbageBlockBase(): base()
        {
            
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(invalidName_, 0, 168);
                return nextAddress;
            }
        }
    };
}
