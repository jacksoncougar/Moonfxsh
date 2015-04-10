// ReSharper disable All
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
        public  AiSceneRoleBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
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
        internal  AiSceneRoleBlockBase(System.IO.BinaryReader binaryReader)
        {
            name = binaryReader.ReadStringID();
            group = (Group)binaryReader.ReadInt16();
            invalidName_ = binaryReader.ReadBytes(2);
            ReadAiSceneRoleVariantsBlockArray(binaryReader);
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
        internal  virtual AiSceneRoleVariantsBlock[] ReadAiSceneRoleVariantsBlockArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteAiSceneRoleVariantsBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(name);
                binaryWriter.Write((Int16)group);
                binaryWriter.Write(invalidName_, 0, 2);
                WriteAiSceneRoleVariantsBlockArray(binaryWriter);
            }
        }
        internal enum Group : short
        
        {
            Group1 = 0,
            Group2 = 1,
            Group3 = 2,
        };
    };
}
