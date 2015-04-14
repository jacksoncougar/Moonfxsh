// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class ScreenEffectBonusStructBlock : ScreenEffectBonusStructBlockBase
    {
        public  ScreenEffectBonusStructBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 16, Alignment = 4)]
    public class ScreenEffectBonusStructBlockBase  : IGuerilla
    {
        [TagReference("egor")]
        internal Moonfish.Tags.TagReference halfscreenScreenEffect;
        [TagReference("egor")]
        internal Moonfish.Tags.TagReference quarterscreenScreenEffect;
        internal  ScreenEffectBonusStructBlockBase(BinaryReader binaryReader)
        {
            halfscreenScreenEffect = binaryReader.ReadTagReference();
            quarterscreenScreenEffect = binaryReader.ReadTagReference();
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(halfscreenScreenEffect);
                binaryWriter.Write(quarterscreenScreenEffect);
                return nextAddress = (int)binaryWriter.BaseStream.Position;
            }
        }
    };
}
