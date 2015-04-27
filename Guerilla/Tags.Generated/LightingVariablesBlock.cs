// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class LightingVariablesBlock : LightingVariablesBlockBase
    {
        public LightingVariablesBlock( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 144, Alignment = 4 )]
    public class LightingVariablesBlockBase : GuerillaBlock
    {
        internal ObjectAffected objectAffected;
        internal float lightmapBrightnessOffset;
        internal PrimaryLightStructBlock primaryLight;
        internal SecondaryLightStructBlock secondaryLight;
        internal AmbientLightStructBlock ambientLight;
        internal LightmapShadowsStructBlock lightmapShadows;

        public override int SerializedSize
        {
            get { return 144; }
        }

        internal LightingVariablesBlockBase( BinaryReader binaryReader ) : base( binaryReader )
        {
            objectAffected = ( ObjectAffected ) binaryReader.ReadInt32( );
            lightmapBrightnessOffset = binaryReader.ReadSingle( );
            primaryLight = new PrimaryLightStructBlock( binaryReader );
            secondaryLight = new SecondaryLightStructBlock( binaryReader );
            ambientLight = new AmbientLightStructBlock( binaryReader );
            lightmapShadows = new LightmapShadowsStructBlock( binaryReader );
        }

        public override int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                binaryWriter.Write( ( Int32 ) objectAffected );
                binaryWriter.Write( lightmapBrightnessOffset );
                primaryLight.Write( binaryWriter );
                secondaryLight.Write( binaryWriter );
                ambientLight.Write( binaryWriter );
                lightmapShadows.Write( binaryWriter );
                return nextAddress;
            }
        }

        [FlagsAttribute]
        internal enum ObjectAffected : int
        {
            All = 1,
            Biped = 2,
            Vehicle = 4,
            Weapon = 8,
            Equipment = 16,
            Garbage = 32,
            Projectile = 64,
            Scenery = 128,
            Machine = 256,
            Control = 512,
            LightFixture = 1024,
            SoundScenery = 2048,
            Crate = 4096,
            Creature = 8192,
        };
    };
}