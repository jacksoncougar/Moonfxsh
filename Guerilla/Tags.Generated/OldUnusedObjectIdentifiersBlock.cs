// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class OldUnusedObjectIdentifiersBlock : OldUnusedObjectIdentifiersBlockBase
    {
        public  OldUnusedObjectIdentifiersBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  OldUnusedObjectIdentifiersBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 8, Alignment = 4)]
    public class OldUnusedObjectIdentifiersBlockBase : GuerillaBlock
    {
        internal ScenarioObjectIdStructBlock objectID;
        
        public override int SerializedSize{get { return 8; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  OldUnusedObjectIdentifiersBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            objectID = new ScenarioObjectIdStructBlock(binaryReader);
        }
        public  OldUnusedObjectIdentifiersBlockBase(): base()
        {
            
        }
        public override void Read(BinaryReader binaryReader)
        {
            objectID = new ScenarioObjectIdStructBlock(binaryReader);
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                objectID.Write(binaryWriter);
                return nextAddress;
            }
        }
    };
}
