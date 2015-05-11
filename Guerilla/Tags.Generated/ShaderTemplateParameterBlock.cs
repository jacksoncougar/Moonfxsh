// ReSharper disable All

using Moonfish.Model;

using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Moonfish.Guerilla.Tags
{
    public partial class ShaderTemplateParameterBlock : ShaderTemplateParameterBlockBase
    {
        public ShaderTemplateParameterBlock() : base()
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
        [TagReference("bitm")] internal Moonfish.Tags.TagReference defaultBitmap;
        internal float defaultConstValue;
        internal Moonfish.Tags.ColourR8G8B8 defaultConstColor;
        internal BitmapType bitmapType;
        internal byte[] invalidName_;
        internal BitmapAnimationFlags bitmapAnimationFlags;
        internal byte[] invalidName_0;
        internal float bitmapScale;

        public override int SerializedSize
        {
            get { return 52; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public ShaderTemplateParameterBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            name = binaryReader.ReadStringID();
            blamPointers.Enqueue(ReadBlockArrayPointer(binaryReader, 1));
            type = (Type) binaryReader.ReadInt16();
            flags = (Flags) binaryReader.ReadInt16();
            defaultBitmap = binaryReader.ReadTagReference();
            defaultConstValue = binaryReader.ReadSingle();
            defaultConstColor = binaryReader.ReadColorR8G8B8();
            bitmapType = (BitmapType) binaryReader.ReadInt16();
            invalidName_ = binaryReader.ReadBytes(2);
            bitmapAnimationFlags = (BitmapAnimationFlags) binaryReader.ReadInt16();
            invalidName_0 = binaryReader.ReadBytes(2);
            bitmapScale = binaryReader.ReadSingle();
            return blamPointers;
        }

        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            explanation = ReadDataByteArray(binaryReader, blamPointers.Dequeue());
        }

        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
            using (binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(name);
                nextAddress = Guerilla.WriteData(binaryWriter, explanation, nextAddress);
                binaryWriter.Write((Int16) type);
                binaryWriter.Write((Int16) flags);
                binaryWriter.Write(defaultBitmap);
                binaryWriter.Write(defaultConstValue);
                binaryWriter.Write(defaultConstColor);
                binaryWriter.Write((Int16) bitmapType);
                binaryWriter.Write(invalidName_, 0, 2);
                binaryWriter.Write((Int16) bitmapAnimationFlags);
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