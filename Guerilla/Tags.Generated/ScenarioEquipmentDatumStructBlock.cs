// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class ScenarioEquipmentDatumStructBlock : ScenarioEquipmentDatumStructBlockBase
    {
        public  ScenarioEquipmentDatumStructBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  ScenarioEquipmentDatumStructBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 4, Alignment = 4)]
    public class ScenarioEquipmentDatumStructBlockBase : GuerillaBlock
    {
        internal EquipmentFlags equipmentFlags;
        
        public override int SerializedSize{get { return 4; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  ScenarioEquipmentDatumStructBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            equipmentFlags = (EquipmentFlags)binaryReader.ReadInt32();
        }
        public  ScenarioEquipmentDatumStructBlockBase(): base()
        {
            
        }
        public void Read(BinaryReader binaryReader)
        {
            equipmentFlags = (EquipmentFlags)binaryReader.ReadInt32();
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
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
