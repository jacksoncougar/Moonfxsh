// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Moonfish.Tags
{
    public partial struct TagClass
    {
        public static readonly TagClass Foot = (TagClass)"foot";
    };
};

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("foot")]
    public partial class MaterialEffectsBlock : MaterialEffectsBlockBase
    {
        public MaterialEffectsBlock() : base()
        {
        }
    };
    [LayoutAttribute(Size = 8, Alignment = 4)]
    public class MaterialEffectsBlockBase : GuerillaBlock
    {
        internal MaterialEffectBlockV2[] effects;
        public override int SerializedSize { get { return 8; } }
        public override int Alignment { get { return 4; } }
        public MaterialEffectsBlockBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<MaterialEffectBlockV2>(binaryReader));
            return blamPointers;
        }
        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            effects = ReadBlockArrayData<MaterialEffectBlockV2>(binaryReader, blamPointers.Dequeue());
        }
        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
using(binaryWriter.BaseStream.Pin())
            {
                nextAddress = Guerilla.WriteBlockArray<MaterialEffectBlockV2>(binaryWriter, effects, nextAddress);
                return nextAddress;
            }
        }
    };
}
