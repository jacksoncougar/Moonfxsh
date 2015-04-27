// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class SkyLightBlock : SkyLightBlockBase
    {
        public  SkyLightBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 52, Alignment = 4)]
    public class SkyLightBlockBase : GuerillaBlock
    {
        internal OpenTK.Vector3 directionVector;
        internal OpenTK.Vector2 direction;
        [TagReference("lens")]
        internal Moonfish.Tags.TagReference lensFlare;
        internal SkyLightFogBlock[] fog;
        internal SkyLightFogBlock[] fogOpposite;
        internal SkyRadiosityLightBlock[] radiosity;
        
        public override int SerializedSize{get { return 52; }}
        
        internal  SkyLightBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            directionVector = binaryReader.ReadVector3();
            direction = binaryReader.ReadVector2();
            lensFlare = binaryReader.ReadTagReference();
            fog = Guerilla.ReadBlockArray<SkyLightFogBlock>(binaryReader);
            fogOpposite = Guerilla.ReadBlockArray<SkyLightFogBlock>(binaryReader);
            radiosity = Guerilla.ReadBlockArray<SkyRadiosityLightBlock>(binaryReader);
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(directionVector);
                binaryWriter.Write(direction);
                binaryWriter.Write(lensFlare);
                nextAddress = Guerilla.WriteBlockArray<SkyLightFogBlock>(binaryWriter, fog, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<SkyLightFogBlock>(binaryWriter, fogOpposite, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<SkyRadiosityLightBlock>(binaryWriter, radiosity, nextAddress);
                return nextAddress;
            }
        }
    };
}
