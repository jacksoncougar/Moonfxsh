// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class SoundGestaltRuntimePermutationBitVectorBlock : SoundGestaltRuntimePermutationBitVectorBlockBase
    {
        public SoundGestaltRuntimePermutationBitVectorBlock( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 1, Alignment = 4 )]
    public class SoundGestaltRuntimePermutationBitVectorBlockBase : IGuerilla
    {
        internal byte invalidName_;

        internal SoundGestaltRuntimePermutationBitVectorBlockBase( BinaryReader binaryReader )
        {
            invalidName_ = binaryReader.ReadByte( );
        }

        public int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                binaryWriter.Write( invalidName_ );
                return nextAddress;
            }
        }
    };
}