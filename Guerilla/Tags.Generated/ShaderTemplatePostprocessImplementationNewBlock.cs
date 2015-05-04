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
    public partial class ShaderTemplatePostprocessImplementationNewBlock :
        ShaderTemplatePostprocessImplementationNewBlockBase
    {
        public ShaderTemplatePostprocessImplementationNewBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 6, Alignment = 4)]
    public class ShaderTemplatePostprocessImplementationNewBlockBase : GuerillaBlock
    {
        internal TagBlockIndexStructBlock bitmaps;
        internal TagBlockIndexStructBlock pixelConstants;
        internal TagBlockIndexStructBlock vertexConstants;

        public override int SerializedSize
        {
            get { return 6; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public ShaderTemplatePostprocessImplementationNewBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            bitmaps = new TagBlockIndexStructBlock();
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(bitmaps.ReadFields(binaryReader)));
            pixelConstants = new TagBlockIndexStructBlock();
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(pixelConstants.ReadFields(binaryReader)));
            vertexConstants = new TagBlockIndexStructBlock();
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(vertexConstants.ReadFields(binaryReader)));
            return blamPointers;
        }

        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            bitmaps.ReadPointers(binaryReader, blamPointers);
            pixelConstants.ReadPointers(binaryReader, blamPointers);
            vertexConstants.ReadPointers(binaryReader, blamPointers);
        }

        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
            using (binaryWriter.BaseStream.Pin())
            {
                bitmaps.Write(binaryWriter);
                pixelConstants.Write(binaryWriter);
                vertexConstants.Write(binaryWriter);
                return nextAddress;
            }
        }
    };
}