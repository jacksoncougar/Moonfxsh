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
    public partial class ScenarioWeaponDatumStructBlock : ScenarioWeaponDatumStructBlockBase
    {
        public ScenarioWeaponDatumStructBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 8, Alignment = 4)]
    public class ScenarioWeaponDatumStructBlockBase : GuerillaBlock
    {
        internal short roundsLeft;
        internal short roundsLoaded;
        internal Flags flags;

        public override int SerializedSize
        {
            get { return 8; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public ScenarioWeaponDatumStructBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            roundsLeft = binaryReader.ReadInt16();
            roundsLoaded = binaryReader.ReadInt16();
            flags = (Flags) binaryReader.ReadInt32();
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
                binaryWriter.Write(roundsLeft);
                binaryWriter.Write(roundsLoaded);
                binaryWriter.Write((Int32) flags);
                return nextAddress;
            }
        }

        [FlagsAttribute]
        internal enum Flags : int
        {
            InitiallyAtRestDoesNotFall = 1,
            Obsolete = 2,
            DoesAccelerateMovesDueToExplosions = 4,
        };
    };
}