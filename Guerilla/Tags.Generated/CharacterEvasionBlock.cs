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
    public partial class CharacterEvasionBlock : CharacterEvasionBlockBase
    {
        public CharacterEvasionBlock() : base()
        {
        }
    };
    [LayoutAttribute(Size = 20, Alignment = 4)]
    public class CharacterEvasionBlockBase : GuerillaBlock
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
        public override int SerializedSize { get { return 20; } }
        public override int Alignment { get { return 4; } }
        public CharacterEvasionBlockBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            evasionDangerThreshold = binaryReader.ReadSingle();
            evasionDelayTimer = binaryReader.ReadSingle();
            evasionChance = binaryReader.ReadSingle();
            evasionProximityThreshold = binaryReader.ReadSingle();
            diveRetreatChance = binaryReader.ReadSingle();
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
                binaryWriter.Write(evasionDangerThreshold);
                binaryWriter.Write(evasionDelayTimer);
                binaryWriter.Write(evasionChance);
                binaryWriter.Write(evasionProximityThreshold);
                binaryWriter.Write(diveRetreatChance);
                return nextAddress;
            }
        }
    };
}
