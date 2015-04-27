// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class ScreenEffectBonusStructBlock : ScreenEffectBonusStructBlockBase
    {
        public  ScreenEffectBonusStructBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 16, Alignment = 4)]
    public class ScreenEffectBonusStructBlockBase : GuerillaBlock
    {
        [TagReference("egor")]
        internal Moonfish.Tags.TagReference halfscreenScreenEffect;
        [TagReference("egor")]
        internal Moonfish.Tags.TagReference quarterscreenScreenEffect;
        
        public override int SerializedSize{get { return 16; }}
        
        internal  ScreenEffectBonusStructBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            halfscreenScreenEffect = binaryReader.ReadTagReference();
            quarterscreenScreenEffect = binaryReader.ReadTagReference();
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(halfscreenScreenEffect);
                binaryWriter.Write(quarterscreenScreenEffect);
                return nextAddress;
            }
        }
    };
}
