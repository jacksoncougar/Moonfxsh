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
    public partial class ScenarioEquipmentDatumStructBlock : ScenarioEquipmentDatumStructBlockBase
    {
        public ScenarioEquipmentDatumStructBlock() : base()
        {
        }
    };
    [LayoutAttribute(Size = 4, Alignment = 4)]
    public class ScenarioEquipmentDatumStructBlockBase : GuerillaBlock
    {
        internal EquipmentFlags equipmentFlags;
        public override int SerializedSize { get { return 4; } }
        public override int Alignment { get { return 4; } }
        public ScenarioEquipmentDatumStructBlockBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            equipmentFlags = (EquipmentFlags)binaryReader.ReadInt32();
            return blamPointers;
        }
        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
        }
        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write((Int32)equipmentFlags);
                return nextAddress;
            }
        }
        [FlagsAttribute]
        internal enum EquipmentFlags : int
        {
            InitiallyAtRestDoesNotFall = 1,
            Obsolete = 2,
            DoesAccelerateMovesDueToExplosions = 4,
        };
    };
}
