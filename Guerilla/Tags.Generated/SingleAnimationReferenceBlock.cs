// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class SingleAnimationReferenceBlock : SingleAnimationReferenceBlockBase
    {
        public  SingleAnimationReferenceBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  SingleAnimationReferenceBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 16, Alignment = 4)]
    public class SingleAnimationReferenceBlockBase : GuerillaBlock
    {
        internal Flags flags;
        internal int animationPeriodMilliseconds;
        internal ScreenAnimationKeyframeReferenceBlock[] keyframes;
        
        public override int SerializedSize{get { return 16; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  SingleAnimationReferenceBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            flags = (Flags)binaryReader.ReadInt32();
            animationPeriodMilliseconds = binaryReader.ReadInt32();
            keyframes = Guerilla.ReadBlockArray<ScreenAnimationKeyframeReferenceBlock>(binaryReader);
        }
        public  SingleAnimationReferenceBlockBase(): base()
        {
            
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write((Int32)flags);
                binaryWriter.Write(animationPeriodMilliseconds);
                nextAddress = Guerilla.WriteBlockArray<ScreenAnimationKeyframeReferenceBlock>(binaryWriter, keyframes, nextAddress);
                return nextAddress;
            }
        }
        [FlagsAttribute]
        internal enum Flags : int
        {
            Unused = 1,
        };
    };
}
