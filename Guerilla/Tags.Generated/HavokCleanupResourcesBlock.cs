// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class HavokCleanupResourcesBlock : HavokCleanupResourcesBlockBase
    {
        public  HavokCleanupResourcesBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  HavokCleanupResourcesBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 8, Alignment = 4)]
    public class HavokCleanupResourcesBlockBase : GuerillaBlock
    {
        [TagReference("effe")]
        internal Moonfish.Tags.TagReference objectCleanupEffect;
        
        public override int SerializedSize{get { return 8; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  HavokCleanupResourcesBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            objectCleanupEffect = binaryReader.ReadTagReference();
        }
        public  HavokCleanupResourcesBlockBase(): base()
        {
            
        }
        public void Read(BinaryReader binaryReader)
        {
            objectCleanupEffect = binaryReader.ReadTagReference();
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(objectCleanupEffect);
                return nextAddress;
            }
        }
    };
}
