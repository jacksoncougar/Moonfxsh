// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class WeaponTriggerAutofireStructBlock : WeaponTriggerAutofireStructBlockBase
    {
        public  WeaponTriggerAutofireStructBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 12, Alignment = 4)]
    public class WeaponTriggerAutofireStructBlockBase  : IGuerilla
    {
        internal float autofireTime;
        internal float autofireThrow;
        internal SecondaryAction secondaryAction;
        internal PrimaryAction primaryAction;
        internal  WeaponTriggerAutofireStructBlockBase(BinaryReader binaryReader)
        {
            autofireTime = binaryReader.ReadSingle();
            autofireThrow = binaryReader.ReadSingle();
            secondaryAction = (SecondaryAction)binaryReader.ReadInt16();
            primaryAction = (PrimaryAction)binaryReader.ReadInt16();
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(autofireTime);
                binaryWriter.Write(autofireThrow);
                binaryWriter.Write((Int16)secondaryAction);
                binaryWriter.Write((Int16)primaryAction);
                return nextAddress = (int)binaryWriter.BaseStream.Position;
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
