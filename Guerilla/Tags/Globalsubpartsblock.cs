using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class GlobalSubpartsBlock : GlobalSubpartsBlockBase
    {
        public  GlobalSubpartsBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 8)]
    public class GlobalSubpartsBlockBase
    {
        internal short indicesStartIndex;
        internal short indicesLength;
        internal short visibilityBoundsIndex;
        internal short partIndex;
        internal  GlobalSubpartsBlockBase(BinaryReader binaryReader)
        {
            this.indicesStartIndex = binaryReader.ReadInt16();
            this.indicesLength = binaryReader.ReadInt16();
            this.visibilityBoundsIndex = binaryReader.ReadInt16();
            this.partIndex = binaryReader.ReadInt16();
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
