// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class PredictedBitmapsBlock : PredictedBitmapsBlockBase
    {
        public  PredictedBitmapsBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  PredictedBitmapsBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 8, Alignment = 4)]
    public class PredictedBitmapsBlockBase : GuerillaBlock
    {
        [TagReference("bitm")]
        internal Moonfish.Tags.TagReference bitmap;
        
        public override int SerializedSize{get { return 8; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  PredictedBitmapsBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            bitmap = binaryReader.ReadTagReference();
        }
        public  PredictedBitmapsBlockBase(): base()
        {
            
        }
        public void Read(BinaryReader binaryReader)
        {
            bitmap = binaryReader.ReadTagReference();
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(bitmap);
                return nextAddress;
            }
        }
    };
}
