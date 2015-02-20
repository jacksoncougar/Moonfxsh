using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class GearBlock : GearBlockBase
    {
        public  GearBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 68)]
    public class GearBlockBase
    {
        internal TorqueCurveStructBlock loadedTorqueCurve;
        internal TorqueCurveStructBlock cruisingTorqueCurve;
        /// <summary>
        /// seconds
        /// </summary>
        internal float minTimeToUpshift;
        /// <summary>
        /// 0-1
        /// </summary>
        internal float engineUpShiftScale;
        internal float gearRatio;
        /// <summary>
        /// seconds
        /// </summary>
        internal float minTimeToDownshift;
        /// <summary>
        /// 0-1
        /// </summary>
        internal float engineDownShiftScale;
        internal  GearBlockBase(BinaryReader binaryReader)
        {
            this.loadedTorqueCurve = new TorqueCurveStructBlock(binaryReader);
            this.cruisingTorqueCurve = new TorqueCurveStructBlock(binaryReader);
            this.minTimeToUpshift = binaryReader.ReadSingle();
            this.engineUpShiftScale = binaryReader.ReadSingle();
            this.gearRatio = binaryReader.ReadSingle();
            this.minTimeToDownshift = binaryReader.ReadSingle();
            this.engineDownShiftScale = binaryReader.ReadSingle();
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
