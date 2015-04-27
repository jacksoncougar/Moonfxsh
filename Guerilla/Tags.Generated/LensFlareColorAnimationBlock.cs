// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class LensFlareColorAnimationBlock : LensFlareColorAnimationBlockBase
    {
        public  LensFlareColorAnimationBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 8, Alignment = 4)]
    public class LensFlareColorAnimationBlockBase : GuerillaBlock
    {
        internal ColorFunctionStructBlock function;
        
        public override int SerializedSize{get { return 8; }}
        
        internal  LensFlareColorAnimationBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            function = new ColorFunctionStructBlock(binaryReader);
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
