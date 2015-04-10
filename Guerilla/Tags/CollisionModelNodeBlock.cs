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
        public  CollisionModelNodeBlock(BinaryReader binaryReader): base(binaryReader)
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
        internal  CollisionModelNodeBlockBase(BinaryReader binaryReader)
        {
            this.name = binaryReader.ReadStringID();
            this.invalidName_ = binaryReader.ReadBytes(2);
            this.parentNode = binaryReader.ReadShortBlockIndex1();
            this.nextSiblingNode = binaryReader.ReadShortBlockIndex1();
            this.firstChildNode = binaryReader.ReadShortBlockIndex1();
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
