using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class PackedDataSizesStructBlock : PackedDataSizesStructBlockBase
    {
        public  PackedDataSizesStructBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 16)]
    public class PackedDataSizesStructBlockBase
    {
        internal byte invalidName_;
        internal byte invalidName_0;
        internal short invalidName_1;
        internal short invalidName_2;
        internal short invalidName_3;
        internal int invalidName_4;
        internal int invalidName_5;
        internal  PackedDataSizesStructBlockBase(BinaryReader binaryReader)
        {
            this.invalidName_ = binaryReader.ReadByte();
            this.invalidName_0 = binaryReader.ReadByte();
            this.invalidName_1 = binaryReader.ReadInt16();
            this.invalidName_2 = binaryReader.ReadInt16();
            this.invalidName_3 = binaryReader.ReadInt16();
            this.invalidName_4 = binaryReader.ReadInt32();
            this.invalidName_5 = binaryReader.ReadInt32();
        }
        internal  virtual byte[] ReadData(BinaryReader binaryReader)
        {
            var blamPointer = binaryReader.ReadBlamPointer(1);
            var data = new byte[blamPointer.count];
            if(blamPointer.count > 0)
            {
                using (binaryReader.BaseStream.Pin())
                {
                    binaryReader.BaseStream.Position = blamPointer[0];
                    data = binaryReader.ReadBytes(blamPointer.count);
                }
            }
            return data;
        }
    };
}
