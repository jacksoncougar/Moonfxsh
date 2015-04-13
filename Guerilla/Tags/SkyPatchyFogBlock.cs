using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class SkyPatchyFogBlock : SkyPatchyFogBlockBase
    {
        public  SkyPatchyFogBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 80)]
    public class SkyPatchyFogBlockBase
    {
        internal Moonfish.Tags.ColorR8G8B8 color;
        internal byte[] invalidName_;
        internal OpenTK.Vector2 density01;
        internal Moonfish.Model.Range distanceWorldUnits;
        internal byte[] invalidName_0;
        [TagReference("fpch")]
        internal Moonfish.Tags.TagReference patchyFog;
        internal  SkyPatchyFogBlockBase(BinaryReader binaryReader)
        {
            this.color = binaryReader.ReadColorR8G8B8();
            this.invalidName_ = binaryReader.ReadBytes(12);
            this.density01 = binaryReader.ReadVector2();
            this.distanceWorldUnits = binaryReader.ReadRange();
            this.invalidName_0 = binaryReader.ReadBytes(32);
            this.patchyFog = binaryReader.ReadTagReference();
        }
        internal  virtual byte[] ReadData(BinaryReader binaryReader)
        {
            var blamPointer = binaryReader.ReadBlamPointer(1);
            var data = new byte[blamPointer.elementCount];
            if(blamPointer.elementCount > 0)
            {
                using (binaryReader.BaseStream.Pin())
                {
                    binaryReader.BaseStream.Position = blamPointer[0];
                    data = binaryReader.ReadBytes(blamPointer.elementCount);
                }
            }
            return data;
        }
    };
}
