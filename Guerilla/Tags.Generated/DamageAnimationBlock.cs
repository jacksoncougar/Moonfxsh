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
    public partial class DamageAnimationBlock : DamageAnimationBlockBase
    {
        public DamageAnimationBlock() : base()
        {
        }
    };
    [LayoutAttribute(Size = 12, Alignment = 4)]
    public class DamageAnimationBlockBase : GuerillaBlock
    {
        internal Moonfish.Tags.StringIdent label;
        internal DamageDirectionBlock[] directionsAABBCC;
        public override int SerializedSize { get { return 12; } }
        public override int Alignment { get { return 4; } }
        public DamageAnimationBlockBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            label = binaryReader.ReadStringID();
            blamPointers.Enqueue(ReadBlockArrayPointer<DamageDirectionBlock>(binaryReader));
            return blamPointers;
        }
        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            directionsAABBCC = ReadBlockArrayData<DamageDirectionBlock>(binaryReader, blamPointers.Dequeue());
        }
        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(label);
                nextAddress = Guerilla.WriteBlockArray<DamageDirectionBlock>(binaryWriter, directionsAABBCC, nextAddress);
                return nextAddress;
            }
        }
    };
}
