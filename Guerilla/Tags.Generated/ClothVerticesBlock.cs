// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class ClothVerticesBlock : ClothVerticesBlockBase
    {
        public  ClothVerticesBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  ClothVerticesBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 20, Alignment = 4)]
    public class ClothVerticesBlockBase : GuerillaBlock
    {
        internal OpenTK.Vector3 initialPosition;
        internal OpenTK.Vector2 uv;
        
        public override int SerializedSize{get { return 20; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  ClothVerticesBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            initialPosition = binaryReader.ReadVector3();
            uv = binaryReader.ReadVector2();
        }
        public  ClothVerticesBlockBase(): base()
        {
            
        }
        public void Read(BinaryReader binaryReader)
        {
            initialPosition = binaryReader.ReadVector3();
            uv = binaryReader.ReadVector2();
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(initialPosition);
                binaryWriter.Write(uv);
                return nextAddress;
            }
        }
    };
}
