// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class PackedDataSizesStructBlock : PackedDataSizesStructBlockBase
    {
        public  PackedDataSizesStructBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  PackedDataSizesStructBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 16, Alignment = 4)]
    public class PackedDataSizesStructBlockBase : GuerillaBlock
    {
        internal byte invalidName_;
        internal byte invalidName_0;
        internal short invalidName_1;
        internal short invalidName_2;
        internal short invalidName_3;
        internal int invalidName_4;
        internal int invalidName_5;
        
        public override int SerializedSize{get { return 16; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  PackedDataSizesStructBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            invalidName_ = binaryReader.ReadByte();
            invalidName_0 = binaryReader.ReadByte();
            invalidName_1 = binaryReader.ReadInt16();
            invalidName_2 = binaryReader.ReadInt16();
            invalidName_3 = binaryReader.ReadInt16();
            invalidName_4 = binaryReader.ReadInt32();
            invalidName_5 = binaryReader.ReadInt32();
        }
        public  PackedDataSizesStructBlockBase(): base()
        {
            
        }
        public void Read(BinaryReader binaryReader)
        {
            invalidName_ = binaryReader.ReadByte();
            invalidName_0 = binaryReader.ReadByte();
            invalidName_1 = binaryReader.ReadInt16();
            invalidName_2 = binaryReader.ReadInt16();
            invalidName_3 = binaryReader.ReadInt16();
            invalidName_4 = binaryReader.ReadInt32();
            invalidName_5 = binaryReader.ReadInt32();
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
                binaryWriter.Write(invalidName_4);
                binaryWriter.Write(invalidName_5);
                return nextAddress;
            }
        }
    };
}
