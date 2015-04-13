using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class CharacterPerceptionBlock : CharacterPerceptionBlockBase
    {
        public  CharacterPerceptionBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 52)]
    public class CharacterPerceptionBlockBase
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
        internal  CharacterPerceptionBlockBase(BinaryReader binaryReader)
        {
            this.perceptionFlags = (PerceptionFlags)binaryReader.ReadInt32();
            this.maxVisionDistanceWorldUnits = binaryReader.ReadSingle();
            this.centralVisionAngleDegrees = binaryReader.ReadSingle();
            this.maxVisionAngleDegrees = binaryReader.ReadSingle();
            this.peripheralVisionAngleDegrees = binaryReader.ReadSingle();
            this.peripheralDistanceWorldUnits = binaryReader.ReadSingle();
            this.hearingDistanceWorldUnits = binaryReader.ReadSingle();
            this.noticeProjectileChance01 = binaryReader.ReadSingle();
            this.noticeVehicleChance01 = binaryReader.ReadSingle();
            this.combatPerceptionTimeSeconds = binaryReader.ReadSingle();
            this.guardPerceptionTimeSeconds = binaryReader.ReadSingle();
            this.nonCombatPerceptionTimeSeconds = binaryReader.ReadSingle();
            this.firstAckSurpriseDistanceWorldUnits = binaryReader.ReadSingle();
        }
        internal  virtual byte[] ReadData(BinaryReader binaryReader)
        {
            var blamPointer = binaryReader.ReadBlamPointer(1);
            var data = new byte[blamPointer.elementCount];
            if(blamPointer.elementCount > 0)
            {
                using (binaryReader.BaseStream.Pin())
                {
                    binaryReader.BaseStream.Position = blamPointer[0];
                    data = binaryReader.ReadBytes(blamPointer.elementCount);
                }
            }
            return data;
        }
        [FlagsAttribute]
        internal enum PerceptionFlags : int
        
        {
            Flag1 = 1,
        };
    };
}
