// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class ScenarioWeaponDatumStructBlock : ScenarioWeaponDatumStructBlockBase
    {
        public  ScenarioWeaponDatumStructBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 8, Alignment = 4)]
    public class ScenarioWeaponDatumStructBlockBase  : IGuerilla
    {
        internal short roundsLeft;
        internal short roundsLoaded;
        internal Flags flags;
        internal  ScenarioWeaponDatumStructBlockBase(BinaryReader binaryReader)
        {
            roundsLeft = binaryReader.ReadInt16();
            roundsLoaded = binaryReader.ReadInt16();
            flags = (Flags)binaryReader.ReadInt32();
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(roundsLeft);
                binaryWriter.Write(roundsLoaded);
                binaryWriter.Write((Int32)flags);
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
