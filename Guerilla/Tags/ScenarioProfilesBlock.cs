// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class ScenarioProfilesBlock : ScenarioProfilesBlockBase
    {
        public  ScenarioProfilesBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 68, Alignment = 4)]
    public class ScenarioProfilesBlockBase  : IGuerilla
    {
        internal Moonfish.Tags.String32 name;
        internal float startingHealthDamage01;
        internal float startingShieldDamage01;
        [TagReference("weap")]
        internal Moonfish.Tags.TagReference primaryWeapon;
        internal short roundsLoaded;
        internal short roundsTotal;
        [TagReference("weap")]
        internal Moonfish.Tags.TagReference secondaryWeapon;
        internal short roundsLoaded0;
        internal short roundsTotal0;
        internal byte startingFragmentationGrenadeCount;
        internal byte startingPlasmaGrenadeCount;
        internal byte startingUnknownGrenadeCount;
        internal byte startingUnknownGrenadeCount0;
        internal  ScenarioProfilesBlockBase(BinaryReader binaryReader)
        {
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
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
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
                return nextAddress = (int)binaryWriter.BaseStream.Position;
            }
        }
    };
}
