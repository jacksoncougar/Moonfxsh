using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class PlanarFogPatchyFogBlock : PlanarFogPatchyFogBlockBase
    {
        public  PlanarFogPatchyFogBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 52)]
    public class PlanarFogPatchyFogBlockBase
    {
        internal Moonfish.Tags.ColorR8G8B8 color;
        internal byte[] invalidName_;
        internal OpenTK.Vector2 density01;
        internal Moonfish.Model.Range distanceWorldUnits;
        /// <summary>
        /// in range (0,max_depth) world units, where patchy fog starts fading in
        /// </summary>
        internal float minDepthFraction01;
        [TagReference("fpch")]
        internal Moonfish.Tags.TagReference patchyFog;
        internal  PlanarFogPatchyFogBlockBase(BinaryReader binaryReader)
        {
            this.color = binaryReader.ReadColorR8G8B8();
            this.invalidName_ = binaryReader.ReadBytes(12);
            this.density01 = binaryReader.ReadVector2();
            this.distanceWorldUnits = binaryReader.ReadRange();
            this.minDepthFraction01 = binaryReader.ReadSingle();
            this.patchyFog = binaryReader.ReadTagReference();
        }
        internal  virtual byte[] ReadData(BinaryReader binaryReader)
        {
            var blamPointer = binaryReader.ReadBlamPointer(1);
            var data = new byte[blamPointer.count];
            if(blamPointer.count > 0)
            {
                using (binaryReader.BaseStream.Pin())
                {
                    binaryReader.BaseStream.Position = blamPointer[0];
                    data = binaryReader.ReadBytes(blamPointer.count);
                }
            }
            return data;
        }
    };
}
