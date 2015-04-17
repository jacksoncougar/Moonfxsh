// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class GlobalWindModelStructBlock : GlobalWindModelStructBlockBase
    {
        public GlobalWindModelStructBlock( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 156, Alignment = 4 )]
    public class GlobalWindModelStructBlockBase : IGuerilla
    {
        internal float windTilingScale;
        internal OpenTK.Vector3 windPrimaryHeadingPitchStrength;
        internal float primaryRateOfChange;
        internal float primaryMinStrength;
        internal byte[] invalidName_;
        internal byte[] invalidName_0;
        internal byte[] invalidName_1;
        internal OpenTK.Vector3 windGustingHeadingPitchStrength;
        internal float gustDiretionalRateOfChange;
        internal float gustStrengthRateOfChange;
        internal float gustConeAngle;
        internal byte[] invalidName_2;
        internal byte[] invalidName_3;
        internal byte[] invalidName_4;
        internal byte[] invalidName_5;
        internal byte[] invalidName_6;
        internal byte[] invalidName_7;
        internal float turbulanceRateOfChange;
        internal OpenTK.Vector3 turbulenceScaleXYZ;
        internal float gravityConstant;
        internal GloalWindPrimitivesBlock[] windPirmitives;
        internal byte[] invalidName_8;

        internal GlobalWindModelStructBlockBase( BinaryReader binaryReader )
        {
            windTilingScale = binaryReader.ReadSingle( );
            windPrimaryHeadingPitchStrength = binaryReader.ReadVector3( );
            primaryRateOfChange = binaryReader.ReadSingle( );
            primaryMinStrength = binaryReader.ReadSingle( );
            invalidName_ = binaryReader.ReadBytes( 4 );
            invalidName_0 = binaryReader.ReadBytes( 4 );
            invalidName_1 = binaryReader.ReadBytes( 12 );
            windGustingHeadingPitchStrength = binaryReader.ReadVector3( );
            gustDiretionalRateOfChange = binaryReader.ReadSingle( );
            gustStrengthRateOfChange = binaryReader.ReadSingle( );
            gustConeAngle = binaryReader.ReadSingle( );
            invalidName_2 = binaryReader.ReadBytes( 4 );
            invalidName_3 = binaryReader.ReadBytes( 4 );
            invalidName_4 = binaryReader.ReadBytes( 12 );
            invalidName_5 = binaryReader.ReadBytes( 12 );
            invalidName_6 = binaryReader.ReadBytes( 12 );
            invalidName_7 = binaryReader.ReadBytes( 12 );
            turbulanceRateOfChange = binaryReader.ReadSingle( );
            turbulenceScaleXYZ = binaryReader.ReadVector3( );
            gravityConstant = binaryReader.ReadSingle( );
            windPirmitives = Guerilla.ReadBlockArray<GloalWindPrimitivesBlock>( binaryReader );
            invalidName_8 = binaryReader.ReadBytes( 4 );
        }

        public int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                binaryWriter.Write( windTilingScale );
                binaryWriter.Write( windPrimaryHeadingPitchStrength );
                binaryWriter.Write( primaryRateOfChange );
                binaryWriter.Write( primaryMinStrength );
                binaryWriter.Write( invalidName_, 0, 4 );
                binaryWriter.Write( invalidName_0, 0, 4 );
                binaryWriter.Write( invalidName_1, 0, 12 );
                binaryWriter.Write( windGustingHeadingPitchStrength );
                binaryWriter.Write( gustDiretionalRateOfChange );
                binaryWriter.Write( gustStrengthRateOfChange );
                binaryWriter.Write( gustConeAngle );
                binaryWriter.Write( invalidName_2, 0, 4 );
                binaryWriter.Write( invalidName_3, 0, 4 );
                binaryWriter.Write( invalidName_4, 0, 12 );
                binaryWriter.Write( invalidName_5, 0, 12 );
                binaryWriter.Write( invalidName_6, 0, 12 );
                binaryWriter.Write( invalidName_7, 0, 12 );
                binaryWriter.Write( turbulanceRateOfChange );
                binaryWriter.Write( turbulenceScaleXYZ );
                binaryWriter.Write( gravityConstant );
                nextAddress = Guerilla.WriteBlockArray<GloalWindPrimitivesBlock>( binaryWriter, windPirmitives,
                    nextAddress );
                binaryWriter.Write( invalidName_8, 0, 4 );
                return nextAddress;
            }
        }
    };
}