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
        public  TorqueCurveStructBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 24)]
    public class TorqueCurveStructBlockBase
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
        internal  TorqueCurveStructBlockBase(System.IO.BinaryReader binaryReader)
        {
            minTorque = binaryReader.ReadSingle();
            maxTorque = binaryReader.ReadSingle();
            peakTorqueScale = binaryReader.ReadSingle();
            pastPeakTorqueExponent = binaryReader.ReadSingle();
            torqueAtMaxAngularVelocity = binaryReader.ReadSingle();
            torqueAt2XMaxAngularVelocity = binaryReader.ReadSingle();
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
                binaryWriter.Write(minTorque);
                binaryWriter.Write(maxTorque);
                binaryWriter.Write(peakTorqueScale);
                binaryWriter.Write(pastPeakTorqueExponent);
                binaryWriter.Write(torqueAtMaxAngularVelocity);
                binaryWriter.Write(torqueAt2XMaxAngularVelocity);
            }
        }
    };
}
