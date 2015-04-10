using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class GlobalShaderParameterBlock : GlobalShaderParameterBlockBase
    {
        public  GlobalShaderParameterBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 40)]
    public class GlobalShaderParameterBlockBase
    {
        internal Moonfish.Tags.StringID name;
        internal Type type;
        internal byte[] invalidName_;
        [TagReference("bitm")]
        internal Moonfish.Tags.TagReference bitmap;
        internal float constValue;
        internal Moonfish.Tags.ColorR8G8B8 constColor;
        internal ShaderAnimationPropertyBlock[] animationProperties;
        internal  GlobalShaderParameterBlockBase(BinaryReader binaryReader)
        {
            this.name = binaryReader.ReadStringID();
            this.type = (Type)binaryReader.ReadInt16();
            this.invalidName_ = binaryReader.ReadBytes(2);
            this.bitmap = binaryReader.ReadTagReference();
            this.constValue = binaryReader.ReadSingle();
            this.constColor = binaryReader.ReadColorR8G8B8();
            this.animationProperties = ReadShaderAnimationPropertyBlockArray(binaryReader);
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
        internal  virtual ShaderAnimationPropertyBlock[] ReadShaderAnimationPropertyBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ShaderAnimationPropertyBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ShaderAnimationPropertyBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ShaderAnimationPropertyBlock(binaryReader);
                }
            }
            return array;
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
