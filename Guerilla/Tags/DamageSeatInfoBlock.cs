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
        public  DamageSeatInfoBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 20, Alignment = 4)]
    public class DamageSeatInfoBlockBase  : IGuerilla
    {
        internal Moonfish.Tags.StringID seatLabel;
        /// <summary>
        /// 0==no damage, 1==full damage
        /// </summary>
        internal float directDamageScale;
        internal float damageTransferFallOffRadius;
        internal float maximumTransferDamageScale;
        internal float minimumTransferDamageScale;
        internal  DamageSeatInfoBlockBase(BinaryReader binaryReader)
        {
            seatLabel = binaryReader.ReadStringID();
            directDamageScale = binaryReader.ReadSingle();
            damageTransferFallOffRadius = binaryReader.ReadSingle();
            maximumTransferDamageScale = binaryReader.ReadSingle();
            minimumTransferDamageScale = binaryReader.ReadSingle();
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(seatLabel);
                binaryWriter.Write(directDamageScale);
                binaryWriter.Write(damageTransferFallOffRadius);
                binaryWriter.Write(maximumTransferDamageScale);
                binaryWriter.Write(minimumTransferDamageScale);
                return nextAddress;
            }
        }
    };
}
