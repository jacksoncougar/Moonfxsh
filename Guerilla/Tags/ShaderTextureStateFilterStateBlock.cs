using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class ShaderTextureStateFilterStateBlock : ShaderTextureStateFilterStateBlockBase
    {
        public  ShaderTextureStateFilterStateBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 16)]
    public class ShaderTextureStateFilterStateBlockBase
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
        internal  ShaderTextureStateFilterStateBlockBase(BinaryReader binaryReader)
        {
            this.magFilter = (MagFilter)binaryReader.ReadInt16();
            this.minFilter = (MinFilter)binaryReader.ReadInt16();
            this.mipFilter = (MipFilter)binaryReader.ReadInt16();
            this.invalidName_ = binaryReader.ReadBytes(2);
            this.mipmapBias = binaryReader.ReadSingle();
            this.maxMipmapIndex = binaryReader.ReadInt16();
            this.anisotropy = (Anisotropy)binaryReader.ReadInt16();
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
