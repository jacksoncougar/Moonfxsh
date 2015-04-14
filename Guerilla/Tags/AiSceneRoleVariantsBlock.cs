// ReSharper disable All
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
    [LayoutAttribute(Size = 4, Alignment = 4)]
    public class AiSceneRoleVariantsBlockBase  : IGuerilla
    {
        internal Moonfish.Tags.StringID variantDesignation;
        internal  AiSceneRoleVariantsBlockBase(BinaryReader binaryReader)
        {
            variantDesignation = binaryReader.ReadStringID();
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(variantDesignation);
                return nextAddress = (int)binaryWriter.BaseStream.Position;
            }
        }
    };
}
