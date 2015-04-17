// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class StructureLightmapLightingEnvironmentBlock : StructureLightmapLightingEnvironmentBlockBase
    {
        public StructureLightmapLightingEnvironmentBlock( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 220, Alignment = 4 )]
    public class StructureLightmapLightingEnvironmentBlockBase : IGuerilla
    {
        internal OpenTK.Vector3 samplePoint;
        internal RedCoefficients[] redCoefficients;
        internal GreenCoefficients[] greenCoefficients;
        internal BlueCoefficients[] blueCoefficients;
        internal OpenTK.Vector3 meanIncomingLightDirection;
        internal OpenTK.Vector3 incomingLightIntensity;
        internal int specularBitmapIndex;
        internal OpenTK.Vector3 rotationAxis;
        internal float rotationSpeed;
        internal OpenTK.Vector3 bumpDirection;
        internal Moonfish.Tags.ColorR8G8B8 colorTint;
        internal ProceduralOveride proceduralOveride;
        internal Flags flags;
        internal OpenTK.Vector3 proceduralParam0;
        internal OpenTK.Vector3 proceduralParam1Xyz;
        internal float proceduralParam1W;

        internal StructureLightmapLightingEnvironmentBlockBase( BinaryReader binaryReader )
        {
            samplePoint = binaryReader.ReadVector3( );
            redCoefficients = new[]
            {
                new RedCoefficients( binaryReader ), new RedCoefficients( binaryReader ),
                new RedCoefficients( binaryReader ), new RedCoefficients( binaryReader ),
                new RedCoefficients( binaryReader ), new RedCoefficients( binaryReader ),
                new RedCoefficients( binaryReader ), new RedCoefficients( binaryReader ),
                new RedCoefficients( binaryReader ),
            };
            greenCoefficients = new[]
            {
                new GreenCoefficients( binaryReader ), new GreenCoefficients( binaryReader ),
                new GreenCoefficients( binaryReader ), new GreenCoefficients( binaryReader ),
                new GreenCoefficients( binaryReader ), new GreenCoefficients( binaryReader ),
                new GreenCoefficients( binaryReader ), new GreenCoefficients( binaryReader ),
                new GreenCoefficients( binaryReader ),
            };
            blueCoefficients = new[]
            {
                new BlueCoefficients( binaryReader ), new BlueCoefficients( binaryReader ),
                new BlueCoefficients( binaryReader ), new BlueCoefficients( binaryReader ),
                new BlueCoefficients( binaryReader ), new BlueCoefficients( binaryReader ),
                new BlueCoefficients( binaryReader ), new BlueCoefficients( binaryReader ),
                new BlueCoefficients( binaryReader ),
            };
            meanIncomingLightDirection = binaryReader.ReadVector3( );
            incomingLightIntensity = binaryReader.ReadVector3( );
            specularBitmapIndex = binaryReader.ReadInt32( );
            rotationAxis = binaryReader.ReadVector3( );
            rotationSpeed = binaryReader.ReadSingle( );
            bumpDirection = binaryReader.ReadVector3( );
            colorTint = binaryReader.ReadColorR8G8B8( );
            proceduralOveride = ( ProceduralOveride ) binaryReader.ReadInt16( );
            flags = ( Flags ) binaryReader.ReadInt16( );
            proceduralParam0 = binaryReader.ReadVector3( );
            proceduralParam1Xyz = binaryReader.ReadVector3( );
            proceduralParam1W = binaryReader.ReadSingle( );
        }

        public int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                binaryWriter.Write( samplePoint );
                redCoefficients[ 0 ].Write( binaryWriter );
                redCoefficients[ 1 ].Write( binaryWriter );
                redCoefficients[ 2 ].Write( binaryWriter );
                redCoefficients[ 3 ].Write( binaryWriter );
                redCoefficients[ 4 ].Write( binaryWriter );
                redCoefficients[ 5 ].Write( binaryWriter );
                redCoefficients[ 6 ].Write( binaryWriter );
                redCoefficients[ 7 ].Write( binaryWriter );
                redCoefficients[ 8 ].Write( binaryWriter );
                greenCoefficients[ 0 ].Write( binaryWriter );
                greenCoefficients[ 1 ].Write( binaryWriter );
                greenCoefficients[ 2 ].Write( binaryWriter );
                greenCoefficients[ 3 ].Write( binaryWriter );
                greenCoefficients[ 4 ].Write( binaryWriter );
                greenCoefficients[ 5 ].Write( binaryWriter );
                greenCoefficients[ 6 ].Write( binaryWriter );
                greenCoefficients[ 7 ].Write( binaryWriter );
                greenCoefficients[ 8 ].Write( binaryWriter );
                blueCoefficients[ 0 ].Write( binaryWriter );
                blueCoefficients[ 1 ].Write( binaryWriter );
                blueCoefficients[ 2 ].Write( binaryWriter );
                blueCoefficients[ 3 ].Write( binaryWriter );
                blueCoefficients[ 4 ].Write( binaryWriter );
                blueCoefficients[ 5 ].Write( binaryWriter );
                blueCoefficients[ 6 ].Write( binaryWriter );
                blueCoefficients[ 7 ].Write( binaryWriter );
                blueCoefficients[ 8 ].Write( binaryWriter );
                binaryWriter.Write( meanIncomingLightDirection );
                binaryWriter.Write( incomingLightIntensity );
                binaryWriter.Write( specularBitmapIndex );
                binaryWriter.Write( rotationAxis );
                binaryWriter.Write( rotationSpeed );
                binaryWriter.Write( bumpDirection );
                binaryWriter.Write( colorTint );
                binaryWriter.Write( ( Int16 ) proceduralOveride );
                binaryWriter.Write( ( Int16 ) flags );
                binaryWriter.Write( proceduralParam0 );
                binaryWriter.Write( proceduralParam1Xyz );
                binaryWriter.Write( proceduralParam1W );
                return nextAddress;
            }
        }

        internal enum ProceduralOveride : short
        {
            NoOveride = 0,
            CIEClearSky = 1,
            CIEPartlyCloudy = 2,
            CIECloudy = 3,
            DirectionalLight = 4,
            ConeLight = 5,
            SphereLight = 6,
            HemisphereLight = 7,
        };

        [FlagsAttribute]
        internal enum Flags : short
        {
            LeaveMeAlonePlease = 1,
        };

        public class RedCoefficients : IGuerilla
        {
            internal float redCoefficient;

            internal RedCoefficients( BinaryReader binaryReader )
            {
                redCoefficient = binaryReader.ReadSingle( );
            }

            public int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
            {
                using ( binaryWriter.BaseStream.Pin( ) )
                {
                    binaryWriter.Write( redCoefficient );
                    return nextAddress;
                }
            }
        };

        public class GreenCoefficients : IGuerilla
        {
            internal float greenCoefficient;

            internal GreenCoefficients( BinaryReader binaryReader )
            {
                greenCoefficient = binaryReader.ReadSingle( );
            }

            public int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
            {
                using ( binaryWriter.BaseStream.Pin( ) )
                {
                    binaryWriter.Write( greenCoefficient );
                    return nextAddress;
                }
            }
        };

        public class BlueCoefficients : IGuerilla
        {
            internal float blueCoefficient;

            internal BlueCoefficients( BinaryReader binaryReader )
            {
                blueCoefficient = binaryReader.ReadSingle( );
            }

            public int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
            {
                using ( binaryWriter.BaseStream.Pin( ) )
                {
                    binaryWriter.Write( blueCoefficient );
                    return nextAddress;
                }
            }
        };
    };
}