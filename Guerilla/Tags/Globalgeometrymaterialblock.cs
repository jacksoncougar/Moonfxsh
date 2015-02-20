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
        public  GlobalGeometryMaterialBlock(BinaryReader binaryReader): base(binaryReader)
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
        internal  GlobalGeometryMaterialBlockBase(BinaryReader binaryReader)
        {
            this.oldShader = binaryReader.ReadTagReference();
            this.shader = binaryReader.ReadTagReference();
            this.properties = ReadGlobalGeometryMaterialPropertyBlockArray(binaryReader);
            this.invalidName_ = binaryReader.ReadBytes(4);
            this.breakableSurfaceIndex = binaryReader.ReadByte();
            this.invalidName_0 = binaryReader.ReadBytes(3);
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
        internal  virtual GlobalGeometryMaterialPropertyBlock[] ReadGlobalGeometryMaterialPropertyBlockArray(BinaryReader binaryReader)
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
    };
}
