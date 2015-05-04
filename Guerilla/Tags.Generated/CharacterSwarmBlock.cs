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
    public partial class CharacterSwarmBlock : CharacterSwarmBlockBase
    {
        public CharacterSwarmBlock() : base()
        {
        }
    };
    [LayoutAttribute(Size = 40, Alignment = 4)]
    public class CharacterSwarmBlockBase : GuerillaBlock
    {
        /// <summary>
        /// After the given number of deaths, the swarm scatters
        /// </summary>
        internal short scatterKilledCount;
        internal byte[] invalidName_;
        /// <summary>
        /// the distance from the target that the swarm scatters
        /// </summary>
        internal float scatterRadius;
        /// <summary>
        /// amount of time to remain scattered
        /// </summary>
        internal float scatterTime;
        internal float houndMinDistance;
        internal float houndMaxDistance;
        /// <summary>
        /// amount of randomness added to creature's throttle
        /// </summary>
        internal float perlinOffsetScale01;
        /// <summary>
        /// how fast the creature changes random offset to throttle
        /// </summary>
        internal Moonfish.Model.Range offsetPeriodS;
        /// <summary>
        /// a random offset lower then given threshold is made 0. (threshold of 1 = no movement)
        /// </summary>
        internal float perlinIdleMovementThreshold01;
        /// <summary>
        /// a random offset lower then given threshold is made 0. (threshold of 1 = no movement)
        /// </summary>
        internal float perlinCombatMovementThreshold01;
        public override int SerializedSize { get { return 40; } }
        public override int Alignment { get { return 4; } }
        public CharacterSwarmBlockBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            scatterKilledCount = binaryReader.ReadInt16();
            invalidName_ = binaryReader.ReadBytes(2);
            scatterRadius = binaryReader.ReadSingle();
            scatterTime = binaryReader.ReadSingle();
            houndMinDistance = binaryReader.ReadSingle();
            houndMaxDistance = binaryReader.ReadSingle();
            perlinOffsetScale01 = binaryReader.ReadSingle();
            offsetPeriodS = binaryReader.ReadRange();
            perlinIdleMovementThreshold01 = binaryReader.ReadSingle();
            perlinCombatMovementThreshold01 = binaryReader.ReadSingle();
            return blamPointers;
        }
        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            invalidName_[0].ReadPointers(binaryReader, blamPointers);
            invalidName_[1].ReadPointers(binaryReader, blamPointers);
        }
        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(scatterKilledCount);
                binaryWriter.Write(invalidName_, 0, 2);
                binaryWriter.Write(scatterRadius);
                binaryWriter.Write(scatterTime);
                binaryWriter.Write(houndMinDistance);
                binaryWriter.Write(houndMaxDistance);
                binaryWriter.Write(perlinOffsetScale01);
                binaryWriter.Write(offsetPeriodS);
                binaryWriter.Write(perlinIdleMovementThreshold01);
                binaryWriter.Write(perlinCombatMovementThreshold01);
                return nextAddress;
            }
        }
    };
}
