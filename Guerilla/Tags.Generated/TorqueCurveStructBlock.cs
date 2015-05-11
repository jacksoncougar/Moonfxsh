// ReSharper disable All

using Moonfish.Model;

using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Moonfish.Guerilla.Tags
{
    public partial class TorqueCurveStructBlock : TorqueCurveStructBlockBase
    {
        public TorqueCurveStructBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 24, Alignment = 4)]
    public class TorqueCurveStructBlockBase : GuerillaBlock
    {
        internal float minTorque;
        internal float maxTorque;
        internal float peakTorqueScale;
        internal float pastPeakTorqueExponent;

        /// <summary>
        /// generally 0 for loading torque and something less than max torque for cruising torque
        /// </summary>
        internal float torqueAtMaxAngularVelocity;

        internal float torqueAt2XMaxAngularVelocity;

        public override int SerializedSize
        {
            get { return 24; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public TorqueCurveStructBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            minTorque = binaryReader.ReadSingle();
            maxTorque = binaryReader.ReadSingle();
            peakTorqueScale = binaryReader.ReadSingle();
            pastPeakTorqueExponent = binaryReader.ReadSingle();
            torqueAtMaxAngularVelocity = binaryReader.ReadSingle();
            torqueAt2XMaxAngularVelocity = binaryReader.ReadSingle();
            return blamPointers;
        }

        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
        }

        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
            using (binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(minTorque);
                binaryWriter.Write(maxTorque);
                binaryWriter.Write(peakTorqueScale);
                binaryWriter.Write(pastPeakTorqueExponent);
                binaryWriter.Write(torqueAtMaxAngularVelocity);
                binaryWriter.Write(torqueAt2XMaxAngularVelocity);
                return nextAddress;
            }
        }
    };
}