// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class DamageEffectSoundEffectDefinitionBlock : DamageEffectSoundEffectDefinitionBlockBase
    {
        public DamageEffectSoundEffectDefinitionBlock( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 16, Alignment = 4 )]
    public class DamageEffectSoundEffectDefinitionBlockBase : IGuerilla
    {
        internal Moonfish.Tags.StringID effectName;
        internal float durationSeconds;
        internal MappingFunctionBlock effectScaleFunction;

        internal DamageEffectSoundEffectDefinitionBlockBase( BinaryReader binaryReader )
        {
            effectName = binaryReader.ReadStringID( );
            durationSeconds = binaryReader.ReadSingle( );
            effectScaleFunction = new MappingFunctionBlock( binaryReader );
        }

        public int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                binaryWriter.Write( effectName );
                binaryWriter.Write( durationSeconds );
                effectScaleFunction.Write( binaryWriter );
                return nextAddress;
            }
        }
    };
}