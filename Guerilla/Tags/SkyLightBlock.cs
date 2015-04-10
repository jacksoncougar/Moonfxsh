using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class SkyLightBlock : SkyLightBlockBase
    {
        public  SkyLightBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 52)]
    public class SkyLightBlockBase
    {
        internal OpenTK.Vector3 directionVector;
        internal OpenTK.Vector2 direction;
        [TagReference("lens")]
        internal Moonfish.Tags.TagReference lensFlare;
        internal SkyLightFogBlock[] fog;
        internal SkyLightFogBlock[] fogOpposite;
        internal SkyRadiosityLightBlock[] radiosity;
        internal  SkyLightBlockBase(BinaryReader binaryReader)
        {
            this.directionVector = binaryReader.ReadVector3();
            this.direction = binaryReader.ReadVector2();
            this.lensFlare = binaryReader.ReadTagReference();
            this.fog = ReadSkyLightFogBlockArray(binaryReader);
            this.fogOpposite = ReadSkyLightFogBlockArray(binaryReader);
            this.radiosity = ReadSkyRadiosityLightBlockArray(binaryReader);
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
        internal  virtual SkyLightFogBlock[] ReadSkyLightFogBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(SkyLightFogBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new SkyLightFogBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new SkyLightFogBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual SkyRadiosityLightBlock[] ReadSkyRadiosityLightBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(SkyRadiosityLightBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new SkyRadiosityLightBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new SkyRadiosityLightBlock(binaryReader);
                }
            }
            return array;
        }
    };
}
