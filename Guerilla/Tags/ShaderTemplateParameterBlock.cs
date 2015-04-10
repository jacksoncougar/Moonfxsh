using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class ShaderTemplateParameterBlock : ShaderTemplateParameterBlockBase
    {
        public  ShaderTemplateParameterBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 52)]
    public class ShaderTemplateParameterBlockBase
    {
        internal Moonfish.Tags.StringID name;
        internal byte[] explanation;
        internal Type type;
        internal Flags flags;
        [TagReference("bitm")]
        internal Moonfish.Tags.TagReference defaultBitmap;
        internal float defaultConstValue;
        internal Moonfish.Tags.ColorR8G8B8 defaultConstColor;
        internal BitmapType bitmapType;
        internal byte[] invalidName_;
        internal BitmapAnimationFlags bitmapAnimationFlags;
        internal byte[] invalidName_0;
        internal float bitmapScale;
        internal  ShaderTemplateParameterBlockBase(BinaryReader binaryReader)
        {
            this.name = binaryReader.ReadStringID();
            this.explanation = ReadData(binaryReader);
            this.type = (Type)binaryReader.ReadInt16();
            this.flags = (Flags)binaryReader.ReadInt16();
            this.defaultBitmap = binaryReader.ReadTagReference();
            this.defaultConstValue = binaryReader.ReadSingle();
            this.defaultConstColor = binaryReader.ReadColorR8G8B8();
            this.bitmapType = (BitmapType)binaryReader.ReadInt16();
            this.invalidName_ = binaryReader.ReadBytes(2);
            this.bitmapAnimationFlags = (BitmapAnimationFlags)binaryReader.ReadInt16();
            this.invalidName_0 = binaryReader.ReadBytes(2);
            this.bitmapScale = binaryReader.ReadSingle();
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
            Bitmap = 0,
            Value = 1,
            Color = 2,
            Switch = 3,
        };
        [FlagsAttribute]
        internal enum Flags : short
        
        {
            Animated = 1,
            HideBitmapReference = 2,
        };
        internal enum BitmapType : short
        
        {
            InvalidName2D = 0,
            InvalidName3D = 1,
            CubeMap = 2,
        };
        [FlagsAttribute]
        internal enum BitmapAnimationFlags : short
        
        {
            ScaleUniform = 1,
            Scale = 2,
            Translation = 4,
            Rotation = 8,
            Index = 16,
        };
    };
}
