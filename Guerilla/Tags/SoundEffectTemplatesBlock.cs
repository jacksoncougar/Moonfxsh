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
        public  SoundEffectTemplatesBlock(BinaryReader binaryReader): base(binaryReader)
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
        internal  SoundEffectTemplatesBlockBase(BinaryReader binaryReader)
        {
            this.dspEffect = binaryReader.ReadStringID();
            this.explanation = ReadData(binaryReader);
            this.flags = (Flags)binaryReader.ReadInt32();
            this.invalidName_ = binaryReader.ReadInt16();
            this.invalidName_0 = binaryReader.ReadInt16();
            this.parameters = ReadSoundEffectTemplateParameterBlockArray(binaryReader);
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
        internal  virtual SoundEffectTemplateParameterBlock[] ReadSoundEffectTemplateParameterBlockArray(BinaryReader binaryReader)
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
        [FlagsAttribute]
        internal enum Flags : int
        
        {
            UseHighLevelParameters = 1,
            CustomParameters = 2,
        };
    };
}
