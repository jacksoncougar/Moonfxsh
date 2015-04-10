// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class ShaderTextureStateKillStateBlock : ShaderTextureStateKillStateBlockBase
    {
        public  ShaderTextureStateKillStateBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 11)]
    public class ShaderTextureStateKillStateBlockBase
    {
        internal Flags flags;
        internal byte[] invalidName_;
        internal ColorkeyMode colorkeyMode;
        internal byte[] invalidName_0;
        internal Moonfish.Tags.RGBColor colorkeyColor;
        internal  ShaderTextureStateKillStateBlockBase(System.IO.BinaryReader binaryReader)
        {
            flags = (Flags)binaryReader.ReadInt16();
            invalidName_ = binaryReader.ReadBytes(2);
            colorkeyMode = (ColorkeyMode)binaryReader.ReadInt16();
            invalidName_0 = binaryReader.ReadBytes(2);
            colorkeyColor = binaryReader.ReadRGBColor();
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
                binaryWriter.Write(invalidName_, 0, 2);
                binaryWriter.Write((Int16)colorkeyMode);
                binaryWriter.Write(invalidName_0, 0, 2);
                binaryWriter.Write(colorkeyColor);
            }
        }
        [FlagsAttribute]
        internal enum Flags : short
        
        {
            AlphaKill = 1,
        };
        internal enum ColorkeyMode : short
        
        {
            Disabled = 0,
            ZeroAlpha = 1,
            ZeroARGB = 2,
            Kill = 3,
        };
    };
}
