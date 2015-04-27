// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class PlanarFogPatchyFogBlock : PlanarFogPatchyFogBlockBase
    {
        public  PlanarFogPatchyFogBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 52, Alignment = 4)]
    public class PlanarFogPatchyFogBlockBase : GuerillaBlock
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
        
        public override int SerializedSize{get { return 52; }}
        
        internal  PlanarFogPatchyFogBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            color = binaryReader.ReadColorR8G8B8();
            invalidName_ = binaryReader.ReadBytes(12);
            density01 = binaryReader.ReadVector2();
            distanceWorldUnits = binaryReader.ReadRange();
            minDepthFraction01 = binaryReader.ReadSingle();
            patchyFog = binaryReader.ReadTagReference();
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(color);
                binaryWriter.Write(invalidName_, 0, 12);
                binaryWriter.Write(density01);
                binaryWriter.Write(distanceWorldUnits);
                binaryWriter.Write(minDepthFraction01);
                binaryWriter.Write(patchyFog);
                return nextAddress;
            }
        }
    };
}
