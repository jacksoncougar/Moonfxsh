using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class SoundEffectOverrideParametersBlock : SoundEffectOverrideParametersBlockBase
    {
        public  SoundEffectOverrideParametersBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 32)]
    public class SoundEffectOverrideParametersBlockBase
    {
        internal Moonfish.Tags.StringID name;
        internal Moonfish.Tags.StringID input;
        internal Moonfish.Tags.StringID range;
        internal float timePeriodSeconds;
        internal int integerValue;
        internal float realValue;
        internal MappingFunctionBlock functionValue;
        internal  SoundEffectOverrideParametersBlockBase(BinaryReader binaryReader)
        {
            this.name = binaryReader.ReadStringID();
            this.input = binaryReader.ReadStringID();
            this.range = binaryReader.ReadStringID();
            this.timePeriodSeconds = binaryReader.ReadSingle();
            this.integerValue = binaryReader.ReadInt32();
            this.realValue = binaryReader.ReadSingle();
            this.functionValue = new MappingFunctionBlock(binaryReader);
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
    };
}
