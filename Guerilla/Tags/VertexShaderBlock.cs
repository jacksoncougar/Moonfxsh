using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("vrtx")]
    public  partial class VertexShaderBlock : VertexShaderBlockBase
    {
        public  VertexShaderBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 16)]
    public class VertexShaderBlockBase
    {
        internal Platform platform;
        internal byte[] invalidName_;
        internal VertexShaderClassificationBlock[] geometryClassifications;
        internal int outputSwizzles;
        internal  VertexShaderBlockBase(BinaryReader binaryReader)
        {
            this.platform = (Platform)binaryReader.ReadInt16();
            this.invalidName_ = binaryReader.ReadBytes(2);
            this.geometryClassifications = ReadVertexShaderClassificationBlockArray(binaryReader);
            this.outputSwizzles = binaryReader.ReadInt32();
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
        internal  virtual VertexShaderClassificationBlock[] ReadVertexShaderClassificationBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(VertexShaderClassificationBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new VertexShaderClassificationBlock[blamPointer.elementCount];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.elementCount; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new VertexShaderClassificationBlock(binaryReader);
                }
            }
            return array;
        }
        internal enum Platform : short
        
        {
            Pc = 0,
            Xbox = 1,
        };
    };
}
