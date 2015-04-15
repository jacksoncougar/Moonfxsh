// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Tags
{
    public partial struct TagClass
    {
        public static readonly TagClass Vrtx = (TagClass)"vrtx";
    };
};

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("vrtx")]
    public  partial class VertexShaderBlock : VertexShaderBlockBase
    {
        public  VertexShaderBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 16, Alignment = 4)]
    public class VertexShaderBlockBase  : IGuerilla
    {
        internal Platform platform;
        internal byte[] invalidName_;
        internal VertexShaderClassificationBlock[] geometryClassifications;
        internal int outputSwizzles;
        internal  VertexShaderBlockBase(BinaryReader binaryReader)
        {
            platform = (Platform)binaryReader.ReadInt16();
            invalidName_ = binaryReader.ReadBytes(2);
            geometryClassifications = Guerilla.ReadBlockArray<VertexShaderClassificationBlock>(binaryReader);
            outputSwizzles = binaryReader.ReadInt32();
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write((Int16)platform);
                binaryWriter.Write(invalidName_, 0, 2);
                nextAddress = Guerilla.WriteBlockArray<VertexShaderClassificationBlock>(binaryWriter, geometryClassifications, nextAddress);
                binaryWriter.Write(outputSwizzles);
                return nextAddress;
            }
        }
        internal enum Platform : short
        {
            Pc = 0,
            Xbox = 1,
        };
    };
}
