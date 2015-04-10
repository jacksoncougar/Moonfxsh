// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class EditorCommentBlock : EditorCommentBlockBase
    {
        public  EditorCommentBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 304)]
    public class EditorCommentBlockBase
    {
        internal OpenTK.Vector3 position;
        internal Type type;
        internal Moonfish.Tags.String32 name;
        internal Moonfish.Tags.String256 comment;
        internal  EditorCommentBlockBase(System.IO.BinaryReader binaryReader)
        {
            position = binaryReader.ReadVector3();
            type = (Type)binaryReader.ReadInt32();
            name = binaryReader.ReadString32();
            comment = binaryReader.ReadString256();
        }
        internal  virtual byte[] ReadData(System.IO.BinaryReader binaryReader)
        {
            var blamPointer = binaryReader.ReadBlamPointer(1);
            var data = new byte[blamPointer.Count];
            if(blamPointer.Count > 0)
            {
                using (binaryReader.BaseStream.Pin())
                {
                    binaryReader.BaseStream.Position = blamPointer[0];
                    data = binaryReader.ReadBytes(blamPointer.Count);
                }
            }
            return data;
        }
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(position);
                binaryWriter.Write((Int32)type);
                binaryWriter.Write(name);
                binaryWriter.Write(comment);
            }
        }
        internal enum Type : int
        
        {
            Generic = 0,
        };
    };
}
