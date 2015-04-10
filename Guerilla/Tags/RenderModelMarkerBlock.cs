using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class RenderModelMarkerBlock : RenderModelMarkerBlockBase
    {
        public  RenderModelMarkerBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 36)]
    public class RenderModelMarkerBlockBase
    {
        internal byte regionIndex;
        internal byte permutationIndex;
        internal byte nodeIndex;
        internal byte[] invalidName_;
        internal OpenTK.Vector3 translation;
        internal OpenTK.Quaternion rotation;
        internal float scale;
        internal  RenderModelMarkerBlockBase(BinaryReader binaryReader)
        {
            this.regionIndex = binaryReader.ReadByte();
            this.permutationIndex = binaryReader.ReadByte();
            this.nodeIndex = binaryReader.ReadByte();
            this.invalidName_ = binaryReader.ReadBytes(1);
            this.translation = binaryReader.ReadVector3();
            this.rotation = binaryReader.ReadQuaternion();
            this.scale = binaryReader.ReadSingle();
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
    };
}
