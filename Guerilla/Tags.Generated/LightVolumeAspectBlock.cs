// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class LightVolumeAspectBlock : LightVolumeAspectBlockBase
    {
        public LightVolumeAspectBlock( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 28, Alignment = 4 )]
    public class LightVolumeAspectBlockBase : GuerillaBlock
    {
        internal ScalarFunctionStructBlock alongAxis;
        internal ScalarFunctionStructBlock awayFromAxis;
        internal float parallelScale;
        internal float parallelThresholdAngleDegrees;
        internal float parallelExponent;

        public override int SerializedSize
        {
            get { return 28; }
        }

        internal LightVolumeAspectBlockBase( BinaryReader binaryReader ) : base( binaryReader )
        {
            alongAxis = new ScalarFunctionStructBlock( binaryReader );
            awayFromAxis = new ScalarFunctionStructBlock( binaryReader );
            parallelScale = binaryReader.ReadSingle( );
            parallelThresholdAngleDegrees = binaryReader.ReadSingle( );
            parallelExponent = binaryReader.ReadSingle( );
        }

        public override int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                alongAxis.Write( binaryWriter );
                awayFromAxis.Write( binaryWriter );
                binaryWriter.Write( parallelScale );
                binaryWriter.Write( parallelThresholdAngleDegrees );
                binaryWriter.Write( parallelExponent );
                return nextAddress;
            }
        }
    };
}