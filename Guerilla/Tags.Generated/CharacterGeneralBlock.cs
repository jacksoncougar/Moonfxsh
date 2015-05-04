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
    public partial class CharacterGeneralBlock : CharacterGeneralBlockBase
    {
        public CharacterGeneralBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 12, Alignment = 4)]
    public class CharacterGeneralBlockBase : GuerillaBlock
    {
        internal GeneralFlags generalFlags;
        internal Type type;
        internal byte[] invalidName_;

        /// <summary>
        /// the inherent scariness of the character
        /// </summary>
        internal float scariness;

        public override int SerializedSize
        {
            get { return 12; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public CharacterGeneralBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            generalFlags = (GeneralFlags) binaryReader.ReadInt32();
            type = (Type) binaryReader.ReadInt16();
            invalidName_ = binaryReader.ReadBytes(2);
            scariness = binaryReader.ReadSingle();
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
                binaryWriter.Write((Int32) generalFlags);
                binaryWriter.Write((Int16) type);
                binaryWriter.Write(invalidName_, 0, 2);
                binaryWriter.Write(scariness);
                return nextAddress;
            }
        }

        [FlagsAttribute]
        internal enum GeneralFlags : int
        {
            Swarm = 1,
            Flying = 2,
            DualWields = 4,
            UsesGravemind = 8,
        };

        internal enum Type : short
        {
            Elite = 0,
            Jackal = 1,
            Grunt = 2,
            Hunter = 3,
            Engineer = 4,
            Assassin = 5,
            Player = 6,
            Marine = 7,
            Crew = 8,
            CombatForm = 9,
            InfectionForm = 10,
            CarrierForm = 11,
            Monitor = 12,
            Sentinel = 13,
            None = 14,
            MountedWeapon = 15,
            Brute = 16,
            Prophet = 17,
            Bugger = 18,
            Juggernaut = 19,
        };
    };
}