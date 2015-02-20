using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("bloc")]
    public  partial class CrateBlock : CrateBlockBase
    {
        public  CrateBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 4)]
    public class CrateBlockBase : ObjectBlock
    {
        internal Flags flags;
        internal byte[] invalidName_;
        internal  CrateBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            this.flags = (Flags)binaryReader.ReadInt16();
            this.invalidName_ = binaryReader.ReadBytes(2);
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
        internal enum Flags : short
        {
            DoesNotBlockAOE = 1,
        };
    };
}
