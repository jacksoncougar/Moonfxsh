// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Moonfish.Tags
{
    public partial struct TagClass
    {
        public static readonly TagClass Mcsr = (TagClass) "mcsr";
    };
} ;

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("mcsr")]
    public partial class MouseCursorDefinitionBlock : MouseCursorDefinitionBlockBase
    {
        public MouseCursorDefinitionBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 12, Alignment = 4)]
    public class MouseCursorDefinitionBlockBase : GuerillaBlock
    {
        internal MouseCursorBitmapReferenceBlock[] mouseCursorBitmaps;
        internal float animationSpeedFps;

        public override int SerializedSize
        {
            get { return 12; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public MouseCursorDefinitionBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<MouseCursorBitmapReferenceBlock>(binaryReader));
            animationSpeedFps = binaryReader.ReadSingle();
            return blamPointers;
        }

        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            mouseCursorBitmaps = ReadBlockArrayData<MouseCursorBitmapReferenceBlock>(binaryReader,
                blamPointers.Dequeue());
        }

        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
            using (binaryWriter.BaseStream.Pin())
            {
                nextAddress = Guerilla.WriteBlockArray<MouseCursorBitmapReferenceBlock>(binaryWriter, mouseCursorBitmaps,
                    nextAddress);
                binaryWriter.Write(animationSpeedFps);
                return nextAddress;
            }
        }
    };
}