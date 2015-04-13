using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class SoundGlobalsBlock : SoundGlobalsBlockBase
    {
        public  SoundGlobalsBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 36)]
    public class SoundGlobalsBlockBase
    {
        [TagReference("sncl")]
        internal Moonfish.Tags.TagReference soundClasses;
        [TagReference("sfx+")]
        internal Moonfish.Tags.TagReference soundEffects;
        [TagReference("snmx")]
        internal Moonfish.Tags.TagReference soundMix;
        [TagReference("spk!")]
        internal Moonfish.Tags.TagReference soundCombatDialogueConstants;
        internal int invalidName_;
        internal  SoundGlobalsBlockBase(BinaryReader binaryReader)
        {
            this.soundClasses = binaryReader.ReadTagReference();
            this.soundEffects = binaryReader.ReadTagReference();
            this.soundMix = binaryReader.ReadTagReference();
            this.soundCombatDialogueConstants = binaryReader.ReadTagReference();
            this.invalidName_ = binaryReader.ReadInt32();
        }
        internal  virtual byte[] ReadData(BinaryReader binaryReader)
        {
            var blamPointer = binaryReader.ReadBlamPointer(1);
            var data = new byte[blamPointer.elementCount];
            if(blamPointer.elementCount > 0)
            {
                using (binaryReader.BaseStream.Pin())
                {
                    binaryReader.BaseStream.Position = blamPointer[0];
                    data = binaryReader.ReadBytes(blamPointer.elementCount);
                }
            }
            return data;
        }
    };
}
