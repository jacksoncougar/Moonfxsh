// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class LookFunctionBlock : LookFunctionBlockBase
    {
        public  LookFunctionBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  LookFunctionBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 4, Alignment = 4)]
    public class LookFunctionBlockBase : GuerillaBlock
    {
        internal float scale;
        
        public override int SerializedSize{get { return 4; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  LookFunctionBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            scale = binaryReader.ReadSingle();
        }
        public  LookFunctionBlockBase(): base()
        {
            
        }
        public override void Read(BinaryReader binaryReader)
        {
            scale = binaryReader.ReadSingle();
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(scale);
                return nextAddress;
            }
        }
    };
}
