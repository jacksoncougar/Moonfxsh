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
    public partial class ShaderPostprocessBitmapTransformOverlayBlock : ShaderPostprocessBitmapTransformOverlayBlockBase
    {
        public ShaderPostprocessBitmapTransformOverlayBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 23, Alignment = 4)]
    public class ShaderPostprocessBitmapTransformOverlayBlockBase : GuerillaBlock
    {
        internal byte parameterIndex;
        internal byte transformIndex;
        internal byte animationPropertyType;
        internal Moonfish.Tags.StringIdent inputName;
        internal Moonfish.Tags.StringIdent rangeName;
        internal float timePeriodInSeconds;
        internal ScalarFunctionStructBlock function;

        public override int SerializedSize
        {
            get { return 23; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public ShaderPostprocessBitmapTransformOverlayBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            parameterIndex = binaryReader.ReadByte();
            transformIndex = binaryReader.ReadByte();
            animationPropertyType = binaryReader.ReadByte();
            inputName = binaryReader.ReadStringID();
            rangeName = binaryReader.ReadStringID();
            timePeriodInSeconds = binaryReader.ReadSingle();
            function = new ScalarFunctionStructBlock();
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
                binaryWriter.Write(parameterIndex);
                binaryWriter.Write(transformIndex);
                binaryWriter.Write(animationPropertyType);
                binaryWriter.Write(inputName);
                binaryWriter.Write(rangeName);
                binaryWriter.Write(timePeriodInSeconds);
                function.Write(binaryWriter);
                return nextAddress;
            }
        }
    };
}