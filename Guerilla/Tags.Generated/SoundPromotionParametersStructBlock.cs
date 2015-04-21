// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class SoundPromotionParametersStructBlock : SoundPromotionParametersStructBlockBase
    {
        public SoundPromotionParametersStructBlock( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 20, Alignment = 4 )]
    public class SoundPromotionParametersStructBlockBase : IGuerilla
    {
        [TagReference( "snd!" )] internal Moonfish.Tags.TagReference promotionSound;

        /// <summary>
        /// when there are this many instances of the sound, promote to the new sound.
        /// </summary>
        internal short promotionCount;

        internal byte[] invalidName_;
        internal byte[] invalidName_0;

        internal SoundPromotionParametersStructBlockBase( BinaryReader binaryReader )
        {
            promotionSound = binaryReader.ReadTagReference( );
            promotionCount = binaryReader.ReadInt16( );
            invalidName_ = binaryReader.ReadBytes( 2 );
            invalidName_0 = binaryReader.ReadBytes( 8 );
        }

        public int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                binaryWriter.Write( promotionSound );
                binaryWriter.Write( promotionCount );
                binaryWriter.Write( invalidName_, 0, 2 );
                binaryWriter.Write( invalidName_0, 0, 8 );
                return nextAddress;
            }
        }
    };
}