using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class ScenarioVehicleBlock : ScenarioVehicleBlockBase
    {
        public  ScenarioVehicleBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 84)]
    public class ScenarioVehicleBlockBase
    {
        internal Moonfish.Tags.ShortBlockIndex1 type;
        internal Moonfish.Tags.ShortBlockIndex1 name;
        internal ScenarioObjectDatumStructBlock objectData;
        internal byte[] indexer;
        internal ScenarioObjectPermutationStructBlock permutationData;
        internal ScenarioUnitStructBlock unitData;
        internal  ScenarioVehicleBlockBase(BinaryReader binaryReader)
        {
            this.type = binaryReader.ReadShortBlockIndex1();
            this.name = binaryReader.ReadShortBlockIndex1();
            this.objectData = new ScenarioObjectDatumStructBlock(binaryReader);
            this.indexer = binaryReader.ReadBytes(4);
            this.permutationData = new ScenarioObjectPermutationStructBlock(binaryReader);
            this.unitData = new ScenarioUnitStructBlock(binaryReader);
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
