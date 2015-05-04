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
    public partial class ScenarioSceneryDatumStructV4Block : ScenarioSceneryDatumStructV4BlockBase
    {
        public ScenarioSceneryDatumStructV4Block() : base()
        {
        }
    };
    [LayoutAttribute(Size = 16, Alignment = 4)]
    public class ScenarioSceneryDatumStructV4BlockBase : GuerillaBlock
    {
        internal PathfindingPolicy pathfindingPolicy;
        internal LightmappingPolicy lightmappingPolicy;
        internal PathfindingObjectIndexListBlock[] pathfindingReferences;
        internal byte[] invalidName_;
        internal ValidMultiplayerGames validMultiplayerGames;
        public override int SerializedSize { get { return 16; } }
        public override int Alignment { get { return 4; } }
        public ScenarioSceneryDatumStructV4BlockBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            pathfindingPolicy = (PathfindingPolicy)binaryReader.ReadInt16();
            lightmappingPolicy = (LightmappingPolicy)binaryReader.ReadInt16();
            blamPointers.Enqueue(ReadBlockArrayPointer<PathfindingObjectIndexListBlock>(binaryReader));
            invalidName_ = binaryReader.ReadBytes(2);
            validMultiplayerGames = (ValidMultiplayerGames)binaryReader.ReadInt16();
            return blamPointers;
        }
        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            pathfindingReferences = ReadBlockArrayData<PathfindingObjectIndexListBlock>(binaryReader, blamPointers.Dequeue());
        }
        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write((Int16)pathfindingPolicy);
                binaryWriter.Write((Int16)lightmappingPolicy);
                nextAddress = Guerilla.WriteBlockArray<PathfindingObjectIndexListBlock>(binaryWriter, pathfindingReferences, nextAddress);
                binaryWriter.Write(invalidName_, 0, 2);
                binaryWriter.Write((Int16)validMultiplayerGames);
                return nextAddress;
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
