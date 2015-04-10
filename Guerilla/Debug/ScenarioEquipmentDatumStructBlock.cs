// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class ScenarioEquipmentDatumStructBlock : ScenarioEquipmentDatumStructBlockBase
    {
        public  ScenarioEquipmentDatumStructBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 4)]
    public class ScenarioEquipmentDatumStructBlockBase
    {
        internal EquipmentFlags equipmentFlags;
        internal  ScenarioEquipmentDatumStructBlockBase(System.IO.BinaryReader binaryReader)
        {
            equipmentFlags = (EquipmentFlags)binaryReader.ReadInt32();
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
                binaryWriter.Write((Int32)equipmentFlags);
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
