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
    public partial class WeaponTriggerAutofireStructBlock : WeaponTriggerAutofireStructBlockBase
    {
        public WeaponTriggerAutofireStructBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 12, Alignment = 4)]
    public class WeaponTriggerAutofireStructBlockBase : GuerillaBlock
    {
        internal float autofireTime;
        internal float autofireThrow;
        internal SecondaryAction secondaryAction;
        internal PrimaryAction primaryAction;

        public override int SerializedSize
        {
            get { return 12; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public WeaponTriggerAutofireStructBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            autofireTime = binaryReader.ReadSingle();
            autofireThrow = binaryReader.ReadSingle();
            secondaryAction = (SecondaryAction) binaryReader.ReadInt16();
            primaryAction = (PrimaryAction) binaryReader.ReadInt16();
            return blamPointers;
        }

        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
        }

        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
            using (binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(autofireTime);
                binaryWriter.Write(autofireThrow);
                binaryWriter.Write((Int16) secondaryAction);
                binaryWriter.Write((Int16) primaryAction);
                return nextAddress;
            }
        }

        internal enum SecondaryAction : short
        {
            Fire = 0,
            Charge = 1,
            Track = 2,
            FireOther = 3,
        };

        internal enum PrimaryAction : short
        {
            Fire = 0,
            Charge = 1,
            Track = 2,
            FireOther = 3,
        };
    };
}