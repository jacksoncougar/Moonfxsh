using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class ScenarioUnitStructBlock : ScenarioUnitStructBlockBase
    {
        public  ScenarioUnitStructBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 8)]
    public class ScenarioUnitStructBlockBase
    {
        internal float bodyVitality01;
        internal Flags flags;
        internal  ScenarioUnitStructBlockBase(BinaryReader binaryReader)
        {
            this.bodyVitality01 = binaryReader.ReadSingle();
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
            Dead = 1,
            Closed = 2,
            NotEnterableByPlayer = 4,
        };
    };
}
