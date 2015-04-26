// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class ScenarioLightFixtureBlock : ScenarioLightFixtureBlockBase
    {
        public  ScenarioLightFixtureBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 84, Alignment = 4)]
    public class ScenarioLightFixtureBlockBase  : IGuerilla
    {
        internal Moonfish.Tags.ShortBlockIndex1 type;
        internal Moonfish.Tags.ShortBlockIndex1 name;
        internal ScenarioObjectDatumStructBlock objectData;
        internal ScenarioDeviceStructBlock deviceData;
        internal ScenarioLightFixtureStructBlock lightFixtureData;
        internal  ScenarioLightFixtureBlockBase(BinaryReader binaryReader)
        {
            type = binaryReader.ReadShortBlockIndex1();
            name = binaryReader.ReadShortBlockIndex1();
            objectData = new ScenarioObjectDatumStructBlock(binaryReader);
            deviceData = new ScenarioDeviceStructBlock(binaryReader);
            lightFixtureData = new ScenarioLightFixtureStructBlock(binaryReader);
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(type);
                binaryWriter.Write(name);
                objectData.Write(binaryWriter);
                deviceData.Write(binaryWriter);
                lightFixtureData.Write(binaryWriter);
                return nextAddress;
            }
        }
    };
}
