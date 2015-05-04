// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Moonfish.Guerilla.Tags
{
    public partial class ShaderAnimationPropertyBlock : ShaderAnimationPropertyBlockBase
    {
        public ShaderAnimationPropertyBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 24, Alignment = 4)]
    public class ShaderAnimationPropertyBlockBase : GuerillaBlock
    {
        internal Type type;
        internal byte[] invalidName_;
        internal Moonfish.Tags.StringIdent inputName;
        internal Moonfish.Tags.StringIdent rangeName;
        internal float timePeriodSec;
        internal MappingFunctionBlock function;

        public override int SerializedSize
        {
            get { return 24; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public ShaderAnimationPropertyBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            type = (Type) binaryReader.ReadInt16();
            invalidName_ = binaryReader.ReadBytes(2);
            inputName = binaryReader.ReadStringID();
            rangeName = binaryReader.ReadStringID();
            timePeriodSec = binaryReader.ReadSingle();
            function = new MappingFunctionBlock();
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(function.ReadFields(binaryReader)));
            return blamPointers;
        }

        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            function.ReadPointers(binaryReader, blamPointers);
        }

        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
            using (binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write((Int16) type);
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