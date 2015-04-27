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
        public static readonly TagClass Pmov = ( TagClass ) "pmov";
    };
} ;

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute( "pmov" )]
    public partial class ParticlePhysicsBlock : ParticlePhysicsBlockBase
    {
        public ParticlePhysicsBlock( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 20, Alignment = 4 )]
    public class ParticlePhysicsBlockBase : IGuerilla
    {
        [TagReference( "pmov" )] internal Moonfish.Tags.TagReference template;
        internal Flags flags;
        internal ParticleController[] movements;

        internal ParticlePhysicsBlockBase( BinaryReader binaryReader )
        {
            template = binaryReader.ReadTagReference( );
            flags = ( Flags ) binaryReader.ReadInt32( );
            movements = Guerilla.ReadBlockArray<ParticleController>( binaryReader );
        }

        public int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                binaryWriter.Write( template );
                binaryWriter.Write( ( Int32 ) flags );
                nextAddress = Guerilla.WriteBlockArray<ParticleController>( binaryWriter, movements, nextAddress );
                return nextAddress;
            }
        }

        [FlagsAttribute]
        internal enum Flags : int
        {
            Physics = 1,
            CollideWithStructure = 2,
            CollideWithMedia = 4,
            CollideWithScenery = 8,
            CollideWithVehicles = 16,
            CollideWithBipeds = 32,
            Swarm = 64,
            Wind = 128,
        };
    };
}