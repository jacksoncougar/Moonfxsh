// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class ScenarioSceneryDatumStructV4Block : ScenarioSceneryDatumStructV4BlockBase
    {
        public  ScenarioSceneryDatumStructV4Block(System.IO.BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 16)]
    public class ScenarioSceneryDatumStructV4BlockBase
    {
        internal PathfindingPolicy pathfindingPolicy;
        internal LightmappingPolicy lightmappingPolicy;
        internal PathfindingObjectIndexListBlock[] pathfindingReferences;
        internal byte[] invalidName_;
        internal ValidMultiplayerGames validMultiplayerGames;
        internal  ScenarioSceneryDatumStructV4BlockBase(System.IO.BinaryReader binaryReader)
        {
            pathfindingPolicy = (PathfindingPolicy)binaryReader.ReadInt16();
            lightmappingPolicy = (LightmappingPolicy)binaryReader.ReadInt16();
            ReadPathfindingObjectIndexListBlockArray(binaryReader);
            invalidName_ = binaryReader.ReadBytes(2);
            validMultiplayerGames = (ValidMultiplayerGames)binaryReader.ReadInt16();
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
        internal  virtual PathfindingObjectIndexListBlock[] ReadPathfindingObjectIndexListBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(PathfindingObjectIndexListBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new PathfindingObjectIndexListBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new PathfindingObjectIndexListBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WritePathfindingObjectIndexListBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write((Int16)pathfindingPolicy);
                binaryWriter.Write((Int16)lightmappingPolicy);
                WritePathfindingObjectIndexListBlockArray(binaryWriter);
                binaryWriter.Write(invalidName_, 0, 2);
                binaryWriter.Write((Int16)validMultiplayerGames);
            }
        }
        internal enum PathfindingPolicy : short
        
        {
            TagDefault = 0,
            PathfindingDYNAMIC = 1,
            PathfindingCUTOUT = 2,
            PathfindingSTATIC = 3,
            PathfindingNONE = 4,
        };
        internal enum LightmappingPolicy : short
        
        {
            TagDefault = 0,
            Dynamic = 1,
            PerVertex = 2,
        };
        [FlagsAttribute]
        internal enum ValidMultiplayerGames : short
        
        {
            CaptureTheFlag = 1,
            Slayer = 2,
            Oddball = 4,
            KingOfTheHill = 8,
            Juggernaut = 16,
            Territories = 32,
            Assault = 64,
        };
    };
}
