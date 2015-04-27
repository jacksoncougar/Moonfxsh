// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class ExternReferenceBlock : ExternReferenceBlockBase
    {
        public  ExternReferenceBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  ExternReferenceBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 2, Alignment = 4)]
    public class ExternReferenceBlockBase : GuerillaBlock
    {
        internal byte parameterIndex;
        internal byte externIndex;
        
        public override int SerializedSize{get { return 2; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  ExternReferenceBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            parameterIndex = binaryReader.ReadByte();
            externIndex = binaryReader.ReadByte();
        }
        public  ExternReferenceBlockBase(): base()
        {
            
        }
        public override void Read(BinaryReader binaryReader)
        {
            parameterIndex = binaryReader.ReadByte();
            externIndex = binaryReader.ReadByte();
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(parameterIndex);
                binaryWriter.Write(externIndex);
                return nextAddress;
            }
        }
    };
}
