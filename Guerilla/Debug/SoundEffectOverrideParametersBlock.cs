// ReSharper disable All
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
        public  SoundEffectOverrideParametersBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
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
        internal  SoundEffectOverrideParametersBlockBase(System.IO.BinaryReader binaryReader)
        {
            name = binaryReader.ReadStringID();
            input = binaryReader.ReadStringID();
            range = binaryReader.ReadStringID();
            timePeriodSeconds = binaryReader.ReadSingle();
            integerValue = binaryReader.ReadInt32();
            realValue = binaryReader.ReadSingle();
            functionValue = new MappingFunctionBlock(binaryReader);
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
                binaryWriter.Write(name);
                binaryWriter.Write(input);
                binaryWriter.Write(range);
                binaryWriter.Write(timePeriodSeconds);
                binaryWriter.Write(integerValue);
                binaryWriter.Write(realValue);
                functionValue.Write(binaryWriter);
            }
        }
    };
}
