// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Moonfish.Guerilla.Tags
{
    public partial class LightVolumeAspectBlock : LightVolumeAspectBlockBase
    {
        public LightVolumeAspectBlock() : base()
        {
        }
    };
    [LayoutAttribute(Size = 28, Alignment = 4)]
    public class LightVolumeAspectBlockBase : GuerillaBlock
    {
        internal ScalarFunctionStructBlock alongAxis;
        internal ScalarFunctionStructBlock awayFromAxis;
        internal float parallelScale;
        internal float parallelThresholdAngleDegrees;
        internal float parallelExponent;
        public override int SerializedSize { get { return 28; } }
        public override int Alignment { get { return 4; } }
        public LightVolumeAspectBlockBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            alongAxis = new ScalarFunctionStructBlock();
            blamPointers.Concat(alongAxis.ReadFields(binaryReader));
            awayFromAxis = new ScalarFunctionStructBlock();
            blamPointers.Concat(awayFromAxis.ReadFields(binaryReader));
            parallelScale = binaryReader.ReadSingle();
            parallelThresholdAngleDegrees = binaryReader.ReadSingle();
            parallelExponent = binaryReader.ReadSingle();
            return blamPointers;
        }
        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            alongAxis.ReadPointers(binaryReader, blamPointers);
            awayFromAxis.ReadPointers(binaryReader, blamPointers);
        }
        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
using(binaryWriter.BaseStream.Pin())
            {
                alongAxis.Write(binaryWriter);
                awayFromAxis.Write(binaryWriter);
                binaryWriter.Write(parallelScale);
                binaryWriter.Write(parallelThresholdAngleDegrees);
                binaryWriter.Write(parallelExponent);
                return nextAddress;
            }
        }
    };
}
