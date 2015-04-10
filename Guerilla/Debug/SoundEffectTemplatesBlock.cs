// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class SoundEffectTemplatesBlock : SoundEffectTemplatesBlockBase
    {
        public  SoundEffectTemplatesBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 28)]
    public class SoundEffectTemplatesBlockBase
    {
        internal Moonfish.Tags.StringID dspEffect;
        internal byte[] explanation;
        internal Flags flags;
        internal short invalidName_;
        internal short invalidName_0;
        internal SoundEffectTemplateParameterBlock[] parameters;
        internal  SoundEffectTemplatesBlockBase(System.IO.BinaryReader binaryReader)
        {
            dspEffect = binaryReader.ReadStringID();
            explanation = ReadData(binaryReader);
            flags = (Flags)binaryReader.ReadInt32();
            invalidName_ = binaryReader.ReadInt16();
            invalidName_0 = binaryReader.ReadInt16();
            ReadSoundEffectTemplateParameterBlockArray(binaryReader);
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
        internal  virtual SoundEffectTemplateParameterBlock[] ReadSoundEffectTemplateParameterBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(SoundEffectTemplateParameterBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new SoundEffectTemplateParameterBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new SoundEffectTemplateParameterBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteSoundEffectTemplateParameterBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(dspEffect);
                WriteData(binaryWriter);
                binaryWriter.Write((Int32)flags);
                binaryWriter.Write(invalidName_);
                binaryWriter.Write(invalidName_0);
                WriteSoundEffectTemplateParameterBlockArray(binaryWriter);
            }
        }
        [FlagsAttribute]
        internal enum Flags : int
        
        {
            UseHighLevelParameters = 1,
            CustomParameters = 2,
        };
    };
}
