using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class CharacterEvasionBlock : CharacterEvasionBlockBase
    {
        public  CharacterEvasionBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 20)]
    public class CharacterEvasionBlockBase
    {
        /// <summary>
        /// Consider evading when immediate danger surpasses threshold
        /// </summary>
        internal float evasionDangerThreshold;
        /// <summary>
        /// Wait at least this delay between evasions
        /// </summary>
        internal float evasionDelayTimer;
        /// <summary>
        /// If danger is above threshold, the chance that we will evade. Expressed as chance of evading within a 1 second time period
        /// </summary>
        internal float evasionChance;
        /// <summary>
        /// If target is within given proximity, possibly evade
        /// </summary>
        internal float evasionProximityThreshold;
        /// <summary>
        /// Chance of retreating (fleeing) after danger avoidance dive
        /// </summary>
        internal float diveRetreatChance;
        internal  CharacterEvasionBlockBase(BinaryReader binaryReader)
        {
            this.evasionDangerThreshold = binaryReader.ReadSingle();
            this.evasionDelayTimer = binaryReader.ReadSingle();
            this.evasionChance = binaryReader.ReadSingle();
            this.evasionProximityThreshold = binaryReader.ReadSingle();
            this.diveRetreatChance = binaryReader.ReadSingle();
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
    };
}
