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
    public partial class ShaderPostprocessImplementationNewBlock : ShaderPostprocessImplementationNewBlockBase
    {
        public ShaderPostprocessImplementationNewBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 10, Alignment = 4)]
    public class ShaderPostprocessImplementationNewBlockBase : GuerillaBlock
    {
        internal TagBlockIndexStructBlock bitmapTransforms;
        internal TagBlockIndexStructBlock renderStates;
        internal TagBlockIndexStructBlock textureStates;
        internal TagBlockIndexStructBlock pixelConstants;
        internal TagBlockIndexStructBlock vertexConstants;

        public override int SerializedSize
        {
            get { return 10; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public ShaderPostprocessImplementationNewBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            bitmapTransforms = new TagBlockIndexStructBlock();
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(bitmapTransforms.ReadFields(binaryReader)));
            renderStates = new TagBlockIndexStructBlock();
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(renderStates.ReadFields(binaryReader)));
            textureStates = new TagBlockIndexStructBlock();
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(textureStates.ReadFields(binaryReader)));
            pixelConstants = new TagBlockIndexStructBlock();
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(pixelConstants.ReadFields(binaryReader)));
            vertexConstants = new TagBlockIndexStructBlock();
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(vertexConstants.ReadFields(binaryReader)));
            return blamPointers;
        }

        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            bitmapTransforms.ReadPointers(binaryReader, blamPointers);
            renderStates.ReadPointers(binaryReader, blamPointers);
            textureStates.ReadPointers(binaryReader, blamPointers);
            pixelConstants.ReadPointers(binaryReader, blamPointers);
            vertexConstants.ReadPointers(binaryReader, blamPointers);
        }

        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
            using (binaryWriter.BaseStream.Pin())
            {
                bitmapTransforms.Write(binaryWriter);
                renderStates.Write(binaryWriter);
                textureStates.Write(binaryWriter);
                pixelConstants.Write(binaryWriter);
                vertexConstants.Write(binaryWriter);
                return nextAddress;
            }
        }
    };
}