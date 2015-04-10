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
        public  EditorCommentBlock(BinaryReader binaryReader): base(binaryReader)
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
        internal  EditorCommentBlockBase(BinaryReader binaryReader)
        {
            this.position = binaryReader.ReadVector3();
            this.type = (Type)binaryReader.ReadInt32();
            this.name = binaryReader.ReadString32();
            this.comment = binaryReader.ReadString256();
        }
        internal  virtual byte[] ReadData(BinaryReader binaryReader)
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
        internal enum Type : int
        
        {
            Generic = 0,
        };
    };
}
