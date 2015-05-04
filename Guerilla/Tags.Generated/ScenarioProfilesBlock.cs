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
    public partial class ScenarioProfilesBlock : ScenarioProfilesBlockBase
    {
        public ScenarioProfilesBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 68, Alignment = 4)]
    public class ScenarioProfilesBlockBase : GuerillaBlock
    {
        internal Moonfish.Tags.String32 name;
        internal float startingHealthDamage01;
        internal float startingShieldDamage01;
        [TagReference("weap")] internal Moonfish.Tags.TagReference primaryWeapon;
        internal short roundsLoaded;
        internal short roundsTotal;
        [TagReference("weap")] internal Moonfish.Tags.TagReference secondaryWeapon;
        internal short roundsLoaded0;
        internal short roundsTotal0;
        internal byte startingFragmentationGrenadeCount;
        internal byte startingPlasmaGrenadeCount;
        internal byte startingUnknownGrenadeCount;
        internal byte startingUnknownGrenadeCount0;

        public override int SerializedSize
        {
            get { return 68; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public ScenarioProfilesBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            name = binaryReader.ReadString32();
            startingHealthDamage01 = binaryReader.ReadSingle();
            startingShieldDamage01 = binaryReader.ReadSingle();
            primaryWeapon = binaryReader.ReadTagReference();
            roundsLoaded = binaryReader.ReadInt16();
            roundsTotal = binaryReader.ReadInt16();
            secondaryWeapon = binaryReader.ReadTagReference();
            roundsLoaded0 = binaryReader.ReadInt16();
            roundsTotal0 = binaryReader.ReadInt16();
            startingFragmentationGrenadeCount = binaryReader.ReadByte();
            startingPlasmaGrenadeCount = binaryReader.ReadByte();
            startingUnknownGrenadeCount = binaryReader.ReadByte();
            startingUnknownGrenadeCount0 = binaryReader.ReadByte();
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
                binaryWriter.Write(name);
                binaryWriter.Write(startingHealthDamage01);
                binaryWriter.Write(startingShieldDamage01);
                binaryWriter.Write(primaryWeapon);
                binaryWriter.Write(roundsLoaded);
                binaryWriter.Write(roundsTotal);
                binaryWriter.Write(secondaryWeapon);
                binaryWriter.Write(roundsLoaded0);
                binaryWriter.Write(roundsTotal0);
                binaryWriter.Write(startingFragmentationGrenadeCount);
                binaryWriter.Write(startingPlasmaGrenadeCount);
                binaryWriter.Write(startingUnknownGrenadeCount);
                binaryWriter.Write(startingUnknownGrenadeCount0);
                return nextAddress;
            }
        }
    };
}