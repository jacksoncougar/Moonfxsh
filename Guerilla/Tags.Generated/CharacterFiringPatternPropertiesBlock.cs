// ReSharper disable All

using Moonfish.Model;

using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Moonfish.Guerilla.Tags
{
    public partial class CharacterFiringPatternPropertiesBlock : CharacterFiringPatternPropertiesBlockBase
    {
        public CharacterFiringPatternPropertiesBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 16, Alignment = 4)]
    public class CharacterFiringPatternPropertiesBlockBase : GuerillaBlock
    {
        [TagReference("weap")] internal Moonfish.Tags.TagReference weapon;
        internal CharacterFiringPatternBlock[] firingPatterns;

        public override int SerializedSize
        {
            get { return 16; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public CharacterFiringPatternPropertiesBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            weapon = binaryReader.ReadTagReference();
            blamPointers.Enqueue(ReadBlockArrayPointer<CharacterFiringPatternBlock>(binaryReader));
            return blamPointers;
        }

        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            firingPatterns = ReadBlockArrayData<CharacterFiringPatternBlock>(binaryReader, blamPointers.Dequeue());
        }

        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
            using (binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(weapon);
                nextAddress = Guerilla.WriteBlockArray<CharacterFiringPatternBlock>(binaryWriter, firingPatterns,
                    nextAddress);
                return nextAddress;
            }
        }
    };
}