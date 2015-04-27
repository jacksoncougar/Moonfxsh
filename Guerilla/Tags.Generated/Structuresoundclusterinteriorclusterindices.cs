// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class StructureSoundClusterInteriorClusterIndices : StructureSoundClusterInteriorClusterIndicesBase
    {
        public StructureSoundClusterInteriorClusterIndices( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 2, Alignment = 4 )]
    public class StructureSoundClusterInteriorClusterIndicesBase : GuerillaBlock
    {
        internal short interiorClusterIndex;

        public override int SerializedSize
        {
            get { return 2; }
        }

        internal StructureSoundClusterInteriorClusterIndicesBase( BinaryReader binaryReader ) : base( binaryReader )
        {
            interiorClusterIndex = binaryReader.ReadInt16( );
        }

        public override int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                binaryWriter.Write( interiorClusterIndex );
                return nextAddress;
            }
        }
    };
}