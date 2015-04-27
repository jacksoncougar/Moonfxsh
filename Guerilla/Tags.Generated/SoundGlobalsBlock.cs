// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class SoundGlobalsBlock : SoundGlobalsBlockBase
    {
        public  SoundGlobalsBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  SoundGlobalsBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 36, Alignment = 4)]
    public class SoundGlobalsBlockBase : GuerillaBlock
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
        
        public override int SerializedSize{get { return 36; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  SoundGlobalsBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            soundClasses = binaryReader.ReadTagReference();
            soundEffects = binaryReader.ReadTagReference();
            soundMix = binaryReader.ReadTagReference();
            soundCombatDialogueConstants = binaryReader.ReadTagReference();
            invalidName_ = binaryReader.ReadInt32();
        }
        public  SoundGlobalsBlockBase(): base()
        {
            
        }
        public void Read(BinaryReader binaryReader)
        {
            soundClasses = binaryReader.ReadTagReference();
            soundEffects = binaryReader.ReadTagReference();
            soundMix = binaryReader.ReadTagReference();
            soundCombatDialogueConstants = binaryReader.ReadTagReference();
            invalidName_ = binaryReader.ReadInt32();
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(soundClasses);
                binaryWriter.Write(soundEffects);
                binaryWriter.Write(soundMix);
                binaryWriter.Write(soundCombatDialogueConstants);
                binaryWriter.Write(invalidName_);
                return nextAddress;
            }
        }
    };
}
