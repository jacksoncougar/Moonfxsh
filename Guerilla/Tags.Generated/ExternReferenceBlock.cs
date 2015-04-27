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
    };
    [LayoutAttribute(Size = 2, Alignment = 4)]
    public class ExternReferenceBlockBase : GuerillaBlock
    {
        internal byte parameterIndex;
        internal byte externIndex;
        
        public override int SerializedSize{get { return 2; }}
        
        internal  ExternReferenceBlockBase(BinaryReader binaryReader): base(binaryReader)
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
