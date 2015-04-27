// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class WeaponTriggerAutofireStructBlock : WeaponTriggerAutofireStructBlockBase
    {
        public  WeaponTriggerAutofireStructBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  WeaponTriggerAutofireStructBlock(): base()
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
        
        public override int SerializedSize{get { return 12; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  WeaponTriggerAutofireStructBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            autofireTime = binaryReader.ReadSingle();
            autofireThrow = binaryReader.ReadSingle();
            secondaryAction = (SecondaryAction)binaryReader.ReadInt16();
            primaryAction = (PrimaryAction)binaryReader.ReadInt16();
        }
        public  WeaponTriggerAutofireStructBlockBase(): base()
        {
            
        }
        public void Read(BinaryReader binaryReader)
        {
            autofireTime = binaryReader.ReadSingle();
            autofireThrow = binaryReader.ReadSingle();
            secondaryAction = (SecondaryAction)binaryReader.ReadInt16();
            primaryAction = (PrimaryAction)binaryReader.ReadInt16();
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(autofireTime);
                binaryWriter.Write(autofireThrow);
                binaryWriter.Write((Int16)secondaryAction);
                binaryWriter.Write((Int16)primaryAction);
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
