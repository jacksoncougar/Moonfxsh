// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class StructureBspFogPlaneDebugInfoBlock : StructureBspFogPlaneDebugInfoBlockBase
    {
        public StructureBspFogPlaneDebugInfoBlock( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 56, Alignment = 4 )]
    public class StructureBspFogPlaneDebugInfoBlockBase : GuerillaBlock
    {
        internal int fogZoneIndex;
        internal byte[] invalidName_;
        internal int connectedPlaneDesignator;
        internal StructureBspDebugInfoRenderLineBlock[] lines;
        internal StructureBspDebugInfoIndicesBlock[] intersectedClusterIndices;
        internal StructureBspDebugInfoIndicesBlock[] infExtentClusterIndices;

        public override int SerializedSize
        {
            get { return 56; }
        }

        internal StructureBspFogPlaneDebugInfoBlockBase( BinaryReader binaryReader ) : base( binaryReader )
        {
            fogZoneIndex = binaryReader.ReadInt32( );
            invalidName_ = binaryReader.ReadBytes( 24 );
            connectedPlaneDesignator = binaryReader.ReadInt32( );
            lines = Guerilla.ReadBlockArray<StructureBspDebugInfoRenderLineBlock>( binaryReader );
            intersectedClusterIndices = Guerilla.ReadBlockArray<StructureBspDebugInfoIndicesBlock>( binaryReader );
            infExtentClusterIndices = Guerilla.ReadBlockArray<StructureBspDebugInfoIndicesBlock>( binaryReader );
        }

        public override int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                binaryWriter.Write( fogZoneIndex );
                binaryWriter.Write( invalidName_, 0, 24 );
                binaryWriter.Write( connectedPlaneDesignator );
                nextAddress = Guerilla.WriteBlockArray<StructureBspDebugInfoRenderLineBlock>( binaryWriter, lines,
                    nextAddress );
                nextAddress = Guerilla.WriteBlockArray<StructureBspDebugInfoIndicesBlock>( binaryWriter,
                    intersectedClusterIndices, nextAddress );
                nextAddress = Guerilla.WriteBlockArray<StructureBspDebugInfoIndicesBlock>( binaryWriter,
                    infExtentClusterIndices, nextAddress );
                return nextAddress;
            }
        }
    };
}