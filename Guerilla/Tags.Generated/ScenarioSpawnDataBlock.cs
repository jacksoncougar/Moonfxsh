// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class ScenarioSpawnDataBlock : ScenarioSpawnDataBlockBase
    {
        public  ScenarioSpawnDataBlock(BinaryReader binaryReader): base(binaryReader)
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
        
        public override int SerializedSize{get { return 96; }}
        
        internal  ScenarioSpawnDataBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            dynamicSpawnLowerHeight = binaryReader.ReadSingle();
            dynamicSpawnUpperHeight = binaryReader.ReadSingle();
            gameObjectResetHeight = binaryReader.ReadSingle();
            invalidName_ = binaryReader.ReadBytes(60);
            dynamicSpawnOverloads = Guerilla.ReadBlockArray<DynamicSpawnZoneOverloadBlock>(binaryReader);
            staticRespawnZones = Guerilla.ReadBlockArray<StaticSpawnZoneBlock>(binaryReader);
            staticInitialSpawnZones = Guerilla.ReadBlockArray<StaticSpawnZoneBlock>(binaryReader);
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(dynamicSpawnLowerHeight);
                binaryWriter.Write(dynamicSpawnUpperHeight);
                binaryWriter.Write(gameObjectResetHeight);
                binaryWriter.Write(invalidName_, 0, 60);
                nextAddress = Guerilla.WriteBlockArray<DynamicSpawnZoneOverloadBlock>(binaryWriter, dynamicSpawnOverloads, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<StaticSpawnZoneBlock>(binaryWriter, staticRespawnZones, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<StaticSpawnZoneBlock>(binaryWriter, staticInitialSpawnZones, nextAddress);
                return nextAddress;
            }
        }
    };
}
