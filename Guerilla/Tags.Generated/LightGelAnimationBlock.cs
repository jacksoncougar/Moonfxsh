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
    public partial class LightGelAnimationBlock : LightGelAnimationBlockBase
    {
        public LightGelAnimationBlock() : base()
        {
        }
    };
    [LayoutAttribute(Size = 16, Alignment = 4)]
    public class LightGelAnimationBlockBase : GuerillaBlock
    {
        internal MappingFunctionBlock dx;
        internal MappingFunctionBlock dy;
        public override int SerializedSize { get { return 16; } }
        public override int Alignment { get { return 4; } }
        public LightGelAnimationBlockBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            dx = new MappingFunctionBlock();
            blamPointers.Concat(dx.ReadFields(binaryReader));
            dy = new MappingFunctionBlock();
            blamPointers.Concat(dy.ReadFields(binaryReader));
            return blamPointers;
        }
        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            dx.ReadPointers(binaryReader, blamPointers);
            dy.ReadPointers(binaryReader, blamPointers);
        }
        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
using(binaryWriter.BaseStream.Pin())
            {
                dx.Write(binaryWriter);
                dy.Write(binaryWriter);
                return nextAddress;
            }
        }
    };
}
