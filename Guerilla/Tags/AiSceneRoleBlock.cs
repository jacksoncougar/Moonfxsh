using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class AiSceneRoleBlock : AiSceneRoleBlockBase
    {
        public  AiSceneRoleBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 16)]
    public class AiSceneRoleBlockBase
    {
        internal Moonfish.Tags.StringID name;
        internal Group group;
        internal byte[] invalidName_;
        internal AiSceneRoleVariantsBlock[] roleVariants;
        internal  AiSceneRoleBlockBase(BinaryReader binaryReader)
        {
            this.name = binaryReader.ReadStringID();
            this.group = (Group)binaryReader.ReadInt16();
            this.invalidName_ = binaryReader.ReadBytes(2);
            this.roleVariants = ReadAiSceneRoleVariantsBlockArray(binaryReader);
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
        internal  virtual AiSceneRoleVariantsBlock[] ReadAiSceneRoleVariantsBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(AiSceneRoleVariantsBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new AiSceneRoleVariantsBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new AiSceneRoleVariantsBlock(binaryReader);
                }
            }
            return array;
        }
        internal enum Group : short
        
        {
            Group1 = 0,
            Group2 = 1,
            Group3 = 2,
        };
    };
}
