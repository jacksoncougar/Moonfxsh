// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class CharacterEngageBlock : CharacterEngageBlockBase
    {
        public  CharacterEngageBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 16, Alignment = 4)]
    public class CharacterEngageBlockBase : GuerillaBlock
    {
        internal Flags flags;
        /// <summary>
        /// When danger rises above the threshold, the actor crouches
        /// </summary>
        internal float crouchDangerThreshold;
        /// <summary>
        /// When danger drops below this threshold, the actor can stand again.
        /// </summary>
        internal float standDangerThreshold;
        /// <summary>
        /// When danger goes above given level, this actor switches firing positions
        /// </summary>
        internal float fightDangerMoveThreshold;
        
        public override int SerializedSize{get { return 16; }}
        
        internal  CharacterEngageBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            flags = (Flags)binaryReader.ReadInt32();
            crouchDangerThreshold = binaryReader.ReadSingle();
            standDangerThreshold = binaryReader.ReadSingle();
            fightDangerMoveThreshold = binaryReader.ReadSingle();
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write((Int32)flags);
                binaryWriter.Write(crouchDangerThreshold);
                binaryWriter.Write(standDangerThreshold);
                binaryWriter.Write(fightDangerMoveThreshold);
                return nextAddress;
            }
        }
        [FlagsAttribute]
        internal enum Flags : int
        {
            EngagePerch = 1,
            FightConstantMovement = 2,
            FlightFightConstantMovement = 4,
        };
    };
}
