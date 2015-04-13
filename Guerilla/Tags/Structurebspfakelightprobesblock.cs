// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class StructureBspFakeLightprobesBlock : StructureBspFakeLightprobesBlockBase
    {
        public  StructureBspFakeLightprobesBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 92, Alignment = 4)]
    public class StructureBspFakeLightprobesBlockBase  : IGuerilla
    {
        internal ScenarioObjectIdStructBlock objectIdentifier;
        internal RenderLightingStructBlock renderLighting;
        internal  StructureBspFakeLightprobesBlockBase(BinaryReader binaryReader)
        {
            objectIdentifier = new ScenarioObjectIdStructBlock(binaryReader);
            renderLighting = new RenderLightingStructBlock(binaryReader);
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                objectIdentifier.Write(binaryWriter);
                renderLighting.Write(binaryWriter);
                return nextAddress = (int)binaryWriter.BaseStream.Position;
            }
        }
    };
}
