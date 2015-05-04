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
    public partial class DamageSeatInfoBlock : DamageSeatInfoBlockBase
    {
        public DamageSeatInfoBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 20, Alignment = 4)]
    public class DamageSeatInfoBlockBase : GuerillaBlock
    {
        internal Moonfish.Tags.StringIdent seatLabel;

        /// <summary>
        /// 0==no damage, 1==full damage
        /// </summary>
        internal float directDamageScale;

        internal float damageTransferFallOffRadius;
        internal float maximumTransferDamageScale;
        internal float minimumTransferDamageScale;

        public override int SerializedSize
        {
            get { return 20; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public DamageSeatInfoBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            seatLabel = binaryReader.ReadStringID();
            directDamageScale = binaryReader.ReadSingle();
            damageTransferFallOffRadius = binaryReader.ReadSingle();
            maximumTransferDamageScale = binaryReader.ReadSingle();
            minimumTransferDamageScale = binaryReader.ReadSingle();
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