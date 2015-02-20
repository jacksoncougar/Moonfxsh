using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class Magazines : MagazinesBase
    {
        public  Magazines(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 92)]
    public class MagazinesBase
    {
        internal Flags flags;
        internal short roundsRechargedPerSecond;
        internal short roundsTotalInitial;
        internal short roundsTotalMaximum;
        internal short roundsLoadedMaximum;
        internal byte[] invalidName_;
        /// <summary>
        /// the length of time it takes to load a single magazine into the weapon
        /// </summary>
        internal float reloadTimeSeconds;
        internal short roundsReloaded;
        internal byte[] invalidName_0;
        /// <summary>
        /// the length of time it takes to chamber the next round
        /// </summary>
        internal float chamberTimeSeconds;
        internal byte[] invalidName_1;
        internal byte[] invalidName_2;
        [TagReference("null")]
        internal Moonfish.Tags.TagReference reloadingEffect;
        [TagReference("jpt!")]
        internal Moonfish.Tags.TagReference reloadingDamageEffect;
        [TagReference("null")]
        internal Moonfish.Tags.TagReference chamberingEffect;
        [TagReference("jpt!")]
        internal Moonfish.Tags.TagReference chamberingDamageEffect;
        internal MagazineObjects[] magazines;
        internal  MagazinesBase(BinaryReader binaryReader)
        {
            this.flags = (Flags)binaryReader.ReadInt32();
            this.roundsRechargedPerSecond = binaryReader.ReadInt16();
            this.roundsTotalInitial = binaryReader.ReadInt16();
            this.roundsTotalMaximum = binaryReader.ReadInt16();
            this.roundsLoadedMaximum = binaryReader.ReadInt16();
            this.invalidName_ = binaryReader.ReadBytes(4);
            this.reloadTimeSeconds = binaryReader.ReadSingle();
            this.roundsReloaded = binaryReader.ReadInt16();
            this.invalidName_0 = binaryReader.ReadBytes(2);
            this.chamberTimeSeconds = binaryReader.ReadSingle();
            this.invalidName_1 = binaryReader.ReadBytes(8);
            this.invalidName_2 = binaryReader.ReadBytes(16);
            this.reloadingEffect = binaryReader.ReadTagReference();
            this.reloadingDamageEffect = binaryReader.ReadTagReference();
            this.chamberingEffect = binaryReader.ReadTagReference();
            this.chamberingDamageEffect = binaryReader.ReadTagReference();
            this.magazines = ReadMagazineObjectsArray(binaryReader);
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
        internal  virtual MagazineObjects[] ReadMagazineObjectsArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(MagazineObjects));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new MagazineObjects[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new MagazineObjects(binaryReader);
                }
            }
            return array;
        }
        [FlagsAttribute]
        internal enum Flags : int
        
        {
            WastesRoundsWhenReloaded = 1,
            EveryRoundMustBeChambered = 2,
        };
    };
}
