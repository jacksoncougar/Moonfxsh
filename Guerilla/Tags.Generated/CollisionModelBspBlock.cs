// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class CollisionModelBspBlock : CollisionModelBspBlockBase
    {
        public  CollisionModelBspBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  CollisionModelBspBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 68, Alignment = 4)]
    public class CollisionModelBspBlockBase : GuerillaBlock
    {
        internal short nodeIndex;
        internal byte[] invalidName_;
        internal GlobalCollisionBspStructBlock bsp;
        
        public override int SerializedSize{get { return 68; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  CollisionModelBspBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            nodeIndex = binaryReader.ReadInt16();
            invalidName_ = binaryReader.ReadBytes(2);
            bsp = new GlobalCollisionBspStructBlock(binaryReader);
        }
        public  CollisionModelBspBlockBase(): base()
        {
            
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(nodeIndex);
                binaryWriter.Write(invalidName_, 0, 2);
                bsp.Write(binaryWriter);
                return nextAddress;
            }
        }
    };
}
