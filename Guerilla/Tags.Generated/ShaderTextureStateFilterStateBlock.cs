// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Moonfish.Guerilla.Tags
{
    public partial class ShaderTextureStateFilterStateBlock : ShaderTextureStateFilterStateBlockBase
    {
        public ShaderTextureStateFilterStateBlock() : base()
        {
        }
    };
    [LayoutAttribute(Size = 16, Alignment = 4)]
    public class ShaderTextureStateFilterStateBlockBase : GuerillaBlock
    {
        internal MagFilter magFilter;
        internal MinFilter minFilter;
        internal MipFilter mipFilter;
        internal byte[] invalidName_;
        internal float mipmapBias;
        /// <summary>
        /// 0 means all mipmap levels are used
        /// </summary>
        internal short maxMipmapIndex;
        internal Anisotropy anisotropy;
        public override int SerializedSize { get { return 16; } }
        public override int Alignment { get { return 4; } }
        public ShaderTextureStateFilterStateBlockBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            magFilter = (MagFilter)binaryReader.ReadInt16();
            minFilter = (MinFilter)binaryReader.ReadInt16();
            mipFilter = (MipFilter)binaryReader.ReadInt16();
            invalidName_ = binaryReader.ReadBytes(2);
            mipmapBias = binaryReader.ReadSingle();
            maxMipmapIndex = binaryReader.ReadInt16();
            anisotropy = (Anisotropy)binaryReader.ReadInt16();
            return blamPointers;
        }
        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
        }
        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write((Int16)magFilter);
                binaryWriter.Write((Int16)minFilter);
                binaryWriter.Write((Int16)mipFilter);
                binaryWriter.Write(invalidName_, 0, 2);
                binaryWriter.Write(mipmapBias);
                binaryWriter.Write(maxMipmapIndex);
                binaryWriter.Write((Int16)anisotropy);
                return nextAddress;
            }
        }
        internal enum MagFilter : short
        {
            None = 0,
            PointSampled = 1,
            Linear = 2,
            Anisotropic = 3,
            Quincunx = 4,
            GaussianCubic = 5,
        };
        internal enum MinFilter : short
        {
            None = 0,
            PointSampled = 1,
            Linear = 2,
            Anisotropic = 3,
            Quincunx = 4,
            GaussianCubic = 5,
        };
        internal enum MipFilter : short
        {
            None = 0,
            PointSampled = 1,
            Linear = 2,
            Anisotropic = 3,
            Quincunx = 4,
            GaussianCubic = 5,
        };
        internal enum Anisotropy : short
        {
            NonAnisotropic = 0,
            InvalidName2Tap = 1,
            InvalidName3Tap = 2,
            InvalidName4Tap = 3,
        };
    };
}
