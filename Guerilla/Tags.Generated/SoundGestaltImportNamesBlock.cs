// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class SoundGestaltImportNamesBlock : SoundGestaltImportNamesBlockBase
    {
        public  SoundGestaltImportNamesBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  SoundGestaltImportNamesBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 4, Alignment = 4)]
    public class SoundGestaltImportNamesBlockBase : GuerillaBlock
    {
        internal Moonfish.Tags.StringID importName;
        
        public override int SerializedSize{get { return 4; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  SoundGestaltImportNamesBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            importName = binaryReader.ReadStringID();
        }
        public  SoundGestaltImportNamesBlockBase(): base()
        {
            
        }
        public void Read(BinaryReader binaryReader)
        {
            importName = binaryReader.ReadStringID();
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(importName);
                return nextAddress;
            }
        }
    };
}
