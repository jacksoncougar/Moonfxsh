// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class WeaponTypeBlock : WeaponTypeBlockBase
    {
        public  WeaponTypeBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 52, Alignment = 4)]
    public class WeaponTypeBlockBase  : IGuerilla
    {
        internal Moonfish.Tags.StringID label;
        internal AnimationEntryBlock[] actionsAABBCC;
        internal AnimationEntryBlock[] overlaysAABBCC;
        internal DamageAnimationBlock[] deathAndDamageAABBCC;
        internal AnimationTransitionBlock[] transitionsAABBCC;
        internal PrecacheListBlock[] highPrecacheCCCCC;
        internal PrecacheListBlock[] lowPrecacheCCCCC;
        internal  WeaponTypeBlockBase(BinaryReader binaryReader)
        {
            label = binaryReader.ReadStringID();
            actionsAABBCC = Guerilla.ReadBlockArray<AnimationEntryBlock>(binaryReader);
            overlaysAABBCC = Guerilla.ReadBlockArray<AnimationEntryBlock>(binaryReader);
            deathAndDamageAABBCC = Guerilla.ReadBlockArray<DamageAnimationBlock>(binaryReader);
            transitionsAABBCC = Guerilla.ReadBlockArray<AnimationTransitionBlock>(binaryReader);
            highPrecacheCCCCC = Guerilla.ReadBlockArray<PrecacheListBlock>(binaryReader);
            lowPrecacheCCCCC = Guerilla.ReadBlockArray<PrecacheListBlock>(binaryReader);
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(label);
                nextAddress = Guerilla.WriteBlockArray<AnimationEntryBlock>(binaryWriter, actionsAABBCC, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<AnimationEntryBlock>(binaryWriter, overlaysAABBCC, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<DamageAnimationBlock>(binaryWriter, deathAndDamageAABBCC, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<AnimationTransitionBlock>(binaryWriter, transitionsAABBCC, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<PrecacheListBlock>(binaryWriter, highPrecacheCCCCC, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<PrecacheListBlock>(binaryWriter, lowPrecacheCCCCC, nextAddress);
                return nextAddress = (int)binaryWriter.BaseStream.Position;
            }
        }
    };
}
