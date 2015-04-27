// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class SoundEffectPlaybackBlock : SoundEffectPlaybackBlockBase
    {
        public SoundEffectPlaybackBlock( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 40, Alignment = 4 )]
    public class SoundEffectPlaybackBlockBase : GuerillaBlock
    {
        internal SoundEffectStructDefinitionBlock soundEffectStruct;

        public override int SerializedSize
        {
            get { return 40; }
        }

        internal SoundEffectPlaybackBlockBase( BinaryReader binaryReader ) : base( binaryReader )
        {
            soundEffectStruct = new SoundEffectStructDefinitionBlock( binaryReader );
        }

        public override int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                soundEffectStruct.Write( binaryWriter );
                return nextAddress;
            }
        }
    };
}