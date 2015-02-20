using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class GlobalGeometryMaterialPropertyBlock : GlobalGeometryMaterialPropertyBlockBase
    {
        public  GlobalGeometryMaterialPropertyBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 8)]
    public class GlobalGeometryMaterialPropertyBlockBase
    {
        internal Type type;
        internal short intValue;
        internal float realValue;
        internal  GlobalGeometryMaterialPropertyBlockBase(BinaryReader binaryReader)
        {
            this.type = (Type)binaryReader.ReadInt16();
            this.intValue = binaryReader.ReadInt16();
            this.realValue = binaryReader.ReadSingle();
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
        internal enum Type : short
        {
            LightmapResolution = 0,
            LightmapPower = 1,
            LightmapHalfLife = 2,
            LightmapDiffuseScale = 3,
        };
    };
}
