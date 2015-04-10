using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class PredictedResourceBlock : PredictedResourceBlockBase
    {
        public  PredictedResourceBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 8)]
    public class PredictedResourceBlockBase
    {
        internal Type type;
        internal short resourceIndex;
        internal int tagIndex;
        internal  PredictedResourceBlockBase(BinaryReader binaryReader)
        {
            this.type = (Type)binaryReader.ReadInt16();
            this.resourceIndex = binaryReader.ReadInt16();
            this.tagIndex = binaryReader.ReadInt32();
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
        internal enum Type : short
        
        {
            Bitmap = 0,
            Sound = 1,
            RenderModelGeometry = 2,
            ClusterGeometry = 3,
            ClusterInstancedGeometry = 4,
            LightmapGeometryObjectBuckets = 5,
            LightmapGeometryInstanceBuckets = 6,
            LightmapClusterBitmaps = 7,
            LightmapInstanceBitmaps = 8,
        };
    };
}
