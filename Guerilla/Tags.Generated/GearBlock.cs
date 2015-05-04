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
    public partial class GearBlock : GearBlockBase
    {
        public GearBlock() : base()
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
        public override int SerializedSize { get { return 68; } }
        public override int Alignment { get { return 4; } }
        public GearBlockBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            loadedTorqueCurve = new TorqueCurveStructBlock();
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(loadedTorqueCurve.ReadFields(binaryReader)));
            cruisingTorqueCurve = new TorqueCurveStructBlock();
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(cruisingTorqueCurve.ReadFields(binaryReader)));
            minTimeToUpshift = binaryReader.ReadSingle();
            engineUpShiftScale = binaryReader.ReadSingle();
            gearRatio = binaryReader.ReadSingle();
            minTimeToDownshift = binaryReader.ReadSingle();
            engineDownShiftScale = binaryReader.ReadSingle();
            return blamPointers;
        }
        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            loadedTorqueCurve.ReadPointers(binaryReader, blamPointers);
            cruisingTorqueCurve.ReadPointers(binaryReader, blamPointers);
        }
        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
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
