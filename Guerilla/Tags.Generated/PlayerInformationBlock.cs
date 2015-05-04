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
    public partial class PlayerInformationBlock : PlayerInformationBlockBase
    {
        public PlayerInformationBlock() : base()
        {
        }
    };
    [LayoutAttribute(Size = 284, Alignment = 4)]
    public class PlayerInformationBlockBase : GuerillaBlock
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
        public override int SerializedSize { get { return 284; } }
        public override int Alignment { get { return 4; } }
        public PlayerInformationBlockBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            unused = binaryReader.ReadTagReference();
            invalidName_ = binaryReader.ReadBytes(28);
            walkingSpeedWorldUnitsPerSecond = binaryReader.ReadSingle();
            invalidName_0 = binaryReader.ReadBytes(4);
            runForwardWorldUnitsPerSecond = binaryReader.ReadSingle();
            runBackwardWorldUnitsPerSecond = binaryReader.ReadSingle();
            runSidewaysWorldUnitsPerSecond = binaryReader.ReadSingle();
            runAccelerationWorldUnitsPerSecondSquared = binaryReader.ReadSingle();
            sneakForwardWorldUnitsPerSecond = binaryReader.ReadSingle();
            sneakBackwardWorldUnitsPerSecond = binaryReader.ReadSingle();
            sneakSidewaysWorldUnitsPerSecond = binaryReader.ReadSingle();
            sneakAccelerationWorldUnitsPerSecondSquared = binaryReader.ReadSingle();
            airborneAccelerationWorldUnitsPerSecondSquared = binaryReader.ReadSingle();
            invalidName_1 = binaryReader.ReadBytes(16);
            grenadeOrigin = binaryReader.ReadVector3();
            invalidName_2 = binaryReader.ReadBytes(12);
            stunMovementPenalty01 = binaryReader.ReadSingle();
            stunTurningPenalty01 = binaryReader.ReadSingle();
            stunJumpingPenalty01 = binaryReader.ReadSingle();
            minimumStunTimeSeconds = binaryReader.ReadSingle();
            maximumStunTimeSeconds = binaryReader.ReadSingle();
            invalidName_3 = binaryReader.ReadBytes(8);
            firstPersonIdleTimeSeconds = binaryReader.ReadRange();
            firstPersonSkipFraction01 = binaryReader.ReadSingle();
            invalidName_4 = binaryReader.ReadBytes(16);
            coopRespawnEffect = binaryReader.ReadTagReference();
            binocularsZoomCount = binaryReader.ReadInt32();
            binocularsZoomRange = binaryReader.ReadRange();
            binocularsZoomInSound = binaryReader.ReadTagReference();
            binocularsZoomOutSound = binaryReader.ReadTagReference();
            invalidName_5 = binaryReader.ReadBytes(16);
            activeCamouflageOn = binaryReader.ReadTagReference();
            activeCamouflageOff = binaryReader.ReadTagReference();
            activeCamouflageError = binaryReader.ReadTagReference();
            activeCamouflageReady = binaryReader.ReadTagReference();
            flashlightOn = binaryReader.ReadTagReference();
            flashlightOff = binaryReader.ReadTagReference();
            iceCream = binaryReader.ReadTagReference();
            return blamPointers;
        }
        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            invalidName_[0].ReadPointers(binaryReader, blamPointers);
            invalidName_[1].ReadPointers(binaryReader, blamPointers);
            invalidName_[2].ReadPointers(binaryReader, blamPointers);
            invalidName_[3].ReadPointers(binaryReader, blamPointers);
            invalidName_[4].ReadPointers(binaryReader, blamPointers);
            invalidName_[5].ReadPointers(binaryReader, blamPointers);
            invalidName_[6].ReadPointers(binaryReader, blamPointers);
            invalidName_[7].ReadPointers(binaryReader, blamPointers);
            invalidName_[8].ReadPointers(binaryReader, blamPointers);
            invalidName_[9].ReadPointers(binaryReader, blamPointers);
            invalidName_[10].ReadPointers(binaryReader, blamPointers);
            invalidName_[11].ReadPointers(binaryReader, blamPointers);
            invalidName_[12].ReadPointers(binaryReader, blamPointers);
            invalidName_[13].ReadPointers(binaryReader, blamPointers);
            invalidName_[14].ReadPointers(binaryReader, blamPointers);
            invalidName_[15].ReadPointers(binaryReader, blamPointers);
            invalidName_[16].ReadPointers(binaryReader, blamPointers);
            invalidName_[17].ReadPointers(binaryReader, blamPointers);
            invalidName_[18].ReadPointers(binaryReader, blamPointers);
            invalidName_[19].ReadPointers(binaryReader, blamPointers);
            invalidName_[20].ReadPointers(binaryReader, blamPointers);
            invalidName_[21].ReadPointers(binaryReader, blamPointers);
            invalidName_[22].ReadPointers(binaryReader, blamPointers);
            invalidName_[23].ReadPointers(binaryReader, blamPointers);
            invalidName_[24].ReadPointers(binaryReader, blamPointers);
            invalidName_[25].ReadPointers(binaryReader, blamPointers);
            invalidName_[26].ReadPointers(binaryReader, blamPointers);
            invalidName_[27].ReadPointers(binaryReader, blamPointers);
            invalidName_0[0].ReadPointers(binaryReader, blamPointers);
            invalidName_0[1].ReadPointers(binaryReader, blamPointers);
            invalidName_0[2].ReadPointers(binaryReader, blamPointers);
            invalidName_0[3].ReadPointers(binaryReader, blamPointers);
            invalidName_1[0].ReadPointers(binaryReader, blamPointers);
            invalidName_1[1].ReadPointers(binaryReader, blamPointers);
            invalidName_1[2].ReadPointers(binaryReader, blamPointers);
            invalidName_1[3].ReadPointers(binaryReader, blamPointers);
            invalidName_1[4].ReadPointers(binaryReader, blamPointers);
            invalidName_1[5].ReadPointers(binaryReader, blamPointers);
            invalidName_1[6].ReadPointers(binaryReader, blamPointers);
            invalidName_1[7].ReadPointers(binaryReader, blamPointers);
            invalidName_1[8].ReadPointers(binaryReader, blamPointers);
            invalidName_1[9].ReadPointers(binaryReader, blamPointers);
            invalidName_1[10].ReadPointers(binaryReader, blamPointers);
            invalidName_1[11].ReadPointers(binaryReader, blamPointers);
            invalidName_1[12].ReadPointers(binaryReader, blamPointers);
            invalidName_1[13].ReadPointers(binaryReader, blamPointers);
            invalidName_1[14].ReadPointers(binaryReader, blamPointers);
            invalidName_1[15].ReadPointers(binaryReader, blamPointers);
            invalidName_2[0].ReadPointers(binaryReader, blamPointers);
            invalidName_2[1].ReadPointers(binaryReader, blamPointers);
            invalidName_2[2].ReadPointers(binaryReader, blamPointers);
            invalidName_2[3].ReadPointers(binaryReader, blamPointers);
            invalidName_2[4].ReadPointers(binaryReader, blamPointers);
            invalidName_2[5].ReadPointers(binaryReader, blamPointers);
            invalidName_2[6].ReadPointers(binaryReader, blamPointers);
            invalidName_2[7].ReadPointers(binaryReader, blamPointers);
            invalidName_2[8].ReadPointers(binaryReader, blamPointers);
            invalidName_2[9].ReadPointers(binaryReader, blamPointers);
            invalidName_2[10].ReadPointers(binaryReader, blamPointers);
            invalidName_2[11].ReadPointers(binaryReader, blamPointers);
            invalidName_3[0].ReadPointers(binaryReader, blamPointers);
            invalidName_3[1].ReadPointers(binaryReader, blamPointers);
            invalidName_3[2].ReadPointers(binaryReader, blamPointers);
            invalidName_3[3].ReadPointers(binaryReader, blamPointers);
            invalidName_3[4].ReadPointers(binaryReader, blamPointers);
            invalidName_3[5].ReadPointers(binaryReader, blamPointers);
            invalidName_3[6].ReadPointers(binaryReader, blamPointers);
            invalidName_3[7].ReadPointers(binaryReader, blamPointers);
            invalidName_4[0].ReadPointers(binaryReader, blamPointers);
            invalidName_4[1].ReadPointers(binaryReader, blamPointers);
            invalidName_4[2].ReadPointers(binaryReader, blamPointers);
            invalidName_4[3].ReadPointers(binaryReader, blamPointers);
            invalidName_4[4].ReadPointers(binaryReader, blamPointers);
            invalidName_4[5].ReadPointers(binaryReader, blamPointers);
            invalidName_4[6].ReadPointers(binaryReader, blamPointers);
            invalidName_4[7].ReadPointers(binaryReader, blamPointers);
            invalidName_4[8].ReadPointers(binaryReader, blamPointers);
            invalidName_4[9].ReadPointers(binaryReader, blamPointers);
            invalidName_4[10].ReadPointers(binaryReader, blamPointers);
            invalidName_4[11].ReadPointers(binaryReader, blamPointers);
            invalidName_4[12].ReadPointers(binaryReader, blamPointers);
            invalidName_4[13].ReadPointers(binaryReader, blamPointers);
            invalidName_4[14].ReadPointers(binaryReader, blamPointers);
            invalidName_4[15].ReadPointers(binaryReader, blamPointers);
            invalidName_5[0].ReadPointers(binaryReader, blamPointers);
            invalidName_5[1].ReadPointers(binaryReader, blamPointers);
            invalidName_5[2].ReadPointers(binaryReader, blamPointers);
            invalidName_5[3].ReadPointers(binaryReader, blamPointers);
            invalidName_5[4].ReadPointers(binaryReader, blamPointers);
            invalidName_5[5].ReadPointers(binaryReader, blamPointers);
            invalidName_5[6].ReadPointers(binaryReader, blamPointers);
            invalidName_5[7].ReadPointers(binaryReader, blamPointers);
            invalidName_5[8].ReadPointers(binaryReader, blamPointers);
            invalidName_5[9].ReadPointers(binaryReader, blamPointers);
            invalidName_5[10].ReadPointers(binaryReader, blamPointers);
            invalidName_5[11].ReadPointers(binaryReader, blamPointers);
            invalidName_5[12].ReadPointers(binaryReader, blamPointers);
            invalidName_5[13].ReadPointers(binaryReader, blamPointers);
            invalidName_5[14].ReadPointers(binaryReader, blamPointers);
            invalidName_5[15].ReadPointers(binaryReader, blamPointers);
        }
        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(unused);
                binaryWriter.Write(invalidName_, 0, 28);
                binaryWriter.Write(walkingSpeedWorldUnitsPerSecond);
                binaryWriter.Write(invalidName_0, 0, 4);
                binaryWriter.Write(runForwardWorldUnitsPerSecond);
                binaryWriter.Write(runBackwardWorldUnitsPerSecond);
                binaryWriter.Write(runSidewaysWorldUnitsPerSecond);
                binaryWriter.Write(runAccelerationWorldUnitsPerSecondSquared);
                binaryWriter.Write(sneakForwardWorldUnitsPerSecond);
                binaryWriter.Write(sneakBackwardWorldUnitsPerSecond);
                binaryWriter.Write(sneakSidewaysWorldUnitsPerSecond);
                binaryWriter.Write(sneakAccelerationWorldUnitsPerSecondSquared);
                binaryWriter.Write(airborneAccelerationWorldUnitsPerSecondSquared);
                binaryWriter.Write(invalidName_1, 0, 16);
                binaryWriter.Write(grenadeOrigin);
                binaryWriter.Write(invalidName_2, 0, 12);
                binaryWriter.Write(stunMovementPenalty01);
                binaryWriter.Write(stunTurningPenalty01);
                binaryWriter.Write(stunJumpingPenalty01);
                binaryWriter.Write(minimumStunTimeSeconds);
                binaryWriter.Write(maximumStunTimeSeconds);
                binaryWriter.Write(invalidName_3, 0, 8);
                binaryWriter.Write(firstPersonIdleTimeSeconds);
                binaryWriter.Write(firstPersonSkipFraction01);
                binaryWriter.Write(invalidName_4, 0, 16);
                binaryWriter.Write(coopRespawnEffect);
                binaryWriter.Write(binocularsZoomCount);
                binaryWriter.Write(binocularsZoomRange);
                binaryWriter.Write(binocularsZoomInSound);
                binaryWriter.Write(binocularsZoomOutSound);
                binaryWriter.Write(invalidName_5, 0, 16);
                binaryWriter.Write(activeCamouflageOn);
                binaryWriter.Write(activeCamouflageOff);
                binaryWriter.Write(activeCamouflageError);
                binaryWriter.Write(activeCamouflageReady);
                binaryWriter.Write(flashlightOn);
                binaryWriter.Write(flashlightOff);
                binaryWriter.Write(iceCream);
                return nextAddress;
            }
        }
    };
}
