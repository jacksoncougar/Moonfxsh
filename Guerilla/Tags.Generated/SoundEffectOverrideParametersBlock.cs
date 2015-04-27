// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class SoundEffectOverrideParametersBlock : SoundEffectOverrideParametersBlockBase
    {
        public SoundEffectOverrideParametersBlock( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 32, Alignment = 4 )]
    public class SoundEffectOverrideParametersBlockBase : IGuerilla
    {
        internal Moonfish.Tags.StringID name;
        internal Moonfish.Tags.StringID input;
        internal Moonfish.Tags.StringID range;
        internal float timePeriodSeconds;
        internal int integerValue;
        internal float realValue;
        internal MappingFunctionBlock functionValue;

        internal SoundEffectOverrideParametersBlockBase( BinaryReader binaryReader )
        {
            name = binaryReader.ReadStringID( );
            input = binaryReader.ReadStringID( );
            range = binaryReader.ReadStringID( );
            timePeriodSeconds = binaryReader.ReadSingle( );
            integerValue = binaryReader.ReadInt32( );
            realValue = binaryReader.ReadSingle( );
            functionValue = new MappingFunctionBlock( binaryReader );
        }

        public int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                binaryWriter.Write( name );
                binaryWriter.Write( input );
                binaryWriter.Write( range );
                binaryWriter.Write( timePeriodSeconds );
                binaryWriter.Write( integerValue );
                binaryWriter.Write( realValue );
                functionValue.Write( binaryWriter );
                return nextAddress;
            }
        }
    };
}