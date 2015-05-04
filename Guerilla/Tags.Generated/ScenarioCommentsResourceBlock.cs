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
        public static readonly TagClass Cmnt = (TagClass) "/**/";
    };
} ;

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("/**/")]
    public partial class ScenarioCommentsResourceBlock : ScenarioCommentsResourceBlockBase
    {
        public ScenarioCommentsResourceBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 8, Alignment = 4)]
    public class ScenarioCommentsResourceBlockBase : GuerillaBlock
    {
        internal EditorCommentBlock[] comments;

        public override int SerializedSize
        {
            get { return 8; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public ScenarioCommentsResourceBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<EditorCommentBlock>(binaryReader));
            return blamPointers;
        }

        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            comments = ReadBlockArrayData<EditorCommentBlock>(binaryReader, blamPointers.Dequeue());
        }

        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
            using (binaryWriter.BaseStream.Pin())
            {
                nextAddress = Guerilla.WriteBlockArray<EditorCommentBlock>(binaryWriter, comments, nextAddress);
                return nextAddress;
            }
        }
    };
}