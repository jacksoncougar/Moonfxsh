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
        public  GScenarioEditorFolderBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 260, Alignment = 4)]
    public class GScenarioEditorFolderBlockBase  : IGuerilla
    {
        internal Moonfish.Tags.LongBlockIndex1 parentFolder;
        internal Moonfish.Tags.String256 name;
        internal  GScenarioEditorFolderBlockBase(BinaryReader binaryReader)
        {
            parentFolder = binaryReader.ReadLongBlockIndex1();
            name = binaryReader.ReadString256();
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(parentFolder);
                binaryWriter.Write(name);
                return nextAddress = (int)binaryWriter.BaseStream.Position;
            }
        }
    };
}
