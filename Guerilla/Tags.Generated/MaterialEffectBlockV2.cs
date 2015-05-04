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
    public partial class MaterialEffectBlockV2 : MaterialEffectBlockV2Base
    {
        public MaterialEffectBlockV2() : base()
        {
        }
    };

    [LayoutAttribute(Size = 24, Alignment = 4)]
    public class MaterialEffectBlockV2Base : GuerillaBlock
    {
        internal OldMaterialEffectMaterialBlock[] oldMaterialsDONOTUSE;
        internal MaterialEffectMaterialBlock[] sounds;
        internal MaterialEffectMaterialBlock[] effects;

        public override int SerializedSize
        {
            get { return 24; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public MaterialEffectBlockV2Base() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<OldMaterialEffectMaterialBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<MaterialEffectMaterialBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<MaterialEffectMaterialBlock>(binaryReader));
            return blamPointers;
        }

        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            oldMaterialsDONOTUSE = ReadBlockArrayData<OldMaterialEffectMaterialBlock>(binaryReader,
                blamPointers.Dequeue());
            sounds = ReadBlockArrayData<MaterialEffectMaterialBlock>(binaryReader, blamPointers.Dequeue());
            effects = ReadBlockArrayData<MaterialEffectMaterialBlock>(binaryReader, blamPointers.Dequeue());
        }

        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
            using (binaryWriter.BaseStream.Pin())
            {
                nextAddress = Guerilla.WriteBlockArray<OldMaterialEffectMaterialBlock>(binaryWriter,
                    oldMaterialsDONOTUSE, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<MaterialEffectMaterialBlock>(binaryWriter, sounds, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<MaterialEffectMaterialBlock>(binaryWriter, effects, nextAddress);
                return nextAddress;
            }
        }
    };
}