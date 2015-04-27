// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class StructureBspFakeLightprobesBlock : StructureBspFakeLightprobesBlockBase
    {
        public  StructureBspFakeLightprobesBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  StructureBspFakeLightprobesBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 92, Alignment = 4)]
    public class StructureBspFakeLightprobesBlockBase : GuerillaBlock
    {
        internal ScenarioObjectIdStructBlock objectIdentifier;
        internal RenderLightingStructBlock renderLighting;
        
        public override int SerializedSize{get { return 92; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  StructureBspFakeLightprobesBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            objectIdentifier = new ScenarioObjectIdStructBlock(binaryReader);
            renderLighting = new RenderLightingStructBlock(binaryReader);
        }
        public  StructureBspFakeLightprobesBlockBase(): base()
        {
            
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                objectIdentifier.Write(binaryWriter);
                renderLighting.Write(binaryWriter);
                return nextAddress;
            }
        }
    };
}
