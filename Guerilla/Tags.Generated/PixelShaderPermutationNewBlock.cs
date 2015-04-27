// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class PixelShaderPermutationNewBlock : PixelShaderPermutationNewBlockBase
    {
        public PixelShaderPermutationNewBlock( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 6, Alignment = 4 )]
    public class PixelShaderPermutationNewBlockBase : IGuerilla
    {
        internal short enumIndex;
        internal short flags;
        internal TagBlockIndexStructBlock combiners;

        internal PixelShaderPermutationNewBlockBase( BinaryReader binaryReader )
        {
            enumIndex = binaryReader.ReadInt16( );
            flags = binaryReader.ReadInt16( );
            combiners = new TagBlockIndexStructBlock( binaryReader );
        }

        public int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                binaryWriter.Write( enumIndex );
                binaryWriter.Write( flags );
                combiners.Write( binaryWriter );
                return nextAddress;
            }
        }
    };
}