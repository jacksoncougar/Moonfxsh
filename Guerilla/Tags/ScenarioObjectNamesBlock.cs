using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class ScenarioObjectNamesBlock : ScenarioObjectNamesBlockBase
    {
        public  ScenarioObjectNamesBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 36)]
    public class ScenarioObjectNamesBlockBase
    {
        internal Moonfish.Tags.String32 name;
        internal Moonfish.Tags.ShortBlockIndex1 eMPTYSTRING;
        internal Moonfish.Tags.ShortBlockIndex2 eMPTYSTRING0;
        internal  ScenarioObjectNamesBlockBase(BinaryReader binaryReader)
        {
            this.name = binaryReader.ReadString32();
            this.eMPTYSTRING = binaryReader.ReadShortBlockIndex1();
            this.eMPTYSTRING0 = binaryReader.ReadShortBlockIndex2();
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
