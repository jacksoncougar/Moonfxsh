using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class AiSceneRoleVariantsBlock : AiSceneRoleVariantsBlockBase
    {
        public  AiSceneRoleVariantsBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 4)]
    public class AiSceneRoleVariantsBlockBase
    {
        internal Moonfish.Tags.StringID variantDesignation;
        internal  AiSceneRoleVariantsBlockBase(BinaryReader binaryReader)
        {
            this.variantDesignation = binaryReader.ReadStringID();
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
    };
}
