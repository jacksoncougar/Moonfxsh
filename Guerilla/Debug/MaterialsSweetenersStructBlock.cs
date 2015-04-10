// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class MaterialsSweetenersStructBlock : MaterialsSweetenersStructBlockBase
    {
        public  MaterialsSweetenersStructBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 116)]
    public class MaterialsSweetenersStructBlockBase
    {
        [TagReference("snd!")]
        internal Moonfish.Tags.TagReference soundSweetenerSmall;
        [TagReference("snd!")]
        internal Moonfish.Tags.TagReference soundSweetenerMedium;
        [TagReference("snd!")]
        internal Moonfish.Tags.TagReference soundSweetenerLarge;
        [TagReference("lsnd")]
        internal Moonfish.Tags.TagReference soundSweetenerRolling;
        [TagReference("lsnd")]
        internal Moonfish.Tags.TagReference soundSweetenerGrinding;
        [TagReference("snd!")]
        internal Moonfish.Tags.TagReference soundSweetenerMelee;
        [TagReference("null")]
        internal Moonfish.Tags.TagReference invalidName_;
        [TagReference("effe")]
        internal Moonfish.Tags.TagReference effectSweetenerSmall;
        [TagReference("effe")]
        internal Moonfish.Tags.TagReference effectSweetenerMedium;
        [TagReference("effe")]
        internal Moonfish.Tags.TagReference effectSweetenerLarge;
        [TagReference("effe")]
        internal Moonfish.Tags.TagReference effectSweetenerRolling;
        [TagReference("effe")]
        internal Moonfish.Tags.TagReference effectSweetenerGrinding;
        [TagReference("effe")]
        internal Moonfish.Tags.TagReference effectSweetenerMelee;
        [TagReference("null")]
        internal Moonfish.Tags.TagReference invalidName_0;
        internal SweetenerInheritanceFlags sweetenerInheritanceFlags;
        internal  MaterialsSweetenersStructBlockBase(System.IO.BinaryReader binaryReader)
        {
            soundSweetenerSmall = binaryReader.ReadTagReference();
            soundSweetenerMedium = binaryReader.ReadTagReference();
            soundSweetenerLarge = binaryReader.ReadTagReference();
            soundSweetenerRolling = binaryReader.ReadTagReference();
            soundSweetenerGrinding = binaryReader.ReadTagReference();
            soundSweetenerMelee = binaryReader.ReadTagReference();
            invalidName_ = binaryReader.ReadTagReference();
            effectSweetenerSmall = binaryReader.ReadTagReference();
            effectSweetenerMedium = binaryReader.ReadTagReference();
            effectSweetenerLarge = binaryReader.ReadTagReference();
            effectSweetenerRolling = binaryReader.ReadTagReference();
            effectSweetenerGrinding = binaryReader.ReadTagReference();
            effectSweetenerMelee = binaryReader.ReadTagReference();
            invalidName_0 = binaryReader.ReadTagReference();
            sweetenerInheritanceFlags = (SweetenerInheritanceFlags)binaryReader.ReadInt32();
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
                binaryWriter.Write(soundSweetenerSmall);
                binaryWriter.Write(soundSweetenerMedium);
                binaryWriter.Write(soundSweetenerLarge);
                binaryWriter.Write(soundSweetenerRolling);
                binaryWriter.Write(soundSweetenerGrinding);
                binaryWriter.Write(soundSweetenerMelee);
                binaryWriter.Write(invalidName_);
                binaryWriter.Write(effectSweetenerSmall);
                binaryWriter.Write(effectSweetenerMedium);
                binaryWriter.Write(effectSweetenerLarge);
                binaryWriter.Write(effectSweetenerRolling);
                binaryWriter.Write(effectSweetenerGrinding);
                binaryWriter.Write(effectSweetenerMelee);
                binaryWriter.Write(invalidName_0);
                binaryWriter.Write((Int32)sweetenerInheritanceFlags);
            }
        }
        [FlagsAttribute]
        internal enum SweetenerInheritanceFlags : int
        
        {
            SoundSmall = 1,
            SoundMedium = 2,
            SoundLarge = 4,
            SoundRolling = 8,
            SoundGrinding = 16,
            SoundMelee = 32,
            InvalidName = 64,
            EffectSmall = 128,
            EffectMedium = 256,
            EffectLarge = 512,
            EffectRolling = 1024,
            EffectGrinding = 2048,
            EffectMelee = 4096,
            InvalidName0 = 8192,
        };
    };
}
