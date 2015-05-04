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
    public partial class ShaderStateCullStateBlock : ShaderStateCullStateBlockBase
    {
        public ShaderStateCullStateBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 4, Alignment = 4)]
    public class ShaderStateCullStateBlockBase : GuerillaBlock
    {
        internal Mode mode;
        internal FrontFace frontFace;

        public override int SerializedSize
        {
            get { return 4; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public ShaderStateCullStateBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            mode = (Mode) binaryReader.ReadInt16();
            frontFace = (FrontFace) binaryReader.ReadInt16();
            return blamPointers;
        }

        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
        }

        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
            using (binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write((Int16) mode);
                binaryWriter.Write((Int16) frontFace);
                return nextAddress;
            }
        }

        internal enum Mode : short
        {
            None = 0,
            CW = 1,
            CCW = 2,
        };

        internal enum FrontFace : short
        {
            CW = 0,
            CCW = 1,
        };
    };
}