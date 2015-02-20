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
    [LayoutAttribute(Size = 68)]
    public class ScenarioProfilesBlockBase
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
            this.name = binaryReader.ReadString32();
            this.startingHealthDamage01 = binaryReader.ReadSingle();
            this.startingShieldDamage01 = binaryReader.ReadSingle();
            this.primaryWeapon = binaryReader.ReadTagReference();
            this.roundsLoaded = binaryReader.ReadInt16();
            this.roundsTotal = binaryReader.ReadInt16();
            this.secondaryWeapon = binaryReader.ReadTagReference();
            this.roundsLoaded0 = binaryReader.ReadInt16();
            this.roundsTotal0 = binaryReader.ReadInt16();
            this.startingFragmentationGrenadeCount = binaryReader.ReadByte();
            this.startingPlasmaGrenadeCount = binaryReader.ReadByte();
            this.startingUnknownGrenadeCount = binaryReader.ReadByte();
            this.startingUnknownGrenadeCount0 = binaryReader.ReadByte();
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
    };
}
