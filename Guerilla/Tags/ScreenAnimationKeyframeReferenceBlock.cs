// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class ScreenAnimationKeyframeReferenceBlock : ScreenAnimationKeyframeReferenceBlockBase
    {
        public  ScreenAnimationKeyframeReferenceBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 20, Alignment = 4)]
    public class ScreenAnimationKeyframeReferenceBlockBase  : IGuerilla
    {
        internal byte[] invalidName_;
        internal float alpha;
        internal OpenTK.Vector3 position;
        internal  ScreenAnimationKeyframeReferenceBlockBase(BinaryReader binaryReader)
        {
            invalidName_ = binaryReader.ReadBytes(4);
            alpha = binaryReader.ReadSingle();
            position = binaryReader.ReadVector3();
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
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
