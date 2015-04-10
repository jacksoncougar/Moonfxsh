using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class GrenadeHudSoundBlock : GrenadeHudSoundBlockBase
    {
        public  GrenadeHudSoundBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 48)]
    public class GrenadeHudSoundBlockBase
    {
        [TagReference("null")]
        internal Moonfish.Tags.TagReference sound;
        internal LatchedTo latchedTo;
        internal float scale;
        internal byte[] invalidName_;
        internal  GrenadeHudSoundBlockBase(BinaryReader binaryReader)
        {
            this.sound = binaryReader.ReadTagReference();
            this.latchedTo = (LatchedTo)binaryReader.ReadInt32();
            this.scale = binaryReader.ReadSingle();
            this.invalidName_ = binaryReader.ReadBytes(32);
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
        internal enum LatchedTo : int
        
        {
            LowGrenadeCount = 1,
            NoGrenadesLeft = 2,
            ThrowOnNoGrenades = 4,
        };
    };
}
