// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class PredictedResourceBlock : PredictedResourceBlockBase
    {
        public  PredictedResourceBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  PredictedResourceBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 8, Alignment = 4)]
    public class PredictedResourceBlockBase : GuerillaBlock
    {
        internal Type type;
        internal short resourceIndex;
        internal int tagIndex;
        
        public override int SerializedSize{get { return 8; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  PredictedResourceBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            type = (Type)binaryReader.ReadInt16();
            resourceIndex = binaryReader.ReadInt16();
            tagIndex = binaryReader.ReadInt32();
        }
        public  PredictedResourceBlockBase(): base()
        {
            
        }
        public override void Read(BinaryReader binaryReader)
        {
            type = (Type)binaryReader.ReadInt16();
            resourceIndex = binaryReader.ReadInt16();
            tagIndex = binaryReader.ReadInt32();
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write((Int16)type);
                binaryWriter.Write(resourceIndex);
                binaryWriter.Write(tagIndex);
                return nextAddress;
            }
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
