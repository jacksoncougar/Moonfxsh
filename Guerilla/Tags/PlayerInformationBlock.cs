using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class PlayerInformationBlock : PlayerInformationBlockBase
    {
        public  PlayerInformationBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 284)]
    public class PlayerInformationBlockBase
    {
        [TagReference("unit")]
        internal Moonfish.Tags.TagReference unused;
        internal byte[] invalidName_;
        internal float walkingSpeedWorldUnitsPerSecond;
        internal byte[] invalidName_0;
        internal float runForwardWorldUnitsPerSecond;
        internal float runBackwardWorldUnitsPerSecond;
        internal float runSidewaysWorldUnitsPerSecond;
        internal float runAccelerationWorldUnitsPerSecondSquared;
        internal float sneakForwardWorldUnitsPerSecond;
        internal float sneakBackwardWorldUnitsPerSecond;
        internal float sneakSidewaysWorldUnitsPerSecond;
        internal float sneakAccelerationWorldUnitsPerSecondSquared;
        internal float airborneAccelerationWorldUnitsPerSecondSquared;
        internal byte[] invalidName_1;
        internal OpenTK.Vector3 grenadeOrigin;
        internal byte[] invalidName_2;
        /// <summary>
        /// 1.0 prevents moving while stunned
        /// </summary>
        internal float stunMovementPenalty01;
        /// <summary>
        /// 1.0 prevents turning while stunned
        /// </summary>
        internal float stunTurningPenalty01;
        /// <summary>
        /// 1.0 prevents jumping while stunned
        /// </summary>
        internal float stunJumpingPenalty01;
        /// <summary>
        /// all stunning damage will last for at least this long
        /// </summary>
        internal float minimumStunTimeSeconds;
        /// <summary>
        /// no stunning damage will last for longer than this
        /// </summary>
        internal float maximumStunTimeSeconds;
        internal byte[] invalidName_3;
        internal Moonfish.Model.Range firstPersonIdleTimeSeconds;
        internal float firstPersonSkipFraction01;
        internal byte[] invalidName_4;
        [TagReference("effe")]
        internal Moonfish.Tags.TagReference coopRespawnEffect;
        internal int binocularsZoomCount;
        internal Moonfish.Model.Range binocularsZoomRange;
        [TagReference("snd!")]
        internal Moonfish.Tags.TagReference binocularsZoomInSound;
        [TagReference("snd!")]
        internal Moonfish.Tags.TagReference binocularsZoomOutSound;
        internal byte[] invalidName_5;
        [TagReference("snd!")]
        internal Moonfish.Tags.TagReference activeCamouflageOn;
        [TagReference("snd!")]
        internal Moonfish.Tags.TagReference activeCamouflageOff;
        [TagReference("snd!")]
        internal Moonfish.Tags.TagReference activeCamouflageError;
        [TagReference("snd!")]
        internal Moonfish.Tags.TagReference activeCamouflageReady;
        [TagReference("snd!")]
        internal Moonfish.Tags.TagReference flashlightOn;
        [TagReference("snd!")]
        internal Moonfish.Tags.TagReference flashlightOff;
        [TagReference("snd!")]
        internal Moonfish.Tags.TagReference iceCream;
        internal  PlayerInformationBlockBase(BinaryReader binaryReader)
        {
            this.unused = binaryReader.ReadTagReference();
            this.invalidName_ = binaryReader.ReadBytes(28);
            this.walkingSpeedWorldUnitsPerSecond = binaryReader.ReadSingle();
            this.invalidName_0 = binaryReader.ReadBytes(4);
            this.runForwardWorldUnitsPerSecond = binaryReader.ReadSingle();
            this.runBackwardWorldUnitsPerSecond = binaryReader.ReadSingle();
            this.runSidewaysWorldUnitsPerSecond = binaryReader.ReadSingle();
            this.runAccelerationWorldUnitsPerSecondSquared = binaryReader.ReadSingle();
            this.sneakForwardWorldUnitsPerSecond = binaryReader.ReadSingle();
            this.sneakBackwardWorldUnitsPerSecond = binaryReader.ReadSingle();
            this.sneakSidewaysWorldUnitsPerSecond = binaryReader.ReadSingle();
            this.sneakAccelerationWorldUnitsPerSecondSquared = binaryReader.ReadSingle();
            this.airborneAccelerationWorldUnitsPerSecondSquared = binaryReader.ReadSingle();
            this.invalidName_1 = binaryReader.ReadBytes(16);
            this.grenadeOrigin = binaryReader.ReadVector3();
            this.invalidName_2 = binaryReader.ReadBytes(12);
            this.stunMovementPenalty01 = binaryReader.ReadSingle();
            this.stunTurningPenalty01 = binaryReader.ReadSingle();
            this.stunJumpingPenalty01 = binaryReader.ReadSingle();
            this.minimumStunTimeSeconds = binaryReader.ReadSingle();
            this.maximumStunTimeSeconds = binaryReader.ReadSingle();
            this.invalidName_3 = binaryReader.ReadBytes(8);
            this.firstPersonIdleTimeSeconds = binaryReader.ReadRange();
            this.firstPersonSkipFraction01 = binaryReader.ReadSingle();
            this.invalidName_4 = binaryReader.ReadBytes(16);
            this.coopRespawnEffect = binaryReader.ReadTagReference();
            this.binocularsZoomCount = binaryReader.ReadInt32();
            this.binocularsZoomRange = binaryReader.ReadRange();
            this.binocularsZoomInSound = binaryReader.ReadTagReference();
            this.binocularsZoomOutSound = binaryReader.ReadTagReference();
            this.invalidName_5 = binaryReader.ReadBytes(16);
            this.activeCamouflageOn = binaryReader.ReadTagReference();
            this.activeCamouflageOff = binaryReader.ReadTagReference();
            this.activeCamouflageError = binaryReader.ReadTagReference();
            this.activeCamouflageReady = binaryReader.ReadTagReference();
            this.flashlightOn = binaryReader.ReadTagReference();
            this.flashlightOff = binaryReader.ReadTagReference();
            this.iceCream = binaryReader.ReadTagReference();
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
    };
}
