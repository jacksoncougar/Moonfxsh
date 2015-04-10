// ReSharper disable All
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
        public  GlobalShaderParameterBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
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
        internal  GlobalShaderParameterBlockBase(System.IO.BinaryReader binaryReader)
        {
            name = binaryReader.ReadStringID();
            type = (Type)binaryReader.ReadInt16();
            invalidName_ = binaryReader.ReadBytes(2);
            bitmap = binaryReader.ReadTagReference();
            constValue = binaryReader.ReadSingle();
            constColor = binaryReader.ReadColorR8G8B8();
            ReadShaderAnimationPropertyBlockArray(binaryReader);
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
        internal  virtual ShaderAnimationPropertyBlock[] ReadShaderAnimationPropertyBlockArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteShaderAnimationPropertyBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(name);
                binaryWriter.Write((Int16)type);
                binaryWriter.Write(invalidName_, 0, 2);
                binaryWriter.Write(bitmap);
                binaryWriter.Write(constValue);
                binaryWriter.Write(constColor);
                WriteShaderAnimationPropertyBlockArray(binaryWriter);
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
