// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class GlobalGeometryMaterialPropertyBlock : GlobalGeometryMaterialPropertyBlockBase
    {
        public  GlobalGeometryMaterialPropertyBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  GlobalGeometryMaterialPropertyBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 8, Alignment = 4)]
    public class GlobalGeometryMaterialPropertyBlockBase : GuerillaBlock
    {
        internal Type type;
        internal short intValue;
        internal float realValue;
        
        public override int SerializedSize{get { return 8; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  GlobalGeometryMaterialPropertyBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            type = (Type)binaryReader.ReadInt16();
            intValue = binaryReader.ReadInt16();
            realValue = binaryReader.ReadSingle();
        }
        public  GlobalGeometryMaterialPropertyBlockBase(): base()
        {
            
        }
        public void Read(BinaryReader binaryReader)
        {
            type = (Type)binaryReader.ReadInt16();
            intValue = binaryReader.ReadInt16();
            realValue = binaryReader.ReadSingle();
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write((Int16)type);
                binaryWriter.Write(intValue);
                binaryWriter.Write(realValue);
                return nextAddress;
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
