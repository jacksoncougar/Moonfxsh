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
    public partial class ShaderPostprocessAnimatedParameterNewBlock : ShaderPostprocessAnimatedParameterNewBlockBase
    {
        public ShaderPostprocessAnimatedParameterNewBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 2, Alignment = 4)]
    public class ShaderPostprocessAnimatedParameterNewBlockBase : GuerillaBlock
    {
        internal TagBlockIndexStructBlock overlayReferences;

        public override int SerializedSize
        {
            get { return 2; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public ShaderPostprocessAnimatedParameterNewBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            overlayReferences = new TagBlockIndexStructBlock();
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(overlayReferences.ReadFields(binaryReader)));
            return blamPointers;
        }

        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            overlayReferences.ReadPointers(binaryReader, blamPointers);
        }

        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
            using (binaryWriter.BaseStream.Pin())
            {
                overlayReferences.Write(binaryWriter);
                return nextAddress;
            }
        }
    };
}