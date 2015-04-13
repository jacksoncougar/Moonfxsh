// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class LensFlareScalarAnimationBlock : LensFlareScalarAnimationBlockBase
    {
        public  LensFlareScalarAnimationBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 8, Alignment = 4)]
    public class LensFlareScalarAnimationBlockBase  : IGuerilla
    {
        internal ScalarFunctionStructBlock function;
        internal  LensFlareScalarAnimationBlockBase(BinaryReader binaryReader)
        {
            function = new ScalarFunctionStructBlock(binaryReader);
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                function.Write(binaryWriter);
                return nextAddress = (int)binaryWriter.BaseStream.Position;
            }
        }
    };
}
