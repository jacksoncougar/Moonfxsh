// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class AiSceneRoleBlock : AiSceneRoleBlockBase
    {
        public  AiSceneRoleBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  AiSceneRoleBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 16, Alignment = 4)]
    public class AiSceneRoleBlockBase : GuerillaBlock
    {
        internal Moonfish.Tags.StringIdent name;
        internal Group group;
        internal byte[] invalidName_;
        internal AiSceneRoleVariantsBlock[] roleVariants;
        
        public override int SerializedSize{get { return 16; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  AiSceneRoleBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            name = binaryReader.ReadStringID();
            group = (Group)binaryReader.ReadInt16();
            invalidName_ = binaryReader.ReadBytes(2);
            roleVariants = Guerilla.ReadBlockArray<AiSceneRoleVariantsBlock>(binaryReader);
        }
        public  AiSceneRoleBlockBase(): base()
        {
            
        }
        public override void Read(BinaryReader binaryReader)
        {
            name = binaryReader.ReadStringID();
            group = (Group)binaryReader.ReadInt16();
            invalidName_ = binaryReader.ReadBytes(2);
            roleVariants = Guerilla.ReadBlockArray<AiSceneRoleVariantsBlock>(binaryReader);
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(name);
                binaryWriter.Write((Int16)group);
                binaryWriter.Write(invalidName_, 0, 2);
                nextAddress = Guerilla.WriteBlockArray<AiSceneRoleVariantsBlock>(binaryWriter, roleVariants, nextAddress);
                return nextAddress;
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
