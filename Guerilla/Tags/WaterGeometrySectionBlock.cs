// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class WaterGeometrySectionBlock : WaterGeometrySectionBlockBase
    {
        public  WaterGeometrySectionBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 68, Alignment = 4)]
    public class WaterGeometrySectionBlockBase  : IGuerilla
    {
        internal GlobalGeometrySectionStructBlock section;
        internal  WaterGeometrySectionBlockBase(BinaryReader binaryReader)
        {
            section = new GlobalGeometrySectionStructBlock(binaryReader);
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                section.Write(binaryWriter);
                return nextAddress = (int)binaryWriter.BaseStream.Position;
            }
        }
    };
}
