using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class CharacterEngageBlock : CharacterEngageBlockBase
    {
        public  CharacterEngageBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 16)]
    public class CharacterEngageBlockBase
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
        internal  CharacterEngageBlockBase(BinaryReader binaryReader)
        {
            this.flags = (Flags)binaryReader.ReadInt32();
            this.crouchDangerThreshold = binaryReader.ReadSingle();
            this.standDangerThreshold = binaryReader.ReadSingle();
            this.fightDangerMoveThreshold = binaryReader.ReadSingle();
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
        internal enum Flags : int
        
        {
            EngagePerch = 1,
            FightConstantMovement = 2,
            FlightFightConstantMovement = 4,
        };
    };
}
