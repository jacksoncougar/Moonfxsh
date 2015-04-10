// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class CollisionModelNodeBlock : CollisionModelNodeBlockBase
    {
        public  CollisionModelNodeBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 12)]
    public class CollisionModelNodeBlockBase
    {
        internal Moonfish.Tags.StringID name;
        internal byte[] invalidName_;
        internal Moonfish.Tags.ShortBlockIndex1 parentNode;
        internal Moonfish.Tags.ShortBlockIndex1 nextSiblingNode;
        internal Moonfish.Tags.ShortBlockIndex1 firstChildNode;
        internal  CollisionModelNodeBlockBase(System.IO.BinaryReader binaryReader)
        {
            name = binaryReader.ReadStringID();
            invalidName_ = binaryReader.ReadBytes(2);
            parentNode = binaryReader.ReadShortBlockIndex1();
            nextSiblingNode = binaryReader.ReadShortBlockIndex1();
            firstChildNode = binaryReader.ReadShortBlockIndex1();
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
                binaryWriter.Write(name);
                binaryWriter.Write(invalidName_, 0, 2);
                binaryWriter.Write(parentNode);
                binaryWriter.Write(nextSiblingNode);
                binaryWriter.Write(firstChildNode);
            }
        }
    };
}
