using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    [LayoutAttribute(Size = 56)]
    public  partial class GlobalDamageSectionBlock : GlobalDamageSectionBlockBase
    {
        public  GlobalDamageSectionBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 56)]
    public class GlobalDamageSectionBlockBase
    {
        internal Moonfish.Tags.StringID name;
        internal Flags flags;
        /// <summary>
        /// percentage of total object vitality
        /// </summary>
        internal float vitalityPercentage01;
        internal InstantaneousDamageRepsonseBlock[] instantResponses;
        internal GNullBlock[] gNullBlock;
        internal GNullBlock[] gNullBlock0;
        internal float stunTimeSeconds;
        internal float rechargeTimeSeconds;
        internal byte[] invalidName_;
        internal Moonfish.Tags.StringID resurrectionRestoredRegionName;
        internal byte[] invalidName_0;
        internal  GlobalDamageSectionBlockBase(BinaryReader binaryReader)
        {
            this.name = binaryReader.ReadStringID();
            this.flags = (Flags)binaryReader.ReadInt32();
            this.vitalityPercentage01 = binaryReader.ReadSingle();
            this.instantResponses = ReadInstantaneousDamageRepsonseBlockArray(binaryReader);
            this.gNullBlock = ReadGNullBlockArray(binaryReader);
            this.gNullBlock0 = ReadGNullBlockArray(binaryReader);
            this.stunTimeSeconds = binaryReader.ReadSingle();
            this.rechargeTimeSeconds = binaryReader.ReadSingle();
            this.invalidName_ = binaryReader.ReadBytes(4);
            this.resurrectionRestoredRegionName = binaryReader.ReadStringID();
            this.invalidName_0 = binaryReader.ReadBytes(4);
        }
        internal  virtual byte[] ReadData(BinaryReader binaryReader)
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
        internal  virtual InstantaneousDamageRepsonseBlock[] ReadInstantaneousDamageRepsonseBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(InstantaneousDamageRepsonseBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new InstantaneousDamageRepsonseBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new InstantaneousDamageRepsonseBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual GNullBlock[] ReadGNullBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(GNullBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new GNullBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new GNullBlock(binaryReader);
                }
            }
            return array;
        }
        internal enum Flags : int
        {
            AbsorbsBodyDamage = 1,
            TakesFullDmgWhenObjectDies = 2,
            CannotDieWithRiders = 4,
            TakesFullDmgWhenObjDstryd = 8,
            RestoredOnRessurection = 16,
            Unused = 32,
            Unused0 = 64,
            Heatshottable = 128,
            IgnoresShields = 256,
        };
    };
}
