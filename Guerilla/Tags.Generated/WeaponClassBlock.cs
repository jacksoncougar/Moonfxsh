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
    public partial class WeaponClassBlock : WeaponClassBlockBase
    {
        public WeaponClassBlock() : base()
        {
        }
    };
    [LayoutAttribute(Size = 20, Alignment = 4)]
    public class WeaponClassBlockBase : GuerillaBlock
    {
        internal Moonfish.Tags.StringIdent label;
        internal WeaponTypeBlock[] weaponTypeAABBCC;
        internal AnimationIkBlock[] weaponIkAABBCC;
        public override int SerializedSize { get { return 20; } }
        public override int Alignment { get { return 4; } }
        public WeaponClassBlockBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            label = binaryReader.ReadStringID();
            blamPointers.Enqueue(ReadBlockArrayPointer<WeaponTypeBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<AnimationIkBlock>(binaryReader));
            return blamPointers;
        }
        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            weaponTypeAABBCC = ReadBlockArrayData<WeaponTypeBlock>(binaryReader, blamPointers.Dequeue());
            weaponIkAABBCC = ReadBlockArrayData<AnimationIkBlock>(binaryReader, blamPointers.Dequeue());
        }
        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(label);
                nextAddress = Guerilla.WriteBlockArray<WeaponTypeBlock>(binaryWriter, weaponTypeAABBCC, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<AnimationIkBlock>(binaryWriter, weaponIkAABBCC, nextAddress);
                return nextAddress;
            }
        }
    };
}
