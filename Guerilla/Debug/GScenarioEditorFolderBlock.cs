// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class GScenarioEditorFolderBlock : GScenarioEditorFolderBlockBase
    {
        public  GScenarioEditorFolderBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 260)]
    public class GScenarioEditorFolderBlockBase
    {
        internal Moonfish.Tags.LongBlockIndex1 parentFolder;
        internal Moonfish.Tags.String256 name;
        internal  GScenarioEditorFolderBlockBase(System.IO.BinaryReader binaryReader)
        {
            parentFolder = binaryReader.ReadLongBlockIndex1();
            name = binaryReader.ReadString256();
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
                binaryWriter.Write(parentFolder);
                binaryWriter.Write(name);
            }
        }
    };
}
