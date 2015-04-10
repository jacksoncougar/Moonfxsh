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
        public  ClothLinksBlock(BinaryReader binaryReader): base(binaryReader)
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
        internal  ClothLinksBlockBase(BinaryReader binaryReader)
        {
            this.attachmentBits = binaryReader.ReadInt32();
            this.index1 = binaryReader.ReadInt16();
            this.index2 = binaryReader.ReadInt16();
            this.defaultDistance = binaryReader.ReadSingle();
            this.dampingMultiplier = binaryReader.ReadSingle();
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
