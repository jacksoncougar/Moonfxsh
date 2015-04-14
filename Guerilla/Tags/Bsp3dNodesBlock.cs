// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class Bsp3dNodesBlock : Bsp3dNodesBlockBase
    {
        public  Bsp3dNodesBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 8, Alignment = 8)]
    public class Bsp3dNodesBlockBase  : IGuerilla
    {
        internal byte[] invalidName_;
        internal  Bsp3dNodesBlockBase(BinaryReader binaryReader)
        {
            invalidName_ = binaryReader.ReadBytes(8);
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(invalidName_, 0, 8);
                return nextAddress = (int)binaryWriter.BaseStream.Position;
            }
        }
    };
}
