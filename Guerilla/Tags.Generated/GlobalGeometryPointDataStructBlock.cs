// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class GlobalGeometryPointDataStructBlock : GlobalGeometryPointDataStructBlockBase
    {
        public GlobalGeometryPointDataStructBlock( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 32, Alignment = 4 )]
    public class GlobalGeometryPointDataStructBlockBase : IGuerilla
    {
        internal GlobalGeometryRawPointBlock[] rawPoints;
        internal byte[] runtimePointData;
        internal GlobalGeometryRigidPointGroupBlock[] rigidPointGroups;
        internal GlobalGeometryPointDataIndexBlock[] vertexPointIndices;

        internal GlobalGeometryPointDataStructBlockBase( BinaryReader binaryReader )
        {
            rawPoints = Guerilla.ReadBlockArray<GlobalGeometryRawPointBlock>( binaryReader );
            runtimePointData = Guerilla.ReadData( binaryReader );
            rigidPointGroups = Guerilla.ReadBlockArray<GlobalGeometryRigidPointGroupBlock>( binaryReader );
            vertexPointIndices = Guerilla.ReadBlockArray<GlobalGeometryPointDataIndexBlock>( binaryReader );
        }

        public int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                nextAddress = Guerilla.WriteBlockArray<GlobalGeometryRawPointBlock>( binaryWriter, rawPoints,
                    nextAddress );
                nextAddress = Guerilla.WriteData( binaryWriter, runtimePointData, nextAddress );
                nextAddress = Guerilla.WriteBlockArray<GlobalGeometryRigidPointGroupBlock>( binaryWriter,
                    rigidPointGroups, nextAddress );
                nextAddress = Guerilla.WriteBlockArray<GlobalGeometryPointDataIndexBlock>( binaryWriter,
                    vertexPointIndices, nextAddress );
                return nextAddress;
            }
        }
    };
}