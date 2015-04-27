// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class GlobalShaderParameterBlock : GlobalShaderParameterBlockBase
    {
        public  GlobalShaderParameterBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  GlobalShaderParameterBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 40, Alignment = 4)]
    public class GlobalShaderParameterBlockBase : GuerillaBlock
    {
        internal Moonfish.Tags.StringID name;
        internal Type type;
        internal byte[] invalidName_;
        [TagReference("bitm")]
        internal Moonfish.Tags.TagReference bitmap;
        internal float constValue;
        internal Moonfish.Tags.ColorR8G8B8 constColor;
        internal ShaderAnimationPropertyBlock[] animationProperties;
        
        public override int SerializedSize{get { return 40; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  GlobalShaderParameterBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            name = binaryReader.ReadStringID();
            type = (Type)binaryReader.ReadInt16();
            invalidName_ = binaryReader.ReadBytes(2);
            bitmap = binaryReader.ReadTagReference();
            constValue = binaryReader.ReadSingle();
            constColor = binaryReader.ReadColorR8G8B8();
            animationProperties = Guerilla.ReadBlockArray<ShaderAnimationPropertyBlock>(binaryReader);
        }
        public  GlobalShaderParameterBlockBase(): base()
        {
            
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(name);
                binaryWriter.Write((Int16)type);
                binaryWriter.Write(invalidName_, 0, 2);
                binaryWriter.Write(bitmap);
                binaryWriter.Write(constValue);
                binaryWriter.Write(constColor);
                nextAddress = Guerilla.WriteBlockArray<ShaderAnimationPropertyBlock>(binaryWriter, animationProperties, nextAddress);
                return nextAddress;
            }
        }
        internal enum Type : short
        {
            Bitmap = 0,
            Value = 1,
            Color = 2,
            Switch = 3,
        };
    };
}
