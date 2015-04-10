// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class DamageSeatInfoBlock : DamageSeatInfoBlockBase
    {
        public  DamageSeatInfoBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 20)]
    public class DamageSeatInfoBlockBase
    {
        internal Moonfish.Tags.StringID seatLabel;
        /// <summary>
        /// 0==no damage, 1==full damage
        /// </summary>
        internal float directDamageScale;
        internal float damageTransferFallOffRadius;
        internal float maximumTransferDamageScale;
        internal float minimumTransferDamageScale;
        internal  DamageSeatInfoBlockBase(System.IO.BinaryReader binaryReader)
        {
            seatLabel = binaryReader.ReadStringID();
            directDamageScale = binaryReader.ReadSingle();
            damageTransferFallOffRadius = binaryReader.ReadSingle();
            maximumTransferDamageScale = binaryReader.ReadSingle();
            minimumTransferDamageScale = binaryReader.ReadSingle();
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
                binaryWriter.Write(seatLabel);
                binaryWriter.Write(directDamageScale);
                binaryWriter.Write(damageTransferFallOffRadius);
                binaryWriter.Write(maximumTransferDamageScale);
                binaryWriter.Write(minimumTransferDamageScale);
            }
        }
    };
}
