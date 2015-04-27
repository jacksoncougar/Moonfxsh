// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class SoundGestaltRuntimePermutationBitVectorBlock : SoundGestaltRuntimePermutationBitVectorBlockBase
    {
        public  SoundGestaltRuntimePermutationBitVectorBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  SoundGestaltRuntimePermutationBitVectorBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 1, Alignment = 4)]
    public class SoundGestaltRuntimePermutationBitVectorBlockBase : GuerillaBlock
    {
        internal byte invalidName_;
        
        public override int SerializedSize{get { return 1; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  SoundGestaltRuntimePermutationBitVectorBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            invalidName_ = binaryReader.ReadByte();
        }
        public  SoundGestaltRuntimePermutationBitVectorBlockBase(): base()
        {
            
        }
        public void Read(BinaryReader binaryReader)
        {
            invalidName_ = binaryReader.ReadByte();
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(invalidName_);
                return nextAddress;
            }
        }
    };
}
