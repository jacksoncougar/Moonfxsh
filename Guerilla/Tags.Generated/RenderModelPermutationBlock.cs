// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class RenderModelPermutationBlock : RenderModelPermutationBlockBase
    {
        public RenderModelPermutationBlock( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 16, Alignment = 4 )]
    public class RenderModelPermutationBlockBase : IGuerilla
    {
        internal Moonfish.Tags.StringID name;
        internal short l1SectionIndexSuperLow;
        internal short l2SectionIndexLow;
        internal short l3SectionIndexMedium;
        internal short l4SectionIndexHigh;
        internal short l5SectionIndexSuperHigh;
        internal short l6SectionIndexHollywood;

        internal RenderModelPermutationBlockBase( BinaryReader binaryReader )
        {
            name = binaryReader.ReadStringID( );
            l1SectionIndexSuperLow = binaryReader.ReadInt16( );
            l2SectionIndexLow = binaryReader.ReadInt16( );
            l3SectionIndexMedium = binaryReader.ReadInt16( );
            l4SectionIndexHigh = binaryReader.ReadInt16( );
            l5SectionIndexSuperHigh = binaryReader.ReadInt16( );
            l6SectionIndexHollywood = binaryReader.ReadInt16( );
        }

        public int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                binaryWriter.Write( name );
                binaryWriter.Write( l1SectionIndexSuperLow );
                binaryWriter.Write( l2SectionIndexLow );
                binaryWriter.Write( l3SectionIndexMedium );
                binaryWriter.Write( l4SectionIndexHigh );
                binaryWriter.Write( l5SectionIndexSuperHigh );
                binaryWriter.Write( l6SectionIndexHollywood );
                return nextAddress;
            }
        }
    };
}