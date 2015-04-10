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
        internal  TorqueCurveStructBlockBase(BinaryReader binaryReader)
        {
            this.minTorque = binaryReader.ReadSingle();
            this.maxTorque = binaryReader.ReadSingle();
            this.peakTorqueScale = binaryReader.ReadSingle();
            this.pastPeakTorqueExponent = binaryReader.ReadSingle();
            this.torqueAtMaxAngularVelocity = binaryReader.ReadSingle();
            this.torqueAt2XMaxAngularVelocity = binaryReader.ReadSingle();
        }
        internal  virtual byte[] ReadData(BinaryReader binaryReader)
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
    };
}
