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
    public partial class SoundEffectOverrideParametersBlock : SoundEffectOverrideParametersBlockBase
    {
        public SoundEffectOverrideParametersBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 32, Alignment = 4)]
    public class SoundEffectOverrideParametersBlockBase : GuerillaBlock
    {
        internal Moonfish.Tags.StringIdent name;
        internal Moonfish.Tags.StringIdent input;
        internal Moonfish.Tags.StringIdent range;
        internal float timePeriodSeconds;
        internal int integerValue;
        internal float realValue;
        internal MappingFunctionBlock functionValue;

        public override int SerializedSize
        {
            get { return 32; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public SoundEffectOverrideParametersBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            name = binaryReader.ReadStringID();
            input = binaryReader.ReadStringID();
            range = binaryReader.ReadStringID();
            timePeriodSeconds = binaryReader.ReadSingle();
            integerValue = binaryReader.ReadInt32();
            realValue = binaryReader.ReadSingle();
            functionValue = new MappingFunctionBlock();
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(functionValue.ReadFields(binaryReader)));
            return blamPointers;
        }

        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            functionValue.ReadPointers(binaryReader, blamPointers);
        }

        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
            using (binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(name);
                binaryWriter.Write(input);
                binaryWriter.Write(range);
                binaryWriter.Write(timePeriodSeconds);
                binaryWriter.Write(integerValue);
                binaryWriter.Write(realValue);
                functionValue.Write(binaryWriter);
                return nextAddress;
            }
        }
    };
}