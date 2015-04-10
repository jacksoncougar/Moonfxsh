using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class GlobalDetailObjectCellsBlock : GlobalDetailObjectCellsBlockBase
    {
        public  GlobalDetailObjectCellsBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 32)]
    public class GlobalDetailObjectCellsBlockBase
    {
        internal short invalidName_;
        internal short invalidName_0;
        internal short invalidName_1;
        internal short invalidName_2;
        internal int invalidName_3;
        internal int invalidName_4;
        internal int invalidName_5;
        internal byte[] invalidName_6;
        internal  GlobalDetailObjectCellsBlockBase(BinaryReader binaryReader)
        {
            this.invalidName_ = binaryReader.ReadInt16();
            this.invalidName_0 = binaryReader.ReadInt16();
            this.invalidName_1 = binaryReader.ReadInt16();
            this.invalidName_2 = binaryReader.ReadInt16();
            this.invalidName_3 = binaryReader.ReadInt32();
            this.invalidName_4 = binaryReader.ReadInt32();
            this.invalidName_5 = binaryReader.ReadInt32();
            this.invalidName_6 = binaryReader.ReadBytes(12);
        }
        internal  virtual byte[] ReadData(BinaryReader binaryReader)
        {
            var blamPointer = binaryReader.ReadBlamPointer(1);
            var data = new byte[blamPointer.Count];
            if(blamPointer.Count > 0)
            {
                using (binaryReader.BaseStream.Pin())
                {
                    binaryReader.BaseStream.Position = blamPointer[0];
                    data = binaryReader.ReadBytes(blamPointer.Count);
                }
            }
            return data;
        }
    };
}
