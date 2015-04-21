// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class SoundPromotionRuleBlock : SoundPromotionRuleBlockBase
    {
        public SoundPromotionRuleBlock( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 16, Alignment = 4 )]
    public class SoundPromotionRuleBlockBase : IGuerilla
    {
        internal Moonfish.Tags.ShortBlockIndex1 pitchRanges;
        internal short maximumPlayingCount;

        /// <summary>
        /// time from when first permutation plays to when another sound from an equal or lower promotion can play
        /// </summary>
        internal float suppressionTimeSeconds;

        internal byte[] invalidName_;

        internal SoundPromotionRuleBlockBase( BinaryReader binaryReader )
        {
            pitchRanges = binaryReader.ReadShortBlockIndex1( );
            maximumPlayingCount = binaryReader.ReadInt16( );
            suppressionTimeSeconds = binaryReader.ReadSingle( );
            invalidName_ = binaryReader.ReadBytes( 8 );
        }

        public int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                binaryWriter.Write( pitchRanges );
                binaryWriter.Write( maximumPlayingCount );
                binaryWriter.Write( suppressionTimeSeconds );
                binaryWriter.Write( invalidName_, 0, 8 );
                return nextAddress;
            }
        }
    };
}