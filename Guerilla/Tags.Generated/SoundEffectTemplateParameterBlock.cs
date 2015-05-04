// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Moonfish.Guerilla.Tags
{
    public partial class SoundEffectTemplateParameterBlock : SoundEffectTemplateParameterBlockBase
    {
        public SoundEffectTemplateParameterBlock() : base()
        {
        }
    };
    [LayoutAttribute(Size = 36, Alignment = 4)]
    public class SoundEffectTemplateParameterBlockBase : GuerillaBlock
    {
        internal Moonfish.Tags.StringIdent name;
        internal Type type;
        internal Flags flags;
        internal int hardwareOffset;
        internal int defaultEnumIntegerValue;
        internal float defaultScalarValue;
        internal MappingFunctionBlock defaultFunction;
        internal float minimumScalarValue;
        internal float maximumScalarValue;
        public override int SerializedSize { get { return 36; } }
        public override int Alignment { get { return 4; } }
        public SoundEffectTemplateParameterBlockBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            name = binaryReader.ReadStringID();
            type = (Type)binaryReader.ReadInt16();
            flags = (Flags)binaryReader.ReadInt16();
            hardwareOffset = binaryReader.ReadInt32();
            defaultEnumIntegerValue = binaryReader.ReadInt32();
            defaultScalarValue = binaryReader.ReadSingle();
            defaultFunction = new MappingFunctionBlock();
            blamPointers.Concat(defaultFunction.ReadFields(binaryReader));
            minimumScalarValue = binaryReader.ReadSingle();
            maximumScalarValue = binaryReader.ReadSingle();
            return blamPointers;
        }
        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            defaultFunction.ReadPointers(binaryReader, blamPointers);
        }
        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
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
                return nextAddress;
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
