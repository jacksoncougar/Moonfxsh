using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class HsSourceFilesBlock : HsSourceFilesBlockBase
    {
        public  HsSourceFilesBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 40)]
    public class HsSourceFilesBlockBase
    {
        internal Moonfish.Tags.String32 name;
        internal byte[] source;
        internal  HsSourceFilesBlockBase(BinaryReader binaryReader)
        {
            this.name = binaryReader.ReadString32();
            this.source = ReadData(binaryReader);
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
