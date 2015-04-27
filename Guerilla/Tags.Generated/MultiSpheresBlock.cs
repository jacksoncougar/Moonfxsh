// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class MultiSpheresBlock : MultiSpheresBlockBase
    {
        public MultiSpheresBlock( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 176, Alignment = 16 )]
    public class MultiSpheresBlockBase : GuerillaBlock
    {
        internal Moonfish.Tags.StringID name;
        internal Moonfish.Tags.ShortBlockIndex1 material;
        internal Flags flags;
        internal float relativeMassScale;
        internal float friction;
        internal float restitution;
        internal float volume;
        internal float mass;
        internal byte[] invalidName_;
        internal Moonfish.Tags.ShortBlockIndex1 phantom;
        internal byte[] invalidName_0;
        internal short size;
        internal short count;
        internal byte[] invalidName_1;
        internal int numSpheres;
        internal FourVectorsStorage[] fourVectorsStorage;

        public override int SerializedSize
        {
            get { return 176; }
        }

        internal MultiSpheresBlockBase( BinaryReader binaryReader ) : base( binaryReader )
        {
            name = binaryReader.ReadStringID( );
            material = binaryReader.ReadShortBlockIndex1( );
            flags = ( Flags ) binaryReader.ReadInt16( );
            relativeMassScale = binaryReader.ReadSingle( );
            friction = binaryReader.ReadSingle( );
            restitution = binaryReader.ReadSingle( );
            volume = binaryReader.ReadSingle( );
            mass = binaryReader.ReadSingle( );
            invalidName_ = binaryReader.ReadBytes( 2 );
            phantom = binaryReader.ReadShortBlockIndex1( );
            invalidName_0 = binaryReader.ReadBytes( 4 );
            size = binaryReader.ReadInt16( );
            count = binaryReader.ReadInt16( );
            invalidName_1 = binaryReader.ReadBytes( 4 );
            numSpheres = binaryReader.ReadInt32( );
            fourVectorsStorage = new[]
            {
                new FourVectorsStorage( binaryReader ), new FourVectorsStorage( binaryReader ),
                new FourVectorsStorage( binaryReader ), new FourVectorsStorage( binaryReader ),
                new FourVectorsStorage( binaryReader ), new FourVectorsStorage( binaryReader ),
                new FourVectorsStorage( binaryReader ), new FourVectorsStorage( binaryReader ),
            };
        }

        public override int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                binaryWriter.Write( name );
                binaryWriter.Write( material );
                binaryWriter.Write( ( Int16 ) flags );
                binaryWriter.Write( relativeMassScale );
                binaryWriter.Write( friction );
                binaryWriter.Write( restitution );
                binaryWriter.Write( volume );
                binaryWriter.Write( mass );
                binaryWriter.Write( invalidName_, 0, 2 );
                binaryWriter.Write( phantom );
                binaryWriter.Write( invalidName_0, 0, 4 );
                binaryWriter.Write( size );
                binaryWriter.Write( count );
                binaryWriter.Write( invalidName_1, 0, 4 );
                binaryWriter.Write( numSpheres );
                fourVectorsStorage[ 0 ].Write( binaryWriter );
                fourVectorsStorage[ 1 ].Write( binaryWriter );
                fourVectorsStorage[ 2 ].Write( binaryWriter );
                fourVectorsStorage[ 3 ].Write( binaryWriter );
                fourVectorsStorage[ 4 ].Write( binaryWriter );
                fourVectorsStorage[ 5 ].Write( binaryWriter );
                fourVectorsStorage[ 6 ].Write( binaryWriter );
                fourVectorsStorage[ 7 ].Write( binaryWriter );
                return nextAddress;
            }
        }

        [FlagsAttribute]
        internal enum Flags : short
        {
            Unused = 1,
        };

        [LayoutAttribute( Size = 16, Alignment = 1 )]
        public class FourVectorsStorage : GuerillaBlock
        {
            internal OpenTK.Vector3 sphere;
            internal byte[] invalidName_;

            public override int SerializedSize
            {
                get { return 16; }
            }

            internal FourVectorsStorage( BinaryReader binaryReader ) : base( binaryReader )
            {
                sphere = binaryReader.ReadVector3( );
                invalidName_ = binaryReader.ReadBytes( 4 );
            }

            public override int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
            {
                using ( binaryWriter.BaseStream.Pin( ) )
                {
                    binaryWriter.Write( sphere );
                    binaryWriter.Write( invalidName_, 0, 4 );
                    return nextAddress;
                }
            }
        };
    };
}