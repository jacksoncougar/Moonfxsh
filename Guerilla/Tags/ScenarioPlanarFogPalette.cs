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
    [LayoutAttribute(Size = 16)]
    public class ScenarioPlanarFogPaletteBase
    {
        internal Moonfish.Tags.StringID name;
        [TagReference("fog ")]
        internal Moonfish.Tags.TagReference planarFog;
        internal byte[] invalidName_;
        internal byte[] invalidName_0;
        internal  ScenarioPlanarFogPaletteBase(BinaryReader binaryReader)
        {
            this.name = binaryReader.ReadStringID();
            this.planarFog = binaryReader.ReadTagReference();
            this.invalidName_ = binaryReader.ReadBytes(2);
            this.invalidName_0 = binaryReader.ReadBytes(2);
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
