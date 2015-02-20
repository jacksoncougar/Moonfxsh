using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class ScenarioFunctionBlock : ScenarioFunctionBlockBase
    {
        public  ScenarioFunctionBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 120)]
    public class ScenarioFunctionBlockBase
    {
        internal Flags flags;
        internal Moonfish.Tags.String32 name;
        /// <summary>
        /// Period for above function (lower values make function oscillate quickly; higher values make it oscillate slowly).
        /// </summary>
        internal float periodSeconds;
        /// <summary>
        /// Multiply this function by above period
        /// </summary>
        internal Moonfish.Tags.ShortBlockIndex1 scalePeriodBy;
        internal Function function;
        /// <summary>
        /// Multiply this function by result of above function.
        /// </summary>
        internal Moonfish.Tags.ShortBlockIndex1 scaleFunctionBy;
        /// <summary>
        /// Curve used for wobble.
        /// </summary>
        internal WobbleFunctionCurveUsedForWobble wobbleFunction;
        /// <summary>
        /// Time it takes for magnitude of this function to complete a wobble.
        /// </summary>
        internal float wobblePeriodSeconds;
        /// <summary>
        /// Amount of random wobble in the magnitude.
        /// </summary>
        internal float wobbleMagnitudePercent;
        /// <summary>
        /// If non-zero, all values above square wave threshold are snapped to 1.0, and all values below it are snapped to 0.0 to create a square wave.
        /// </summary>
        internal float squareWaveThreshold;
        /// <summary>
        /// Number of discrete values to snap to (e.g., step count of 5 snaps function to 0.00, 0.25, 0.50,0.75, or 1.00).
        /// </summary>
        internal short stepCount;
        internal MapTo mapTo;
        /// <summary>
        /// Number of times this function should repeat (e.g., sawtooth count of 5 gives function value of 1.0 at each of 0.25, 0.50, and 0.75, as well as at 1.0).
        /// </summary>
        internal short sawtoothCount;
        internal byte[] invalidName_;
        /// <summary>
        /// Multiply this function (e.g., from a weapon, vehicle) final result of all of the above math.
        /// </summary>
        internal Moonfish.Tags.ShortBlockIndex1 scaleResultBy;
        /// <summary>
        /// Controls how bounds, below, are used.
        /// </summary>
        internal BoundsModeControlsHowBoundsBelowAreUsed boundsMode;
        internal OpenTK.Vector2 bounds;
        internal byte[] invalidName_0;
        internal byte[] invalidName_1;
        /// <summary>
        /// If specified function is off, so is this function.
        /// </summary>
        internal Moonfish.Tags.ShortBlockIndex1 turnOffWith;
        internal byte[] invalidName_2;
        internal byte[] invalidName_3;
        internal  ScenarioFunctionBlockBase(BinaryReader binaryReader)
        {
            this.flags = (Flags)binaryReader.ReadInt32();
            this.name = binaryReader.ReadString32();
            this.periodSeconds = binaryReader.ReadSingle();
            this.scalePeriodBy = binaryReader.ReadShortBlockIndex1();
            this.function = (Function)binaryReader.ReadInt16();
            this.scaleFunctionBy = binaryReader.ReadShortBlockIndex1();
            this.wobbleFunction = (WobbleFunctionCurveUsedForWobble)binaryReader.ReadInt16();
            this.wobblePeriodSeconds = binaryReader.ReadSingle();
            this.wobbleMagnitudePercent = binaryReader.ReadSingle();
            this.squareWaveThreshold = binaryReader.ReadSingle();
            this.stepCount = binaryReader.ReadInt16();
            this.mapTo = (MapTo)binaryReader.ReadInt16();
            this.sawtoothCount = binaryReader.ReadInt16();
            this.invalidName_ = binaryReader.ReadBytes(2);
            this.scaleResultBy = binaryReader.ReadShortBlockIndex1();
            this.boundsMode = (BoundsModeControlsHowBoundsBelowAreUsed)binaryReader.ReadInt16();
            this.bounds = binaryReader.ReadVector2();
            this.invalidName_0 = binaryReader.ReadBytes(4);
            this.invalidName_1 = binaryReader.ReadBytes(2);
            this.turnOffWith = binaryReader.ReadShortBlockIndex1();
            this.invalidName_2 = binaryReader.ReadBytes(16);
            this.invalidName_3 = binaryReader.ReadBytes(16);
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
        [FlagsAttribute]
        internal enum Flags : int
        
        {
            ScriptedLevelScriptWillSetThisValueOtherSettingsHereWillBeIgnored = 1,
            InvertResultOfFunctionIs1MinusActualResult = 2,
            Additive = 4,
            AlwaysActiveFunctionDoesNotDeactivateWhenAtOrBelowLowerBound = 8,
        };
        internal enum Function : short
        
        {
            One = 0,
            Zero = 1,
            Cosine = 2,
            CosineVariablePeriod = 3,
            DiagonalWave = 4,
            DiagonalWaveVariablePeriod = 5,
            Slide = 6,
            SlideVariablePeriod = 7,
            Noise = 8,
            Jitter = 9,
            Wander = 10,
            Spark = 11,
        };
        internal enum WobbleFunctionCurveUsedForWobble : short
        
        {
            One = 0,
            Zero = 1,
            Cosine = 2,
            CosineVariablePeriod = 3,
            DiagonalWave = 4,
            DiagonalWaveVariablePeriod = 5,
            Slide = 6,
            SlideVariablePeriod = 7,
            Noise = 8,
            Jitter = 9,
            Wander = 10,
            Spark = 11,
        };
        internal enum MapTo : short
        
        {
            Linear = 0,
            Early = 1,
            VeryEarly = 2,
            Late = 3,
            VeryLate = 4,
            Cosine = 5,
            One = 6,
            Zero = 7,
        };
        internal enum BoundsModeControlsHowBoundsBelowAreUsed : short
        
        {
            Clip = 0,
            ClipAndNormalize = 1,
            ScaleToFit = 2,
        };
    };
}
