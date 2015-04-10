// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class SkyShaderFunctionBlock : SkyShaderFunctionBlockBase
    {
        public  SkyShaderFunctionBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 36)]
    public class SkyShaderFunctionBlockBase
    {
        internal byte[] invalidName_;
        /// <summary>
        /// Global function that controls this shader value.
        /// </summary>
        internal Moonfish.Tags.String32 globalFunctionName;
        internal  SkyShaderFunctionBlockBase(System.IO.BinaryReader binaryReader)
        {
            invalidName_ = binaryReader.ReadBytes(4);
            globalFunctionName = binaryReader.ReadString32();
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
                binaryWriter.Write(invalidName_, 0, 4);
                binaryWriter.Write(globalFunctionName);
            }
        }
    };
}
