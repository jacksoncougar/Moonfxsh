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
    public partial class DamageEffectSoundEffectDefinitionBlock : DamageEffectSoundEffectDefinitionBlockBase
    {
        public DamageEffectSoundEffectDefinitionBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 16, Alignment = 4)]
    public class DamageEffectSoundEffectDefinitionBlockBase : GuerillaBlock
    {
        internal Moonfish.Tags.StringIdent effectName;
        internal float durationSeconds;
        internal MappingFunctionBlock effectScaleFunction;

        public override int SerializedSize
        {
            get { return 16; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public DamageEffectSoundEffectDefinitionBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            effectName = binaryReader.ReadStringID();
            durationSeconds = binaryReader.ReadSingle();
            effectScaleFunction = new MappingFunctionBlock();
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(effectScaleFunction.ReadFields(binaryReader)));
            return blamPointers;
        }

        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            effectScaleFunction.ReadPointers(binaryReader, blamPointers);
        }

        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
            using (binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(effectName);
                binaryWriter.Write(durationSeconds);
                effectScaleFunction.Write(binaryWriter);
                return nextAddress;
            }
        }
    };
}