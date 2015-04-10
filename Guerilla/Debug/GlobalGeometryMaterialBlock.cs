// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class GlobalGeometryMaterialBlock : GlobalGeometryMaterialBlockBase
    {
        public  GlobalGeometryMaterialBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 32)]
    public class GlobalGeometryMaterialBlockBase
    {
        [TagReference("shad")]
        internal Moonfish.Tags.TagReference oldShader;
        [TagReference("shad")]
        internal Moonfish.Tags.TagReference shader;
        internal GlobalGeometryMaterialPropertyBlock[] properties;
        internal byte[] invalidName_;
        internal byte breakableSurfaceIndex;
        internal byte[] invalidName_0;
        internal  GlobalGeometryMaterialBlockBase(System.IO.BinaryReader binaryReader)
        {
            oldShader = binaryReader.ReadTagReference();
            shader = binaryReader.ReadTagReference();
            ReadGlobalGeometryMaterialPropertyBlockArray(binaryReader);
            invalidName_ = binaryReader.ReadBytes(4);
            breakableSurfaceIndex = binaryReader.ReadByte();
            invalidName_0 = binaryReader.ReadBytes(3);
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
        internal  virtual GlobalGeometryMaterialPropertyBlock[] ReadGlobalGeometryMaterialPropertyBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(GlobalGeometryMaterialPropertyBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new GlobalGeometryMaterialPropertyBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new GlobalGeometryMaterialPropertyBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteGlobalGeometryMaterialPropertyBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(oldShader);
                binaryWriter.Write(shader);
                WriteGlobalGeometryMaterialPropertyBlockArray(binaryWriter);
                binaryWriter.Write(invalidName_, 0, 4);
                binaryWriter.Write(breakableSurfaceIndex);
                binaryWriter.Write(invalidName_0, 0, 3);
            }
        }
    };
}
