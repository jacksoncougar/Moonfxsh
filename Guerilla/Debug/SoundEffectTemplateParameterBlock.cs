// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class SoundEffectTemplateParameterBlock : SoundEffectTemplateParameterBlockBase
    {
        public  SoundEffectTemplateParameterBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 36)]
    public class SoundEffectTemplateParameterBlockBase
    {
        internal Moonfish.Tags.StringID name;
        internal Type type;
        internal Flags flags;
        internal int hardwareOffset;
        internal int defaultEnumIntegerValue;
        internal float defaultScalarValue;
        internal MappingFunctionBlock defaultFunction;
        internal float minimumScalarValue;
        internal float maximumScalarValue;
        internal  SoundEffectTemplateParameterBlockBase(System.IO.BinaryReader binaryReader)
        {
            name = binaryReader.ReadStringID();
            type = (Type)binaryReader.ReadInt16();
            flags = (Flags)binaryReader.ReadInt16();
            hardwareOffset = binaryReader.ReadInt32();
            defaultEnumIntegerValue = binaryReader.ReadInt32();
            defaultScalarValue = binaryReader.ReadSingle();
            defaultFunction = new MappingFunctionBlock(binaryReader);
            minimumScalarValue = binaryReader.ReadSingle();
            maximumScalarValue = binaryReader.ReadSingle();
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
                binaryWriter.Write((Int16)type);
                binaryWriter.Write((Int16)flags);
                binaryWriter.Write(hardwareOffset);
                binaryWriter.Write(defaultEnumIntegerValue);
                binaryWriter.Write(defaultScalarValue);
                defaultFunction.Write(binaryWriter);
                binaryWriter.Write(minimumScalarValue);
                binaryWriter.Write(maximumScalarValue);
            }
        }
        internal enum Type : short
        
        {
            Integer = 0,
            Real = 1,
            FilterType = 2,
        };
        [FlagsAttribute]
        internal enum Flags : short
        
        {
            ExposeAsFunction = 1,
        };
    };
}
