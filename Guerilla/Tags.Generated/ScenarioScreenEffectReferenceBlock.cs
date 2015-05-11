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
    public partial class ScenarioScreenEffectReferenceBlock : ScenarioScreenEffectReferenceBlockBase
    {
        public ScenarioScreenEffectReferenceBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 36, Alignment = 4)]
    public class ScenarioScreenEffectReferenceBlockBase : GuerillaBlock
    {
        internal byte[] invalidName_;
        [TagReference("egor")] internal Moonfish.Tags.TagReference screenEffect;
        internal Moonfish.Tags.StringIdent primaryInputInterpolator;
        internal Moonfish.Tags.StringIdent secondaryInputInterpolator;
        internal byte[] invalidName_0;
        internal byte[] invalidName_1;

        public override int SerializedSize
        {
            get { return 36; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public ScenarioScreenEffectReferenceBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            invalidName_ = binaryReader.ReadBytes(16);
            screenEffect = binaryReader.ReadTagReference();
            primaryInputInterpolator = binaryReader.ReadStringID();
            secondaryInputInterpolator = binaryReader.ReadStringID();
            invalidName_0 = binaryReader.ReadBytes(2);
            invalidName_1 = binaryReader.ReadBytes(2);
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
                binaryWriter.Write(invalidName_, 0, 16);
                binaryWriter.Write(screenEffect);
                binaryWriter.Write(primaryInputInterpolator);
                binaryWriter.Write(secondaryInputInterpolator);
                binaryWriter.Write(invalidName_0, 0, 2);
                binaryWriter.Write(invalidName_1, 0, 2);
                return nextAddress;
            }
        }
    };
}