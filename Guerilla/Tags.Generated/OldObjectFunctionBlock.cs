// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class OldObjectFunctionBlock : OldObjectFunctionBlockBase
    {
        public  OldObjectFunctionBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  OldObjectFunctionBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 80, Alignment = 4)]
    public class OldObjectFunctionBlockBase : GuerillaBlock
    {
        internal byte[] invalidName_;
        internal Moonfish.Tags.StringID invalidName_0;
        
        public override int SerializedSize{get { return 80; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  OldObjectFunctionBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            invalidName_ = binaryReader.ReadBytes(76);
            invalidName_0 = binaryReader.ReadStringID();
        }
        public  OldObjectFunctionBlockBase(): base()
        {
            
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(invalidName_, 0, 76);
                binaryWriter.Write(invalidName_0);
                return nextAddress;
            }
        }
    };
}
