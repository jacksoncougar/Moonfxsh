using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class CharacterGeneralBlock : CharacterGeneralBlockBase
    {
        public  CharacterGeneralBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 12)]
    public class CharacterGeneralBlockBase
    {
        internal GeneralFlags generalFlags;
        internal Type type;
        internal byte[] invalidName_;
        /// <summary>
        /// the inherent scariness of the character
        /// </summary>
        internal float scariness;
        internal  CharacterGeneralBlockBase(BinaryReader binaryReader)
        {
            this.generalFlags = (GeneralFlags)binaryReader.ReadInt32();
            this.type = (Type)binaryReader.ReadInt16();
            this.invalidName_ = binaryReader.ReadBytes(2);
            this.scariness = binaryReader.ReadSingle();
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
