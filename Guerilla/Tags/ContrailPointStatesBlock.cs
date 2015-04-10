using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class ContrailPointStatesBlock : ContrailPointStatesBlockBase
    {
        public  ContrailPointStatesBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 64)]
    public class ContrailPointStatesBlockBase
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
        internal  ContrailPointStatesBlockBase(BinaryReader binaryReader)
        {
            this.durationSecondsSeconds = binaryReader.ReadRange();
            this.transitionDurationSeconds = binaryReader.ReadRange();
            this.physics = binaryReader.ReadTagReference();
            this.widthWorldUnits = binaryReader.ReadSingle();
            this.colorLowerBound = binaryReader.ReadVector4();
            this.colorUpperBound = binaryReader.ReadVector4();
            this.scaleFlags = (ScaleFlagsTheseFlagsDetermineWhichFieldsAreScaledByTheContrailDensity)binaryReader.ReadInt32();
        }
        internal  virtual byte[] ReadData(BinaryReader binaryReader)
        {
            var blamPointer = binaryReader.ReadBlamPointer(1);
            var data = new byte[blamPointer.count];
            if(blamPointer.count > 0)
            {
                using (binaryReader.BaseStream.Pin())
                {
                    binaryReader.BaseStream.Position = blamPointer[0];
                    data = binaryReader.ReadBytes(blamPointer.count);
                }
            }
            return data;
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
