// ReSharper disable All
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
    [LayoutAttribute(Size = 24, Alignment = 4)]
    public class LightmapBucketRawVertexBlockBase  : IGuerilla
    {
        internal Moonfish.Tags.ColorR8G8B8 primaryLightmapColor;
        internal OpenTK.Vector3 primaryLightmapIncidentDirection;
        internal  LightmapBucketRawVertexBlockBase(BinaryReader binaryReader)
        {
            primaryLightmapColor = binaryReader.ReadColorR8G8B8();
            primaryLightmapIncidentDirection = binaryReader.ReadVector3();
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(primaryLightmapColor);
                binaryWriter.Write(primaryLightmapIncidentDirection);
                return nextAddress;
            }
        }
    };
}
