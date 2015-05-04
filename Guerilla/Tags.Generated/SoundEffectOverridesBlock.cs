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
    public partial class SoundEffectOverridesBlock : SoundEffectOverridesBlockBase
    {
        public SoundEffectOverridesBlock() : base()
        {
        }
    };
    [LayoutAttribute(Size = 12, Alignment = 4)]
    public class SoundEffectOverridesBlockBase : GuerillaBlock
    {
        internal Moonfish.Tags.StringIdent name;
        internal SoundEffectOverrideParametersBlock[] overrides;
        public override int SerializedSize { get { return 12; } }
        public override int Alignment { get { return 4; } }
        public SoundEffectOverridesBlockBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            name = binaryReader.ReadStringID();
            blamPointers.Enqueue(ReadBlockArrayPointer<SoundEffectOverrideParametersBlock>(binaryReader));
            return blamPointers;
        }
        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            overrides = ReadBlockArrayData<SoundEffectOverrideParametersBlock>(binaryReader, blamPointers.Dequeue());
        }
        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(name);
                nextAddress = Guerilla.WriteBlockArray<SoundEffectOverrideParametersBlock>(binaryWriter, overrides, nextAddress);
                return nextAddress;
            }
        }
    };
}
