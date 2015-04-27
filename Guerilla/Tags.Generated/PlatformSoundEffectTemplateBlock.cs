// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class PlatformSoundEffectTemplateBlock : PlatformSoundEffectTemplateBlockBase
    {
        public PlatformSoundEffectTemplateBlock( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 24, Alignment = 4 )]
    public class PlatformSoundEffectTemplateBlockBase : IGuerilla
    {
        internal Moonfish.Tags.StringID inputDspEffectName;
        internal byte[] invalidName_;
        internal PlatformSoundEffectTemplateComponentBlock[] components;

        internal PlatformSoundEffectTemplateBlockBase( BinaryReader binaryReader )
        {
            inputDspEffectName = binaryReader.ReadStringID( );
            invalidName_ = binaryReader.ReadBytes( 12 );
            components = Guerilla.ReadBlockArray<PlatformSoundEffectTemplateComponentBlock>( binaryReader );
        }

        public int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                binaryWriter.Write( inputDspEffectName );
                binaryWriter.Write( invalidName_, 0, 12 );
                nextAddress = Guerilla.WriteBlockArray<PlatformSoundEffectTemplateComponentBlock>( binaryWriter,
                    components, nextAddress );
                return nextAddress;
            }
        }
    };
}