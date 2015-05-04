// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class AiAnimationReferenceBlock : AiAnimationReferenceBlockBase
    {
        public  AiAnimationReferenceBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  AiAnimationReferenceBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 52, Alignment = 4)]
    public class AiAnimationReferenceBlockBase : GuerillaBlock
    {
        internal Moonfish.Tags.String32 animationName;
        /// <summary>
        /// leave this blank to use the unit's normal animationGraph
        /// </summary>
        [TagReference("jmad")]
        internal Moonfish.Tags.TagReference animationGraph;
        internal byte[] invalidName_;
        
        public override int SerializedSize{get { return 52; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  AiAnimationReferenceBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            animationName = binaryReader.ReadString32();
            animationGraph = binaryReader.ReadTagReference();
            invalidName_ = binaryReader.ReadBytes(12);
        }
        public  AiAnimationReferenceBlockBase(): base()
        {
            
        }
        public override void Read(BinaryReader binaryReader)
        {
            animationName = binaryReader.ReadString32();
            animationGraph = binaryReader.ReadTagReference();
            invalidName_ = binaryReader.ReadBytes(12);
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(animationName);
                binaryWriter.Write(animationGraph);
                binaryWriter.Write(invalidName_, 0, 12);
                return nextAddress;
            }
        }
    };
}
