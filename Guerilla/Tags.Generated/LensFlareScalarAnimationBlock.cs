// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class LensFlareScalarAnimationBlock : LensFlareScalarAnimationBlockBase
    {
        public  LensFlareScalarAnimationBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  LensFlareScalarAnimationBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 8, Alignment = 4)]
    public class LensFlareScalarAnimationBlockBase : GuerillaBlock
    {
        internal ScalarFunctionStructBlock function;
        
        public override int SerializedSize{get { return 8; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  LensFlareScalarAnimationBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            function = new ScalarFunctionStructBlock(binaryReader);
        }
        public  LensFlareScalarAnimationBlockBase(): base()
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
