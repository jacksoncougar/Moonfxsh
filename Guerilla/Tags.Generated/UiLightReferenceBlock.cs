// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class UiLightReferenceBlock : UiLightReferenceBlockBase
    {
        public  UiLightReferenceBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 32, Alignment = 4)]
    public class UiLightReferenceBlockBase : GuerillaBlock
    {
        internal Moonfish.Tags.String32 name;
        
        public override int SerializedSize{get { return 32; }}
        
        internal  UiLightReferenceBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            name = binaryReader.ReadString32();
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(name);
                return nextAddress;
            }
        }
    };
}
