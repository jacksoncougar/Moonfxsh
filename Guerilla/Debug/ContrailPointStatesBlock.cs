// ReSharper disable All
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
        public  ContrailPointStatesBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
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
        internal  ContrailPointStatesBlockBase(System.IO.BinaryReader binaryReader)
        {
            durationSecondsSeconds = binaryReader.ReadRange();
            transitionDurationSeconds = binaryReader.ReadRange();
            physics = binaryReader.ReadTagReference();
            widthWorldUnits = binaryReader.ReadSingle();
            colorLowerBound = binaryReader.ReadVector4();
            colorUpperBound = binaryReader.ReadVector4();
            scaleFlags = (ScaleFlagsTheseFlagsDetermineWhichFieldsAreScaledByTheContrailDensity)binaryReader.ReadInt32();
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
                binaryWriter.Write(durationSecondsSeconds);
                binaryWriter.Write(transitionDurationSeconds);
                binaryWriter.Write(physics);
                binaryWriter.Write(widthWorldUnits);
                binaryWriter.Write(colorLowerBound);
                binaryWriter.Write(colorUpperBound);
                binaryWriter.Write((Int32)scaleFlags);
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
