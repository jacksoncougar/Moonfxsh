// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class ScenarioMachineBlock : ScenarioMachineBlockBase
    {
        public  ScenarioMachineBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  ScenarioMachineBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 72, Alignment = 4)]
    public class ScenarioMachineBlockBase : GuerillaBlock
    {
        internal Moonfish.Tags.ShortBlockIndex1 type;
        internal Moonfish.Tags.ShortBlockIndex1 name;
        internal ScenarioObjectDatumStructBlock objectData;
        internal ScenarioDeviceStructBlock deviceData;
        internal ScenarioMachineStructV3Block machineData;
        
        public override int SerializedSize{get { return 72; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  ScenarioMachineBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            type = binaryReader.ReadShortBlockIndex1();
            name = binaryReader.ReadShortBlockIndex1();
            objectData = new ScenarioObjectDatumStructBlock(binaryReader);
            deviceData = new ScenarioDeviceStructBlock(binaryReader);
            machineData = new ScenarioMachineStructV3Block(binaryReader);
        }
        public  ScenarioMachineBlockBase(): base()
        {
            
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(type);
                binaryWriter.Write(name);
                objectData.Write(binaryWriter);
                deviceData.Write(binaryWriter);
                machineData.Write(binaryWriter);
                return nextAddress;
            }
        }
    };
}
