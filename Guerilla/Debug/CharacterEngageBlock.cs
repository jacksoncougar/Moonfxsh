// ReSharper disable All
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
        public  CharacterEngageBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
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
        internal  CharacterEngageBlockBase(System.IO.BinaryReader binaryReader)
        {
            flags = (Flags)binaryReader.ReadInt32();
            crouchDangerThreshold = binaryReader.ReadSingle();
            standDangerThreshold = binaryReader.ReadSingle();
            fightDangerMoveThreshold = binaryReader.ReadSingle();
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
                binaryWriter.Write((Int32)flags);
                binaryWriter.Write(crouchDangerThreshold);
                binaryWriter.Write(standDangerThreshold);
                binaryWriter.Write(fightDangerMoveThreshold);
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
