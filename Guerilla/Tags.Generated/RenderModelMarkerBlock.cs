// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class RenderModelMarkerBlock : RenderModelMarkerBlockBase
    {
        public  RenderModelMarkerBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  RenderModelMarkerBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 36, Alignment = 4)]
    public class RenderModelMarkerBlockBase : GuerillaBlock
    {
        internal byte regionIndex;
        internal byte permutationIndex;
        internal byte nodeIndex;
        internal byte[] invalidName_;
        internal OpenTK.Vector3 translation;
        internal OpenTK.Quaternion rotation;
        internal float scale;
        
        public override int SerializedSize{get { return 36; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  RenderModelMarkerBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            regionIndex = binaryReader.ReadByte();
            permutationIndex = binaryReader.ReadByte();
            nodeIndex = binaryReader.ReadByte();
            invalidName_ = binaryReader.ReadBytes(1);
            translation = binaryReader.ReadVector3();
            rotation = binaryReader.ReadQuaternion();
            scale = binaryReader.ReadSingle();
        }
        public  RenderModelMarkerBlockBase(): base()
        {
            
        }
        public void Read(BinaryReader binaryReader)
        {
            regionIndex = binaryReader.ReadByte();
            permutationIndex = binaryReader.ReadByte();
            nodeIndex = binaryReader.ReadByte();
            invalidName_ = binaryReader.ReadBytes(1);
            translation = binaryReader.ReadVector3();
            rotation = binaryReader.ReadQuaternion();
            scale = binaryReader.ReadSingle();
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(regionIndex);
                binaryWriter.Write(permutationIndex);
                binaryWriter.Write(nodeIndex);
                binaryWriter.Write(invalidName_, 0, 1);
                binaryWriter.Write(translation);
                binaryWriter.Write(rotation);
                binaryWriter.Write(scale);
                return nextAddress;
            }
        }
    };
}
