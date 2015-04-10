// ReSharper disable All
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
        public  GearBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
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
        internal  GearBlockBase(System.IO.BinaryReader binaryReader)
        {
            loadedTorqueCurve = new TorqueCurveStructBlock(binaryReader);
            cruisingTorqueCurve = new TorqueCurveStructBlock(binaryReader);
            minTimeToUpshift = binaryReader.ReadSingle();
            engineUpShiftScale = binaryReader.ReadSingle();
            gearRatio = binaryReader.ReadSingle();
            minTimeToDownshift = binaryReader.ReadSingle();
            engineDownShiftScale = binaryReader.ReadSingle();
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
                loadedTorqueCurve.Write(binaryWriter);
                cruisingTorqueCurve.Write(binaryWriter);
                binaryWriter.Write(minTimeToUpshift);
                binaryWriter.Write(engineUpShiftScale);
                binaryWriter.Write(gearRatio);
                binaryWriter.Write(minTimeToDownshift);
                binaryWriter.Write(engineDownShiftScale);
            }
        }
    };
}
