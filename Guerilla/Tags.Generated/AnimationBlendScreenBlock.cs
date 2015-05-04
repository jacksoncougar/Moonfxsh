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
    public partial class AnimationBlendScreenBlock : AnimationBlendScreenBlockBase
    {
        public AnimationBlendScreenBlock() : base()
        {
        }
    };
    [LayoutAttribute(Size = 28, Alignment = 4)]
    public class AnimationBlendScreenBlockBase : GuerillaBlock
    {
        internal Moonfish.Tags.StringIdent label;
        internal AnimationAimingScreenStructBlock aimingScreen;
        public override int SerializedSize { get { return 28; } }
        public override int Alignment { get { return 4; } }
        public AnimationBlendScreenBlockBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            label = binaryReader.ReadStringID();
            aimingScreen = new AnimationAimingScreenStructBlock();
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(aimingScreen.ReadFields(binaryReader)));
            return blamPointers;
        }
        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            aimingScreen.ReadPointers(binaryReader, blamPointers);
        }
        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(label);
                aimingScreen.Write(binaryWriter);
                return nextAddress;
            }
        }
    };
}
