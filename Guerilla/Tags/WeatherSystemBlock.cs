// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Tags
{
    public partial struct TagClass
    {
        public static readonly TagClass Weat = ( TagClass ) "weat";
    };
} ;

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute( "weat" )]
    public partial class WeatherSystemBlock : WeatherSystemBlockBase
    {
        public WeatherSystemBlock( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 176, Alignment = 4 )]
    public class WeatherSystemBlockBase : IGuerilla
    {
        internal GlobalParticleSystemLiteBlock[] particleSystem;
        internal GlobalWeatherBackgroundPlateBlock[] backgroundPlates;
        internal GlobalWindModelStructBlock windModel;
        internal float fadeRadius;

        internal WeatherSystemBlockBase( BinaryReader binaryReader )
        {
            particleSystem = Guerilla.ReadBlockArray<GlobalParticleSystemLiteBlock>( binaryReader );
            backgroundPlates = Guerilla.ReadBlockArray<GlobalWeatherBackgroundPlateBlock>( binaryReader );
            windModel = new GlobalWindModelStructBlock( binaryReader );
            fadeRadius = binaryReader.ReadSingle( );
        }

        public int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                nextAddress = Guerilla.WriteBlockArray<GlobalParticleSystemLiteBlock>( binaryWriter, particleSystem,
                    nextAddress );
                nextAddress = Guerilla.WriteBlockArray<GlobalWeatherBackgroundPlateBlock>( binaryWriter,
                    backgroundPlates, nextAddress );
                windModel.Write( binaryWriter );
                binaryWriter.Write( fadeRadius );
                return nextAddress;
            }
        }
    };
}