// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class ScenarioPlanarFogPalette : ScenarioPlanarFogPaletteBase
    {
        public  ScenarioPlanarFogPalette(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 16, Alignment = 4)]
    public class ScenarioPlanarFogPaletteBase  : IGuerilla
    {
        internal Moonfish.Tags.StringID name;
        [TagReference("fog ")]
        internal Moonfish.Tags.TagReference planarFog;
        internal byte[] invalidName_;
        internal byte[] invalidName_0;
        internal  ScenarioPlanarFogPaletteBase(BinaryReader binaryReader)
        {
            name = binaryReader.ReadStringID();
            planarFog = binaryReader.ReadTagReference();
            invalidName_ = binaryReader.ReadBytes(2);
            invalidName_0 = binaryReader.ReadBytes(2);
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(name);
                binaryWriter.Write(planarFog);
                binaryWriter.Write(invalidName_, 0, 2);
                binaryWriter.Write(invalidName_0, 0, 2);
                return nextAddress = (int)binaryWriter.BaseStream.Position;
            }
        }
    };
}
