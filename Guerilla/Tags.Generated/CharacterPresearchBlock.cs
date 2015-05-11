// ReSharper disable All

using Moonfish.Model;

using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Moonfish.Guerilla.Tags
{
    public partial class CharacterPresearchBlock : CharacterPresearchBlockBase
    {
        public CharacterPresearchBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 36, Alignment = 4)]
    public class CharacterPresearchBlockBase : GuerillaBlock
    {
        internal PreSearchFlags preSearchFlags;

        /// <summary>
        /// If the min presearch time expires and the target is (actually) outside the min-certainty radius, presearch turns off
        /// </summary>
        internal Moonfish.Model.Range minPresearchTimeSeconds;

        /// <summary>
        /// Presearch turns off after the given time
        /// </summary>
        internal Moonfish.Model.Range maxPresearchTimeSeconds;

        internal float minCertaintyRadius;
        internal float dEPRECATED;

        /// <summary>
        /// if the minSuppressingTime expires and the target is outside the min-certainty radius, suppressing fire turns off
        /// </summary>
        internal Moonfish.Model.Range minSuppressingTime;

        public override int SerializedSize
        {
            get { return 36; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public CharacterPresearchBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            preSearchFlags = (PreSearchFlags) binaryReader.ReadInt32();
            minPresearchTimeSeconds = binaryReader.ReadRange();
            maxPresearchTimeSeconds = binaryReader.ReadRange();
            minCertaintyRadius = binaryReader.ReadSingle();
            dEPRECATED = binaryReader.ReadSingle();
            minSuppressingTime = binaryReader.ReadRange();
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
                binaryWriter.Write((Int32) preSearchFlags);
                binaryWriter.Write(minPresearchTimeSeconds);
                binaryWriter.Write(maxPresearchTimeSeconds);
                binaryWriter.Write(minCertaintyRadius);
                binaryWriter.Write(dEPRECATED);
                binaryWriter.Write(minSuppressingTime);
                return nextAddress;
            }
        }

        [FlagsAttribute]
        internal enum PreSearchFlags : int
        {
            Flag1 = 1,
        };
    };
}