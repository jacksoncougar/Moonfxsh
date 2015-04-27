// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class PlatformSoundFilterLfoBlock : PlatformSoundFilterLfoBlockBase
    {
        public PlatformSoundFilterLfoBlock( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 64, Alignment = 4 )]
    public class PlatformSoundFilterLfoBlockBase : IGuerilla
    {
        internal SoundPlaybackParameterDefinitionBlock delay;
        internal SoundPlaybackParameterDefinitionBlock frequency;
        internal SoundPlaybackParameterDefinitionBlock cutoffModulation;
        internal SoundPlaybackParameterDefinitionBlock gainModulation;

        internal PlatformSoundFilterLfoBlockBase( BinaryReader binaryReader )
        {
            delay = new SoundPlaybackParameterDefinitionBlock( binaryReader );
            frequency = new SoundPlaybackParameterDefinitionBlock( binaryReader );
            cutoffModulation = new SoundPlaybackParameterDefinitionBlock( binaryReader );
            gainModulation = new SoundPlaybackParameterDefinitionBlock( binaryReader );
        }

        public int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                delay.Write( binaryWriter );
                frequency.Write( binaryWriter );
                cutoffModulation.Write( binaryWriter );
                gainModulation.Write( binaryWriter );
                return nextAddress;
            }
        }
    };
}