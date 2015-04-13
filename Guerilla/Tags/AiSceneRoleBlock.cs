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
        public  AiSceneRoleBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 16, Alignment = 4)]
    public class AiSceneRoleBlockBase  : IGuerilla
    {
        internal Moonfish.Tags.StringID name;
        internal Group group;
        internal byte[] invalidName_;
        internal AiSceneRoleVariantsBlock[] roleVariants;
        internal  AiSceneRoleBlockBase(BinaryReader binaryReader)
        {
            name = binaryReader.ReadStringID();
            group = (Group)binaryReader.ReadInt16();
            invalidName_ = binaryReader.ReadBytes(2);
            roleVariants = Guerilla.ReadBlockArray<AiSceneRoleVariantsBlock>(binaryReader);
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(name);
                binaryWriter.Write((Int16)group);
                binaryWriter.Write(invalidName_, 0, 2);
                Guerilla.WriteBlockArray<AiSceneRoleVariantsBlock>(binaryWriter, roleVariants, nextAddress);
                return nextAddress = (int)binaryWriter.BaseStream.Position;
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
