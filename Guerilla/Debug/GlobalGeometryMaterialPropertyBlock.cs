// ReSharper disable All
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
        public  GlobalGeometryMaterialPropertyBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 8)]
    public class GlobalGeometryMaterialPropertyBlockBase
    {
        internal Type type;
        internal short intValue;
        internal float realValue;
        internal  GlobalGeometryMaterialPropertyBlockBase(System.IO.BinaryReader binaryReader)
        {
            type = (Type)binaryReader.ReadInt16();
            intValue = binaryReader.ReadInt16();
            realValue = binaryReader.ReadSingle();
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
                binaryWriter.Write((Int16)type);
                binaryWriter.Write(intValue);
                binaryWriter.Write(realValue);
            }
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
