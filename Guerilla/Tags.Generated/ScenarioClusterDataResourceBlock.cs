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
        public static readonly TagClass Clu = ( TagClass ) "clu*";
    };
} ;

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute( "clu*" )]
    public partial class ScenarioClusterDataResourceBlock : ScenarioClusterDataResourceBlockBase
    {
        public ScenarioClusterDataResourceBlock( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 40, Alignment = 4 )]
    public class ScenarioClusterDataResourceBlockBase : GuerillaBlock
    {
        internal ScenarioClusterDataBlock[] clusterData;
        internal StructureBspBackgroundSoundPaletteBlock[] backgroundSoundPalette;
        internal StructureBspSoundEnvironmentPaletteBlock[] soundEnvironmentPalette;
        internal StructureBspWeatherPaletteBlock[] weatherPalette;
        internal ScenarioAtmosphericFogPalette[] atmosphericFogPalette;

        public override int SerializedSize
        {
            get { return 40; }
        }

        internal ScenarioClusterDataResourceBlockBase( BinaryReader binaryReader ) : base( binaryReader )
        {
            clusterData = Guerilla.ReadBlockArray<ScenarioClusterDataBlock>( binaryReader );
            backgroundSoundPalette = Guerilla.ReadBlockArray<StructureBspBackgroundSoundPaletteBlock>( binaryReader );
            soundEnvironmentPalette = Guerilla.ReadBlockArray<StructureBspSoundEnvironmentPaletteBlock>( binaryReader );
            weatherPalette = Guerilla.ReadBlockArray<StructureBspWeatherPaletteBlock>( binaryReader );
            atmosphericFogPalette = Guerilla.ReadBlockArray<ScenarioAtmosphericFogPalette>( binaryReader );
        }

        public override int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                nextAddress = Guerilla.WriteBlockArray<ScenarioClusterDataBlock>( binaryWriter, clusterData, nextAddress );
                nextAddress = Guerilla.WriteBlockArray<StructureBspBackgroundSoundPaletteBlock>( binaryWriter,
                    backgroundSoundPalette, nextAddress );
                nextAddress = Guerilla.WriteBlockArray<StructureBspSoundEnvironmentPaletteBlock>( binaryWriter,
                    soundEnvironmentPalette, nextAddress );
                nextAddress = Guerilla.WriteBlockArray<StructureBspWeatherPaletteBlock>( binaryWriter, weatherPalette,
                    nextAddress );
                nextAddress = Guerilla.WriteBlockArray<ScenarioAtmosphericFogPalette>( binaryWriter,
                    atmosphericFogPalette, nextAddress );
                return nextAddress;
            }
        }
    };
}