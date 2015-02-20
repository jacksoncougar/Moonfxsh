using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    [LayoutAttribute( Size = 8 )]
    public partial class SceneryBlock : SceneryBlockBase
    {
        public SceneryBlock( BinaryReader binaryReader )
            : base( binaryReader )
        {

        }
    };
    [LayoutAttribute( Size = 8 )]
    public class SceneryBlockBase : ObjectBlock
    {
        internal PathfindingPolicy pathfindingPolicy;
        internal Flags flags;
        internal LightmappingPolicy lightmappingPolicy;
        internal byte[] invalidName_;
        internal SceneryBlockBase( BinaryReader binaryReader )
            : base( binaryReader )
        {
            this.pathfindingPolicy = (PathfindingPolicy)binaryReader.ReadInt16( );
            this.flags = (Flags)binaryReader.ReadInt16( );
            this.lightmappingPolicy = (LightmappingPolicy)binaryReader.ReadInt16( );
            this.invalidName_ = binaryReader.ReadBytes( 2 );
        }
        internal virtual byte[] ReadData( BinaryReader binaryReader )
        {
            var blamPointer = binaryReader.ReadBlamPointer( 1 );
            var data = new byte[blamPointer.Count];
            if( blamPointer.Count > 0 )
            {
                using( binaryReader.BaseStream.Pin( ) )
                {
                    binaryReader.BaseStream.Position = blamPointer[0];
                    data = binaryReader.ReadBytes( blamPointer.Count );
                }
            }
            return data;
        }
        internal enum PathfindingPolicy : short
        {
            PathfindingCUTOUT = 0,
            PathfindingSTATIC = 1,
            PathfindingDYNAMIC = 2,
            PathfindingNONE = 3,
        };
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
