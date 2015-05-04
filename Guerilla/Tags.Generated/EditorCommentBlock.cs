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
    public partial class EditorCommentBlock : EditorCommentBlockBase
    {
        public EditorCommentBlock() : base()
        {
        }
    };
    [LayoutAttribute(Size = 304, Alignment = 4)]
    public class EditorCommentBlockBase : GuerillaBlock
    {
        internal OpenTK.Vector3 position;
        internal Type type;
        internal Moonfish.Tags.String32 name;
        internal Moonfish.Tags.String256 comment;
        public override int SerializedSize { get { return 304; } }
        public override int Alignment { get { return 4; } }
        public EditorCommentBlockBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            position = binaryReader.ReadVector3();
            type = (Type)binaryReader.ReadInt32();
            name = binaryReader.ReadString32();
            comment = binaryReader.ReadString256();
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
                binaryWriter.Write(position);
                binaryWriter.Write((Int32)type);
                binaryWriter.Write(name);
                binaryWriter.Write(comment);
                return nextAddress;
            }
        }
        internal enum Type : int
        {
            Generic = 0,
        };
    };
}
