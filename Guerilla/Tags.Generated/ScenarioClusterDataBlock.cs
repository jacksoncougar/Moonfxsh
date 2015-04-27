// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class ScenarioClusterDataBlock : ScenarioClusterDataBlockBase
    {
        public ScenarioClusterDataBlock( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 52, Alignment = 4 )]
    public class ScenarioClusterDataBlockBase : GuerillaBlock
    {
        [TagReference( "sbsp" )] internal Moonfish.Tags.TagReference bSP;
        internal ScenarioClusterBackgroundSoundsBlock[] backgroundSounds;
        internal ScenarioClusterSoundEnvironmentsBlock[] soundEnvironments;
        internal int bSPChecksum;
        internal ScenarioClusterPointsBlock[] clusterCentroids;
        internal ScenarioClusterWeatherPropertiesBlock[] weatherProperties;
        internal ScenarioClusterAtmosphericFogPropertiesBlock[] atmosphericFogProperties;

        public override int SerializedSize
        {
            get { return 52; }
        }

        internal ScenarioClusterDataBlockBase( BinaryReader binaryReader ) : base( binaryReader )
        {
            bSP = binaryReader.ReadTagReference( );
            backgroundSounds = Guerilla.ReadBlockArray<ScenarioClusterBackgroundSoundsBlock>( binaryReader );
            soundEnvironments = Guerilla.ReadBlockArray<ScenarioClusterSoundEnvironmentsBlock>( binaryReader );
            bSPChecksum = binaryReader.ReadInt32( );
            clusterCentroids = Guerilla.ReadBlockArray<ScenarioClusterPointsBlock>( binaryReader );
            weatherProperties = Guerilla.ReadBlockArray<ScenarioClusterWeatherPropertiesBlock>( binaryReader );
            atmosphericFogProperties =
                Guerilla.ReadBlockArray<ScenarioClusterAtmosphericFogPropertiesBlock>( binaryReader );
        }

        public override int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                binaryWriter.Write( bSP );
                nextAddress = Guerilla.WriteBlockArray<ScenarioClusterBackgroundSoundsBlock>( binaryWriter,
                    backgroundSounds, nextAddress );
                nextAddress = Guerilla.WriteBlockArray<ScenarioClusterSoundEnvironmentsBlock>( binaryWriter,
                    soundEnvironments, nextAddress );
                binaryWriter.Write( bSPChecksum );
                nextAddress = Guerilla.WriteBlockArray<ScenarioClusterPointsBlock>( binaryWriter, clusterCentroids,
                    nextAddress );
                nextAddress = Guerilla.WriteBlockArray<ScenarioClusterWeatherPropertiesBlock>( binaryWriter,
                    weatherProperties, nextAddress );
                nextAddress = Guerilla.WriteBlockArray<ScenarioClusterAtmosphericFogPropertiesBlock>( binaryWriter,
                    atmosphericFogProperties, nextAddress );
                return nextAddress;
            }
        }
    };
}