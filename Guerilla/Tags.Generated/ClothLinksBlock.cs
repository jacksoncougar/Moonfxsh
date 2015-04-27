// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class ClothLinksBlock : ClothLinksBlockBase
    {
        public  ClothLinksBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  ClothLinksBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 16, Alignment = 4)]
    public class ClothLinksBlockBase : GuerillaBlock
    {
        internal int attachmentBits;
        internal short index1;
        internal short index2;
        internal float defaultDistance;
        internal float dampingMultiplier;
        
        public override int SerializedSize{get { return 16; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  ClothLinksBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            attachmentBits = binaryReader.ReadInt32();
            index1 = binaryReader.ReadInt16();
            index2 = binaryReader.ReadInt16();
            defaultDistance = binaryReader.ReadSingle();
            dampingMultiplier = binaryReader.ReadSingle();
        }
        public  ClothLinksBlockBase(): base()
        {
            
        }
        public void Read(BinaryReader binaryReader)
        {
            attachmentBits = binaryReader.ReadInt32();
            index1 = binaryReader.ReadInt16();
            index2 = binaryReader.ReadInt16();
            defaultDistance = binaryReader.ReadSingle();
            dampingMultiplier = binaryReader.ReadSingle();
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(attachmentBits);
                binaryWriter.Write(index1);
                binaryWriter.Write(index2);
                binaryWriter.Write(defaultDistance);
                binaryWriter.Write(dampingMultiplier);
                return nextAddress;
            }
        }
    };
}
