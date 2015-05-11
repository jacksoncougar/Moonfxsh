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
    public partial class ObjectAnimationBlock : ObjectAnimationBlockBase
    {
        public ObjectAnimationBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 20, Alignment = 4)]
    public class ObjectAnimationBlockBase : GuerillaBlock
    {
        internal Moonfish.Tags.StringIdent label;
        internal AnimationIndexStructBlock animation;
        internal byte[] invalidName_;
        internal FunctionControls functionControls;
        internal Moonfish.Tags.StringIdent function;
        internal byte[] invalidName_0;

        public override int SerializedSize
        {
            get { return 20; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public ObjectAnimationBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            label = binaryReader.ReadStringID();
            animation = new AnimationIndexStructBlock();
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(animation.ReadFields(binaryReader)));
            invalidName_ = binaryReader.ReadBytes(2);
            functionControls = (FunctionControls) binaryReader.ReadInt16();
            function = binaryReader.ReadStringID();
            invalidName_0 = binaryReader.ReadBytes(4);
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
            using (binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(label);
                animation.Write(binaryWriter);
                binaryWriter.Write(invalidName_, 0, 2);
                binaryWriter.Write((Int16) functionControls);
                binaryWriter.Write(function);
                binaryWriter.Write(invalidName_0, 0, 4);
                return nextAddress;
            }
        }

        internal enum FunctionControls : short
        {
            Frame = 0,
            Scale = 1,
        };
    };
}