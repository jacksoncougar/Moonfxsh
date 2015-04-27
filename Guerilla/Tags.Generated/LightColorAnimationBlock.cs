// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class LightColorAnimationBlock : LightColorAnimationBlockBase
    {
        public  LightColorAnimationBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  LightColorAnimationBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 8, Alignment = 4)]
    public class LightColorAnimationBlockBase : GuerillaBlock
    {
        internal MappingFunctionBlock function;
        
        public override int SerializedSize{get { return 8; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  LightColorAnimationBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            function = new MappingFunctionBlock(binaryReader);
        }
        public  LightColorAnimationBlockBase(): base()
        {
            
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                function.Write(binaryWriter);
                return nextAddress;
            }
        }
    };
}
