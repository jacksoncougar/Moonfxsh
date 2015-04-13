using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class DecoratorModelsBlock : DecoratorModelsBlockBase
    {
        public  DecoratorModelsBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 8)]
    public class DecoratorModelsBlockBase
    {
        internal Moonfish.Tags.StringID modelName;
        internal short indexStart;
        internal short indexCount;
        internal  DecoratorModelsBlockBase(BinaryReader binaryReader)
        {
            this.modelName = binaryReader.ReadStringID();
            this.indexStart = binaryReader.ReadInt16();
            this.indexCount = binaryReader.ReadInt16();
        }
        internal  virtual byte[] ReadData(BinaryReader binaryReader)
        {
            var blamPointer = binaryReader.ReadBlamPointer(1);
            var data = new byte[blamPointer.elementCount];
            if(blamPointer.elementCount > 0)
            {
                using (binaryReader.BaseStream.Pin())
                {
                    binaryReader.BaseStream.Position = blamPointer[0];
                    data = binaryReader.ReadBytes(blamPointer.elementCount);
                }
            }
            return data;
        }
    };
}
