// ReSharper disable All
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
        public  VertexShaderBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
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
        internal  VertexShaderBlockBase(System.IO.BinaryReader binaryReader)
        {
            platform = (Platform)binaryReader.ReadInt16();
            invalidName_ = binaryReader.ReadBytes(2);
            ReadVertexShaderClassificationBlockArray(binaryReader);
            outputSwizzles = binaryReader.ReadInt32();
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
        internal  virtual VertexShaderClassificationBlock[] ReadVertexShaderClassificationBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(VertexShaderClassificationBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new VertexShaderClassificationBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new VertexShaderClassificationBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteVertexShaderClassificationBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write((Int16)platform);
                binaryWriter.Write(invalidName_, 0, 2);
                WriteVertexShaderClassificationBlockArray(binaryWriter);
                binaryWriter.Write(outputSwizzles);
            }
        }
        internal enum Platform : short
        
        {
            Pc = 0,
            Xbox = 1,
        };
    };
}
