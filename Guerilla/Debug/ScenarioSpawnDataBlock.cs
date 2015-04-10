// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class ScenarioSpawnDataBlock : ScenarioSpawnDataBlockBase
    {
        public  ScenarioSpawnDataBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 96)]
    public class ScenarioSpawnDataBlockBase
    {
        internal float dynamicSpawnLowerHeight;
        internal float dynamicSpawnUpperHeight;
        internal float gameObjectResetHeight;
        internal byte[] invalidName_;
        internal DynamicSpawnZoneOverloadBlock[] dynamicSpawnOverloads;
        internal StaticSpawnZoneBlock[] staticRespawnZones;
        internal StaticSpawnZoneBlock[] staticInitialSpawnZones;
        internal  ScenarioSpawnDataBlockBase(System.IO.BinaryReader binaryReader)
        {
            dynamicSpawnLowerHeight = binaryReader.ReadSingle();
            dynamicSpawnUpperHeight = binaryReader.ReadSingle();
            gameObjectResetHeight = binaryReader.ReadSingle();
            invalidName_ = binaryReader.ReadBytes(60);
            ReadDynamicSpawnZoneOverloadBlockArray(binaryReader);
            ReadStaticSpawnZoneBlockArray(binaryReader);
            ReadStaticSpawnZoneBlockArray(binaryReader);
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
        internal  virtual DynamicSpawnZoneOverloadBlock[] ReadDynamicSpawnZoneOverloadBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(DynamicSpawnZoneOverloadBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new DynamicSpawnZoneOverloadBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new DynamicSpawnZoneOverloadBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual StaticSpawnZoneBlock[] ReadStaticSpawnZoneBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(StaticSpawnZoneBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new StaticSpawnZoneBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new StaticSpawnZoneBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteDynamicSpawnZoneOverloadBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteStaticSpawnZoneBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(dynamicSpawnLowerHeight);
                binaryWriter.Write(dynamicSpawnUpperHeight);
                binaryWriter.Write(gameObjectResetHeight);
                binaryWriter.Write(invalidName_, 0, 60);
                WriteDynamicSpawnZoneOverloadBlockArray(binaryWriter);
                WriteStaticSpawnZoneBlockArray(binaryWriter);
                WriteStaticSpawnZoneBlockArray(binaryWriter);
            }
        }
    };
}
