// ReSharper disable All
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
        public  SkyLightBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
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
        internal  SkyLightBlockBase(System.IO.BinaryReader binaryReader)
        {
            directionVector = binaryReader.ReadVector3();
            direction = binaryReader.ReadVector2();
            lensFlare = binaryReader.ReadTagReference();
            ReadSkyLightFogBlockArray(binaryReader);
            ReadSkyLightFogBlockArray(binaryReader);
            ReadSkyRadiosityLightBlockArray(binaryReader);
        }
        internal  virtual byte[] ReadData(System.IO.BinaryReader binaryReader)
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
        internal  virtual SkyLightFogBlock[] ReadSkyLightFogBlockArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual SkyRadiosityLightBlock[] ReadSkyRadiosityLightBlockArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteSkyLightFogBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteSkyRadiosityLightBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(directionVector);
                binaryWriter.Write(direction);
                binaryWriter.Write(lensFlare);
                WriteSkyLightFogBlockArray(binaryWriter);
                WriteSkyLightFogBlockArray(binaryWriter);
                WriteSkyRadiosityLightBlockArray(binaryWriter);
            }
        }
    };
}
