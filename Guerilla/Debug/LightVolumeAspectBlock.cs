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
        public  LightVolumeAspectBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 28)]
    public class LightVolumeAspectBlockBase
    {
        internal ScalarFunctionStructBlock alongAxis;
        internal ScalarFunctionStructBlock awayFromAxis;
        internal float parallelScale;
        internal float parallelThresholdAngleDegrees;
        internal float parallelExponent;
        internal  LightVolumeAspectBlockBase(System.IO.BinaryReader binaryReader)
        {
            alongAxis = new ScalarFunctionStructBlock(binaryReader);
            awayFromAxis = new ScalarFunctionStructBlock(binaryReader);
            parallelScale = binaryReader.ReadSingle();
            parallelThresholdAngleDegrees = binaryReader.ReadSingle();
            parallelExponent = binaryReader.ReadSingle();
        }
        internal  virtual byte[] ReadData(System.IO.BinaryReader binaryReader)
        {
            var blamPointer = binaryReader.ReadBlamPointer(1);
            var data = new byte[blamPointer.Count];
            if(blamPointer.Count > 0)
            {
                using (binaryReader.BaseStream.Pin())
                {
                    binaryReader.BaseStream.Position = blamPointer[0];
                    data = binaryReader.ReadBytes(blamPointer.Count);
                }
            }
            return data;
        }
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                alongAxis.Write(binaryWriter);
                awayFromAxis.Write(binaryWriter);
                binaryWriter.Write(parallelScale);
                binaryWriter.Write(parallelThresholdAngleDegrees);
                binaryWriter.Write(parallelExponent);
            }
        }
    };
}
