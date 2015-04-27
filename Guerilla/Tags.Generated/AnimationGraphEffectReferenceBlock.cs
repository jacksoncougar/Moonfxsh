// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class AnimationGraphEffectReferenceBlock : AnimationGraphEffectReferenceBlockBase
    {
        public  AnimationGraphEffectReferenceBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  AnimationGraphEffectReferenceBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 12, Alignment = 4)]
    public class AnimationGraphEffectReferenceBlockBase : GuerillaBlock
    {
        [TagReference("effe")]
        internal Moonfish.Tags.TagReference effect;
        internal Flags flags;
        internal byte[] invalidName_;
        
        public override int SerializedSize{get { return 12; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  AnimationGraphEffectReferenceBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            effect = binaryReader.ReadTagReference();
            flags = (Flags)binaryReader.ReadInt16();
            invalidName_ = binaryReader.ReadBytes(2);
        }
        public  AnimationGraphEffectReferenceBlockBase(): base()
        {
            
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(effect);
                binaryWriter.Write((Int16)flags);
                binaryWriter.Write(invalidName_, 0, 2);
                return nextAddress;
            }
        }
        [FlagsAttribute]
        internal enum Flags : short
        {
            AllowOnPlayer = 1,
            LeftArmOnly = 2,
            RightArmOnly = 4,
            FirstPersonOnly = 8,
            ForwardOnly = 16,
            ReverseOnly = 32,
        };
    };
}
