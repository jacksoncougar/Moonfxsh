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
    public partial class SoundPlaybackParameterDefinitionBlock : SoundPlaybackParameterDefinitionBlockBase
    {
        public SoundPlaybackParameterDefinitionBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 16, Alignment = 4)]
    public class SoundPlaybackParameterDefinitionBlockBase : GuerillaBlock
    {
        internal Moonfish.Model.Range scaleBounds;
        internal Moonfish.Model.Range randomBaseAndVariance;

        public override int SerializedSize
        {
            get { return 16; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public SoundPlaybackParameterDefinitionBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            scaleBounds = binaryReader.ReadRange();
            randomBaseAndVariance = binaryReader.ReadRange();
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
                binaryWriter.Write(scaleBounds);
                binaryWriter.Write(randomBaseAndVariance);
                return nextAddress;
            }
        }
    };
}