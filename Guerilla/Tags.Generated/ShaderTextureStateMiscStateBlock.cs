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
    public partial class ShaderTextureStateMiscStateBlock : ShaderTextureStateMiscStateBlockBase
    {
        public ShaderTextureStateMiscStateBlock() : base()
        {
        }
    };
    [LayoutAttribute(Size = 8, Alignment = 4)]
    public class ShaderTextureStateMiscStateBlockBase : GuerillaBlock
    {
        internal ComponentSignFlags componentSignFlags;
        internal byte[] invalidName_;
        internal Moonfish.Tags.ColourA1R1G1B1 borderColor;
        public override int SerializedSize { get { return 8; } }
        public override int Alignment { get { return 4; } }
        public ShaderTextureStateMiscStateBlockBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            componentSignFlags = (ComponentSignFlags)binaryReader.ReadInt16();
            invalidName_ = binaryReader.ReadBytes(2);
            borderColor = binaryReader.ReadColourA1R1G1B1();
            return blamPointers;
        }
        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
        }
        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write((Int16)componentSignFlags);
                binaryWriter.Write(invalidName_, 0, 2);
                binaryWriter.Write(borderColor);
                return nextAddress;
            }
        }
        [FlagsAttribute]
        internal enum ComponentSignFlags : short
        {
            RSigned = 1,
            GSigned = 2,
            BSigned = 4,
            ASigned = 8,
        };
    };
}
