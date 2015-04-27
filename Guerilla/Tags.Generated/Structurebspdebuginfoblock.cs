// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class StructureBspDebugInfoBlock : StructureBspDebugInfoBlockBase
    {
        public StructureBspDebugInfoBlock( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 88, Alignment = 4 )]
    public class StructureBspDebugInfoBlockBase : GuerillaBlock
    {
        internal byte[] invalidName_;
        internal StructureBspClusterDebugInfoBlock[] clusters;
        internal StructureBspFogPlaneDebugInfoBlock[] fogPlanes;
        internal StructureBspFogZoneDebugInfoBlock[] fogZones;

        public override int SerializedSize
        {
            get { return 88; }
        }

        internal StructureBspDebugInfoBlockBase( BinaryReader binaryReader ) : base( binaryReader )
        {
            invalidName_ = binaryReader.ReadBytes( 64 );
            clusters = Guerilla.ReadBlockArray<StructureBspClusterDebugInfoBlock>( binaryReader );
            fogPlanes = Guerilla.ReadBlockArray<StructureBspFogPlaneDebugInfoBlock>( binaryReader );
            fogZones = Guerilla.ReadBlockArray<StructureBspFogZoneDebugInfoBlock>( binaryReader );
        }

        public override int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                binaryWriter.Write( invalidName_, 0, 64 );
                nextAddress = Guerilla.WriteBlockArray<StructureBspClusterDebugInfoBlock>( binaryWriter, clusters,
                    nextAddress );
                nextAddress = Guerilla.WriteBlockArray<StructureBspFogPlaneDebugInfoBlock>( binaryWriter, fogPlanes,
                    nextAddress );
                nextAddress = Guerilla.WriteBlockArray<StructureBspFogZoneDebugInfoBlock>( binaryWriter, fogZones,
                    nextAddress );
                return nextAddress;
            }
        }
    };
}