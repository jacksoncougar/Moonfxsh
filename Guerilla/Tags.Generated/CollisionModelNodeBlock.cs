// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class CollisionModelNodeBlock : CollisionModelNodeBlockBase
    {
        public  CollisionModelNodeBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  CollisionModelNodeBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 12, Alignment = 4)]
    public class CollisionModelNodeBlockBase : GuerillaBlock
    {
        internal Moonfish.Tags.StringID name;
        internal byte[] invalidName_;
        internal Moonfish.Tags.ShortBlockIndex1 parentNode;
        internal Moonfish.Tags.ShortBlockIndex1 nextSiblingNode;
        internal Moonfish.Tags.ShortBlockIndex1 firstChildNode;
        
        public override int SerializedSize{get { return 12; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  CollisionModelNodeBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            name = binaryReader.ReadStringID();
            invalidName_ = binaryReader.ReadBytes(2);
            parentNode = binaryReader.ReadShortBlockIndex1();
            nextSiblingNode = binaryReader.ReadShortBlockIndex1();
            firstChildNode = binaryReader.ReadShortBlockIndex1();
        }
        public  CollisionModelNodeBlockBase(): base()
        {
            
        }
        public override void Read(BinaryReader binaryReader)
        {
            name = binaryReader.ReadStringID();
            invalidName_ = binaryReader.ReadBytes(2);
            parentNode = binaryReader.ReadShortBlockIndex1();
            nextSiblingNode = binaryReader.ReadShortBlockIndex1();
            firstChildNode = binaryReader.ReadShortBlockIndex1();
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(name);
                binaryWriter.Write(invalidName_, 0, 2);
                binaryWriter.Write(parentNode);
                binaryWriter.Write(nextSiblingNode);
                binaryWriter.Write(firstChildNode);
                return nextAddress;
            }
        }
    };
}
