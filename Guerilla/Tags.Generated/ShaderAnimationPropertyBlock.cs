// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class ShaderAnimationPropertyBlock : ShaderAnimationPropertyBlockBase
    {
        public  ShaderAnimationPropertyBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  ShaderAnimationPropertyBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 24, Alignment = 4)]
    public class ShaderAnimationPropertyBlockBase : GuerillaBlock
    {
        internal Type type;
        internal byte[] invalidName_;
        internal Moonfish.Tags.StringID inputName;
        internal Moonfish.Tags.StringID rangeName;
        internal float timePeriodSec;
        internal MappingFunctionBlock function;
        
        public override int SerializedSize{get { return 24; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  ShaderAnimationPropertyBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            type = (Type)binaryReader.ReadInt16();
            invalidName_ = binaryReader.ReadBytes(2);
            inputName = binaryReader.ReadStringID();
            rangeName = binaryReader.ReadStringID();
            timePeriodSec = binaryReader.ReadSingle();
            function = new MappingFunctionBlock(binaryReader);
        }
        public  ShaderAnimationPropertyBlockBase(): base()
        {
            
        }
        public void Read(BinaryReader binaryReader)
        {
            type = (Type)binaryReader.ReadInt16();
            invalidName_ = binaryReader.ReadBytes(2);
            inputName = binaryReader.ReadStringID();
            rangeName = binaryReader.ReadStringID();
            timePeriodSec = binaryReader.ReadSingle();
            function = new MappingFunctionBlock(binaryReader);
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write((Int16)type);
                binaryWriter.Write(invalidName_, 0, 2);
                binaryWriter.Write(inputName);
                binaryWriter.Write(rangeName);
                binaryWriter.Write(timePeriodSec);
                function.Write(binaryWriter);
                return nextAddress;
            }
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
