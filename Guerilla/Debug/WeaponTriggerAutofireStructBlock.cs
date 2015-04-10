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
        public  WeaponTriggerAutofireStructBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 12)]
    public class WeaponTriggerAutofireStructBlockBase
    {
        internal float autofireTime;
        internal float autofireThrow;
        internal SecondaryAction secondaryAction;
        internal PrimaryAction primaryAction;
        internal  WeaponTriggerAutofireStructBlockBase(System.IO.BinaryReader binaryReader)
        {
            autofireTime = binaryReader.ReadSingle();
            autofireThrow = binaryReader.ReadSingle();
            secondaryAction = (SecondaryAction)binaryReader.ReadInt16();
            primaryAction = (PrimaryAction)binaryReader.ReadInt16();
        }
        internal  virtual byte[] ReadData(System.IO.BinaryReader binaryReader)
        {
            var blamPointer = binaryReader.ReadBlamPointer(1);
            var data = new byte[blamPointer.Count];
            if(blamPointer.Count > 0)
            {
                using (binaryReader.BaseStream.Pin())
                {
                    binaryReader.BaseStream.Position = blamPointer[0];
                    data = binaryReader.ReadBytes(blamPointer.Count);
                }
            }
            return data;
        }
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(autofireTime);
                binaryWriter.Write(autofireThrow);
                binaryWriter.Write((Int16)secondaryAction);
                binaryWriter.Write((Int16)primaryAction);
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
