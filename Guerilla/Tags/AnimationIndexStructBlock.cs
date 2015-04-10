using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class AnimationIndexStructBlock : AnimationIndexStructBlockBase
    {
        public  AnimationIndexStructBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 4)]
    public class AnimationIndexStructBlockBase
    {
        internal short graphIndex;
        internal Moonfish.Tags.ShortBlockIndex1 animation;
        internal  AnimationIndexStructBlockBase(BinaryReader binaryReader)
        {
            this.graphIndex = binaryReader.ReadInt16();
            this.animation = binaryReader.ReadShortBlockIndex1();
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
