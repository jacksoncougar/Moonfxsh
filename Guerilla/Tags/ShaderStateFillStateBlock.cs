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
        public  ShaderStateFillStateBlock(BinaryReader binaryReader): base(binaryReader)
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
        internal  ShaderStateFillStateBlockBase(BinaryReader binaryReader)
        {
            this.flags = (Flags)binaryReader.ReadInt16();
            this.fillMode = (FillMode)binaryReader.ReadInt16();
            this.backFillMode = (BackFillMode)binaryReader.ReadInt16();
            this.invalidName_ = binaryReader.ReadBytes(2);
            this.lineWidth = binaryReader.ReadSingle();
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
