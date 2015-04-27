// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class BackgroundAnimationKeyframeReferenceBlock : BackgroundAnimationKeyframeReferenceBlockBase
    {
        public  BackgroundAnimationKeyframeReferenceBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 20, Alignment = 4)]
    public class BackgroundAnimationKeyframeReferenceBlockBase : GuerillaBlock
    {
        internal int startTransitionIndex;
        internal float alpha;
        internal OpenTK.Vector3 position;
        
        public override int SerializedSize{get { return 20; }}
        
        internal  BackgroundAnimationKeyframeReferenceBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            startTransitionIndex = binaryReader.ReadInt32();
            alpha = binaryReader.ReadSingle();
            position = binaryReader.ReadVector3();
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(startTransitionIndex);
                binaryWriter.Write(alpha);
                binaryWriter.Write(position);
                return nextAddress;
            }
        }
    };
}
