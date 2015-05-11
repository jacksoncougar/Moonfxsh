// ReSharper disable All

using Moonfish.Model;

using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Moonfish.Tags
{
    public partial struct TagClass
    {
        public static readonly TagClass Scen = (TagClass) "scen";
    };
} ;

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("scen")]
    public partial class SceneryBlock : SceneryBlockBase
    {
        public SceneryBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 8, Alignment = 4)]
    public class SceneryBlockBase : ObjectBlock
    {
        internal PathfindingPolicy pathfindingPolicy;
        internal Flags flags;
        internal LightmappingPolicy lightmappingPolicy;
        internal byte[] invalidName_;

        public override int SerializedSize
        {
            get { return 196; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public SceneryBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            pathfindingPolicy = (PathfindingPolicy) binaryReader.ReadInt16();
            flags = (Flags) binaryReader.ReadInt16();
            lightmappingPolicy = (LightmappingPolicy) binaryReader.ReadInt16();
            invalidName_ = binaryReader.ReadBytes(2);
            return blamPointers;
        }

        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
        }

        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
            using (binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write((Int16) pathfindingPolicy);
                binaryWriter.Write((Int16) flags);
                binaryWriter.Write((Int16) lightmappingPolicy);
                binaryWriter.Write(invalidName_, 0, 2);
                return nextAddress;
            }
        }

        internal enum PathfindingPolicy : short
        {
            PathfindingCUTOUT = 0,
            PathfindingSTATIC = 1,
            PathfindingDYNAMIC = 2,
            PathfindingNONE = 3,
        };

        [FlagsAttribute]
        internal enum Flags : short
        {
            PhysicallySimulatesStimulates = 1,
        };

        internal enum LightmappingPolicy : short
        {
            PerVertex = 0,
            PerPixelNotImplemented = 1,
            Dynamic = 2,
        };
    };
}