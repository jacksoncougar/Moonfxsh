// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class GamePortalToPortalMappingBlock : GamePortalToPortalMappingBlockBase
    {
        public  GamePortalToPortalMappingBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  GamePortalToPortalMappingBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 2, Alignment = 4)]
    public class GamePortalToPortalMappingBlockBase : GuerillaBlock
    {
        internal short portalIndex;
        
        public override int SerializedSize{get { return 2; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  GamePortalToPortalMappingBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            portalIndex = binaryReader.ReadInt16();
        }
        public  GamePortalToPortalMappingBlockBase(): base()
        {
            
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(portalIndex);
                return nextAddress;
            }
        }
    };
}
