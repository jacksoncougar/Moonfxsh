using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class AnimationGraphEffectReferenceBlock : AnimationGraphEffectReferenceBlockBase
    {
        public  AnimationGraphEffectReferenceBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 12)]
    public class AnimationGraphEffectReferenceBlockBase
    {
        [TagReference("effe")]
        internal Moonfish.Tags.TagReference effect;
        internal Flags flags;
        internal byte[] invalidName_;
        internal  AnimationGraphEffectReferenceBlockBase(BinaryReader binaryReader)
        {
            this.effect = binaryReader.ReadTagReference();
            this.flags = (Flags)binaryReader.ReadInt16();
            this.invalidName_ = binaryReader.ReadBytes(2);
        }
        internal  virtual byte[] ReadData(BinaryReader binaryReader)
        {
            var blamPointer = binaryReader.ReadBlamPointer(1);
            var data = new byte[blamPointer.count];
            if(blamPointer.count > 0)
            {
                using (binaryReader.BaseStream.Pin())
                {
                    binaryReader.BaseStream.Position = blamPointer[0];
                    data = binaryReader.ReadBytes(blamPointer.count);
                }
            }
            return data;
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
