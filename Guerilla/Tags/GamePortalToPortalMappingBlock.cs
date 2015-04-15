// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class GamePortalToPortalMappingBlock : GamePortalToPortalMappingBlockBase
    {
        public  GamePortalToPortalMappingBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 2, Alignment = 4)]
    public class GamePortalToPortalMappingBlockBase  : IGuerilla
    {
        internal short portalIndex;
        internal  GamePortalToPortalMappingBlockBase(BinaryReader binaryReader)
        {
            portalIndex = binaryReader.ReadInt16();
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(portalIndex);
                return nextAddress;
            }
        }
    };
}
