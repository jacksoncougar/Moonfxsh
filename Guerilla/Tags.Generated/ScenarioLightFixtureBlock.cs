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
    public partial class ScenarioLightFixtureBlock : ScenarioLightFixtureBlockBase
    {
        public ScenarioLightFixtureBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 84, Alignment = 4)]
    public class ScenarioLightFixtureBlockBase : GuerillaBlock
    {
        internal Moonfish.Tags.ShortBlockIndex1 type;
        internal Moonfish.Tags.ShortBlockIndex1 name;
        internal ScenarioObjectDatumStructBlock objectData;
        internal ScenarioDeviceStructBlock deviceData;
        internal ScenarioLightFixtureStructBlock lightFixtureData;

        public override int SerializedSize
        {
            get { return 84; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public ScenarioLightFixtureBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            type = binaryReader.ReadShortBlockIndex1();
            name = binaryReader.ReadShortBlockIndex1();
            objectData = new ScenarioObjectDatumStructBlock();
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(objectData.ReadFields(binaryReader)));
            deviceData = new ScenarioDeviceStructBlock();
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(deviceData.ReadFields(binaryReader)));
            lightFixtureData = new ScenarioLightFixtureStructBlock();
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(lightFixtureData.ReadFields(binaryReader)));
            return blamPointers;
        }

        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            objectData.ReadPointers(binaryReader, blamPointers);
            deviceData.ReadPointers(binaryReader, blamPointers);
            lightFixtureData.ReadPointers(binaryReader, blamPointers);
        }

        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
            using (binaryWriter.BaseStream.Pin())
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