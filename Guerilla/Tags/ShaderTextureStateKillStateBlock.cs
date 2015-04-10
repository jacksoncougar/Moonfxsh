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
        public  ShaderTextureStateKillStateBlock(BinaryReader binaryReader): base(binaryReader)
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
        internal  ShaderTextureStateKillStateBlockBase(BinaryReader binaryReader)
        {
            this.flags = (Flags)binaryReader.ReadInt16();
            this.invalidName_ = binaryReader.ReadBytes(2);
            this.colorkeyMode = (ColorkeyMode)binaryReader.ReadInt16();
            this.invalidName_0 = binaryReader.ReadBytes(2);
            this.colorkeyColor = binaryReader.ReadRGBColor();
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
