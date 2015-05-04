// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class GlobalGeometryMaterialBlock : GlobalGeometryMaterialBlockBase
    {
        public  GlobalGeometryMaterialBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  GlobalGeometryMaterialBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 32, Alignment = 4)]
    public class GlobalGeometryMaterialBlockBase : GuerillaBlock
    {
        [TagReference("shad")]
        internal Moonfish.Tags.TagReference oldShader;
        [TagReference("shad")]
        internal Moonfish.Tags.TagReference shader;
        internal GlobalGeometryMaterialPropertyBlock[] properties;
        internal byte[] invalidName_;
        internal byte breakableSurfaceIndex;
        internal byte[] invalidName_0;
        
        public override int SerializedSize{get { return 32; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  GlobalGeometryMaterialBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            oldShader = binaryReader.ReadTagReference();
            shader = binaryReader.ReadTagReference();
            properties = Guerilla.ReadBlockArray<GlobalGeometryMaterialPropertyBlock>(binaryReader);
            invalidName_ = binaryReader.ReadBytes(4);
            breakableSurfaceIndex = binaryReader.ReadByte();
            invalidName_0 = binaryReader.ReadBytes(3);
        }
        public  GlobalGeometryMaterialBlockBase(): base()
        {
            
        }
        public override void Read(BinaryReader binaryReader)
        {
            oldShader = binaryReader.ReadTagReference();
            shader = binaryReader.ReadTagReference();
            properties = Guerilla.ReadBlockArray<GlobalGeometryMaterialPropertyBlock>(binaryReader);
            invalidName_ = binaryReader.ReadBytes(4);
            breakableSurfaceIndex = binaryReader.ReadByte();
            invalidName_0 = binaryReader.ReadBytes(3);
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(oldShader);
                binaryWriter.Write(shader);
                nextAddress = Guerilla.WriteBlockArray<GlobalGeometryMaterialPropertyBlock>(binaryWriter, properties, nextAddress);
                binaryWriter.Write(invalidName_, 0, 4);
                binaryWriter.Write(breakableSurfaceIndex);
                binaryWriter.Write(invalidName_0, 0, 3);
                return nextAddress;
            }
        }
    };
}
