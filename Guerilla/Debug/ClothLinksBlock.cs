// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class ClothLinksBlock : ClothLinksBlockBase
    {
        public  ClothLinksBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 16)]
    public class ClothLinksBlockBase
    {
        internal int attachmentBits;
        internal short index1;
        internal short index2;
        internal float defaultDistance;
        internal float dampingMultiplier;
        internal  ClothLinksBlockBase(System.IO.BinaryReader binaryReader)
        {
            attachmentBits = binaryReader.ReadInt32();
            index1 = binaryReader.ReadInt16();
            index2 = binaryReader.ReadInt16();
            defaultDistance = binaryReader.ReadSingle();
            dampingMultiplier = binaryReader.ReadSingle();
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
                binaryWriter.Write(attachmentBits);
                binaryWriter.Write(index1);
                binaryWriter.Write(index2);
                binaryWriter.Write(defaultDistance);
                binaryWriter.Write(dampingMultiplier);
            }
        }
    };
}
