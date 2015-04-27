// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class Bsp3dNodesBlock : Bsp3dNodesBlockBase
    {
        public  Bsp3dNodesBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  Bsp3dNodesBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 8, Alignment = 8)]
    public class Bsp3dNodesBlockBase : GuerillaBlock
    {
        internal byte[] invalidName_;
        
        public override int SerializedSize{get { return 8; }}
        
        
        public override int Alignment{get { return 8; }}
        
        public  Bsp3dNodesBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            invalidName_ = binaryReader.ReadBytes(8);
        }
        public  Bsp3dNodesBlockBase(): base()
        {
            
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(invalidName_, 0, 8);
                return nextAddress;
            }
        }
    };
}
