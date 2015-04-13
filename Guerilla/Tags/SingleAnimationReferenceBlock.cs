// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class SingleAnimationReferenceBlock : SingleAnimationReferenceBlockBase
    {
        public  SingleAnimationReferenceBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 16, Alignment = 4)]
    public class SingleAnimationReferenceBlockBase  : IGuerilla
    {
        internal Flags flags;
        internal int animationPeriodMilliseconds;
        internal ScreenAnimationKeyframeReferenceBlock[] keyframes;
        internal  SingleAnimationReferenceBlockBase(BinaryReader binaryReader)
        {
            flags = (Flags)binaryReader.ReadInt32();
            animationPeriodMilliseconds = binaryReader.ReadInt32();
            keyframes = Guerilla.ReadBlockArray<ScreenAnimationKeyframeReferenceBlock>(binaryReader);
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write((Int32)flags);
                binaryWriter.Write(animationPeriodMilliseconds);
                Guerilla.WriteBlockArray<ScreenAnimationKeyframeReferenceBlock>(binaryWriter, keyframes, nextAddress);
                return nextAddress = (int)binaryWriter.BaseStream.Position;
            }
        }
        [FlagsAttribute]
        internal enum Flags : int
        {
            Unused = 1,
        };
    };
}
