//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18444
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Moonfish.Guerilla.Tags
{
    using Moonfish.Tags;
    using Moonfish.Model;
    using System.IO;
    using System.Collections.Generic;
    using System.Linq;
    
    public partial class ShaderTextureStateFilterStateBlock : GuerillaBlock, IWriteQueueable
    {
        public MagFilterEnum MagFilter;
        public MinFilterEnum MinFilter;
        public MipFilterEnum MipFilter;
        private byte[] fieldpad = new byte[2];
        public float MipmapBias;
        public short MaxMipmapIndex;
        public AnisotropyEnum Anisotropy;
        public override int SerializedSize
        {
            get
            {
                return 16;
            }
        }
        public override int Alignment
        {
            get
            {
                return 4;
            }
        }
        public override System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> ReadFields(System.IO.BinaryReader binaryReader)
        {
            System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> pointerQueue = new System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer>(base.ReadFields(binaryReader));
            this.MagFilter = ((MagFilterEnum)(binaryReader.ReadInt16()));
            this.MinFilter = ((MinFilterEnum)(binaryReader.ReadInt16()));
            this.MipFilter = ((MipFilterEnum)(binaryReader.ReadInt16()));
            this.fieldpad = binaryReader.ReadBytes(2);
            this.MipmapBias = binaryReader.ReadSingle();
            this.MaxMipmapIndex = binaryReader.ReadInt16();
            this.Anisotropy = ((AnisotropyEnum)(binaryReader.ReadInt16()));
            return pointerQueue;
        }
        public override void ReadInstances(System.IO.BinaryReader binaryReader, System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> pointerQueue)
        {
            base.ReadInstances(binaryReader, pointerQueue);
        }
        public override void QueueWrites(Moonfish.Guerilla.QueueableBinaryWriter queueableBinaryWriter)
        {
            base.QueueWrites(queueableBinaryWriter);
        }
        public override void Write_(Moonfish.Guerilla.QueueableBinaryWriter queueableBinaryWriter)
        {
            base.Write_(queueableBinaryWriter);
            queueableBinaryWriter.Write(((short)(this.MagFilter)));
            queueableBinaryWriter.Write(((short)(this.MinFilter)));
            queueableBinaryWriter.Write(((short)(this.MipFilter)));
            queueableBinaryWriter.Write(this.fieldpad);
            queueableBinaryWriter.Write(this.MipmapBias);
            queueableBinaryWriter.Write(this.MaxMipmapIndex);
            queueableBinaryWriter.Write(((short)(this.Anisotropy)));
        }
        public enum MagFilterEnum : short
        {
            None = 0,
            PointSampled = 1,
            Linear = 2,
            Anisotropic = 3,
            Quincunx = 4,
            GaussianCubic = 5,
        }
        public enum MinFilterEnum : short
        {
            None = 0,
            PointSampled = 1,
            Linear = 2,
            Anisotropic = 3,
            Quincunx = 4,
            GaussianCubic = 5,
        }
        public enum MipFilterEnum : short
        {
            None = 0,
            PointSampled = 1,
            Linear = 2,
            Anisotropic = 3,
            Quincunx = 4,
            GaussianCubic = 5,
        }
        public enum AnisotropyEnum : short
        {
            NonAnisotropic = 0,
            _2tap = 1,
            _3tap = 2,
            _4tap = 3,
        }
    }
}
