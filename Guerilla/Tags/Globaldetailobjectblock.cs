using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class GlobalDetailObjectBlock : GlobalDetailObjectBlockBase
    {
        public  GlobalDetailObjectBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 6)]
    public class GlobalDetailObjectBlockBase
    {
        internal byte invalidName_;
        internal byte invalidName_0;
        internal byte invalidName_1;
        internal byte invalidName_2;
        internal short invalidName_3;
        internal  GlobalDetailObjectBlockBase(BinaryReader binaryReader)
        {
            this.invalidName_ = binaryReader.ReadByte();
            this.invalidName_0 = binaryReader.ReadByte();
            this.invalidName_1 = binaryReader.ReadByte();
            this.invalidName_2 = binaryReader.ReadByte();
            this.invalidName_3 = binaryReader.ReadInt16();
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
