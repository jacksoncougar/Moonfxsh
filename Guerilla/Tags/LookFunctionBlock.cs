// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class LookFunctionBlock : LookFunctionBlockBase
    {
        public  LookFunctionBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 4, Alignment = 4)]
    public class LookFunctionBlockBase  : IGuerilla
    {
        internal float scale;
        internal  LookFunctionBlockBase(BinaryReader binaryReader)
        {
            scale = binaryReader.ReadSingle();
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(scale);
                return nextAddress = (int)binaryWriter.BaseStream.Position;
            }
        }
    };
}
