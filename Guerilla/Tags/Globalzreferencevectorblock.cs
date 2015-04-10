using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class GlobalZReferenceVectorBlock : GlobalZReferenceVectorBlockBase
    {
        public  GlobalZReferenceVectorBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 16)]
    public class GlobalZReferenceVectorBlockBase
    {
        internal float invalidName_;
        internal float invalidName_0;
        internal float invalidName_1;
        internal float invalidName_2;
        internal  GlobalZReferenceVectorBlockBase(BinaryReader binaryReader)
        {
            this.invalidName_ = binaryReader.ReadSingle();
            this.invalidName_0 = binaryReader.ReadSingle();
            this.invalidName_1 = binaryReader.ReadSingle();
            this.invalidName_2 = binaryReader.ReadSingle();
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
