// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class UiObjectReferenceBlock : UiObjectReferenceBlockBase
    {
        public  UiObjectReferenceBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  UiObjectReferenceBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 32, Alignment = 4)]
    public class UiObjectReferenceBlockBase : GuerillaBlock
    {
        internal Moonfish.Tags.String32 name;
        
        public override int SerializedSize{get { return 32; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  UiObjectReferenceBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            name = binaryReader.ReadString32();
        }
        public  UiObjectReferenceBlockBase(): base()
        {
            
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
