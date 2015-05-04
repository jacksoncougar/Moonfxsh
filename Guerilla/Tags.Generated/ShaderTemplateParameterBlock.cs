// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class ShaderTemplateParameterBlock : ShaderTemplateParameterBlockBase
    {
        public  ShaderTemplateParameterBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  ShaderTemplateParameterBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 52, Alignment = 4)]
    public class ShaderTemplateParameterBlockBase : GuerillaBlock
    {
        internal Moonfish.Tags.StringIdent name;
        internal byte[] explanation;
        internal Type type;
        internal Flags flags;
        [TagReference("bitm")]
        internal Moonfish.Tags.TagReference defaultBitmap;
        internal float defaultConstValue;
        internal Moonfish.Tags.ColourR8G8B8 DefaultConstColour;
        internal BitmapType bitmapType;
        internal byte[] invalidName_;
        internal BitmapAnimationFlags bitmapAnimationFlags;
        internal byte[] invalidName_0;
        internal float bitmapScale;
        
        public override int SerializedSize{get { return 52; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  ShaderTemplateParameterBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            name = binaryReader.ReadStringID();
            explanation = Guerilla.ReadData(binaryReader);
            type = (Type)binaryReader.ReadInt16();
            flags = (Flags)binaryReader.ReadInt16();
            defaultBitmap = binaryReader.ReadTagReference();
            defaultConstValue = binaryReader.ReadSingle();
            DefaultConstColour = binaryReader.ReadColorR8G8B8();
            bitmapType = (BitmapType)binaryReader.ReadInt16();
            invalidName_ = binaryReader.ReadBytes(2);
            bitmapAnimationFlags = (BitmapAnimationFlags)binaryReader.ReadInt16();
            invalidName_0 = binaryReader.ReadBytes(2);
            bitmapScale = binaryReader.ReadSingle();
        }
        public  ShaderTemplateParameterBlockBase(): base()
        {
            
        }
        public override void Read(BinaryReader binaryReader)
        {
            name = binaryReader.ReadStringID();
            explanation = Guerilla.ReadData(binaryReader);
            type = (Type)binaryReader.ReadInt16();
            flags = (Flags)binaryReader.ReadInt16();
            defaultBitmap = binaryReader.ReadTagReference();
            defaultConstValue = binaryReader.ReadSingle();
            DefaultConstColour = binaryReader.ReadColorR8G8B8();
            bitmapType = (BitmapType)binaryReader.ReadInt16();
            invalidName_ = binaryReader.ReadBytes(2);
            bitmapAnimationFlags = (BitmapAnimationFlags)binaryReader.ReadInt16();
            invalidName_0 = binaryReader.ReadBytes(2);
            bitmapScale = binaryReader.ReadSingle();
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(name);
                nextAddress = Guerilla.WriteData(binaryWriter, explanation, nextAddress);
                binaryWriter.Write((Int16)type);
                binaryWriter.Write((Int16)flags);
                binaryWriter.Write(defaultBitmap);
                binaryWriter.Write(defaultConstValue);
                binaryWriter.Write(DefaultConstColour);
                binaryWriter.Write((Int16)bitmapType);
                binaryWriter.Write(invalidName_, 0, 2);
                binaryWriter.Write((Int16)bitmapAnimationFlags);
                binaryWriter.Write(invalidName_0, 0, 2);
                binaryWriter.Write(bitmapScale);
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
