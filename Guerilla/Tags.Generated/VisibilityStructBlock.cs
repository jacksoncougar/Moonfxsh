// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class VisibilityStructBlock : VisibilityStructBlockBase
    {
        public VisibilityStructBlock( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 40, Alignment = 4 )]
    public class VisibilityStructBlockBase : GuerillaBlock
    {
        internal short projectionCount;
        internal short clusterCount;
        internal short volumeCount;
        internal byte[] invalidName_;
        internal byte[] projections;
        internal byte[] visibilityClusters;
        internal byte[] clusterRemapTable;
        internal byte[] visibilityVolumes;

        public override int SerializedSize
        {
            get { return 40; }
        }

        internal VisibilityStructBlockBase( BinaryReader binaryReader ) : base( binaryReader )
        {
            projectionCount = binaryReader.ReadInt16( );
            clusterCount = binaryReader.ReadInt16( );
            volumeCount = binaryReader.ReadInt16( );
            invalidName_ = binaryReader.ReadBytes( 2 );
            projections = Guerilla.ReadData( binaryReader );
            visibilityClusters = Guerilla.ReadData( binaryReader );
            clusterRemapTable = Guerilla.ReadData( binaryReader );
            visibilityVolumes = Guerilla.ReadData( binaryReader );
        }

        public override int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                binaryWriter.Write( projectionCount );
                binaryWriter.Write( clusterCount );
                binaryWriter.Write( volumeCount );
                binaryWriter.Write( invalidName_, 0, 2 );
                nextAddress = Guerilla.WriteData( binaryWriter, projections, nextAddress );
                nextAddress = Guerilla.WriteData( binaryWriter, visibilityClusters, nextAddress );
                nextAddress = Guerilla.WriteData( binaryWriter, clusterRemapTable, nextAddress );
                nextAddress = Guerilla.WriteData( binaryWriter, visibilityVolumes, nextAddress );
                return nextAddress;
            }
        }
    };
}