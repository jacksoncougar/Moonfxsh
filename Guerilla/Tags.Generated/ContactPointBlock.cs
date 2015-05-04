// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class ContactPointBlock : ContactPointBlockBase
    {
        public  ContactPointBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  ContactPointBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 4, Alignment = 4)]
    public class ContactPointBlockBase : GuerillaBlock
    {
        internal Moonfish.Tags.StringIdent markerName;
        
        public override int SerializedSize{get { return 4; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  ContactPointBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            markerName = binaryReader.ReadStringID();
        }
        public  ContactPointBlockBase(): base()
        {
            
        }
        public override void Read(BinaryReader binaryReader)
        {
            markerName = binaryReader.ReadStringID();
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(markerName);
                return nextAddress;
            }
        }
    };
}
