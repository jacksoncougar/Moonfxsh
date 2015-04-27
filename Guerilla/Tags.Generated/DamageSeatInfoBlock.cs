// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class DamageSeatInfoBlock : DamageSeatInfoBlockBase
    {
        public  DamageSeatInfoBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  DamageSeatInfoBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 20, Alignment = 4)]
    public class DamageSeatInfoBlockBase : GuerillaBlock
    {
        internal Moonfish.Tags.StringID seatLabel;
        /// <summary>
        /// 0==no damage, 1==full damage
        /// </summary>
        internal float directDamageScale;
        internal float damageTransferFallOffRadius;
        internal float maximumTransferDamageScale;
        internal float minimumTransferDamageScale;
        
        public override int SerializedSize{get { return 20; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  DamageSeatInfoBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            seatLabel = binaryReader.ReadStringID();
            directDamageScale = binaryReader.ReadSingle();
            damageTransferFallOffRadius = binaryReader.ReadSingle();
            maximumTransferDamageScale = binaryReader.ReadSingle();
            minimumTransferDamageScale = binaryReader.ReadSingle();
        }
        public  DamageSeatInfoBlockBase(): base()
        {
            
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
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
