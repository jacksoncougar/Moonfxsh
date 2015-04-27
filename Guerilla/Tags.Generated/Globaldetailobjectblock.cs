// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class GlobalDetailObjectBlock : GlobalDetailObjectBlockBase
    {
        public  GlobalDetailObjectBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  GlobalDetailObjectBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 6, Alignment = 4)]
    public class GlobalDetailObjectBlockBase : GuerillaBlock
    {
        internal byte invalidName_;
        internal byte invalidName_0;
        internal byte invalidName_1;
        internal byte invalidName_2;
        internal short invalidName_3;
        
        public override int SerializedSize{get { return 6; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  GlobalDetailObjectBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            invalidName_ = binaryReader.ReadByte();
            invalidName_0 = binaryReader.ReadByte();
            invalidName_1 = binaryReader.ReadByte();
            invalidName_2 = binaryReader.ReadByte();
            invalidName_3 = binaryReader.ReadInt16();
        }
        public  GlobalDetailObjectBlockBase(): base()
        {
            
        }
        public void Read(BinaryReader binaryReader)
        {
            invalidName_ = binaryReader.ReadByte();
            invalidName_0 = binaryReader.ReadByte();
            invalidName_1 = binaryReader.ReadByte();
            invalidName_2 = binaryReader.ReadByte();
            invalidName_3 = binaryReader.ReadInt16();
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(invalidName_);
                binaryWriter.Write(invalidName_0);
                binaryWriter.Write(invalidName_1);
                binaryWriter.Write(invalidName_2);
                binaryWriter.Write(invalidName_3);
                return nextAddress;
            }
        }
    };
}
