// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class TorqueCurveStructBlock : TorqueCurveStructBlockBase
    {
        public  TorqueCurveStructBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 24, Alignment = 4)]
    public class TorqueCurveStructBlockBase  : IGuerilla
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
        internal  TorqueCurveStructBlockBase(BinaryReader binaryReader)
        {
            minTorque = binaryReader.ReadSingle();
            maxTorque = binaryReader.ReadSingle();
            peakTorqueScale = binaryReader.ReadSingle();
            pastPeakTorqueExponent = binaryReader.ReadSingle();
            torqueAtMaxAngularVelocity = binaryReader.ReadSingle();
            torqueAt2XMaxAngularVelocity = binaryReader.ReadSingle();
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(minTorque);
                binaryWriter.Write(maxTorque);
                binaryWriter.Write(peakTorqueScale);
                binaryWriter.Write(pastPeakTorqueExponent);
                binaryWriter.Write(torqueAtMaxAngularVelocity);
                binaryWriter.Write(torqueAt2XMaxAngularVelocity);
                return nextAddress = (int)binaryWriter.BaseStream.Position;
            }
        }
    };
}
