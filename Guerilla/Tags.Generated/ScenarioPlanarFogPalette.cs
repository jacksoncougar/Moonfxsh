// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class ScenarioPlanarFogPalette : ScenarioPlanarFogPaletteBase
    {
        public  ScenarioPlanarFogPalette(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  ScenarioPlanarFogPalette(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 16, Alignment = 4)]
    public class ScenarioPlanarFogPaletteBase : GuerillaBlock
    {
        internal Moonfish.Tags.StringID name;
        [TagReference("fog ")]
        internal Moonfish.Tags.TagReference planarFog;
        internal byte[] invalidName_;
        internal byte[] invalidName_0;
        
        public override int SerializedSize{get { return 16; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  ScenarioPlanarFogPaletteBase(BinaryReader binaryReader): base(binaryReader)
        {
            name = binaryReader.ReadStringID();
            planarFog = binaryReader.ReadTagReference();
            invalidName_ = binaryReader.ReadBytes(2);
            invalidName_0 = binaryReader.ReadBytes(2);
        }
        public  ScenarioPlanarFogPaletteBase(): base()
        {
            
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(name);
                binaryWriter.Write(planarFog);
                binaryWriter.Write(invalidName_, 0, 2);
                binaryWriter.Write(invalidName_0, 0, 2);
                return nextAddress;
            }
        }
    };
}
