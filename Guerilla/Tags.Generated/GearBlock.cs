// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class GearBlock : GearBlockBase
    {
        public  GearBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  GearBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 68, Alignment = 4)]
    public class GearBlockBase : GuerillaBlock
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
        
        public override int SerializedSize{get { return 68; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  GearBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            loadedTorqueCurve = new TorqueCurveStructBlock(binaryReader);
            cruisingTorqueCurve = new TorqueCurveStructBlock(binaryReader);
            minTimeToUpshift = binaryReader.ReadSingle();
            engineUpShiftScale = binaryReader.ReadSingle();
            gearRatio = binaryReader.ReadSingle();
            minTimeToDownshift = binaryReader.ReadSingle();
            engineDownShiftScale = binaryReader.ReadSingle();
        }
        public  GearBlockBase(): base()
        {
            
        }
        public void Read(BinaryReader binaryReader)
        {
            loadedTorqueCurve = new TorqueCurveStructBlock(binaryReader);
            cruisingTorqueCurve = new TorqueCurveStructBlock(binaryReader);
            minTimeToUpshift = binaryReader.ReadSingle();
            engineUpShiftScale = binaryReader.ReadSingle();
            gearRatio = binaryReader.ReadSingle();
            minTimeToDownshift = binaryReader.ReadSingle();
            engineDownShiftScale = binaryReader.ReadSingle();
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
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
                return nextAddress;
            }
        }
    };
}
