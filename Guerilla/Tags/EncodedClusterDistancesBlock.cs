using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class EncodedClusterDistancesBlock : EncodedClusterDistancesBlockBase
    {
        public  EncodedClusterDistancesBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 1)]
    public class EncodedClusterDistancesBlockBase
    {
        internal byte invalidName_;
        internal  EncodedClusterDistancesBlockBase(BinaryReader binaryReader)
        {
            this.invalidName_ = binaryReader.ReadByte();
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
