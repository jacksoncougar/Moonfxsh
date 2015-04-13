using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class SoundGestaltRuntimePermutationBitVectorBlock : SoundGestaltRuntimePermutationBitVectorBlockBase
    {
        public  SoundGestaltRuntimePermutationBitVectorBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 1)]
    public class SoundGestaltRuntimePermutationBitVectorBlockBase
    {
        internal byte invalidName_;
        internal  SoundGestaltRuntimePermutationBitVectorBlockBase(BinaryReader binaryReader)
        {
            this.invalidName_ = binaryReader.ReadByte();
        }
        internal  virtual byte[] ReadData(BinaryReader binaryReader)
        {
            var blamPointer = binaryReader.ReadBlamPointer(1);
            var data = new byte[blamPointer.elementCount];
            if(blamPointer.elementCount > 0)
            {
                using (binaryReader.BaseStream.Pin())
                {
                    binaryReader.BaseStream.Position = blamPointer[0];
                    data = binaryReader.ReadBytes(blamPointer.elementCount);
                }
            }
            return data;
        }
    };
}
