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
        public static readonly TagClass Coll = ( TagClass ) "coll";
    };
} ;

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute( "coll" )]
    public partial class CollisionModelBlock : CollisionModelBlockBase
    {
        public CollisionModelBlock( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 52, Alignment = 4 )]
    public class CollisionModelBlockBase : GuerillaBlock
    {
        internal GlobalTagImportInfoBlock[] importInfo;
        internal GlobalErrorReportCategoriesBlock[] errors;
        internal Flags flags;
        internal CollisionModelMaterialBlock[] materials;
        internal CollisionModelRegionBlock[] regions;
        internal CollisionModelPathfindingSphereBlock[] pathfindingSpheres;
        internal CollisionModelNodeBlock[] nodes;

        public override int SerializedSize
        {
            get { return 52; }
        }

        internal CollisionModelBlockBase( BinaryReader binaryReader ) : base( binaryReader )
        {
            importInfo = Guerilla.ReadBlockArray<GlobalTagImportInfoBlock>( binaryReader );
            errors = Guerilla.ReadBlockArray<GlobalErrorReportCategoriesBlock>( binaryReader );
            flags = ( Flags ) binaryReader.ReadInt32( );
            materials = Guerilla.ReadBlockArray<CollisionModelMaterialBlock>( binaryReader );
            regions = Guerilla.ReadBlockArray<CollisionModelRegionBlock>( binaryReader );
            pathfindingSpheres = Guerilla.ReadBlockArray<CollisionModelPathfindingSphereBlock>( binaryReader );
            nodes = Guerilla.ReadBlockArray<CollisionModelNodeBlock>( binaryReader );
        }

        public override int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                nextAddress = Guerilla.WriteBlockArray<GlobalTagImportInfoBlock>( binaryWriter, importInfo, nextAddress );
                nextAddress = Guerilla.WriteBlockArray<GlobalErrorReportCategoriesBlock>( binaryWriter, errors,
                    nextAddress );
                binaryWriter.Write( ( Int32 ) flags );
                nextAddress = Guerilla.WriteBlockArray<CollisionModelMaterialBlock>( binaryWriter, materials,
                    nextAddress );
                nextAddress = Guerilla.WriteBlockArray<CollisionModelRegionBlock>( binaryWriter, regions, nextAddress );
                nextAddress = Guerilla.WriteBlockArray<CollisionModelPathfindingSphereBlock>( binaryWriter,
                    pathfindingSpheres, nextAddress );
                nextAddress = Guerilla.WriteBlockArray<CollisionModelNodeBlock>( binaryWriter, nodes, nextAddress );
                return nextAddress;
            }
        }

        [FlagsAttribute]
        internal enum Flags : int
        {
            ContainsOpenEdges = 1,
        };
    };
}