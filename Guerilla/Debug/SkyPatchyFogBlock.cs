// ReSharper disable All
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
        public  SkyPatchyFogBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
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
        internal  SkyPatchyFogBlockBase(System.IO.BinaryReader binaryReader)
        {
            color = binaryReader.ReadColorR8G8B8();
            invalidName_ = binaryReader.ReadBytes(12);
            density01 = binaryReader.ReadVector2();
            distanceWorldUnits = binaryReader.ReadRange();
            invalidName_0 = binaryReader.ReadBytes(32);
            patchyFog = binaryReader.ReadTagReference();
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
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(color);
                binaryWriter.Write(invalidName_, 0, 12);
                binaryWriter.Write(density01);
                binaryWriter.Write(distanceWorldUnits);
                binaryWriter.Write(invalidName_0, 0, 32);
                binaryWriter.Write(patchyFog);
            }
        }
    };
}
