// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class AiSceneRoleVariantsBlock : AiSceneRoleVariantsBlockBase
    {
        public  AiSceneRoleVariantsBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  AiSceneRoleVariantsBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 4, Alignment = 4)]
    public class AiSceneRoleVariantsBlockBase : GuerillaBlock
    {
        internal Moonfish.Tags.StringID variantDesignation;
        
        public override int SerializedSize{get { return 4; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  AiSceneRoleVariantsBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            variantDesignation = binaryReader.ReadStringID();
        }
        public  AiSceneRoleVariantsBlockBase(): base()
        {
            
        }
        public override void Read(BinaryReader binaryReader)
        {
            variantDesignation = binaryReader.ReadStringID();
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(variantDesignation);
                return nextAddress;
            }
        }
    };
}
