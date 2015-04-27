// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class GScenarioEditorFolderBlock : GScenarioEditorFolderBlockBase
    {
        public  GScenarioEditorFolderBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  GScenarioEditorFolderBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 260, Alignment = 4)]
    public class GScenarioEditorFolderBlockBase : GuerillaBlock
    {
        internal Moonfish.Tags.LongBlockIndex1 parentFolder;
        internal Moonfish.Tags.String256 name;
        
        public override int SerializedSize{get { return 260; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  GScenarioEditorFolderBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            parentFolder = binaryReader.ReadLongBlockIndex1();
            name = binaryReader.ReadString256();
        }
        public  GScenarioEditorFolderBlockBase(): base()
        {
            
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(parentFolder);
                binaryWriter.Write(name);
                return nextAddress;
            }
        }
    };
}
