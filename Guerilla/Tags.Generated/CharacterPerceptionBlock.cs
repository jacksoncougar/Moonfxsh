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
    public partial class CharacterPerceptionBlock : CharacterPerceptionBlockBase
    {
        public CharacterPerceptionBlock() : base()
        {
        }
    };
    [LayoutAttribute(Size = 52, Alignment = 4)]
    public class CharacterPerceptionBlockBase : GuerillaBlock
    {
        internal PerceptionFlags perceptionFlags;
        /// <summary>
        /// maximum range of sight
        /// </summary>
        internal float maxVisionDistanceWorldUnits;
        /// <summary>
        /// horizontal angle within which we see targets out to our maximum range
        /// </summary>
        internal float centralVisionAngleDegrees;
        /// <summary>
        /// maximum horizontal angle within which we see targets at range
        /// </summary>
        internal float maxVisionAngleDegrees;
        /// <summary>
        /// maximum horizontal angle within which we can see targets out of the corner of our eye
        /// </summary>
        internal float peripheralVisionAngleDegrees;
        /// <summary>
        /// maximum range at which we can see targets our of the corner of our eye
        /// </summary>
        internal float peripheralDistanceWorldUnits;
        /// <summary>
        /// maximum range at which sounds can be heard
        /// </summary>
        internal float hearingDistanceWorldUnits;
        /// <summary>
        /// random chance of noticing a dangerous enemy projectile (e.g. grenade)
        /// </summary>
        internal float noticeProjectileChance01;
        /// <summary>
        /// random chance of noticing a dangerous vehicle
        /// </summary>
        internal float noticeVehicleChance01;
        /// <summary>
        /// time required to acknowledge a visible enemy when we are already in combat or searching for them
        /// </summary>
        internal float combatPerceptionTimeSeconds;
        /// <summary>
        /// time required to acknowledge a visible enemy when we have been alerted
        /// </summary>
        internal float guardPerceptionTimeSeconds;
        /// <summary>
        /// time required to acknowledge a visible enemy when we are not alerted
        /// </summary>
        internal float nonCombatPerceptionTimeSeconds;
        /// <summary>
        /// If a new prop is acknowledged within the given distance, surprise is registerd
        /// </summary>
        internal float firstAckSurpriseDistanceWorldUnits;
        public override int SerializedSize { get { return 52; } }
        public override int Alignment { get { return 4; } }
        public CharacterPerceptionBlockBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            perceptionFlags = (PerceptionFlags)binaryReader.ReadInt32();
            maxVisionDistanceWorldUnits = binaryReader.ReadSingle();
            centralVisionAngleDegrees = binaryReader.ReadSingle();
            maxVisionAngleDegrees = binaryReader.ReadSingle();
            peripheralVisionAngleDegrees = binaryReader.ReadSingle();
            peripheralDistanceWorldUnits = binaryReader.ReadSingle();
            hearingDistanceWorldUnits = binaryReader.ReadSingle();
            noticeProjectileChance01 = binaryReader.ReadSingle();
            noticeVehicleChance01 = binaryReader.ReadSingle();
            combatPerceptionTimeSeconds = binaryReader.ReadSingle();
            guardPerceptionTimeSeconds = binaryReader.ReadSingle();
            nonCombatPerceptionTimeSeconds = binaryReader.ReadSingle();
            firstAckSurpriseDistanceWorldUnits = binaryReader.ReadSingle();
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
                binaryWriter.Write((Int32)perceptionFlags);
                binaryWriter.Write(maxVisionDistanceWorldUnits);
                binaryWriter.Write(centralVisionAngleDegrees);
                binaryWriter.Write(maxVisionAngleDegrees);
                binaryWriter.Write(peripheralVisionAngleDegrees);
                binaryWriter.Write(peripheralDistanceWorldUnits);
                binaryWriter.Write(hearingDistanceWorldUnits);
                binaryWriter.Write(noticeProjectileChance01);
                binaryWriter.Write(noticeVehicleChance01);
                binaryWriter.Write(combatPerceptionTimeSeconds);
                binaryWriter.Write(guardPerceptionTimeSeconds);
                binaryWriter.Write(nonCombatPerceptionTimeSeconds);
                binaryWriter.Write(firstAckSurpriseDistanceWorldUnits);
                return nextAddress;
            }
        }
        [FlagsAttribute]
        internal enum PerceptionFlags : int
        {
            Flag1 = 1,
        };
    };
}
