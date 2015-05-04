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
    public partial class ScenarioSpawnDataBlock : ScenarioSpawnDataBlockBase
    {
        public ScenarioSpawnDataBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 96, Alignment = 4)]
    public class ScenarioSpawnDataBlockBase : GuerillaBlock
    {
        internal float dynamicSpawnLowerHeight;
        internal float dynamicSpawnUpperHeight;
        internal float gameObjectResetHeight;
        internal byte[] invalidName_;
        internal DynamicSpawnZoneOverloadBlock[] dynamicSpawnOverloads;
        internal StaticSpawnZoneBlock[] staticRespawnZones;
        internal StaticSpawnZoneBlock[] staticInitialSpawnZones;

        public override int SerializedSize
        {
            get { return 96; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public ScenarioSpawnDataBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            dynamicSpawnLowerHeight = binaryReader.ReadSingle();
            dynamicSpawnUpperHeight = binaryReader.ReadSingle();
            gameObjectResetHeight = binaryReader.ReadSingle();
            invalidName_ = binaryReader.ReadBytes(60);
            blamPointers.Enqueue(ReadBlockArrayPointer<DynamicSpawnZoneOverloadBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<StaticSpawnZoneBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<StaticSpawnZoneBlock>(binaryReader));
            return blamPointers;
        }

        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            dynamicSpawnOverloads = ReadBlockArrayData<DynamicSpawnZoneOverloadBlock>(binaryReader,
                blamPointers.Dequeue());
            staticRespawnZones = ReadBlockArrayData<StaticSpawnZoneBlock>(binaryReader, blamPointers.Dequeue());
            staticInitialSpawnZones = ReadBlockArrayData<StaticSpawnZoneBlock>(binaryReader, blamPointers.Dequeue());
        }

        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
            using (binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(dynamicSpawnLowerHeight);
                binaryWriter.Write(dynamicSpawnUpperHeight);
                binaryWriter.Write(gameObjectResetHeight);
                binaryWriter.Write(invalidName_, 0, 60);
                nextAddress = Guerilla.WriteBlockArray<DynamicSpawnZoneOverloadBlock>(binaryWriter,
                    dynamicSpawnOverloads, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<StaticSpawnZoneBlock>(binaryWriter, staticRespawnZones,
                    nextAddress);
                nextAddress = Guerilla.WriteBlockArray<StaticSpawnZoneBlock>(binaryWriter, staticInitialSpawnZones,
                    nextAddress);
                return nextAddress;
            }
        }
    };
}