using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class AnimationGraphSoundReferenceBlock : AnimationGraphSoundReferenceBlockBase
    {
        public  AnimationGraphSoundReferenceBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 12)]
    public class AnimationGraphSoundReferenceBlockBase
    {
        [TagReference("snd!")]
        internal Moonfish.Tags.TagReference sound;
        internal Flags flags;
        internal byte[] invalidName_;
        internal  AnimationGraphSoundReferenceBlockBase(BinaryReader binaryReader)
        {
            this.sound = binaryReader.ReadTagReference();
            this.flags = (Flags)binaryReader.ReadInt16();
            this.invalidName_ = binaryReader.ReadBytes(2);
        }
        internal  virtual byte[] ReadData(BinaryReader binaryReader)
        {
            var blamPointer = binaryReader.ReadBlamPointer(1);
            var data = new byte[blamPointer.Count];
            if(blamPointer.Count > 0)
            {
                using (binaryReader.BaseStream.Pin())
                {
                    binaryReader.BaseStream.Position = blamPointer[0];
                    data = binaryReader.ReadBytes(blamPointer.Count);
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
