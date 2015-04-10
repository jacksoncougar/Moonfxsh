// ReSharper disable All
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
        public  ScenarioObjectNamesBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 36)]
    public class ScenarioObjectNamesBlockBase
    {
        internal Moonfish.Tags.String32 name;
        internal Moonfish.Tags.ShortBlockIndex1 eMPTYSTRING;
        internal Moonfish.Tags.ShortBlockIndex2 eMPTYSTRING0;
        internal  ScenarioObjectNamesBlockBase(System.IO.BinaryReader binaryReader)
        {
            name = binaryReader.ReadString32();
            eMPTYSTRING = binaryReader.ReadShortBlockIndex1();
            eMPTYSTRING0 = binaryReader.ReadShortBlockIndex2();
        }
        internal  virtual byte[] ReadData(System.IO.BinaryReader binaryReader)
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
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(name);
                binaryWriter.Write(eMPTYSTRING);
                binaryWriter.Write(eMPTYSTRING0);
            }
        }
    };
}
