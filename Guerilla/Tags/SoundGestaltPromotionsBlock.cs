// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class SoundGestaltPromotionsBlock : SoundGestaltPromotionsBlockBase
    {
        public SoundGestaltPromotionsBlock( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 28, Alignment = 4 )]
    public class SoundGestaltPromotionsBlockBase : IGuerilla
    {
        internal SoundPromotionRuleBlock[] soundPromotionRules;
        internal SoundPromotionRuntimeTimerBlock[] soundPromotionRuntimeTimers;
        internal byte[] invalidName_;

        internal SoundGestaltPromotionsBlockBase( BinaryReader binaryReader )
        {
            soundPromotionRules = Guerilla.ReadBlockArray<SoundPromotionRuleBlock>( binaryReader );
            soundPromotionRuntimeTimers = Guerilla.ReadBlockArray<SoundPromotionRuntimeTimerBlock>( binaryReader );
            invalidName_ = binaryReader.ReadBytes( 12 );
        }

        public int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                nextAddress = Guerilla.WriteBlockArray<SoundPromotionRuleBlock>( binaryWriter, soundPromotionRules,
                    nextAddress );
                nextAddress = Guerilla.WriteBlockArray<SoundPromotionRuntimeTimerBlock>( binaryWriter,
                    soundPromotionRuntimeTimers, nextAddress );
                binaryWriter.Write( invalidName_, 0, 12 );
                return nextAddress;
            }
        }
    };
}