// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class GlobalDamageSectionBlock : GlobalDamageSectionBlockBase
    {
        public  GlobalDamageSectionBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
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
        internal  GlobalDamageSectionBlockBase(System.IO.BinaryReader binaryReader)
        {
            name = binaryReader.ReadStringID();
            flags = (Flags)binaryReader.ReadInt32();
            vitalityPercentage01 = binaryReader.ReadSingle();
            ReadInstantaneousDamageRepsonseBlockArray(binaryReader);
            ReadGNullBlockArray(binaryReader);
            ReadGNullBlockArray(binaryReader);
            stunTimeSeconds = binaryReader.ReadSingle();
            rechargeTimeSeconds = binaryReader.ReadSingle();
            invalidName_ = binaryReader.ReadBytes(4);
            resurrectionRestoredRegionName = binaryReader.ReadStringID();
            invalidName_0 = binaryReader.ReadBytes(4);
        }
        internal  virtual byte[] ReadData(System.IO.BinaryReader binaryReader)
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
        internal  virtual InstantaneousDamageRepsonseBlock[] ReadInstantaneousDamageRepsonseBlockArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual GNullBlock[] ReadGNullBlockArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteInstantaneousDamageRepsonseBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteGNullBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(name);
                binaryWriter.Write((Int32)flags);
                binaryWriter.Write(vitalityPercentage01);
                WriteInstantaneousDamageRepsonseBlockArray(binaryWriter);
                WriteGNullBlockArray(binaryWriter);
                WriteGNullBlockArray(binaryWriter);
                binaryWriter.Write(stunTimeSeconds);
                binaryWriter.Write(rechargeTimeSeconds);
                binaryWriter.Write(invalidName_, 0, 4);
                binaryWriter.Write(resurrectionRestoredRegionName);
                binaryWriter.Write(invalidName_0, 0, 4);
            }
        }
        [FlagsAttribute]
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
