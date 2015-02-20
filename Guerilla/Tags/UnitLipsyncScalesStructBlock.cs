using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class UnitLipsyncScalesStructBlock : UnitLipsyncScalesStructBlockBase
    {
        public  UnitLipsyncScalesStructBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 8)]
    public class UnitLipsyncScalesStructBlockBase
    {
        internal float attackWeight;
        internal float decayWeight;
        internal  UnitLipsyncScalesStructBlockBase(BinaryReader binaryReader)
        {
            this.attackWeight = binaryReader.ReadSingle();
            this.decayWeight = binaryReader.ReadSingle();
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
