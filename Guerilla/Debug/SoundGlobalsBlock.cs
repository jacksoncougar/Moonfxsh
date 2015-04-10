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
        public  SoundGlobalsBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
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
        internal  SoundGlobalsBlockBase(System.IO.BinaryReader binaryReader)
        {
            soundClasses = binaryReader.ReadTagReference();
            soundEffects = binaryReader.ReadTagReference();
            soundMix = binaryReader.ReadTagReference();
            soundCombatDialogueConstants = binaryReader.ReadTagReference();
            invalidName_ = binaryReader.ReadInt32();
        }
        internal  virtual byte[] ReadData(System.IO.BinaryReader binaryReader)
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
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(soundClasses);
                binaryWriter.Write(soundEffects);
                binaryWriter.Write(soundMix);
                binaryWriter.Write(soundCombatDialogueConstants);
                binaryWriter.Write(invalidName_);
            }
        }
    };
}
