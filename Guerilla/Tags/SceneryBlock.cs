// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Tags
{
    public partial struct TagClass
    {
        public static readonly TagClass ScenClass = (TagClass)"scen";
    };
};

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("scen")]
    public  partial class SceneryBlock : SceneryBlockBase
    {
        public  SceneryBlock(BinaryReader binaryReader): base(binaryReader)
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
        internal  SceneryBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            pathfindingPolicy = (PathfindingPolicy)binaryReader.ReadInt16();
            flags = (Flags)binaryReader.ReadInt16();
            lightmappingPolicy = (LightmappingPolicy)binaryReader.ReadInt16();
            invalidName_ = binaryReader.ReadBytes(2);
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write((Int16)pathfindingPolicy);
                binaryWriter.Write((Int16)flags);
                binaryWriter.Write((Int16)lightmappingPolicy);
                binaryWriter.Write(invalidName_, 0, 2);
                return nextAddress = (int)binaryWriter.BaseStream.Position;
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
