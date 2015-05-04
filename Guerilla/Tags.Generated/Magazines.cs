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
    public partial class Magazines : MagazinesBase
    {
        public Magazines() : base()
        {
        }
    };
    [LayoutAttribute(Size = 92, Alignment = 4)]
    public class MagazinesBase : GuerillaBlock
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
        public override int SerializedSize { get { return 92; } }
        public override int Alignment { get { return 4; } }
        public MagazinesBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            flags = (Flags)binaryReader.ReadInt32();
            roundsRechargedPerSecond = binaryReader.ReadInt16();
            roundsTotalInitial = binaryReader.ReadInt16();
            roundsTotalMaximum = binaryReader.ReadInt16();
            roundsLoadedMaximum = binaryReader.ReadInt16();
            invalidName_ = binaryReader.ReadBytes(4);
            reloadTimeSeconds = binaryReader.ReadSingle();
            roundsReloaded = binaryReader.ReadInt16();
            invalidName_0 = binaryReader.ReadBytes(2);
            chamberTimeSeconds = binaryReader.ReadSingle();
            invalidName_1 = binaryReader.ReadBytes(8);
            invalidName_2 = binaryReader.ReadBytes(16);
            reloadingEffect = binaryReader.ReadTagReference();
            reloadingDamageEffect = binaryReader.ReadTagReference();
            chamberingEffect = binaryReader.ReadTagReference();
            chamberingDamageEffect = binaryReader.ReadTagReference();
            blamPointers.Enqueue(ReadBlockArrayPointer<MagazineObjects>(binaryReader));
            return blamPointers;
        }
        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            magazines = ReadBlockArrayData<MagazineObjects>(binaryReader, blamPointers.Dequeue());
        }
        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write((Int32)flags);
                binaryWriter.Write(roundsRechargedPerSecond);
                binaryWriter.Write(roundsTotalInitial);
                binaryWriter.Write(roundsTotalMaximum);
                binaryWriter.Write(roundsLoadedMaximum);
                binaryWriter.Write(invalidName_, 0, 4);
                binaryWriter.Write(reloadTimeSeconds);
                binaryWriter.Write(roundsReloaded);
                binaryWriter.Write(invalidName_0, 0, 2);
                binaryWriter.Write(chamberTimeSeconds);
                binaryWriter.Write(invalidName_1, 0, 8);
                binaryWriter.Write(invalidName_2, 0, 16);
                binaryWriter.Write(reloadingEffect);
                binaryWriter.Write(reloadingDamageEffect);
                binaryWriter.Write(chamberingEffect);
                binaryWriter.Write(chamberingDamageEffect);
                nextAddress = Guerilla.WriteBlockArray<MagazineObjects>(binaryWriter, magazines, nextAddress);
                return nextAddress;
            }
        }
        [FlagsAttribute]
        internal enum Flags : int
        {
            WastesRoundsWhenReloaded = 1,
            EveryRoundMustBeChambered = 2,
        };
    };
}
