// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class UserInterfaceWidgetReferenceBlock : UserInterfaceWidgetReferenceBlockBase
    {
        public  UserInterfaceWidgetReferenceBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  UserInterfaceWidgetReferenceBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 8, Alignment = 4)]
    public class UserInterfaceWidgetReferenceBlockBase : GuerillaBlock
    {
        [TagReference("wgit")]
        internal Moonfish.Tags.TagReference widgetTag;
        
        public override int SerializedSize{get { return 8; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  UserInterfaceWidgetReferenceBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            widgetTag = binaryReader.ReadTagReference();
        }
        public  UserInterfaceWidgetReferenceBlockBase(): base()
        {
            
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(widgetTag);
                return nextAddress;
            }
        }
    };
}
