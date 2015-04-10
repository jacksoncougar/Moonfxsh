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
    [LayoutAttribute(Size = 28)]
    public class LightVolumeAspectBlockBase
    {
        internal ScalarFunctionStructBlock alongAxis;
        internal ScalarFunctionStructBlock awayFromAxis;
        internal float parallelScale;
        internal float parallelThresholdAngleDegrees;
        internal float parallelExponent;
        internal  LightVolumeAspectBlockBase(BinaryReader binaryReader)
        {
            this.alongAxis = new ScalarFunctionStructBlock(binaryReader);
            this.awayFromAxis = new ScalarFunctionStructBlock(binaryReader);
            this.parallelScale = binaryReader.ReadSingle();
            this.parallelThresholdAngleDegrees = binaryReader.ReadSingle();
            this.parallelExponent = binaryReader.ReadSingle();
        }
        internal  virtual byte[] ReadData(BinaryReader binaryReader)
        {
            var blamPointer = binaryReader.ReadBlamPointer(1);
            var data = new byte[blamPointer.count];
            if(blamPointer.count > 0)
            {
                using (binaryReader.BaseStream.Pin())
                {
                    binaryReader.BaseStream.Position = blamPointer[0];
                    data = binaryReader.ReadBytes(blamPointer.count);
                }
            }
            return data;
        }
    };
}
