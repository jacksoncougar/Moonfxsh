using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class LightmapBucketRawVertexBlock : LightmapBucketRawVertexBlockBase
    {
        public  LightmapBucketRawVertexBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 24)]
    public class LightmapBucketRawVertexBlockBase
    {
        internal Moonfish.Tags.ColorR8G8B8 primaryLightmapColor;
        internal OpenTK.Vector3 primaryLightmapIncidentDirection;
        internal  LightmapBucketRawVertexBlockBase(BinaryReader binaryReader)
        {
            this.primaryLightmapColor = binaryReader.ReadColorR8G8B8();
            this.primaryLightmapIncidentDirection = binaryReader.ReadVector3();
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
