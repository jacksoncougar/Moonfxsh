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
    public partial class AnimationModeBlock : AnimationModeBlockBase
    {
        public AnimationModeBlock() : base()
        {
        }
    };
    [LayoutAttribute(Size = 20, Alignment = 4)]
    public class AnimationModeBlockBase : GuerillaBlock
    {
        internal Moonfish.Tags.StringIdent label;
        internal WeaponClassBlock[] weaponClassAABBCC;
        internal AnimationIkBlock[] modeIkAABBCC;
        public override int SerializedSize { get { return 20; } }
        public override int Alignment { get { return 4; } }
        public AnimationModeBlockBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            label = binaryReader.ReadStringID();
            blamPointers.Enqueue(ReadBlockArrayPointer<WeaponClassBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<AnimationIkBlock>(binaryReader));
            return blamPointers;
        }
        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            weaponClassAABBCC = ReadBlockArrayData<WeaponClassBlock>(binaryReader, blamPointers.Dequeue());
            modeIkAABBCC = ReadBlockArrayData<AnimationIkBlock>(binaryReader, blamPointers.Dequeue());
        }
        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(label);
                nextAddress = Guerilla.WriteBlockArray<WeaponClassBlock>(binaryWriter, weaponClassAABBCC, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<AnimationIkBlock>(binaryWriter, modeIkAABBCC, nextAddress);
                return nextAddress;
            }
        }
    };
}
