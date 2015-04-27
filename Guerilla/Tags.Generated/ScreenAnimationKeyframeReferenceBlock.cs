// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class ScreenAnimationKeyframeReferenceBlock : ScreenAnimationKeyframeReferenceBlockBase
    {
        public  ScreenAnimationKeyframeReferenceBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  ScreenAnimationKeyframeReferenceBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 20, Alignment = 4)]
    public class ScreenAnimationKeyframeReferenceBlockBase : GuerillaBlock
    {
        internal byte[] invalidName_;
        internal float alpha;
        internal OpenTK.Vector3 position;
        
        public override int SerializedSize{get { return 20; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  ScreenAnimationKeyframeReferenceBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            invalidName_ = binaryReader.ReadBytes(4);
            alpha = binaryReader.ReadSingle();
            position = binaryReader.ReadVector3();
        }
        public  ScreenAnimationKeyframeReferenceBlockBase(): base()
        {
            
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(invalidName_, 0, 4);
                binaryWriter.Write(alpha);
                binaryWriter.Write(position);
                return nextAddress;
            }
        }
    };
}
