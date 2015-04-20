// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class PlatformSoundPitchLfoBlock : PlatformSoundPitchLfoBlockBase
    {
        public PlatformSoundPitchLfoBlock( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 48, Alignment = 4 )]
    public class PlatformSoundPitchLfoBlockBase : IGuerilla
    {
        internal SoundPlaybackParameterDefinitionBlock delay;
        internal SoundPlaybackParameterDefinitionBlock frequency;
        internal SoundPlaybackParameterDefinitionBlock pitchModulation;

        internal PlatformSoundPitchLfoBlockBase( BinaryReader binaryReader )
        {
            delay = new SoundPlaybackParameterDefinitionBlock( binaryReader );
            frequency = new SoundPlaybackParameterDefinitionBlock( binaryReader );
            pitchModulation = new SoundPlaybackParameterDefinitionBlock( binaryReader );
        }

        public int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                delay.Write( binaryWriter );
                frequency.Write( binaryWriter );
                pitchModulation.Write( binaryWriter );
                return nextAddress;
            }
        }
    };
}