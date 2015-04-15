// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class ObjectWidgetBlock : ObjectWidgetBlockBase
    {
        public  ObjectWidgetBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 8, Alignment = 4)]
    public class ObjectWidgetBlockBase  : IGuerilla
    {
        [TagReference("null")]
        internal Moonfish.Tags.TagReference type;
        internal  ObjectWidgetBlockBase(BinaryReader binaryReader)
        {
            type = binaryReader.ReadTagReference();
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(type);
                return nextAddress;
            }
        }
    };
}
