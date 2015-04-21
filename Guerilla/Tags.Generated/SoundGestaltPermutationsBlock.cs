// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class SoundGestaltPermutationsBlock : SoundGestaltPermutationsBlockBase
    {
        public SoundGestaltPermutationsBlock( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 16, Alignment = 4 )]
    public class SoundGestaltPermutationsBlockBase : IGuerilla
    {
        internal Moonfish.Tags.ShortBlockIndex1 name;
        internal short encodedSkipFraction;
        internal byte encodedGainDB;
        internal byte permutationInfoIndex;
        internal short languageNeutralTimeMs;
        internal int sampleSize;
        internal Moonfish.Tags.ShortBlockIndex1 firstChunk;
        internal short chunkCount;

        internal SoundGestaltPermutationsBlockBase( BinaryReader binaryReader )
        {
            name = binaryReader.ReadShortBlockIndex1( );
            encodedSkipFraction = binaryReader.ReadInt16( );
            encodedGainDB = binaryReader.ReadByte( );
            permutationInfoIndex = binaryReader.ReadByte( );
            languageNeutralTimeMs = binaryReader.ReadInt16( );
            sampleSize = binaryReader.ReadInt32( );
            firstChunk = binaryReader.ReadShortBlockIndex1( );
            chunkCount = binaryReader.ReadInt16( );
        }

        public int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                binaryWriter.Write( name );
                binaryWriter.Write( encodedSkipFraction );
                binaryWriter.Write( encodedGainDB );
                binaryWriter.Write( permutationInfoIndex );
                binaryWriter.Write( languageNeutralTimeMs );
                binaryWriter.Write( sampleSize );
                binaryWriter.Write( firstChunk );
                binaryWriter.Write( chunkCount );
                return nextAddress;
            }
        }
    };
}