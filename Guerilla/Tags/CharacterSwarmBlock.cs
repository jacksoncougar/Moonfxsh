using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class CharacterSwarmBlock : CharacterSwarmBlockBase
    {
        public  CharacterSwarmBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 40)]
    public class CharacterSwarmBlockBase
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
        internal  CharacterSwarmBlockBase(BinaryReader binaryReader)
        {
            this.scatterKilledCount = binaryReader.ReadInt16();
            this.invalidName_ = binaryReader.ReadBytes(2);
            this.scatterRadius = binaryReader.ReadSingle();
            this.scatterTime = binaryReader.ReadSingle();
            this.houndMinDistance = binaryReader.ReadSingle();
            this.houndMaxDistance = binaryReader.ReadSingle();
            this.perlinOffsetScale01 = binaryReader.ReadSingle();
            this.offsetPeriodS = binaryReader.ReadRange();
            this.perlinIdleMovementThreshold01 = binaryReader.ReadSingle();
            this.perlinCombatMovementThreshold01 = binaryReader.ReadSingle();
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
