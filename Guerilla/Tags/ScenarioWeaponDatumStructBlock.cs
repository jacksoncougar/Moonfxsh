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
    [LayoutAttribute(Size = 8)]
    public class ScenarioWeaponDatumStructBlockBase
    {
        internal short roundsLeft;
        internal short roundsLoaded;
        internal Flags flags;
        internal  ScenarioWeaponDatumStructBlockBase(BinaryReader binaryReader)
        {
            this.roundsLeft = binaryReader.ReadInt16();
            this.roundsLoaded = binaryReader.ReadInt16();
            this.flags = (Flags)binaryReader.ReadInt32();
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
        [FlagsAttribute]
        internal enum Flags : int
        
        {
            InitiallyAtRestDoesNotFall = 1,
            Obsolete = 2,
            DoesAccelerateMovesDueToExplosions = 4,
        };
    };
}
