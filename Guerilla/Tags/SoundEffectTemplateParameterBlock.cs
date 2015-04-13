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
        public  SoundEffectTemplateParameterBlock(BinaryReader binaryReader): base(binaryReader)
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
        internal  SoundEffectTemplateParameterBlockBase(BinaryReader binaryReader)
        {
            this.name = binaryReader.ReadStringID();
            this.type = (Type)binaryReader.ReadInt16();
            this.flags = (Flags)binaryReader.ReadInt16();
            this.hardwareOffset = binaryReader.ReadInt32();
            this.defaultEnumIntegerValue = binaryReader.ReadInt32();
            this.defaultScalarValue = binaryReader.ReadSingle();
            this.defaultFunction = new MappingFunctionBlock(binaryReader);
            this.minimumScalarValue = binaryReader.ReadSingle();
            this.maximumScalarValue = binaryReader.ReadSingle();
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
