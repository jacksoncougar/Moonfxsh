// ReSharper disable All
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
    [LayoutAttribute(Size = 36, Alignment = 4)]
    public class SoundGlobalsBlockBase  : IGuerilla
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
            soundClasses = binaryReader.ReadTagReference();
            soundEffects = binaryReader.ReadTagReference();
            soundMix = binaryReader.ReadTagReference();
            soundCombatDialogueConstants = binaryReader.ReadTagReference();
            invalidName_ = binaryReader.ReadInt32();
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(soundClasses);
                binaryWriter.Write(soundEffects);
                binaryWriter.Write(soundMix);
                binaryWriter.Write(soundCombatDialogueConstants);
                binaryWriter.Write(invalidName_);
                return nextAddress = (int)binaryWriter.BaseStream.Position;
            }
        }
    };
}
