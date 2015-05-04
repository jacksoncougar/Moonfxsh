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
    public partial class ShaderGpuStateReferenceStructBlock : ShaderGpuStateReferenceStructBlockBase
    {
        public ShaderGpuStateReferenceStructBlock() : base()
        {
        }
    };
    [LayoutAttribute(Size = 14, Alignment = 4)]
    public class ShaderGpuStateReferenceStructBlockBase : GuerillaBlock
    {
        internal TagBlockIndexStructBlock renderStates;
        internal TagBlockIndexStructBlock textureStageStates;
        internal TagBlockIndexStructBlock renderStateParameters;
        internal TagBlockIndexStructBlock textureStageParameters;
        internal TagBlockIndexStructBlock textures;
        internal TagBlockIndexStructBlock vnConstants;
        internal TagBlockIndexStructBlock cnConstants;
        public override int SerializedSize { get { return 14; } }
        public override int Alignment { get { return 4; } }
        public ShaderGpuStateReferenceStructBlockBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            renderStates = new TagBlockIndexStructBlock();
            blamPointers.Concat(renderStates.ReadFields(binaryReader));
            textureStageStates = new TagBlockIndexStructBlock();
            blamPointers.Concat(textureStageStates.ReadFields(binaryReader));
            renderStateParameters = new TagBlockIndexStructBlock();
            blamPointers.Concat(renderStateParameters.ReadFields(binaryReader));
            textureStageParameters = new TagBlockIndexStructBlock();
            blamPointers.Concat(textureStageParameters.ReadFields(binaryReader));
            textures = new TagBlockIndexStructBlock();
            blamPointers.Concat(textures.ReadFields(binaryReader));
            vnConstants = new TagBlockIndexStructBlock();
            blamPointers.Concat(vnConstants.ReadFields(binaryReader));
            cnConstants = new TagBlockIndexStructBlock();
            blamPointers.Concat(cnConstants.ReadFields(binaryReader));
            return blamPointers;
        }
        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            renderStates.ReadPointers(binaryReader, blamPointers);
            textureStageStates.ReadPointers(binaryReader, blamPointers);
            renderStateParameters.ReadPointers(binaryReader, blamPointers);
            textureStageParameters.ReadPointers(binaryReader, blamPointers);
            textures.ReadPointers(binaryReader, blamPointers);
            vnConstants.ReadPointers(binaryReader, blamPointers);
            cnConstants.ReadPointers(binaryReader, blamPointers);
        }
        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
using(binaryWriter.BaseStream.Pin())
            {
                renderStates.Write(binaryWriter);
                textureStageStates.Write(binaryWriter);
                renderStateParameters.Write(binaryWriter);
                textureStageParameters.Write(binaryWriter);
                textures.Write(binaryWriter);
                vnConstants.Write(binaryWriter);
                cnConstants.Write(binaryWriter);
                return nextAddress;
            }
        }
    };
}
