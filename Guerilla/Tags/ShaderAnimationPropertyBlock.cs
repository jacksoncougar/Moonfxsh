using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class ShaderAnimationPropertyBlock : ShaderAnimationPropertyBlockBase
    {
        public  ShaderAnimationPropertyBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 24)]
    public class ShaderAnimationPropertyBlockBase
    {
        internal Type type;
        internal byte[] invalidName_;
        internal Moonfish.Tags.StringID inputName;
        internal Moonfish.Tags.StringID rangeName;
        internal float timePeriodSec;
        internal MappingFunctionBlock function;
        internal  ShaderAnimationPropertyBlockBase(BinaryReader binaryReader)
        {
            this.type = (Type)binaryReader.ReadInt16();
            this.invalidName_ = binaryReader.ReadBytes(2);
            this.inputName = binaryReader.ReadStringID();
            this.rangeName = binaryReader.ReadStringID();
            this.timePeriodSec = binaryReader.ReadSingle();
            this.function = new MappingFunctionBlock(binaryReader);
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
            BitmapScaleUniform = 0,
            BitmapScaleX = 1,
            BitmapScaleY = 2,
            BitmapScaleZ = 3,
            BitmapTranslationX = 4,
            BitmapTranslationY = 5,
            BitmapTranslationZ = 6,
            BitmapRotationAngle = 7,
            BitmapRotationAxisX = 8,
            BitmapRotationAxisY = 9,
            BitmapRotationAxisZ = 10,
            Value = 11,
            Color = 12,
            BitmapIndex = 13,
        };
    };
}
