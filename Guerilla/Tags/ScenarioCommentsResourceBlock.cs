using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("/**/")]
    public  partial class ScenarioCommentsResourceBlock : ScenarioCommentsResourceBlockBase
    {
        public  ScenarioCommentsResourceBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 8)]
    public class ScenarioCommentsResourceBlockBase
    {
        internal EditorCommentBlock[] comments;
        internal  ScenarioCommentsResourceBlockBase(BinaryReader binaryReader)
        {
            this.comments = ReadEditorCommentBlockArray(binaryReader);
        }
        internal  virtual byte[] ReadData(BinaryReader binaryReader)
        {
            var blamPointer = binaryReader.ReadBlamPointer(1);
            var data = new byte[blamPointer.count];
            if(blamPointer.count > 0)
            {
                using (binaryReader.BaseStream.Pin())
                {
                    binaryReader.BaseStream.Position = blamPointer[0];
                    data = binaryReader.ReadBytes(blamPointer.count);
                }
            }
            return data;
        }
        internal  virtual EditorCommentBlock[] ReadEditorCommentBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(EditorCommentBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new EditorCommentBlock[blamPointer.count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new EditorCommentBlock(binaryReader);
                }
            }
            return array;
        }
    };
}
