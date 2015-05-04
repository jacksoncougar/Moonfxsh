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
    public partial class ContrailPointStatesBlock : ContrailPointStatesBlockBase
    {
        public ContrailPointStatesBlock() : base()
        {
        }
    };
    [LayoutAttribute(Size = 64, Alignment = 4)]
    public class ContrailPointStatesBlockBase : GuerillaBlock
    {
        /// <summary>
        /// the time a point spends in this state
        /// </summary>
        internal Moonfish.Model.Range durationSecondsSeconds;
        /// <summary>
        /// the time a point takes to transition to the next state
        /// </summary>
        internal Moonfish.Model.Range transitionDurationSeconds;
        [TagReference("pphy")]
        internal Moonfish.Tags.TagReference physics;
        /// <summary>
        /// contrail width at this point
        /// </summary>
        internal float widthWorldUnits;
        /// <summary>
        /// contrail color at this point
        /// </summary>
        internal OpenTK.Vector4 colorLowerBound;
        /// <summary>
        /// contrail color at this point
        /// </summary>
        internal OpenTK.Vector4 colorUpperBound;
        /// <summary>
        /// these flags determine which fields are scaled by the contrail density
        /// </summary>
        internal ScaleFlagsTheseFlagsDetermineWhichFieldsAreScaledByTheContrailDensity scaleFlags;
        public override int SerializedSize { get { return 64; } }
        public override int Alignment { get { return 4; } }
        public ContrailPointStatesBlockBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            durationSecondsSeconds = binaryReader.ReadRange();
            transitionDurationSeconds = binaryReader.ReadRange();
            physics = binaryReader.ReadTagReference();
            widthWorldUnits = binaryReader.ReadSingle();
            colorLowerBound = binaryReader.ReadVector4();
            colorUpperBound = binaryReader.ReadVector4();
            scaleFlags = (ScaleFlagsTheseFlagsDetermineWhichFieldsAreScaledByTheContrailDensity)binaryReader.ReadInt32();
            return blamPointers;
        }
        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
        }
        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(durationSecondsSeconds);
                binaryWriter.Write(transitionDurationSeconds);
                binaryWriter.Write(physics);
                binaryWriter.Write(widthWorldUnits);
                binaryWriter.Write(colorLowerBound);
                binaryWriter.Write(colorUpperBound);
                binaryWriter.Write((Int32)scaleFlags);
                return nextAddress;
            }
        }
        [FlagsAttribute]
        internal enum ScaleFlagsTheseFlagsDetermineWhichFieldsAreScaledByTheContrailDensity : int
        {
            Duration = 1,
            DurationDelta = 2,
            TransitionDuration = 4,
            TransitionDurationDelta = 8,
            Width = 16,
            Color = 32,
        };
    };
}
