using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    [LayoutAttribute(Size = 20)]
    public  partial class DamageSeatInfoBlock : DamageSeatInfoBlockBase
    {
        public  DamageSeatInfoBlock(BinaryReader binaryReader): base(binaryReader)
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
        internal  DamageSeatInfoBlockBase(BinaryReader binaryReader)
        {
            this.seatLabel = binaryReader.ReadStringID();
            this.directDamageScale = binaryReader.ReadSingle();
            this.damageTransferFallOffRadius = binaryReader.ReadSingle();
            this.maximumTransferDamageScale = binaryReader.ReadSingle();
            this.minimumTransferDamageScale = binaryReader.ReadSingle();
        }
        internal  virtual byte[] ReadData(BinaryReader binaryReader)
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
    };
}
