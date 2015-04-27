// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class ScenarioLightBlock : ScenarioLightBlockBase
    {
        public  ScenarioLightBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  ScenarioLightBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 108, Alignment = 4)]
    public class ScenarioLightBlockBase : GuerillaBlock
    {
        internal Moonfish.Tags.ShortBlockIndex1 type;
        internal Moonfish.Tags.ShortBlockIndex1 name;
        internal ScenarioObjectDatumStructBlock objectData;
        internal ScenarioDeviceStructBlock deviceData;
        internal ScenarioLightStructBlock lightData;
        
        public override int SerializedSize{get { return 108; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  ScenarioLightBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            type = binaryReader.ReadShortBlockIndex1();
            name = binaryReader.ReadShortBlockIndex1();
            objectData = new ScenarioObjectDatumStructBlock(binaryReader);
            deviceData = new ScenarioDeviceStructBlock(binaryReader);
            lightData = new ScenarioLightStructBlock(binaryReader);
        }
        public  ScenarioLightBlockBase(): base()
        {
            
        }
        public void Read(BinaryReader binaryReader)
        {
            type = binaryReader.ReadShortBlockIndex1();
            name = binaryReader.ReadShortBlockIndex1();
            objectData = new ScenarioObjectDatumStructBlock(binaryReader);
            deviceData = new ScenarioDeviceStructBlock(binaryReader);
            lightData = new ScenarioLightStructBlock(binaryReader);
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(type);
                binaryWriter.Write(name);
                objectData.Write(binaryWriter);
                deviceData.Write(binaryWriter);
                lightData.Write(binaryWriter);
                return nextAddress;
            }
        }
    };
}
