// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class ShaderStateFillStateBlock : ShaderStateFillStateBlockBase
    {
        public  ShaderStateFillStateBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 12)]
    public class ShaderStateFillStateBlockBase
    {
        internal Flags flags;
        internal FillMode fillMode;
        internal BackFillMode backFillMode;
        internal byte[] invalidName_;
        internal float lineWidth;
        internal  ShaderStateFillStateBlockBase(System.IO.BinaryReader binaryReader)
        {
            flags = (Flags)binaryReader.ReadInt16();
            fillMode = (FillMode)binaryReader.ReadInt16();
            backFillMode = (BackFillMode)binaryReader.ReadInt16();
            invalidName_ = binaryReader.ReadBytes(2);
            lineWidth = binaryReader.ReadSingle();
        }
        internal  virtual byte[] ReadData(System.IO.BinaryReader binaryReader)
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
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write((Int16)flags);
                binaryWriter.Write((Int16)fillMode);
                binaryWriter.Write((Int16)backFillMode);
                binaryWriter.Write(invalidName_, 0, 2);
                binaryWriter.Write(lineWidth);
            }
        }
        [FlagsAttribute]
        internal enum Flags : short
        
        {
            FlatShading = 1,
            EdgeAntialiasing = 2,
        };
        internal enum FillMode : short
        
        {
            Solid = 0,
            Wireframe = 1,
            Points = 2,
        };
        internal enum BackFillMode : short
        
        {
            Solid = 0,
            Wireframe = 1,
            Points = 2,
        };
    };
}
