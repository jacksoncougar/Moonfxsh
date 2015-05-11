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
    public partial class WeaponTypeBlock : WeaponTypeBlockBase
    {
        public WeaponTypeBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 52, Alignment = 4)]
    public class WeaponTypeBlockBase : GuerillaBlock
    {
        internal Moonfish.Tags.StringIdent label;
        internal AnimationEntryBlock[] actionsAABBCC;
        internal AnimationEntryBlock[] overlaysAABBCC;
        internal DamageAnimationBlock[] deathAndDamageAABBCC;
        internal AnimationTransitionBlock[] transitionsAABBCC;
        internal PrecacheListBlock[] highPrecacheCCCCC;
        internal PrecacheListBlock[] lowPrecacheCCCCC;

        public override int SerializedSize
        {
            get { return 52; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public WeaponTypeBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            label = binaryReader.ReadStringID();
            blamPointers.Enqueue(ReadBlockArrayPointer<AnimationEntryBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<AnimationEntryBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<DamageAnimationBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<AnimationTransitionBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<PrecacheListBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<PrecacheListBlock>(binaryReader));
            return blamPointers;
        }

        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            actionsAABBCC = ReadBlockArrayData<AnimationEntryBlock>(binaryReader, blamPointers.Dequeue());
            overlaysAABBCC = ReadBlockArrayData<AnimationEntryBlock>(binaryReader, blamPointers.Dequeue());
            deathAndDamageAABBCC = ReadBlockArrayData<DamageAnimationBlock>(binaryReader, blamPointers.Dequeue());
            transitionsAABBCC = ReadBlockArrayData<AnimationTransitionBlock>(binaryReader, blamPointers.Dequeue());
            highPrecacheCCCCC = ReadBlockArrayData<PrecacheListBlock>(binaryReader, blamPointers.Dequeue());
            lowPrecacheCCCCC = ReadBlockArrayData<PrecacheListBlock>(binaryReader, blamPointers.Dequeue());
        }

        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
            using (binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(label);
                nextAddress = Guerilla.WriteBlockArray<AnimationEntryBlock>(binaryWriter, actionsAABBCC, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<AnimationEntryBlock>(binaryWriter, overlaysAABBCC, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<DamageAnimationBlock>(binaryWriter, deathAndDamageAABBCC,
                    nextAddress);
                nextAddress = Guerilla.WriteBlockArray<AnimationTransitionBlock>(binaryWriter, transitionsAABBCC,
                    nextAddress);
                nextAddress = Guerilla.WriteBlockArray<PrecacheListBlock>(binaryWriter, highPrecacheCCCCC, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<PrecacheListBlock>(binaryWriter, lowPrecacheCCCCC, nextAddress);
                return nextAddress;
            }
        }
    };
}