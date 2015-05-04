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
    public partial class WeaponInterfaceStructBlock : WeaponInterfaceStructBlockBase
    {
        public WeaponInterfaceStructBlock() : base()
        {
        }
    };
    [LayoutAttribute(Size = 32, Alignment = 4)]
    public class WeaponInterfaceStructBlockBase : GuerillaBlock
    {
        internal WeaponSharedInterfaceStructBlock sharedInterface;
        internal WeaponFirstPersonInterfaceBlock[] firstPerson;
        [TagReference("nhdt")]
        internal Moonfish.Tags.TagReference newHudInterface;
        public override int SerializedSize { get { return 32; } }
        public override int Alignment { get { return 4; } }
        public WeaponInterfaceStructBlockBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            sharedInterface = new WeaponSharedInterfaceStructBlock();
            blamPointers.Concat(sharedInterface.ReadFields(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<WeaponFirstPersonInterfaceBlock>(binaryReader));
            newHudInterface = binaryReader.ReadTagReference();
            return blamPointers;
        }
        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            sharedInterface.ReadPointers(binaryReader, blamPointers);
            firstPerson = ReadBlockArrayData<WeaponFirstPersonInterfaceBlock>(binaryReader, blamPointers.Dequeue());
        }
        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
using(binaryWriter.BaseStream.Pin())
            {
                sharedInterface.Write(binaryWriter);
                nextAddress = Guerilla.WriteBlockArray<WeaponFirstPersonInterfaceBlock>(binaryWriter, firstPerson, nextAddress);
                binaryWriter.Write(newHudInterface);
                return nextAddress;
            }
        }
    };
}
