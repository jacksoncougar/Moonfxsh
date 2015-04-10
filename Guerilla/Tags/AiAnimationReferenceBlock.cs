using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class AiAnimationReferenceBlock : AiAnimationReferenceBlockBase
    {
        public  AiAnimationReferenceBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 52)]
    public class AiAnimationReferenceBlockBase
    {
        internal Moonfish.Tags.String32 animationName;
        /// <summary>
        /// leave this blank to use the unit's normal animationGraph
        /// </summary>
        [TagReference("jmad")]
        internal Moonfish.Tags.TagReference animationGraph;
        internal byte[] invalidName_;
        internal  AiAnimationReferenceBlockBase(BinaryReader binaryReader)
        {
            this.animationName = binaryReader.ReadString32();
            this.animationGraph = binaryReader.ReadTagReference();
            this.invalidName_ = binaryReader.ReadBytes(12);
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
