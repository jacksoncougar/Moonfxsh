// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class RenderModelSectionGroupBlock : RenderModelSectionGroupBlockBase
    {
        public RenderModelSectionGroupBlock( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 12, Alignment = 4 )]
    public class RenderModelSectionGroupBlockBase : IGuerilla
    {
        internal DetailLevels detailLevels;
        internal byte[] invalidName_;
        internal RenderModelCompoundNodeBlock[] compoundNodes;

        internal RenderModelSectionGroupBlockBase( BinaryReader binaryReader )
        {
            detailLevels = ( DetailLevels ) binaryReader.ReadInt16( );
            invalidName_ = binaryReader.ReadBytes( 2 );
            compoundNodes = Guerilla.ReadBlockArray<RenderModelCompoundNodeBlock>( binaryReader );
        }

        public int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                binaryWriter.Write( ( Int16 ) detailLevels );
                binaryWriter.Write( invalidName_, 0, 2 );
                nextAddress = Guerilla.WriteBlockArray<RenderModelCompoundNodeBlock>( binaryWriter, compoundNodes,
                    nextAddress );
                return nextAddress;
            }
        }

        [FlagsAttribute]
        internal enum DetailLevels : short
        {
            L1SuperLow = 1,
            L2Low = 2,
            L3Medium = 4,
            L4High = 8,
            L5SuperHigh = 16,
            L6Hollywood = 32,
        };
    };
}