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
    public partial class CharacterEngageBlock : CharacterEngageBlockBase
    {
        public CharacterEngageBlock() : base()
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

        public override int SerializedSize
        {
            get { return 16; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public CharacterEngageBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            flags = (Flags) binaryReader.ReadInt32();
            crouchDangerThreshold = binaryReader.ReadSingle();
            standDangerThreshold = binaryReader.ReadSingle();
            fightDangerMoveThreshold = binaryReader.ReadSingle();
            return blamPointers;
        }

        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
        }

        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
            using (binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write((Int32) flags);
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