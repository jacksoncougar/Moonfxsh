// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class LightVolumeAspectBlock : LightVolumeAspectBlockBase
    {
        public  LightVolumeAspectBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 28, Alignment = 4)]
    public class LightVolumeAspectBlockBase  : IGuerilla
    {
        internal ScalarFunctionStructBlock alongAxis;
        internal ScalarFunctionStructBlock awayFromAxis;
        internal float parallelScale;
        internal float parallelThresholdAngleDegrees;
        internal float parallelExponent;
        internal  LightVolumeAspectBlockBase(BinaryReader binaryReader)
        {
            alongAxis = new ScalarFunctionStructBlock(binaryReader);
            awayFromAxis = new ScalarFunctionStructBlock(binaryReader);
            parallelScale = binaryReader.ReadSingle();
            parallelThresholdAngleDegrees = binaryReader.ReadSingle();
            parallelExponent = binaryReader.ReadSingle();
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                alongAxis.Write(binaryWriter);
                awayFromAxis.Write(binaryWriter);
                binaryWriter.Write(parallelScale);
                binaryWriter.Write(parallelThresholdAngleDegrees);
                binaryWriter.Write(parallelExponent);
                return nextAddress = (int)binaryWriter.BaseStream.Position;
            }
        }
    };
}
