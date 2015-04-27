// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class EffectEventBlock : EffectEventBlockBase
    {
        public EffectEventBlock( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 56, Alignment = 4 )]
    public class EffectEventBlockBase : GuerillaBlock
    {
        internal Flags flags;

        /// <summary>
        /// chance that this event will be skipped entirely
        /// </summary>
        internal float skipFraction;

        /// <summary>
        /// delay before this event takes place
        /// </summary>
        internal Moonfish.Model.Range delayBoundsSeconds;

        /// <summary>
        /// duration of this event
        /// </summary>
        internal Moonfish.Model.Range durationBoundsSeconds;

        internal EffectPartBlock[] parts;
        internal BeamBlock[] beams;
        internal EffectAccelerationsBlock[] accelerations;
        internal ParticleSystemDefinitionBlockNew[] particleSystems;

        public override int SerializedSize
        {
            get { return 56; }
        }

        internal EffectEventBlockBase( BinaryReader binaryReader ) : base( binaryReader )
        {
            flags = ( Flags ) binaryReader.ReadInt32( );
            skipFraction = binaryReader.ReadSingle( );
            delayBoundsSeconds = binaryReader.ReadRange( );
            durationBoundsSeconds = binaryReader.ReadRange( );
            parts = Guerilla.ReadBlockArray<EffectPartBlock>( binaryReader );
            beams = Guerilla.ReadBlockArray<BeamBlock>( binaryReader );
            accelerations = Guerilla.ReadBlockArray<EffectAccelerationsBlock>( binaryReader );
            particleSystems = Guerilla.ReadBlockArray<ParticleSystemDefinitionBlockNew>( binaryReader );
        }

        public override int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                binaryWriter.Write( ( Int32 ) flags );
                binaryWriter.Write( skipFraction );
                binaryWriter.Write( delayBoundsSeconds );
                binaryWriter.Write( durationBoundsSeconds );
                nextAddress = Guerilla.WriteBlockArray<EffectPartBlock>( binaryWriter, parts, nextAddress );
                nextAddress = Guerilla.WriteBlockArray<BeamBlock>( binaryWriter, beams, nextAddress );
                nextAddress = Guerilla.WriteBlockArray<EffectAccelerationsBlock>( binaryWriter, accelerations,
                    nextAddress );
                nextAddress = Guerilla.WriteBlockArray<ParticleSystemDefinitionBlockNew>( binaryWriter, particleSystems,
                    nextAddress );
                return nextAddress;
            }
        }

        [FlagsAttribute]
        internal enum Flags : int
        {
            DisabledForDebugging = 1,
        };
    };
}