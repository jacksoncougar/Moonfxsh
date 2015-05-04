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
    public partial class DamageRegionBlock : DamageRegionBlockBase
    {
        public DamageRegionBlock() : base()
        {
        }
    };
    [LayoutAttribute(Size = 4, Alignment = 4)]
    public class DamageRegionBlockBase : GuerillaBlock
    {
        internal AnimationIndexStructBlock animation;
        public override int SerializedSize { get { return 4; } }
        public override int Alignment { get { return 4; } }
        public DamageRegionBlockBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            animation = new AnimationIndexStructBlock();
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(animation.ReadFields(binaryReader)));
            return blamPointers;
        }
        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            animation.ReadPointers(binaryReader, blamPointers);
        }
        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
using(binaryWriter.BaseStream.Pin())
            {
                animation.Write(binaryWriter);
                return nextAddress;
            }
        }
    };
}
