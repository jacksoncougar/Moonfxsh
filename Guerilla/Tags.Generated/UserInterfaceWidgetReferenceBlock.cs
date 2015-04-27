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
    };
    [LayoutAttribute(Size = 8, Alignment = 4)]
    public class UserInterfaceWidgetReferenceBlockBase : GuerillaBlock
    {
        [TagReference("wgit")]
        internal Moonfish.Tags.TagReference widgetTag;
        
        public override int SerializedSize{get { return 8; }}
        
        internal  UserInterfaceWidgetReferenceBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            widgetTag = binaryReader.ReadTagReference();
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
