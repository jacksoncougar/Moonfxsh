// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class UserInterfaceWidgetReferenceBlock : UserInterfaceWidgetReferenceBlockBase
    {
        public  UserInterfaceWidgetReferenceBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 8, Alignment = 4)]
    public class UserInterfaceWidgetReferenceBlockBase  : IGuerilla
    {
        [TagReference("wgit")]
        internal Moonfish.Tags.TagReference widgetTag;
        internal  UserInterfaceWidgetReferenceBlockBase(BinaryReader binaryReader)
        {
            widgetTag = binaryReader.ReadTagReference();
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(widgetTag);
                return nextAddress = (int)binaryWriter.BaseStream.Position;
            }
        }
    };
}
