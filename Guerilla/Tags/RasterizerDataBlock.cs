using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class RasterizerDataBlock : RasterizerDataBlockBase
    {
        public  RasterizerDataBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 264)]
    public class RasterizerDataBlockBase
    {
        [TagReference("bitm")]
        internal Moonfish.Tags.TagReference distanceAttenuation;
        [TagReference("bitm")]
        internal Moonfish.Tags.TagReference vectorNormalization;
        [TagReference("bitm")]
        internal Moonfish.Tags.TagReference gradients;
        [TagReference("bitm")]
        internal Moonfish.Tags.TagReference uNUSED;
        [TagReference("bitm")]
        internal Moonfish.Tags.TagReference uNUSED0;
        [TagReference("bitm")]
        internal Moonfish.Tags.TagReference uNUSED1;
        [TagReference("bitm")]
        internal Moonfish.Tags.TagReference glow;
        [TagReference("bitm")]
        internal Moonfish.Tags.TagReference uNUSED2;
        [TagReference("bitm")]
        internal Moonfish.Tags.TagReference uNUSED3;
        internal byte[] invalidName_;
        internal VertexShaderReferenceBlock[] globalVertexShaders;
        [TagReference("bitm")]
        internal Moonfish.Tags.TagReference default2D;
        [TagReference("bitm")]
        internal Moonfish.Tags.TagReference default3D;
        [TagReference("bitm")]
        internal Moonfish.Tags.TagReference defaultCubeMap;
        [TagReference("bitm")]
        internal Moonfish.Tags.TagReference uNUSED4;
        [TagReference("bitm")]
        internal Moonfish.Tags.TagReference uNUSED5;
        [TagReference("bitm")]
        internal Moonfish.Tags.TagReference uNUSED6;
        [TagReference("bitm")]
        internal Moonfish.Tags.TagReference uNUSED7;
        [TagReference("bitm")]
        internal Moonfish.Tags.TagReference uNUSED8;
        [TagReference("bitm")]
        internal Moonfish.Tags.TagReference uNUSED9;
        internal byte[] invalidName_0;
        [TagReference("shad")]
        internal Moonfish.Tags.TagReference globalShader;
        internal Flags flags;
        internal byte[] invalidName_1;
        internal float refractionAmountPixels;
        internal float distanceFalloff;
        internal Moonfish.Tags.ColorR8G8B8 tintColor;
        internal float hyperStealthRefractionPixels;
        internal float hyperStealthDistanceFalloff;
        internal Moonfish.Tags.ColorR8G8B8 hyperStealthTintColor;
        [TagReference("bitm")]
        internal Moonfish.Tags.TagReference uNUSED10;
        internal  RasterizerDataBlockBase(BinaryReader binaryReader)
        {
            this.distanceAttenuation = binaryReader.ReadTagReference();
            this.vectorNormalization = binaryReader.ReadTagReference();
            this.gradients = binaryReader.ReadTagReference();
            this.uNUSED = binaryReader.ReadTagReference();
            this.uNUSED0 = binaryReader.ReadTagReference();
            this.uNUSED1 = binaryReader.ReadTagReference();
            this.glow = binaryReader.ReadTagReference();
            this.uNUSED2 = binaryReader.ReadTagReference();
            this.uNUSED3 = binaryReader.ReadTagReference();
            this.invalidName_ = binaryReader.ReadBytes(16);
            this.globalVertexShaders = ReadVertexShaderReferenceBlockArray(binaryReader);
            this.default2D = binaryReader.ReadTagReference();
            this.default3D = binaryReader.ReadTagReference();
            this.defaultCubeMap = binaryReader.ReadTagReference();
            this.uNUSED4 = binaryReader.ReadTagReference();
            this.uNUSED5 = binaryReader.ReadTagReference();
            this.uNUSED6 = binaryReader.ReadTagReference();
            this.uNUSED7 = binaryReader.ReadTagReference();
            this.uNUSED8 = binaryReader.ReadTagReference();
            this.uNUSED9 = binaryReader.ReadTagReference();
            this.invalidName_0 = binaryReader.ReadBytes(36);
            this.globalShader = binaryReader.ReadTagReference();
            this.flags = (Flags)binaryReader.ReadInt16();
            this.invalidName_1 = binaryReader.ReadBytes(2);
            this.refractionAmountPixels = binaryReader.ReadSingle();
            this.distanceFalloff = binaryReader.ReadSingle();
            this.tintColor = binaryReader.ReadColorR8G8B8();
            this.hyperStealthRefractionPixels = binaryReader.ReadSingle();
            this.hyperStealthDistanceFalloff = binaryReader.ReadSingle();
            this.hyperStealthTintColor = binaryReader.ReadColorR8G8B8();
            this.uNUSED10 = binaryReader.ReadTagReference();
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
        internal  virtual VertexShaderReferenceBlock[] ReadVertexShaderReferenceBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(VertexShaderReferenceBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new VertexShaderReferenceBlock[blamPointer.elementCount];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.elementCount; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new VertexShaderReferenceBlock(binaryReader);
                }
            }
            return array;
        }
        [FlagsAttribute]
        internal enum Flags : short
        
        {
            TintEdgeDensity = 1,
        };
    };
}
