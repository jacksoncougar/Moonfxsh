// ReSharper disable All
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
        public  AnimationIndexStructBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 4)]
    public class AnimationIndexStructBlockBase
    {
        internal short graphIndex;
        internal Moonfish.Tags.ShortBlockIndex1 animation;
        internal  AnimationIndexStructBlockBase(System.IO.BinaryReader binaryReader)
        {
            graphIndex = binaryReader.ReadInt16();
            animation = binaryReader.ReadShortBlockIndex1();
        }
        internal  virtual byte[] ReadData(System.IO.BinaryReader binaryReader)
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
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(graphIndex);
                binaryWriter.Write(animation);
            }
        }
    };
}
