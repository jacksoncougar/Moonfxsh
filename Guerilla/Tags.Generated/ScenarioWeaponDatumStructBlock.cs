// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class ScenarioWeaponDatumStructBlock : ScenarioWeaponDatumStructBlockBase
    {
        public  ScenarioWeaponDatumStructBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  ScenarioWeaponDatumStructBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 8, Alignment = 4)]
    public class ScenarioWeaponDatumStructBlockBase : GuerillaBlock
    {
        internal short roundsLeft;
        internal short roundsLoaded;
        internal Flags flags;
        
        public override int SerializedSize{get { return 8; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  ScenarioWeaponDatumStructBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            roundsLeft = binaryReader.ReadInt16();
            roundsLoaded = binaryReader.ReadInt16();
            flags = (Flags)binaryReader.ReadInt32();
        }
        public  ScenarioWeaponDatumStructBlockBase(): base()
        {
            
        }
        public override void Read(BinaryReader binaryReader)
        {
            roundsLeft = binaryReader.ReadInt16();
            roundsLoaded = binaryReader.ReadInt16();
            flags = (Flags)binaryReader.ReadInt32();
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
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
